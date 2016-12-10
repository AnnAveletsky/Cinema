

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/MovieGenres", typeof(Cinema.Movie.Movie.Pages.MovieGenresController))]

namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/MovieGenres"), Route("{action=index}")]
    public class MovieGenresController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieGenres/MovieGenresIndex.cshtml");
        }
    }
}