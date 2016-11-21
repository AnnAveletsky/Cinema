namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/MovieCast"), Route("{action=index}")]
    public class MovieCastController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieCast/MovieCastIndex.cshtml");
        }
    }
}