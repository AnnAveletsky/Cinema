namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Videos = Repositories.VideoRepository;
    using Histories = HistoryController;

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
        [PageAuthorize("Administration")]
        public static SaveResponse Create(SaveRequest<VideoRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<VideoRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new Videos().Create(uow, request);
                uow.Commit();
                connection.Close();
            }
            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add Video",
                    UserName = Authorization.Username,
                    VideoId = (Int64)result.EntityId,
                }
            });
            return result;
        }
    }
}