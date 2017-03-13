

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
    using Common.Init;
    using Entities;
    using System;

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
        public static ListResponse<SaveResponse> UpdateCreate(MovieJson json, RetrieveResponse<MovieRow> movie)
        {
            var serviceRaitings = new ListResponse<SaveResponse>() { Entities = new System.Collections.Generic.List<SaveResponse>() };
            foreach (var sRating in json.ToServiceRatings(movie.Entity))
            {
                try
                {
                    var service = ServiceController.UpdateCreate(new SaveRequest<ServiceRow>()
                    {
                        Entity = new ServiceRow()
                        {
                            Url = sRating.ServiceUrl,
                            Name = sRating.ServiceName,
                            Api = sRating.ServiceApi
                        }
                    });
                    sRating.ServiceId = Int32.Parse(service.EntityId.ToString());
                    serviceRaitings.Entities.Add(UpdateCreate(new SaveRequest<MyRow>()
                    {
                        Entity = sRating
                    }));
                }
                catch (Exception e)
                {
                    e.Log();
                    SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                }
            }
            return serviceRaitings;
        }
    }
}