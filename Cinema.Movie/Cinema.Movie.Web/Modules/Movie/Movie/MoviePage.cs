

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Movie", typeof(Cinema.Movie.Movie.Pages.MovieController))]

namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Movie/MovieIndex.cshtml");
        }
    }
}