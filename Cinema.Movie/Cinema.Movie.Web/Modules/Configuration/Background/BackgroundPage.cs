namespace Cinema.Movie.Configuration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configuration/Background"), Route("{action=index}")]
    public class BackgroundController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Configuration/Background/BackgroundIndex.cshtml");
        }
    }
}