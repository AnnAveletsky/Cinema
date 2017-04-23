[assembly: Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/DataBase", typeof(Cinema.Movie.Pages.DataBaseController))]
namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Movie/DataBase/DataBaseIndex.cshtml");
        }
    }
}