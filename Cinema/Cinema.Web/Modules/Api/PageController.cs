using Cinema.Common.Pages;
using System.Web.Mvc;
using Serenity;
using System.Web.Http;
using System.Web.Http.Cors;
using Serenity.Services;
using Cinema.Movie.Entities;
using Cinema.Administration.Entities;

namespace Cinema.Modules.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class PageController : ApiController
    {
        public class Page
        {
            public SiteRow Site { get; set; }
            public ListResponse<GenreRow> Genres { get; set; }
            public ListResponse<MovieRow> Movies { get; set; }
        }
        public object GetSite()
        {
            return  new Page
            {
                Genres= Common.Pages.PageController.GetPageGenres(),
                Movies= Common.Pages.PageController.GetPageMovies()
            };
        }
    }
}
