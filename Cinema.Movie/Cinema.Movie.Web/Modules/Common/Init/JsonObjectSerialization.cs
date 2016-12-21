using Cinema.Movie.Movie;
using Cinema.Movie.Movie.Entities;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Videos = Cinema.Movie.Movie.Pages.VideoController;
using Movies = Cinema.Movie.Movie.Pages.MovieController;
using Services = Cinema.Movie.Movie.Pages.ServiceController;
using ServicesRatings = Cinema.Movie.Movie.Pages.ServiceRatingController;
using Newtonsoft.Json;
using System.Web.Hosting;
using System.IO;
using System.Xml;
using Serenity;

namespace Cinema.Movie.Common.Init
{
    public class JsonObjectSerialization
    {
        public static void InitKodik(string path, MovieKind movieKind)
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
            InitJson(JsonConvert.DeserializeObject<MovieJson[]>(FileRead(Path.Combine(HostingEnvironment.MapPath(path)))), movieKind, serviceKinopoisk.Entity, serviceKodik.Entity);
        }
        public static void InitGetMovieCC(string path)
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
            doc.LoadXml(FileRead(Path.Combine(HostingEnvironment.MapPath(path))));
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
        public static void InitJson(MovieJson[] data, MovieKind movieKind, ServiceRow serviceKinopoisk, ServiceRow service)
        {
            var filename = Path.Combine(HostingEnvironment.MapPath("~/App_Data/LogDB.txt"));
            StreamWriter sw = new StreamWriter(filename, true);
            StatusTask.Count = data.Length;
            foreach (MovieJson item in data)
            {
                var i = new Task(() =>
                {
                    var res = CreateMovieVideo(
                            new SaveRequest<MovieRow>() { Entity = item.ToMovie(movieKind) },
                            new SaveRequest<VideoRow>() { Entity = item.ToVideo() },
                            new SaveRequest<ServiceRow>() { Entity = serviceKinopoisk, EntityId = serviceKinopoisk.ServiceId, },
                            new SaveRequest<ServiceRow>() { Entity = service, EntityId = service.ServiceId },
                            new SaveRequest<ServiceRatingRow>() { Entity = item.ToServiceRating(service) });
                    if (res.Error != null)
                    {
                        sw.WriteLine(DateTime.UtcNow.ToString() + "\n" + res.Error.Message + "\n" + item.ToJson() + "\n");
                    }
                });
                StatusTask.tasks.Add(i);
            }
            sw.Close();
        }
        public static SaveResponse CreateMovieVideo(SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video, SaveRequest<ServiceRow> serviceKinopoisk, SaveRequest<ServiceRow> service, SaveRequest<ServiceRatingRow> serviceRating)
        {
            if (movie == null || video == null || serviceKinopoisk == null || service == null || serviceRating == null)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = "null object" } };
            }
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