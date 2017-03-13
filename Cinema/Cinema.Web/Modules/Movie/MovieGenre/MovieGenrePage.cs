

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.MovieGenreRepository;
    using MyRow = Entities.MovieGenreRow;
    using Serenity.Services;
    using Serenity.Data;
    using Entities;
    using Common.Init;
    using System;

    [RoutePrefix("Movie/MovieGenre"), Route("{action=index}")]
    public class MovieGenreController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieGenre/MovieGenreIndex.cshtml");
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
                var result = new Repository().ExistCreate(uow, saveRequest);
                uow.Commit();
                return result;
            }
        }
        public static ListResponse<SaveResponse> UpdateCreate(MovieJson json, RetrieveResponse<MovieRow> movie)
        {
            var genres = new ListResponse<SaveResponse>() { Entities = new System.Collections.Generic.List<SaveResponse>() };

            foreach (var genre in json.ToGenres())
            {
                try
                {
                    genres.Entities.Add(UpdateCreate(new SaveRequest<MyRow>()
                    {
                        Entity = new MyRow()
                        {
                            MovieId = movie.Entity.MovieId,
                            GenreId = Int32.Parse(GenreController.UpdateCreate(new SaveRequest<GenreRow>() { Entity = genre }).EntityId.ToString())
                        }
                    }));
                }
                catch (Exception e)
                {
                    e.Log();
                    SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                }

            }
            return genres;
        }
    }
}