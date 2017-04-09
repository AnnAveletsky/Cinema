using Cinema.Common.Pages;
using System.Web.Mvc;
using Serenity;
using System.Web.Http;
using System.Web.Http.Cors;
using Serenity.Services;
using Cinema.Movie.Entities;

namespace Cinema.Modules.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class SiteController : ApiController
    {
        public class Site
        {
            public string Config { get; set; }
            public ListResponse<GenreRow> Genres { get; set; }
            public ListResponse<MovieRow> Movies { get; set; }
        }
        public object GetSite()
        {
            return  new Site {
                Genres= PageController.GetPageGenres(),
                Movies=PageController.GetPageMovies()
            };
        }
    }
}
