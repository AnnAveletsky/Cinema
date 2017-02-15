

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Person", typeof(Cinema.Movie.Pages.PersonController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Movie/Person"), Route("{action=index}")]
    public class PersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Person/PersonIndex.cshtml");
        }
    }
}