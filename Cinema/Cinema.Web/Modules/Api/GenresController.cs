using Cinema.Common.Pages;
using System.Web.Mvc;
using Serenity;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cinema.Modules.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class GenresController : ApiController
    {
        public object GetGenres()
        {
            return Common.Pages.PageController.GetPageGenres();
        }
    }
}
