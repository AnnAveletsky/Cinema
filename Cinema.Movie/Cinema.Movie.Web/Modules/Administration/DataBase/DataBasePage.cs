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
    using MovieGenres = Movie.Pages.MovieGenreController;
    using Services = Movie.Pages.ServiceController;
    using ServicesRatings = Movie.Pages.ServiceRatingController;
    using Histories = Movie.Pages.HistoryController;
    using Genres = Movie.Pages.GenreController;
    using Countries = Movie.Pages.CountryController;
    using MovieCountries = Movie.Pages.MovieCountryController;
    using Persons = Movie.Pages.PersonController;
    using Casts = Movie.Pages.CastController;
    using Movie.Entities;
    using Serenity.Services;
    using Newtonsoft.Json;
    using System.Web.Hosting;
    using System.IO;
    using System.Xml;
    using Serenity;
    using System.Collections.Generic;

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
        public RedirectResult Init(string name, string service)
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
            return Redirect("/Movie/History");
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
                var stringXml = FileRead(Path.Combine(HostingEnvironment.MapPath(path)));
                stringXml = stringXml.Replace("<br />", "&lt;br&gt;").Replace("<br/>", "&lt;br&gt;");
                doc.LoadXml(stringXml);
                string xmlSer = JsonConvert.SerializeXmlNode(doc);
                var xmlDes = JsonConvert.DeserializeObject<XmlObject>(xmlSer);
                movies = xmlDes.content.Movie;
                serials = xmlDes.content.Serial;

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
                        },
                        item.ToGenres(),
                        item.ToCountries());
                foreach (var i in item.ToPersons())
                {
                    i.PersonId = Int64.Parse(Persons.CreateUpdate(new SaveRequest<PersonRow>() { Entity = i }).EntityId.ToString());
                    foreach (var j in item.ToCast(res, i))
                    {
                        Casts.CreateUpdate(new SaveRequest<CastRow>()
                        {
                            Entity = j
                        });
                    }
                }
                if (res.Error != null)
                {
                    Histories.Create(new SaveRequest<HistoryRow>()
                    {
                        Entity = new HistoryRow()
                        {
                            Status = false,
                            Message = "Fail create communication" + res.Error.Message + " " + item.ToJson(),
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
                            Message = "Create communication id =" + res.EntityId + ", movie=" + item.ToString(),
                            UserName = username,
                        }
                    });
                }
            }
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateMovieVideo(string username, SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video, SaveRequest<ServiceRow> serviceKinopoisk, SaveRequest<ServiceRow> service, SaveRequest<ServiceRatingRow> serviceRating, List<GenreRow> genres,List<CountryRow> countries)
        {
            if (movie == null || video == null || serviceKinopoisk == null || service == null || serviceRating == null)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = "CreateMovieVideo null object" } };
            }
            SaveResponse response = null;
            try
            {
                response = Movies.CreateUpdate(movie, serviceRating);
                video.Entity.MovieId = (Int64)response.EntityId;
                serviceRating.Entity.ServiceId = (Int16)serviceKinopoisk.EntityId;
                serviceRating.Entity.MovieId = (Int64)response.EntityId;
                SaveResponse servicesRatingResponse = ServicesRatings.CreateUpdate(serviceRating);
                video.Entity.ServiceId = (Int16)service.EntityId;
                SaveResponse videoResponce = Videos.Create(video);
            }
            catch (Exception e)
            {
                return new SaveResponse() { Error = new ServiceError() { Message = "CreateMovieVideo"+e.Message } };
            }
            foreach (var i in genres)
            {
                try
                {
                    MovieGenres.CreateUpdate(new SaveRequest<MovieGenreRow>()
                    {
                        Entity = new MovieGenreRow()
                        {
                            MovieId = Int64.Parse(response.EntityId.ToString()),
                            GenreId = Int16.Parse(Genres.CreateUpdate(new SaveRequest<GenreRow>()
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
                    MovieCountries.CreateUpdate(new SaveRequest<MovieCountryRow>()
                    {
                        Entity = new MovieCountryRow()
                        {
                            MovieId = Int64.Parse(response.EntityId.ToString()),
                            CountryId = Int16.Parse(Countries.CreateUpdate(new SaveRequest<CountryRow>()
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