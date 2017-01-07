namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Web.Mvc;
    using Countries = Repositories.CountryRepository;
    using Histories = HistoryController;

    [RoutePrefix("Movie/Country"), Route("{action=index}")]
    public class CountryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Country/CountryIndex.cshtml");
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<CountryRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<CountryRow>())
            {
                var country = new Countries().List(connection, new ListRequest()).Entities.Find(i => i.Name == request.Entity.Name);
                if (country != null)
                {
                    return new SaveResponse()
                    {
                        EntityId = country.CountryId
                    };
                }
            }
            using (var connection = SqlConnections.NewFor<CountryRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new Countries().Create(uow, request);
                uow.Commit();
                connection.Close();
            }

            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add Genre",
                    UserName = Authorization.Username,
                    CountryId = Int16.Parse(result.EntityId.ToString()),
                }
            });
            return result;
        }
    }
}