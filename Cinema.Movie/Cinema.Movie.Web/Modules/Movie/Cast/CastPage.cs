
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Casts = Repositories.CastRepository;

    [RoutePrefix("Movie/Cast"), Route("{action=index}")]
    public class CastController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Cast/CastIndex.cshtml");
        }
        public static List<CastRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<CastRow>())
            {
                return new Casts().List(connection, listRequest).Entities;
            }
        }
    }
}