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
    using Histories = HistoryController;
    using System;

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
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<PersonRow> request)
        {
            SaveResponse result = null;
            using (var connection = SqlConnections.NewFor<PersonRow>())
            {
                var person = new Persons().List(connection, new ListRequest()).Entities.Find(i => i.Name == request.Entity.Name&&i.BirthDate==request.Entity.BirthDate);
                if (person != null)
                {
                    return new SaveResponse()
                    {
                        EntityId = person.PersonId
                    };
                }
            }
            using (var connection = SqlConnections.NewFor<PersonRow>())
            using (var uow = new UnitOfWork(connection))
            {
                result = new Persons().Create(uow, request);
                uow.Commit();
                connection.Close();
            }

            Histories.Create(new SaveRequest<HistoryRow>()
            {
                Entity = new HistoryRow()
                {
                    Status = true,
                    Message = "Add Person",
                    UserName = Authorization.Username,
                    PersonId = Int64.Parse(result.EntityId.ToString()),
                }
            });
            return result;
        }
    }
}