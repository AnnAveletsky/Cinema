
namespace Admin.MovieDB.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("MovieDB/Genre"), Route("{action=index}")]
    public class GenreController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/MovieDB/Genre/GenreIndex.cshtml");
        }
    }
}