
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
    using System.IO;
    using System.Web.Hosting;

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
        public static SaveResponse CreateUpdate(SaveRequest<MovieRow> request,SaveRequest<ServiceRatingRow> serviceRating)
        {
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
                    using (var connection = SqlConnections.NewFor<MovieRow>())
                    using (var uow = new UnitOfWork(connection))
                    {
                        request.Entity.MovieId = movie.MovieId;
                        var result = new Movies().Update(uow, new SaveRequest<MovieRow>() { EntityId = movie.MovieId, Entity = request.Entity });
                        uow.Commit();
                        return result;
                    }
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
                        using (var connection = SqlConnections.NewFor<MovieRow>())
                        using (var uow = new UnitOfWork(connection))
                        {
                            request.Entity.MovieId = movie.MovieId;
                            var result = new Movies().Update(uow, new SaveRequest<MovieRow>() { EntityId = movie.MovieId, Entity = request.Entity });
                            uow.Commit();
                            return result;
                        }
                    }
                }
            }
            using (var connection = SqlConnections.NewFor<MovieRow>())
            using (var uow = new UnitOfWork(connection))
            {
                var response = new Movies().Create(uow, request);
                uow.Commit();
                connection.Close();
                return response;
            }
        }
    }
}