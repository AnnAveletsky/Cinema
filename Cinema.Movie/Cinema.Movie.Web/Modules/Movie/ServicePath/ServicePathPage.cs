namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ServicePaths = Repositories.ServicePathRepository;

    [RoutePrefix("Movie/ServicePath"), Route("{action=index}")]
    public class ServicePathController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/ServicePath/ServicePathIndex.cshtml");
        }
        public static SaveResponse Create(SaveRequest<ServicePathRow> request)
        {
            using (var connection = SqlConnections.NewFor<ServicePathRow>())
            using (var uow = new UnitOfWork(connection))
            {
                var result = new ServicePaths().Create(uow, request);
                uow.Commit();
                return result;
            }
        }
    }
}