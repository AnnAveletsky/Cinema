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
    using Movies = MovieController;
    using Casts = CastController;
    using System;

    [RoutePrefix("Movie/Person"), Route("{action=index}")]
    public class PersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Person/PersonIndex.cshtml");
        }
        public static ListResponse<PersonRow> List(ListRequest listRequest)
        {
            using (var connection = SqlConnections.NewFor<PersonRow>())
            {
                return new Persons().List(connection, listRequest);
            }
        }
        public static RetrieveResponse<PersonRow> Person(RetrieveRequest retrieveRequest)
        {
            RetrieveResponse<PersonRow> person = null;
            using (var connection = SqlConnections.NewFor<PersonRow>())
            {
                person= new Persons().Retrieve(connection, retrieveRequest);
            }
            person.Entity.CastList = Casts.List(
                new ListRequest()
                {
                    IncludeColumns = new HashSet<string> { "MovieId" },

                    Criteria = new Criteria("PersonId") == person.Entity.PersonId.Value,
                }).Entities;
            person.Entity.CastSortList = new SortedList<string, ListResponse<MovieRow>>();
            foreach (var i in person.Entity.CastList)
            {
                if (!person.Entity.CastSortList.Keys.Contains(i.CharacterEn)|| person.Entity.CastSortList[i.CharacterEn].Entities==null)
                {
                    person.Entity.CastSortList.Add(i.CharacterEn, new ListResponse<MovieRow>() { Entities = new List<MovieRow>() });
                }
                if (person.Entity.CastSortList[i.CharacterEn].Entities.Find(k => k.MovieId == i.MovieId) == null)
                {
                    person.Entity.CastSortList[i.CharacterEn].Entities.Add(Movies.Movie(new RetrieveRequest() { EntityId = i.MovieId,
                        ExcludeColumns = new HashSet<string>() { "Description", "ReleaseWorldDate", "ReleaseOtherDate", "ReleaseDvd", "Runtime", "CreateDateTime", "PublishDateTime", "Mpaa", "Nice", "ContSeason", "Tagline", "Budget", "GenreList", "GenreListName", "TagList", "TagListName", "UpdateDateTime" }
                    }));
                }
            }
            return person;
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