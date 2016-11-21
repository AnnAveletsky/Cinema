

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Cast", typeof(Cinema.Movie.Movie.Pages.CastController))]

namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Cast"), Route("{action=index}")]
    public class CastController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Cast/CastIndex.cshtml");
        }
    }
}