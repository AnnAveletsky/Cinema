namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Mvc;
    using Services = Repositories.ServiceRepository;
    using Movies = MovieController;
    using System.Threading.Tasks;
    using Histories = HistoryController;

    [RoutePrefix("Movie/Service"), Route("{action=index}")]
    public class ServiceController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Service/ServiceIndex.cshtml");
        }
        public static ListResponse<ServiceRow> All(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                return new Services().List(connection, listRequest);
            }
        }
        public static RetrieveResponse<ServiceRow> Service(RetrieveRequest retrieveRequest)
        {
            using (var connection = SqlConnections.NewFor<ServiceRow>())
            {
                return new Services().Retrieve(connection, retrieveRequest);
            }
        }
        public static SaveResponse CreateUpdate(SaveRequest<ServiceRow> request)
        {
            var searchServices = All(new ListRequest { Criteria = new Criteria("Name").Contains(request.Entity.Name) }).Entities;
            if (searchServices.Count > 0)
            {
                return new SaveResponse() { EntityId = searchServices.Find(i => i.Name.Contains(request.Entity.Name)).ServiceId};
            }
            using (var connection = SqlConnections.NewFor<ServiceRow>())
            using (var uow = new UnitOfWork(connection))
            {
                var result = new Services().Create(uow, request);
                uow.Commit();
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow()
                    {
                        Status = true,
                        Message = "Add Service",
                        UserName = Authorization.Username,
                        ServiceId= (Int16)result.EntityId
                    }
                });
                return result;
            }
        }
        public async Task<string> GetMovies(Int16 id)
        {
            var service = Service(new RetrieveRequest() { EntityId = id });
            return await GetSevice(service.Entity);
        }
        public async Task<string> GetSevice(ServiceRow service)
        {
            using (var httpClient = new HttpClient { BaseAddress = new Uri(service.Api) })
            {
                using (var response = await httpClient.GetAsync("undefined"))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
        public Int64? Kinopoisk(ServiceRow service)
        {
            //return Movies.Create(new SaveRequest<MovieRow>() { Entity = new MovieRow() { } });
            return 1;
        }
        public Int64? HDKinoteatr(ServiceRow service)
        {
            //return Movies.Create(new SaveRequest<MovieRow>() { Entity = new MovieRow() { } });
            return 1;
        }
    }
}