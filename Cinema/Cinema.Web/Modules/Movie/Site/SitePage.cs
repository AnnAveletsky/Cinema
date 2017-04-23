

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Site", typeof(Cinema.Movie.Pages.SiteController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.SiteRepository;
    using MyRow = Entities.SiteRow;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/Site"), Route("{action=index}")]
    public class SiteController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Site/SiteIndex.cshtml");
        }
        public static RetrieveResponse<MyRow> Find(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().Find(connection, listRequest);
            }
        }
    }
}