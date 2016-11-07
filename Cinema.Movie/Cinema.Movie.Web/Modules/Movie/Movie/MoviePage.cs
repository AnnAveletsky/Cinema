
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using Modules.Common.Navigation;
    using Movies = Repositories.MovieRepository;
    using System.Collections.Generic;

    [RoutePrefix("Movie/Movie"), Route("{action=index}")]
    public class MovieController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Movie/MovieIndex.cshtml");
        }
        public List<MovieRow> ListPage(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                return new Movies().ListPage(connection,listRequest);
            }
        }
    }
}