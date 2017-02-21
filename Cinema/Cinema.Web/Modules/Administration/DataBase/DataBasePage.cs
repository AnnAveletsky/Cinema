
namespace Cinema.Administration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Administration/DataBase"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.DataBaseRow))]
    public class DataBaseController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
    }
}