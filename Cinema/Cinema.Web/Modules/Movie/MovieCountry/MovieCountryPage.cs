
namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using Repository = Repositories.MovieCountryRepository;
    using MyRow = Entities.MovieCountryRow;
    using System.Web.Mvc;
    using Serenity.Services;
    using Serenity.Data;
    using Common.Init;
    using Entities;
    using System;

    [RoutePrefix("Movie/MovieCountry"), Route("{action=index}")]
    public class MovieCountryController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/MovieCountry/MovieCountryIndex.cshtml");
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
        public static ListResponse<SaveResponse> UpdateCreate(MovieJson json, RetrieveResponse<MovieRow> movie)
        {
            var countries = new ListResponse<SaveResponse>() { Entities = new System.Collections.Generic.List<SaveResponse>() };

            foreach (var country in json.ToCountries())
            {
                try
                {
                    countries.Entities.Add(MovieCountryController.UpdateCreate(new SaveRequest<MovieCountryRow>()
                    {
                        Entity = new MovieCountryRow()
                        {
                            MovieId = movie.Entity.MovieId,
                            CountryId = Int32.Parse(CountryController.UpdateCreate(new SaveRequest<CountryRow>()
                            {
                                Entity = country
                            }).EntityId.ToString())
                        }
                    }));
                }
                catch (Exception e)
                {
                    e.Log();
                    SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                }
            }
            return countries;
        }
    }
}