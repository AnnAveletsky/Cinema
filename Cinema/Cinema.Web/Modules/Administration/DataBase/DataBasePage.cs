

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Administration/DataBase", typeof(Cinema.Administration.Pages.DataBaseController))]

namespace Cinema.Administration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Administration/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
    }
}