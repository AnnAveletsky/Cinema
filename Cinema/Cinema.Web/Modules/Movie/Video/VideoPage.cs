

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
    using Common.Init;
    using Entities;
    using System;

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
                var result = new Repository().UpdateCreate(uow, saveRequest);
                uow.Commit();
                return result;
            }
        }
        public static ListResponse<SaveResponse> UpdateCreate(MovieJson json, RetrieveResponse<MovieRow> movie, RetrieveResponse<ServicePathRow> servicePath)
        {
            var videos = new ListResponse<SaveResponse>();
            videos.Entities = new System.Collections.Generic.List<SaveResponse>();
            foreach (var video in json.ToVideos(movie, servicePath))
            {
                if (video != null)
                {
                    try
                    {
                        videos.Entities.Add(UpdateCreate(new SaveRequest<MyRow>() { Entity = video }));
                    }
                    catch (Exception e)
                    {
                        e.Log();
                        SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                    }
                }
            }
            return videos;
        }
    }
}