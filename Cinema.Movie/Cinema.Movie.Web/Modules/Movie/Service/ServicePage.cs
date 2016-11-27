namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Services = Repositories.ServiceRepository;

    [RoutePrefix("Movie/Service"), Route("{action=index}")]
    public class ServiceController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Service/ServiceIndex.cshtml");
        }
        public static List<ServiceRow> All(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                return new Services().List(connection, listRequest).Entities;
            }
        }
        public static ServiceRow Service(RetrieveRequest retrieveRequest)
        {
            using (var connection = SqlConnections.NewFor<ServiceRow>())
            {
                return new Services().Retrieve(connection, retrieveRequest).Entity;
            }
        }
        public Int64 GetMovies(Int16 id)
        {
            
            return 1;
        }
    }
}