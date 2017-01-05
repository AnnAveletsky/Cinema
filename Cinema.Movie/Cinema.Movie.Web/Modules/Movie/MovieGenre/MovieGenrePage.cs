
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using MovieGenres = Repositories.MovieGenreRepository;
    using Histories = HistoryController;
    using System;

    [RoutePrefix("Movie/MovieGenre"), Route("{action=index}")]
    public class MovieGenreController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieGenre/MovieGenreIndex.cshtml");
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<MovieGenreRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<MovieGenreRow>())
            {
                var genre = new MovieGenres().List(connection,
                    new ListRequest()).Entities.Find(i => i.GenreId == request.Entity.GenreId && i.MovieId == request.Entity.MovieId);

                if (genre != null)
                {
                    return new SaveResponse()
                    {
                        EntityId = genre.MovieGenreId
                    };
                }
            }
            using (var connection = SqlConnections.NewFor<MovieGenreRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new MovieGenres().Create(uow, request);
                uow.Commit();
            }
            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add MovieGenre",
                    UserName = Authorization.Username,
                    MovieGenreId = Int64.Parse(result.EntityId.ToString()),
                }
            });
            return result;
        }
    }
}