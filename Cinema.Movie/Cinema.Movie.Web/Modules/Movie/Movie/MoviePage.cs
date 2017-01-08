
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Movies = Repositories.MovieRepository;
    using System.Collections.Generic;
    using System;
    using Casts = CastController;
    using MovieCountries = MovieCountryController;
    using ServiceRatings = ServiceRatingController;
    using Videos = VideoController;
    using Histories = HistoryController;
    using System.Linq;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        public static HashSet<string> IncludeColumnsCast = new HashSet<string> { "PersonName", "PersonNameOther","PersonId","PersonUrl" };
        public static HashSet<string> IncludeColumnsServiceRating = new HashSet<string> { "ServiceName" };
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Movie/MovieIndex.cshtml");
        }

        public static ListResponse<MovieRow> Page(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                ListResponse<MovieRow> movies = new Movies().List(connection, listRequest);
                movies.Entities.ForEach((i) =>
                {
                    i.CastList = Casts.List(
                        new ListRequest()
                        {
                            IncludeColumns = IncludeColumnsCast,
                            Criteria = new Criteria("MovieId") == i.MovieId.Value,
                        });
                    i.CountrySortedList = new SortedList<string, string>();
                    foreach( var j in MovieCountries.List(new ListRequest() {
                        Criteria = new Criteria("MovieId") == i.MovieId.Value,
                    IncludeColumns=new HashSet<string>() { "CountryName", "CountryNameOther", "CountryIcon" } }).Entities)
                    {
                        if (!i.CountrySortedList.Keys.Contains(j.CountryNameDisplay))
                        {
                            i.CountrySortedList.Add(j.CountryNameDisplay, j.CountryIcon);
                        }
                    }
                    //i.CastSortList = new SortedList<string, List<CastRow>>();
                    //foreach (var j in i.CastList)
                    //{
                    //    if (!i.CastSortList.Keys.Contains(j.CharacterEn))
                    //    {
                    //        i.CastSortList.Add(j.CharacterEn,new List<CastRow>());
                    //    }
                    //    if (i.CastSortList[j.CharacterEn].Find(k => k.PersonId == j.PersonId)==null){
                    //        i.CastSortList[j.CharacterEn].Add(j);
                    //    }
                    //}
                    i.ServiceRatingList = ServiceRatings.List(
                        new ListRequest()
                        {
                            IncludeColumns = IncludeColumnsServiceRating,
                            Criteria = new Criteria("MovieId") == i.MovieId.Value
                        }).Entities;
                });
                return movies;
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
                        });
                movie.CountrySortedList = new SortedList<string, string>();
                foreach (var j in MovieCountries.List(new ListRequest() {
                    Criteria = new Criteria("MovieId") == movie.MovieId.Value,
                    IncludeColumns = new HashSet<string>() { "CountryName", "CountryNameOther", "CountryIcon" }}).Entities)
                {
                    if (!movie.CountrySortedList.Keys.Contains(j.CountryNameDisplay))
                    {
                        movie.CountrySortedList.Add(j.CountryNameDisplay, j.CountryIcon);
                    }
                }
                movie.CastSortList = new SortedList<string,List<CastRow>>();
                foreach (var i in movie.CastList)
                {
                    if (!movie.CastSortList.Keys.Contains(i.CharacterEn))
                    {
                        movie.CastSortList.Add(i.CharacterEn, new List<CastRow>());
                    }
                    if (movie.CastSortList[i.CharacterEn].Find(k => k.PersonId == i.PersonId) == null)
                    {
                        movie.CastSortList[i.CharacterEn].Add(i);
                    }
                }
                movie.ServiceRatingList = ServiceRatings.List(
                       new ListRequest()
                       {
                           IncludeColumns = IncludeColumnsServiceRating,
                           Criteria = new Criteria("MovieId") == movie.MovieId.Value
                       }).Entities;
                movie.VideoList = Videos.List(
                    new ListRequest()
                    {
                        IncludeColumns = new HashSet<string> { "ServiceName" },
                        Criteria = new Criteria("MovieId") == movie.MovieId.Value,
                        Sort = new[] { new SortBy("ServiceName") }
                    });
                return movie;
            }
        }
        public static SaveResponse Update(SaveRequest<MovieRow> request,MovieRow movie)
        {
            SaveResponse response = null;
            using (var connection = SqlConnections.NewFor<MovieRow>())
            using (var uow = new UnitOfWork(connection))
            {
                request.Entity.MovieId = movie.MovieId;
                if (String.IsNullOrWhiteSpace(movie.TitleTranslation)&& !String.IsNullOrWhiteSpace(request.Entity.TitleTranslation))
                {
                    movie.TitleTranslation = request.Entity.TitleTranslation;
                }
                if (movie.Description.Length==0 &&request.Entity.Description.Length!=0)
                {
                    movie.Description = request.Entity.Description;
                }
                if (String.IsNullOrWhiteSpace(movie.PathImage) && !String.IsNullOrWhiteSpace(request.Entity.PathImage))
                {
                    movie.PathImage = request.Entity.PathImage;
                }
                if (String.IsNullOrWhiteSpace(movie.Runtime) && !String.IsNullOrWhiteSpace(request.Entity.Runtime))
                {
                    movie.PathImage = request.Entity.PathImage;
                }
                movie.UpdateDateTime = DateTime.UtcNow;
                response = new Movies().Update(uow, new SaveRequest<MovieRow>()
                {
                    EntityId = movie.MovieId,
                    Entity = movie
                });
                uow.Commit();
                connection.Close();
            }
            return response;
        }
        public static SaveResponse Create(SaveRequest<MovieRow> request)
        {
            SaveResponse response = null;
            using (var connection = SqlConnections.NewFor<MovieRow>())
            using (var uow = new UnitOfWork(connection))
            {
                response = new Movies().Create(uow, request);
                uow.Commit();
                connection.Close();
            }
            return response;
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<MovieRow> request, SaveRequest<ServiceRatingRow> serviceRating)
        {
            SaveResponse response = null;
            ListResponse<MovieRow> movies = null;
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                movies = new Movies().List(connection, new ListRequest
                {
                    Criteria = new Criteria("TitleOriginal").Contains(request.Entity.TitleOriginal) &&
                        new Criteria("YearEnd").In(request.Entity.YearEnd)
                });
            }
            if (movies.Entities.Count > 0)
            {
                var movie = movies.Entities.Find(i => i.TitleOriginal.Contains(request.Entity.TitleOriginal) && i.YearEnd == request.Entity.YearEnd);
                if (movie != null)
                {
                    response = Update(request, movie);
                    Histories.Create(new SaveRequest<HistoryRow>()
                    {
                        Entity = new HistoryRow()
                        {
                            Status = true,
                            Message = "Update Movie",
                            UserName = Authorization.Username,
                            MovieId = movie.MovieId,
                        }
                    });
                    return response;
                }
            }
            if (serviceRating.Entity.Id != null)
            {
                ListResponse<ServiceRatingRow> serviceRatings = ServiceRatings.List(new ListRequest() { Criteria = new Criteria("Id").In(serviceRating.Entity.Id) });
                if (serviceRatings.Entities.Count > 0)
                {
                    var movie = movies.Entities.Find(i => i.MovieId == serviceRatings.Entities.Find(j => j.Id != null && j.Id == serviceRating.Entity.Id).MovieId);
                    if (movie != null)
                    {
                        response = Update(request, movie);
                        Histories.Create(new SaveRequest<HistoryRow>()
                        {
                            Entity = new HistoryRow()
                            {
                                Status = true,
                                Message = "Update Movie",
                                UserName = Authorization.Username,
                                MovieId = movie.MovieId,
                                ServiceRatingId = (Int64)serviceRating.EntityId
                            }
                        });
                        return response;
                    }
                }
            }
            response = Create(request);
            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add Movie",
                    UserName = Authorization.Username,
                    MovieId = (Int64)response.EntityId,
                }
            });
            return response;
        }
    }
}