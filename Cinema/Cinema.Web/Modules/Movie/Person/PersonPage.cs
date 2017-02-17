

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Person", typeof(Cinema.Movie.Pages.PersonController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.PersonRepository;
    using MyRow = Entities.PersonRow;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/Person"), Route("{action=index}")]
    public class PersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Person/PersonIndex.cshtml");
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
            ListRequest listRequest = new ListRequest() { Criteria = new Repository().Criteria(saveRequest.Entity) };
            using (var connection = SqlConnections.NewFor<MyRow>())
            using (var uow = new UnitOfWork(connection))
            {
                if (new Repository().Exist(connection, listRequest))
                {
                    return new Repository().FindUpdate(uow, saveRequest, listRequest);
                }
                else
                {
                    return new Repository().Create(uow, saveRequest);
                }
            }
        }
    }
}