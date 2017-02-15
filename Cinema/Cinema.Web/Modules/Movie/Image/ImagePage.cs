

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Image", typeof(Cinema.Movie.Pages.ImageController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Image"), Route("{action=index}")]
    public class ImageController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Image/ImageIndex.cshtml");
        }
    }
}