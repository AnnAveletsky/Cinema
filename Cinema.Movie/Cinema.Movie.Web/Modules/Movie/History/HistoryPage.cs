

namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/History"), Route("{action=index}")]
    public class HistoryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/History/HistoryIndex.cshtml");
        }
    }
}