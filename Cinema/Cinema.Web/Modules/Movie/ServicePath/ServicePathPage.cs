

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/ServicePath", typeof(Cinema.Movie.Pages.ServicePathController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/ServicePath"), Route("{action=index}")]
    public class ServicePathController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServicePath/ServicePathIndex.cshtml");
        }
    }
}