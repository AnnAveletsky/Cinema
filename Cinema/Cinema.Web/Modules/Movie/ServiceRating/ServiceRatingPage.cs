

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/ServiceRating", typeof(Cinema.Movie.Pages.ServiceRatingController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/ServiceRating"), Route("{action=index}")]
    public class ServiceRatingController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServiceRating/ServiceRatingIndex.cshtml");
        }
    }
}