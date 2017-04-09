

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Administration/Site", typeof(Cinema.Administration.Pages.SiteController))]

namespace Cinema.Administration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Administration/Site"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.SiteRow))]
    public class SiteController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Administration/Site/SiteIndex.cshtml");
        }
    }
}