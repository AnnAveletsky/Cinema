
namespace Admin.MovieDB.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("MovieDB/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/MovieDB/Movie/MovieIndex.cshtml");
        }
    }
}