

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
    using System.Xml;

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
            //InitKodik();
            InitGetMovieCC();
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
        
        public static void InitKodik()
        {
            var serviceKinopoisk = Services.Service(new RetrieveRequest()
            {
                EntityId = Services.CreateUpdate(new SaveRequest<ServiceRow>()
                {
                    Entity = new ServiceRow() { Name = "kinopoisk", Api = "http://kinopoisk.cf/" }
                }).EntityId
            });
            var serviceKodik = Services.Service(new RetrieveRequest()
            {
                EntityId = Services.CreateUpdate(new SaveRequest<ServiceRow>()
                {
                    Entity = new ServiceRow() { Name = "kodik", Api = "http://kodik.top/" }
                }).EntityId
            });
            InitJson(JsonConvert.DeserializeObject<MovieJson[]>(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/films.json")))), MovieKind.Film, serviceKinopoisk.Entity, serviceKodik.Entity);
            InitJson(JsonConvert.DeserializeObject<MovieJson[]>(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials.json")))), MovieKind.TvSeries, serviceKinopoisk.Entity, serviceKodik.Entity);
        }
        public static void InitGetMovieCC()
        {
            var serviceKinopoisk = Services.Service(new RetrieveRequest()
            {
                EntityId = Services.CreateUpdate(new SaveRequest<ServiceRow>()
                {
                    Entity = new ServiceRow() { Name = "kinopoisk", Api = "http://kinopoisk.cf/" }
                }).EntityId
            });
            var serviceGetMovieCC = Services.Service(new RetrieveRequest()
            {
                EntityId = Services.CreateUpdate(new SaveRequest<ServiceRow>()
                {
                    Entity = new ServiceRow() { Name = "GetMovieCC", Api = "http://getmovie.cc/" }
                }).EntityId
            });
            XmlDocument doc = new XmlDocument();
            MovieJson[] movies = null;
            MovieJson[] serials = null;
            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/movies-word.xml"))));
            movies = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Movie;
            serials = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Serial;
            InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
            InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);

            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/movies-russian.xml"))));
            movies = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Movie;
            serials = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Serial;
            InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
            InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);

            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/movies-anime.xml"))));
            movies = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Movie;
            serials = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Serial;
            InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
            InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);

            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials-word.xml"))));
            movies = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Movie;
            serials = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Serial;
            InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
            InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);

            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials-russian.xml"))));
            movies = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Movie;
            serials = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Serial;
            InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
            InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);

            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials-anime.xml"))));
            movies = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Movie;
            serials = JsonConvert.DeserializeObject<XmlObject>(JsonConvert.SerializeXmlNode(doc)).content.Serial;
            InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
            InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity);
        }
        public static string FileRead(string Path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            string line = file.ReadToEnd();
            file.Close();
            return line;
        }
        
        public static void ToLogFile(string line)
        {
            var filename = Path.Combine(HostingEnvironment.MapPath("~/App_Data/LogDB.txt"));
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(line);
            sw.Close();
        }
        public static bool InitJson(MovieJson[] data, MovieKind movieKind,ServiceRow serviceKinopoisk,ServiceRow service)
        {
            ToLogFile(DateTime.UtcNow.ToString());
            foreach (MovieJson item in data)
            {
                var res= CreateMovieVideo(
                    new SaveRequest<MovieRow>() { Entity = item.ToMovie(movieKind) },
                    new SaveRequest<VideoRow>() { Entity = item.ToVideo() },
                    new SaveRequest<ServiceRow>() { Entity = serviceKinopoisk, EntityId = serviceKinopoisk.ServiceId, },
                    new SaveRequest<ServiceRow>() { Entity = service, EntityId = service.ServiceId },
                    new SaveRequest<ServiceRatingRow>() { Entity = item.ToServiceRating(service) });
                if (res.Error != null)
                {
                    ToLogFile(res.Error.Message);
                }
            }
            return true;
        }
        public static SaveResponse CreateMovieVideo(SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video,SaveRequest<ServiceRow> serviceKinopoisk, SaveRequest<ServiceRow> service, SaveRequest<ServiceRatingRow> serviceRating)
        {
            try
            {
                SaveResponse response = Movies.CreateUpdate(movie, serviceRating);
                video.Entity.MovieId = (Int64)response.EntityId;
                serviceRating.Entity.ServiceId = (Int16)serviceKinopoisk.EntityId;
                serviceRating.Entity.MovieId = (Int64)response.EntityId;
                ServicesRatings.CreateUpdate(serviceRating);
                video.Entity.ServiceId = (Int16)service.EntityId;
                Videos.Create(video);
                return response;
            }
            catch (Exception e)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = e.Message } };
            }
        }
    }
}