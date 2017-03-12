

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
            try
            {
                if (item != null && servicePath.Error == null)
                {
                    #region serviceRaiting and movie
                    var movieRow = item.ToMovie();
                    if (!String.IsNullOrWhiteSpace(item.kinopoisk_id))
                    {
                        var serviceRaiting = ServiceRatingController.Find(new ListRequest()
                        {
                            IncludeColumns = new HashSet<string>()
                                    {
                                        ServiceRatingRow.Fields.MovieId.Name,
                                        ServiceRatingRow.Fields.ServiceId.Name,
                                        ServiceRatingRow.Fields.Id.Name
                                    },
                            Criteria = new Criteria(ServiceRatingRow.Fields.Id.Name) == item.kinopoisk_id && new Criteria(ServiceRatingRow.Fields.ServiceId.Name) == (Int32)servicePath.Entity.ServiceId
                        });
                        if (serviceRaiting != null && serviceRaiting.Entity != null && serviceRaiting.Entity.MovieId != null)
                        {
                            movieRow.MovieId = serviceRaiting.Entity.MovieId;
                        }
                    }
                    //movie
                    var movieResponse = MovieController.UpdateCreate(new SaveRequest<MovieRow>()
                    {
                        Entity = movieRow
                    });
                    #endregion
                    Int64 movieId;
                    if (movieResponse.EntityId != null && movieResponse.EntityId.ToString() != "" && Int64.TryParse(movieResponse.EntityId.ToString(), out movieId))
                    {
                        var movie = MovieController.Retrieve(new RetrieveRequest() { EntityId = movieId });
                        if (movie != null && movie.Entity != null)
                        {
                            try
                            {
                                #region videos
                                foreach (var video in item.ToVideos(movie, servicePath))
                                {
                                    if (video != null)
                                    {
                                        VideoController.UpdateCreate(new SaveRequest<VideoRow>() { Entity = video });
                                    }
                                }
                                #endregion
                            }
                            catch (Exception e)
                            {
                                e.Log();
                                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                            }
                            try
                            {
                                #region persons and casts
                                foreach (var person in item.ToPersons())
                                {
                                    person.PersonId = Int64.Parse(PersonController.UpdateCreate(new SaveRequest<PersonRow>() { Entity = person }).EntityId.ToString());
                                    foreach (var cast in item.ToCast(movie, person))
                                    {
                                        CastController.UpdateCreate(new SaveRequest<CastRow>() { Entity = cast });
                                    }
                                }
                                #endregion
                            }
                            catch (Exception e)
                            {
                                e.Log();
                                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                            }
                            try
                            {
                                #region genres
                                foreach (var genre in item.ToGenres())
                                {
                                    MovieGenreController.UpdateCreate(new SaveRequest<MovieGenreRow>()
                                    {
                                        Entity = new MovieGenreRow()
                                        {
                                            MovieId = movieId,
                                            GenreId = Int32.Parse(GenreController.UpdateCreate(new SaveRequest<GenreRow>() { Entity = genre }).EntityId.ToString())
                                        }
                                    });
                                }
                                #endregion
                            }
                            catch (Exception e)
                            {
                                e.Log();
                                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                            }
                            try
                            {
                                #region countries
                                foreach (var country in item.ToCountries())
                                {
                                    MovieCountryController.UpdateCreate(new SaveRequest<MovieCountryRow>()
                                    {
                                        Entity = new MovieCountryRow()
                                        {
                                            MovieId = movieId,
                                            CountryId = Int32.Parse(CountryController.UpdateCreate(new SaveRequest<CountryRow>()
                                            {
                                                Entity = country
                                            }).EntityId.ToString())
                                        }
                                    });
                                }
                                #endregion
                            }
                            catch (Exception e)
                            {
                                e.Log();
                                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                            }
                            try
                            {
                                #region serviceRaitings and services
                                foreach (var sRating in item.ToServiceRatings(movieRow))
                                {
                                    var service = ServiceController.UpdateCreate(new SaveRequest<ServiceRow>()
                                    {
                                        Entity = new ServiceRow()
                                        {
                                            Url = sRating.ServiceUrl,
                                            Name = sRating.ServiceName,
                                            Api = sRating.ServiceApi
                                        }
                                    });
                                    sRating.ServiceId = Int32.Parse(service.EntityId.ToString());
                                    ServiceRatingController.UpdateCreate(new SaveRequest<ServiceRatingRow>()
                                    {
                                        Entity = sRating
                                    });
                                }
                                #endregion
                            }
                            catch (Exception e)
                            {
                                e.Log();
                                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                            }
                        }
                        else
                        {
                            throw new Exception("movieId is null" + movie.Entity.MovieId + "" + movieRow.ToJson());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.Log();
                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
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
                    Root root= JsonConvert.DeserializeObject<Root>(text);
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