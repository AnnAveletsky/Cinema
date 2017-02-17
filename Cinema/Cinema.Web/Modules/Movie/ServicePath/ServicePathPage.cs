

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
    using Videos = Movie.Pages.VideoController;
    using Movies = Movie.Pages.MovieController;
    using MovieGenres = Movie.Pages.MovieGenreController;
    using MovieCountries = Movie.Pages.MovieCountryController;
    using MovieTags = Movie.Pages.MovieTagController;
    using Services = Movie.Pages.ServiceController;
    using ServicesRatings = Movie.Pages.ServiceRatingController;
    using Genres = Movie.Pages.GenreController;
    using Countries = Movie.Pages.CountryController;
    using Persons = Movie.Pages.PersonController;
    using Casts = Movie.Pages.CastController;
    using Repository = Repositories.ServiceRepository;
    using MyRow = Entities.ServiceRow;
    using System.Xml;
    using System.Xml.Serialization;
    using Serenity.Data;

    [RoutePrefix("Movie/ServicePath"), Route("{action=index}")]
    public class ServicePathController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServicePath/ServicePathIndex.cshtml");
        }
        public void Init()
        {
           

        }

        public static RetrieveResponse<MyRow> Find(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().Find(connection, listRequest);
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
            ListRequest listRequest = new ListRequest() { Criteria = new Repository().Criteria(saveRequest.Entity) };
            using (var connection = SqlConnections.NewFor<MyRow>())
            using (var uow = new UnitOfWork(connection))
            {
                if (new Repository().Exist(connection, listRequest))
                {
                    return new Repository().FindUpdate(uow, saveRequest, listRequest);
                }
                else
                {
                    return new Repository().Create(uow, saveRequest);
                }
            }
        }
        [PageAuthorize("Administration")]
        public static void InitObjects(MovieJson[] data, MovieKind movieKind, ServiceRow serviceKinopoisk, ServiceRow service, string username)
        {
            StatusTask.Count = data.Length;
            foreach (MovieJson item in data)
            {
                var res = CreateMovieVideo(username,
                        new SaveRequest<MovieRow>()
                        {
                            Entity = item.ToMovie(movieKind)
                        },
                        new SaveRequest<VideoRow>()
                        {
                            Entity = item.ToVideo()
                        },
                        new SaveRequest<ServiceRow>()
                        {
                            Entity = serviceKinopoisk,
                            EntityId = serviceKinopoisk.ServiceId,
                        },
                        new SaveRequest<ServiceRow>()
                        {
                            Entity = service,
                            EntityId = service.ServiceId
                        },
                        new SaveRequest<ServiceRatingRow>()
                        {
                            Entity = item.ToServiceRating(service)
                        },
                        item.ToGenres(),
                        item.ToCountries());
                foreach (var i in item.ToPersons())
                {
                    i.PersonId = Int64.Parse(Persons.UpdateCreate(new SaveRequest<PersonRow>() { Entity = i }).EntityId.ToString());
                    foreach (var j in item.ToCast(res, i))
                    {
                        Casts.UpdateCreate(new SaveRequest<CastRow>()
                        {
                            Entity = j
                        });
                    }
                }
            }
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateMovieVideo(string username, SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video, SaveRequest<ServiceRow> serviceKinopoisk, SaveRequest<ServiceRow> service, SaveRequest<ServiceRatingRow> serviceRating, List<GenreRow> genres, List<CountryRow> countries)
        {
            if (movie == null || video == null || serviceKinopoisk == null || service == null || serviceRating == null)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = "CreateMovieVideo null object" } };
            }
            SaveResponse response = null;
            try
            {
                response = Movies.UpdateCreate(movie, serviceRating);
                video.Entity.MovieId = (Int64)response.EntityId;
                serviceRating.Entity.ServiceId = (Int32)serviceKinopoisk.EntityId;
                serviceRating.Entity.MovieId = (Int64)response.EntityId;
                //SaveResponse servicesRatingResponse = ServicesRatings.UpdateCreate(serviceRating);
                video.Entity.ServiceId = (Int32)service.EntityId;
                SaveResponse videoResponce = Videos.UpdateCreate(video);
            }
            catch (Exception e)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = "CreateMovieVideo" + e.Message } };
            }
            foreach (var i in genres)
            {
                try
                {
                    MovieGenres.UpdateCreate(new SaveRequest<MovieGenreRow>()
                    {
                        Entity = new MovieGenreRow()
                        {
                            MovieId = Int64.Parse(response.EntityId.ToString()),
                            GenreId = Int16.Parse(Genres.UpdateCreate(new SaveRequest<GenreRow>()
                            {
                                Entity = i
                            }).EntityId.ToString())
                        }
                    });
                }
                catch (Exception e)
                {
                    return new SaveResponse() { Error = new ServiceError() { Message = "CreateMovieVideo Genres" + e.Message } };
                }
            }
            foreach (var j in countries)
            {
                try
                {
                    MovieCountries.UpdateCreate(new SaveRequest<MovieCountryRow>()
                    {
                        Entity = new MovieCountryRow()
                        {
                            MovieId = Int64.Parse(response.EntityId.ToString()),
                            CountryId = Int16.Parse(Countries.UpdateCreate(new SaveRequest<CountryRow>()
                            {
                                Entity = j
                            }).EntityId.ToString())
                        }
                    });
                }
                catch (Exception e)
                {
                    return new SaveResponse() { Error = new ServiceError() { Message = "CreateMovieVideo Countries" + e.Message } };
                }
            }
            return response;
        }
    }
}