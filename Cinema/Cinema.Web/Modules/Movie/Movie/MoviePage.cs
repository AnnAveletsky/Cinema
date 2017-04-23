

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Movie", typeof(Cinema.Movie.Pages.MovieController))]

namespace Cinema.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Serenity.Data;
    using System.Linq;
    using Repository = Repositories.MovieRepository;
    using MyRow = Entities.MovieRow;
    using Common.Init;
    using System;
    using System.Collections.Generic;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Movie/MovieIndex.cshtml");
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
        public static BaseCriteria Criteria(SaveRequest<MyRow> saveRequest)
        {
            return new Repository().Criteria(saveRequest);
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
        public static RetrieveResponse<MyRow> UpdateCreate(MovieJson json, RetrieveResponse<ServicePathRow> servicePath)
        {
            var movie = json.ToMovie();
            try
            {
                if (!String.IsNullOrWhiteSpace(json.kinopoisk_id))
                {
                    var serviceRaiting = ServiceRatingController.Find(new ListRequest()
                    {
                        IncludeColumns = new HashSet<string>(){
                                        ServiceRatingRow.Fields.MovieId.Name,
                                        ServiceRatingRow.Fields.ServiceId.Name,
                                        ServiceRatingRow.Fields.Id.Name },
                        Criteria = new Criteria(ServiceRatingRow.Fields.Id.Name) == json.kinopoisk_id && new Criteria(ServiceRatingRow.Fields.ServiceId.Name) == (Int32)servicePath.Entity.ServiceId
                    });
                    if (serviceRaiting != null && serviceRaiting.Entity != null && serviceRaiting.Entity.MovieId != null)
                    {
                        return Retrieve(new RetrieveRequest() { EntityId = serviceRaiting.Entity.MovieId });
                    }
                }
            }
            catch (Exception e)
            {
                e.Log();
                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
            }
            try
            {
                var newmovie = UpdateCreate(new SaveRequest<MyRow>()
                {
                    Entity = movie
                });
                if (newmovie != null && newmovie.EntityId != null)
                {
                    return Retrieve(new RetrieveRequest()
                    {
                        EntityId = (Int64)newmovie.EntityId
                    });
                }
                else
                {
                    throw new Exception("newmovie is null");
                }
            }
            catch (Exception e)
            {
                e.Log();
                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
            }
            return null;
        }
        public static SaveResponse ViewsAdd(SaveRequest<MyRow> saveRequest)
        {
            saveRequest.Entity.Views++;
            return UpdateCreate(saveRequest);
        }
    }
}