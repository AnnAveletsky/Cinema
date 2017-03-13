

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Movie/Person", typeof(Cinema.Movie.Pages.PersonController))]

namespace Cinema.Movie.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Repository = Repositories.PersonRepository;
    using MyRow = Entities.PersonRow;
    using Serenity.Services;
    using Serenity.Data;
    using Entities;
    using Common.Init;
    using System;

    [RoutePrefix("Movie/Person"), Route("{action=index}")]
    public class PersonController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Person/PersonIndex.cshtml");
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
            var persons = new ListResponse<SaveResponse>();
            persons.Entities = new System.Collections.Generic.List<SaveResponse>();
            try
            {
                foreach (var person in json.ToPersons())
                {
                    persons.Entities.Add(UpdateCreate(new SaveRequest<MyRow>() { Entity = person }));
                    try
                    {
                        foreach (var cast in json.ToCast(movie, person))
                        {
                            CastController.UpdateCreate(new SaveRequest<CastRow>() { Entity = cast });
                        }
                    }
                    catch (Exception e)
                    {
                        e.Log();
                        SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
                    }
                }
            }
            catch (Exception e)
            {
                e.Log();
                SqlErrorStore.Setup(SqlErrorStore.ApplicationName, StackExchange.Exceptional.ErrorStore.Default);
            }
            return persons;
        }
    }
}