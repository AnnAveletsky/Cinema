namespace Cinema.Movie.Configuration.Pages
{
    using Forms;
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Configuration/ServiceUpdate"), Route("{action=index}")]
    public class ServiceUpdateController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            ServiceUpdateModel model = new ServiceUpdateModel();
            return View("~/Modules/Configuration/ServiceUpdate/ServiceUpdateIndex.cshtml", model);
        }
    }
}