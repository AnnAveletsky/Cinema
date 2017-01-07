
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
    using Casts = Repositories.CastRepository;
    using Histories = HistoryController;

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
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<CastRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<CastRow>())
            {
                var character = new Casts().List(connection, new ListRequest()).Entities.Find(i => i.CharacterEn == request.Entity.CharacterEn && i.PersonId==request.Entity.PersonId && i.MovieId==request.Entity.MovieId);
                if (character != null)
                {
                    return new SaveResponse()
                    {
                        EntityId = character.CastId
                    };
                }
            }
            using (var connection = SqlConnections.NewFor<CastRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new Casts().Create(uow, request);
                uow.Commit();
                connection.Close();
            }

            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add Cast",
                    UserName = Authorization.Username,
                    CastId = Int64.Parse(result.EntityId.ToString()),
                }
            });
            return result;
        }
    }
}