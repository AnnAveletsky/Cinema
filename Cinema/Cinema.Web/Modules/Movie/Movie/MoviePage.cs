

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Movie", typeof(Cinema.Movie.Pages.MovieController))]

namespace Cinema.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Serenity.Data;
    using System.Linq;
    using Repository = Repositories.MovieRepository;
    using MyRow = Entities.MovieRow;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Movie/MovieIndex.cshtml");
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
        public static SaveResponse UpdateCreate(SaveRequest<MyRow> saveRequest, SaveRequest<ServiceRatingRow> serviceRating)
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