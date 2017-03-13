

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/ServicePath", typeof(Cinema.Movie.Pages.ServicePathController))]

namespace Cinema.Movie.Pages
{
    using Common.Init;
    using Entities;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Repository = Repositories.ServicePathRepository;
    using MyRow = Entities.ServicePathRow;
    using System.Xml;
    using System.Xml.Serialization;
    using Serenity.Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Net.Http;
    using System.Net;

    [RoutePrefix("Movie/ServicePath"), Route("{action=index}")]
    public class ServicePathController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServicePath/ServicePathIndex.cshtml");
        }

        public static RetrieveResponse<MyRow> Find(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().Find(connection, listRequest);
            }
        }
        public static RetrieveResponse<MyRow> Retrieve(RetrieveRequest retrieveRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().Retrieve(connection, retrieveRequest);
            }
        }
        public static ListResponse<MyRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().List(connection, listRequest);
            }
        }
        public static SaveResponse UpdateCreate(SaveRequest<MyRow> saveRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            using (var uow = new UnitOfWork(connection))
            {
                var result = new Repository().UpdateCreate(uow, saveRequest);
                uow.Commit();
                return result;
            }
        }
        [PageAuthorize("Administration")]
        public ActionResult Parse(Int32 idServicePath)
        {
            try
            {
                RetrieveResponse<MyRow> servicePath = Retrieve(new RetrieveRequest()
                {
                    EntityId = idServicePath,
                    IncludeColumns = new HashSet<string>() { MyRow.Fields.ServiceId.ToString() }
                });

                var content = ParseContent(servicePath);
                if (content != null)
                {
                    var root = ParseRoot(servicePath);
                    if (root != null)
                    {
                        var e = new Exception("no content " + content.Message + " or no root " + root.Message);
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                e.Log();
                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
            }
            return View("~/Modules/Movie/ServicePath/ServicePathIndex.cshtml");
        }

        public void ParseItem(MovieJson item, RetrieveResponse<MyRow> servicePath)
        {
            if (item != null && servicePath.Error == null)
            {
                var movie = MovieController.UpdateCreate(item, servicePath);
                if (movie != null)
                {
                    var videos = VideoController.UpdateCreate(item, movie, servicePath);
                    var persons = PersonController.UpdateCreate(item, movie);
                    var genres = MovieGenreController.UpdateCreate(item, movie);
                    var countries = MovieCountryController.UpdateCreate(item, movie);
                    var services = ServiceRatingController.UpdateCreate(item, movie);
                }
            }
        }
        public Exception ParseContent(RetrieveResponse<MyRow> servicePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Content));
                using (XmlReader reader = XmlReader.Create(servicePath.Entity.Path))
                {
                    Content obj = (Content)serializer.Deserialize(reader);
                    foreach (MovieJson item in obj.All(servicePath.Entity.Kind).Entities)
                    {
                        ParseItem(item, servicePath);
                    }
                }
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }
        public Exception ParseRoot(RetrieveResponse<MyRow> servicePath)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var text = client.DownloadString(servicePath.Entity.Path);
                    Root root = JsonConvert.DeserializeObject<Root>(text);
                    foreach (MovieJson item in root.Results)
                    {
                        ParseItem(item, servicePath);
                    }
                    if (root.Has_next)
                    {
                        var newServicePath = UpdateCreate(new SaveRequest<MyRow>()
                        {
                            Entity = new MyRow()
                            {
                                Path = root.Next,
                                ServiceId = servicePath.Entity.ServiceId
                            }
                        });
                        ParseRoot(Retrieve(new RetrieveRequest()
                        {
                            EntityId = newServicePath.EntityId,
                            IncludeColumns = new HashSet<string>() { MyRow.Fields.ServiceId.ToString() }
                        }));
                    }
                }
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }
    }
}