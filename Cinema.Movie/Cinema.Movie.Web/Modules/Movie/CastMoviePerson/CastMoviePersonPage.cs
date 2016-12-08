namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CastMoviePersons = Repositories.CastMoviePersonRepository;

    [RoutePrefix("Movie/CastMoviePerson"), Route("{action=index}")]
    public class CastMoviePersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/CastMoviePerson/CastMoviePersonIndex.cshtml");
        }
        public static List<CastMoviePersonRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<CastMoviePersonRow>())
            {
                return new CastMoviePersons().List(connection, listRequest).Entities;
            }
        }
    }
}