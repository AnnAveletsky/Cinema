
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Modules.Common.Navigation;
    using Movies = Repositories.MovieRepository;
    using System.Collections.Generic;
    using System;
    using Casts = Movie.Pages.CastController;
    using ServiceRatings = Movie.Pages.ServiceRatingController;
    using Videos = Movie.Pages.VideoController;
    using Serenity.Abstractions;
    using Newtonsoft.Json;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        public static HashSet<string> IncludeColumnsCast = new HashSet<string> { "PersonNameEn", "PersonNameOther" };
        public static HashSet<string> IncludeColumnsServiceRating = new HashSet<string> { "ServiceName" };
        public static SortBy[] Sort = new[] { new SortBy("Character") };
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Movie/MovieIndex.cshtml");
        }
        public static List<MovieRow> Page(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                List<MovieRow> movie = new Movies().List(connection, listRequest).Entities;
                movie.ForEach((i) =>
                {
                    i.CastList = Casts.List(
                        new ListRequest()
                        {
                            IncludeColumns= IncludeColumnsCast,
                            Criteria = new Criteria("MovieId") == i.MovieId.Value,
                            Sort = Sort
                        });
                    i.ServiceRatingList = ServiceRatings.List(
                        new ListRequest() {
                            IncludeColumns = IncludeColumnsServiceRating,
                            Criteria = new Criteria("MovieId") == i.MovieId.Value
                        });
                });
                return movie;
            }
        }
        public static MovieRow Movie(RetrieveRequest retrieveRequest)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                MovieRow movie = new Movies().Retrieve(connection, retrieveRequest).Entity;
                movie.CastList = Casts.List(
                        new ListRequest()
                        {
                            IncludeColumns = IncludeColumnsCast,
                            Criteria = new Criteria("MovieId") == movie.MovieId.Value,
                            Sort = Sort
                        });
                movie.ServiceRatingList = ServiceRatings.List(
                       new ListRequest()
                       {
                           IncludeColumns = IncludeColumnsServiceRating,
                           Criteria = new Criteria("MovieId") == movie.MovieId.Value
                       });
                movie.VideoList = Videos.List(
                    new ListRequest()
                    {
                        IncludeColumns= new HashSet<string> { "ServiceName" },
                        Criteria = new Criteria("MovieId") == movie.MovieId.Value,
                        Sort= new[] { new SortBy("ServiceName") }
            });
                return movie;
            }
            
        }

        class Item
        {
            public string name_eng;
            public string name;
            public string year;
            public string url;
            public string sub_type;
            public string kinopoisk_id;

            public override string ToString()
            {
                return string.Format("{0} ({1})", name, url);
            }
        }

        public static bool InitJson(string Path, MovieKind movieKind)
        {
            //try
            //{
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            string line = file.ReadToEnd();
            Item[] data = JsonConvert.DeserializeObject<Item[]>(line);
            foreach (Item item in data)
            {
                var Movie = new MovieRow();
                var Video = new VideoRow();
                Movie.Kind = movieKind;
                Movie.YearEnd = Int16.Parse(item.year);
                Movie.YearStart = Int16.Parse(item.year);
                if (item.name_eng == null || item.name_eng == "" || item.name_eng == item.name)
                {
                    Movie.TitleOriginal = item.name;
                    Movie.Url = Translit.GetTranslit(item.name);
                }
                else
                {
                    Movie.TitleOriginal = item.name_eng;
                    Movie.TitleTranslation = item.name;
                    if (item.name == null || item.name == "")
                    {
                        Movie.Url = Translit.GetUrl(item.name_eng);
                    }
                    else
                    {
                        Movie.Url = Translit.GetTranslit(item.name);
                    }
                }
                if (Movie.Url == null || Movie.Url == "")
                {
                    Movie.Url = item.kinopoisk_id;
                }
                
                Video.Path = item.url;
                Video.Translation = item.sub_type!=""? Int16.Parse(item.sub_type):(Int16)0;
                Video.MovieId = Create(new SaveRequest<MovieRow>() { Entity = Movie });
                Videos.Create(new SaveRequest<VideoRow>() { Entity = Video });
            }

            file.Close();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        public static Int64? Create(SaveRequest<MovieRow> request)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            using (var uow = new UnitOfWork(connection))
            {
                var result = new Movies().Create(uow, request).EntityId;
                uow.Commit();
                return (Int64?)result;
            }
        }
    }
}