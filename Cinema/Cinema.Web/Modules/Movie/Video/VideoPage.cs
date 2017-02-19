﻿

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Video", typeof(Cinema.Movie.Pages.VideoController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.VideoRepository;
    using MyRow = Entities.VideoRow;
    using Serenity.Services;
    using Serenity.Data;

    [RoutePrefix("Movie/Video"), Route("{action=index}")]
    public class VideoController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Video/VideoIndex.cshtml");
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
                var result= new Repository().UpdateCreate(uow, saveRequest);
                uow.Commit();
                return result;
            }
        }
    }
}