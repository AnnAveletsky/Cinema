
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Histories= Repositories.HistoryRepository;

    [RoutePrefix("Movie/History"), Route("{action=index}")]
    public class HistoryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/History/HistoryIndex.cshtml");
        }

        public static SaveResponse Create(SaveRequest<HistoryRow> request)
        {
            using (var connection = SqlConnections.NewFor<ServiceRow>())
            {
                using (var uow = new UnitOfWork(connection))
                {
                    var result = new Histories().Create(uow, request);
                    uow.Commit();

                    return result;
                }
            }
        }
    }
}