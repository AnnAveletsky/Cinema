namespace Cinema.Movie.Administration.Pages
{
    using Movie;
    using Serenity.Web;
    using System;
    using System.Web.Mvc;
    using Common.Init;
    using Modules.Administration.DataBase;
    using Videos = Movie.Pages.VideoController;
    using Movies = Movie.Pages.MovieController;
    using Services = Movie.Pages.ServiceController;
    using ServicesRatings = Movie.Pages.ServiceRatingController;
    using Histories = Movie.Pages.HistoryController;
    using Movie.Entities;
    using Serenity.Services;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Web.Hosting;
    using System.IO;
    using System.Xml;
    using Serenity;

    [RoutePrefix("Administration/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        FilesModel model = new FilesModel();
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml", model);
        }

        [PageAuthorize("Administration")]
        public ActionResult Init(string name, string service)
        {
            StatusTask.TimeStart = DateTime.UtcNow;
            var file = model.files.Find(i => i.Name == name);
            Authorization.ValidateLoggedIn();
            if (service == "Kodik")
            {
                InitKodik("~/App_Data/" + file.Name, MovieKind.Film, Authorization.Username);
            }
            else if (service == "GetMovieCC")
            {
                InitGetMovieCC("~/App_Data/" + file.Name, Authorization.Username);
            }
            StatusTask.TimeEnd = DateTime.UtcNow;
            return View("~/Modules/Movie/History/HistoryIndex.cshtml");
        }
        [PageAuthorize("Administration")]
        public static void InitKodik(string path, MovieKind movieKind, string username)
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

            try
            {
                InitJson(JsonConvert.DeserializeObject<MovieJson[]>(FileRead(Path.Combine(HostingEnvironment.MapPath(path)))), movieKind, serviceKinopoisk.Entity, serviceKodik.Entity, username);
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow() { Status = true, Message = "Finish add " + movieKind, UserName = username }
                });
            }
            catch (Exception e)
            {
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow() { Status = true, Message = e.Message, UserName = username }
                });
            }

        }
        [PageAuthorize("Administration")]
        public static void InitGetMovieCC(string path, string username)
        {
            try
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

                InitJson(movies, MovieKind.Film, serviceKinopoisk.Entity, serviceGetMovieCC.Entity, username);
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow() { Status = true, Message = "Finish add Movies", UserName = username }
                });

                InitJson(serials, MovieKind.TvSeries, serviceKinopoisk.Entity, serviceGetMovieCC.Entity, username);
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow() { Status = true, Message = "Finish add Serials", UserName = username }
                });
            }
            catch (Exception e)
            {
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow() { Status = false, Message = e.Message, UserName = username }
                });
            }
        }
        public static string FileRead(string Path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            string line = file.ReadToEnd();
            file.Close();
            return line;
        }
        [PageAuthorize("Administration")]
        public static void InitJson(MovieJson[] data, MovieKind movieKind, ServiceRow serviceKinopoisk, ServiceRow service, string username)
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
                        });
                if (res.Error != null)
                {
                    Histories.Create(new SaveRequest<HistoryRow>()
                    {
                        Entity = new HistoryRow()
                        {
                            Status = false,
                            Message = res.Error.Message + " " + item.ToJson(),
                            UserName = username
                        }
                    });
                }
                else
                {
                    Histories.Create(new SaveRequest<HistoryRow>()
                    {
                        Entity = new HistoryRow()
                        {
                            Status = true,
                            Message = "id=" + res.EntityId + ", movie=" + item.ToString(),
                            UserName = username,
                        }
                    });
                }
            }
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateMovieVideo(string username, SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video, SaveRequest<ServiceRow> serviceKinopoisk, SaveRequest<ServiceRow> service, SaveRequest<ServiceRatingRow> serviceRating)
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
                SaveResponse servicesRatingResponse = ServicesRatings.CreateUpdate(serviceRating);
                video.Entity.ServiceId = (Int16)service.EntityId;
                SaveResponse videoResponce = Videos.Create(video);
                return response;
            }
            catch (Exception e)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = e.Message } };
            }
        }
    }
}