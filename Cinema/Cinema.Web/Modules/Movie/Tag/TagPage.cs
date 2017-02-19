

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Tag", typeof(Cinema.Movie.Pages.TagController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.ServiceRepository;
    using MyRow = Entities.ServiceRow;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/Tag"), Route("{action=index}")]
    public class TagController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Tag/TagIndex.cshtml");
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
                return new Repository().UpdateCreate(uow, saveRequest);
            }
        }
    }
}