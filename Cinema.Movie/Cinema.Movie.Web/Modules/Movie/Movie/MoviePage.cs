
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
    using CastMoviePersons = Movie.Pages.CastMoviePersonController;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
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
                    i.CastPersonList = CastMoviePersons.List(
                        new ListRequest()
                        {
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
                return new Movies().Retrieve(connection, retrieveRequest).Entity;
            }
        }
    }
}