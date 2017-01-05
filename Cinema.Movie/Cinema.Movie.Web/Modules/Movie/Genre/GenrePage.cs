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
    using Genres = Repositories.GenreRepository;
    using Histories = HistoryController;

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
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<GenreRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<GenreRow>())
            {
                var genre = new Genres().List(connection, new ListRequest()).Entities.Find(i => i.Name == request.Entity.Name);
                if (genre != null)
                {
                    return new SaveResponse()
                    {
                        EntityId = genre.GenreId
                    };
                }
            }
            using (var connection = SqlConnections.NewFor<GenreRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new Genres().Create(uow, request);
                uow.Commit();
                connection.Close();
            }
            
            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add Genre",
                    UserName = Authorization.Username,
                    GenreId = Int16.Parse(result.EntityId.ToString()),
                }
            });
            return result;
        }
    }
}