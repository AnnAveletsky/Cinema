namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ServiceRatings = Repositories.ServiceRatingRepository;

    [RoutePrefix("Movie/ServiceRating"), Route("{action=index}")]
    public class ServiceRatingController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServiceRating/ServiceRatingIndex.cshtml");
        }
        public static List<ServiceRatingRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<ServiceRatingRow>())
            {
                return new ServiceRatings().List(connection, listRequest).Entities;
            }
        }
        public static SaveResponse Create(SaveRequest<ServiceRatingRow> request)
        {
            using (var connection = SqlConnections.NewFor<ServiceRatingRow>())
            using (var uow = new UnitOfWork(connection))
            {
                var result = new ServiceRatings().Create(uow, request);
                uow.Commit();
                return result;
            }
        }
    }
}