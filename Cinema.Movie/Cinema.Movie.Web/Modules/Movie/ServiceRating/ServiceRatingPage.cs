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
        public static ListResponse<ServiceRatingRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<ServiceRatingRow>())
            {
                return new ServiceRatings().List(connection, listRequest);
            }
        }
        public static SaveResponse CreateUpdate(SaveRequest<ServiceRatingRow> request)
        {
            var searchServices = List(new ListRequest { Criteria = new Criteria("Id").In(request.Entity.Id) });
            
            if (searchServices.Entities.Count > 0)
            {
                var service = searchServices.Entities.Find(i => i.Id == request.Entity.Id);
                using (var connection = SqlConnections.NewFor<ServiceRatingRow>())
                using (var uow = new UnitOfWork(connection))
                {
                    request.Entity.ServiceRatingId = service.ServiceRatingId;
                    var result = new ServiceRatings().Update(uow, new SaveRequest<ServiceRatingRow>() { EntityId = service.ServiceRatingId, Entity = request.Entity });
                    uow.Commit();
                    return result;
                }
            }
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