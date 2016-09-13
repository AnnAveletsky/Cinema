
namespace Admin.MovieDB.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("MovieDB/Person"), Route("{action=index}")]
    public class PersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/MovieDB/Person/PersonIndex.cshtml");
        }
    }
}