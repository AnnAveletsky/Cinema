

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Genre", typeof(Cinema.Movie.Pages.GenreController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Genre"), Route("{action=index}")]
    public class GenreController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Genre/GenreIndex.cshtml");
        }
    }
}