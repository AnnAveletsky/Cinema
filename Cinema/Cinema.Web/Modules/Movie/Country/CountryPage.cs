

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Country", typeof(Cinema.Movie.Pages.CountryController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Country"), Route("{action=index}")]
    public class CountryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Country/CountryIndex.cshtml");
        }
    }
}