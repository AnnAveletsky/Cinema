

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/MovieCountry", typeof(Cinema.Movie.Movie.Pages.MovieCountryController))]

namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Web.Mvc;
    using MovieCountries = Repositories.MovieCountryRepository;
    using Histories = HistoryController;
    using System;

    [RoutePrefix("Movie/MovieCountry"), Route("{action=index}")]
    public class MovieCountryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieCountry/MovieCountryIndex.cshtml");
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<MovieCountryRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<MovieCountryRow>())
            {
                var genre = new MovieCountries().List(connection,
                    new ListRequest()).Entities.Find(i => i.CountryId == request.Entity.CountryId && i.MovieId == request.Entity.MovieId);
                if (genre != null)
                {
                    return new SaveResponse()
                    {
                        EntityId = genre.MovieCountryId
                    };
                }
            }
            using (var connection = SqlConnections.NewFor<MovieCountryRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new MovieCountries().Create(uow, request);
                uow.Commit();
            }
            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add MovieCountry",
                    UserName = Authorization.Username,
                    MovieCountryId = Int64.Parse(result.EntityId.ToString()),
                }
            });
            return result;
        }
    }
}