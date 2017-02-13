

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Default/DataBase", typeof(Admin.Default.Pages.DataBaseController))]

namespace Admin.Default.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Default/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/DataBase/DataBaseIndex.cshtml");
        }
    }
}