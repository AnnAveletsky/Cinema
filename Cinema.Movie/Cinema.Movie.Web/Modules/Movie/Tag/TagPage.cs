

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Tag", typeof(Cinema.Movie.Movie.Pages.TagController))]

namespace Cinema.Movie.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Tag"), Route("{action=index}")]
    public class TagController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Tag/TagIndex.cshtml");
        }
    }
}