namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/CastMoviePerson"), Route("{action=index}")]
    public class CastMoviePersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/CastMoviePerson/CastMoviePersonIndex.cshtml");
        }
    }
}