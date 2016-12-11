namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Videos = Repositories.VideoRepository;

    [RoutePrefix("Movie/Video"), Route("{action=index}")]
    public class VideoController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Video/VideoIndex.cshtml");
        }
        public static List<VideoRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<VideoRow>())
            {
                return new Videos().List(connection, listRequest).Entities;
            }
        }
    }
}