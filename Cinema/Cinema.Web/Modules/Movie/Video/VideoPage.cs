

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Video", typeof(Cinema.Movie.Pages.VideoController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Video"), Route("{action=index}")]
    public class VideoController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Video/VideoIndex.cshtml");
        }
    }
}