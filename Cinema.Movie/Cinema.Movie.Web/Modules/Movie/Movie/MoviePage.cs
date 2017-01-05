
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
    using ServiceRatings = ServiceRatingController;
    using Videos = VideoController;
    using Histories = HistoryController;

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
                            Sort = Sort
                        });
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
                            Sort = Sort
                        });
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
                response = new Movies().Update(uow, new SaveRequest<MovieRow>()
                {
                    EntityId = movie.MovieId,
                    Entity = request.Entity
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