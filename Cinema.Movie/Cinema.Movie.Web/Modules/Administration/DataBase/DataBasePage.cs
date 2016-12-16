

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Administration/DataBase", typeof(Cinema.Movie.Administration.Pages.DataBaseController))]

namespace Cinema.Movie.Administration.Pages
{
    using Movie;
    using Movie.Entities;
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.IO;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using Videos = Movie.Pages.VideoController;
    using Movies = Movie.Pages.MovieController;
    using Services = Movie.Pages.ServiceController;
    using ServicesRatings = Movie.Pages.ServiceRatingController;
    using System.Collections.Generic;
    using Common.Init;

    [RoutePrefix("Administration/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
        [PageAuthorize("Administration")]
        public ActionResult Init()
        {
            var serviceKinopoisk = Services.Service(new RetrieveRequest()
            {
                EntityId = Services.Create(new SaveRequest<ServiceRow>()
                {
                    Entity = new ServiceRow() { Name = "kinopoisk", Api = "http://kinopoisk.cf/" }
                }).EntityId
            });
            var serviceKodik = Services.Service(new RetrieveRequest()
            {
                EntityId = Services.Create(new SaveRequest<ServiceRow>()
                {
                    Entity = new ServiceRow() { Name = "kodik", Api = "http://kodik.top/" }
                }).EntityId
            });
            InitJson(Path.Combine(HostingEnvironment.MapPath("~/App_Data/films.json")), MovieKind.Film, serviceKinopoisk.Entity, serviceKodik.Entity);
            InitJson(Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials.json")), MovieKind.TvSeries, serviceKinopoisk.Entity, serviceKodik.Entity);
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
        

        public static bool InitJson(string Path, MovieKind movieKind,ServiceRow serviceKinopoisk,ServiceRow service)
        {
            //try
            //{
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            string line = file.ReadToEnd();
            MovieJson[] data = JsonConvert.DeserializeObject<MovieJson[]>(line);

            foreach (MovieJson item in data)
            {
                CreateMovieVideo(
                    new SaveRequest<MovieRow>() { Entity = item.ToMovie(movieKind) },
                    new SaveRequest<VideoRow>() { Entity = item.ToVideo() },
                    new SaveRequest<ServiceRow>() { Entity = serviceKinopoisk, EntityId = serviceKinopoisk.ServiceId, },
                    new SaveRequest<ServiceRow>() { Entity = service, EntityId = service.ServiceId },
                    new SaveRequest<ServiceRatingRow>() { Entity = item.ToServiceRating(service) });
            }
            file.Close();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        public static SaveResponse CreateMovieVideo(SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video,SaveRequest<ServiceRow> serviceKinopoisk, SaveRequest<ServiceRow> service, SaveRequest<ServiceRatingRow> serviceRating)
        {
            SaveResponse response = Movies.Create(movie);
            video.Entity.MovieId = (Int64)response.EntityId;
            serviceRating.Entity.ServiceId = (Int16)serviceKinopoisk.EntityId;
            serviceRating.Entity.MovieId = (Int64)response.EntityId;
            ServicesRatings.Create(serviceRating);
            video.Entity.ServiceId = (Int16)service.EntityId;
            Videos.Create(video);
            return response;
        }
    }
}