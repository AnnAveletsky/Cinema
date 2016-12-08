namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Genres = Repositories.GenreRepository;

    [RoutePrefix("Movie/Genre"), Route("{action=index}")]
    public class GenreController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Genre/GenreIndex.cshtml");
        }
        public static List<GenreRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<GenreRow>())
            {
                return new Genres().List(connection, listRequest).Entities;
            }
        }
    }
}