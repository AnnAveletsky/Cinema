
namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using Repository = Repositories.MovieCountryRepository;
    using MyRow = Entities.MovieCountryRow;
    using System.Web.Mvc;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/MovieCountry"), Route("{action=index}")]
    public class MovieCountryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieCountry/MovieCountryIndex.cshtml");
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