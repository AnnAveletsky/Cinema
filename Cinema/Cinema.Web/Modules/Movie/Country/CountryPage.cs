

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Country", typeof(Cinema.Movie.Pages.CountryController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.CountryRepository;
    using MyRow = Entities.CountryRow;

    [RoutePrefix("Movie/Country"), Route("{action=index}")]
    public class CountryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Country/CountryIndex.cshtml");
        }
        public static RetrieveResponse<MyRow> Find(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().Find(connection, listRequest);
            }
        }
        public static ListResponse<MyRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return new Repository().List(connection, listRequest);
            }
        }
        public static SaveResponse UpdateCreate(SaveRequest<MyRow> saveRequest)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            using (var uow = new UnitOfWork(connection))
            {
                return new Repository().UpdateCreate(uow, saveRequest);
            }
        }
    }
}