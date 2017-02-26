

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/ServiceRating", typeof(Cinema.Movie.Pages.ServiceRatingController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.ServiceRatingRepository;
    using MyRow = Entities.ServiceRatingRow;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/ServiceRating"), Route("{action=index}")]
    public class ServiceRatingController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServiceRating/ServiceRatingIndex.cshtml");
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
                var result = new Repository().UpdateCreate(uow, saveRequest);
                uow.Commit();
                return result;
            }
        }
    }
}