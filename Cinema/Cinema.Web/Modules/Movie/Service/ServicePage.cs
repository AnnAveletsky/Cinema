

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Service", typeof(Cinema.Movie.Pages.ServiceController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Service"), Route("{action=index}")]
    public class ServiceController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Service/ServiceIndex.cshtml");
        }
    }
}