namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Persons = Repositories.PersonRepository;

    [RoutePrefix("Movie/Person"), Route("{action=index}")]
    public class PersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Person/PersonIndex.cshtml");
        }
        public static List<PersonRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<PersonRow>())
            {
                return new Persons().List(connection, listRequest).Entities;
            }
        }
    }
}