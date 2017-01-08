
namespace Cinema.Movie.Common.Pages
{
    using Movie.Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Movies = Movie.Pages.MovieController;
    using Genres = Movie.Pages.GenreController;
    using Persons = Movie.Pages.PersonController;

    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {
        private DashboardPageModel model = new DashboardPageModel() { Genres = Genres.List(new ListRequest()) };

        #region movie
        [HttpGet, Route("~/")]
        public ActionResult Index(int count=10,int page=1)
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("Dashboard/Dashboard", TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLDashboard");
            });
            model.Movies = Movies.Page(new ListRequest
            {
                Skip = (page - 1) * count,
                Take = count,
                Sort= new[] {new SortBy("PublishDateTime", true),
                    new SortBy("UpdateDateTime", true),
                    new SortBy("Rating"),
                    new SortBy("TitleOriginal"),
                    new SortBy("TitleTranslation") }
            });
            ViewData["Page"] = page;
            ViewData["Count"] = count;
            ViewData["MaxRating"] = 10;
            ViewData["Title"] = "";
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Dashboard";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        [HttpGet, Route("~/movies/{name}")]
        public ActionResult Movie(Int64? id, string name = "")
        {
            if (id != null)
            {
                model.Content = "";
                var ExcludeColumns = new HashSet<string>();
                ExcludeColumns.Add("GenreList");
                model.Movie = Movies.Movie(new RetrieveRequest() { EntityId = (Int64)id, ExcludeColumns = ExcludeColumns });
                ViewData["MaxRating"] = 10;
                ViewData["Title"] = "";
                ViewData["Footer"] = "";
                ViewData["PageId"] = "Dashboard/Movie";
                return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        #endregion
        #region pages
        [HttpGet, Route("~/catalog-films")]
        public ActionResult CatalogFilms(int count = 10, int page = 1)
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("Dashboard/CatalogFilms", TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLCatalogFilms");
            });
            model.Movies = Movies.Page(new ListRequest
            {
                Skip = (page - 1) * count,
                Take = count
            });
            ViewData["Page"] = page;
            ViewData["Count"] = count;
            ViewData["MaxRating"] = 10;
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/CatalogFilms");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/CatalogFilms";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        [HttpGet, Route("~/top")]
        public ActionResult Top(int count = 100, int page = 1)
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("Dashboard/Top", TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLTop");
            });
            model.Movies = Movies.Page(new ListRequest
            {
                Skip = (page - 1) * count,
                Take = count
            });
            ViewData["Page"] = page;
            ViewData["Count"] = count;
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/Top");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Top";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        [HttpGet, Route("~/faq")]
        public ActionResult FAQ()
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("Dashboard/FAQ", TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLFAQ");
            });
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/FAQ");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/FAQ";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        [HttpGet, Route("~/contacts")]
        public ActionResult Contacts()
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("Dashboard/Contacts", TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLContacts");
            });
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/Contacts");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Contacts";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        #endregion
        #region genre
        [HttpGet, Route("~/genres/{genre}")]
        public ActionResult Genre(int count = 10, int page = 1, string genre = "")
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("genres/"+genre, TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLDashboard");
            });
            if (genre != "")
            {
                BaseCriteria criteria = new Criteria("MovieId").In(model.Genres.Find(i => i.Name == genre).MovieList);
                model.Movies = Movies.Page(new ListRequest
                {
                    Criteria = criteria,
                    Skip = (page - 1) * count,
                    Take = count
                });
            }
            else
            {
                model.Movies = Movies.Page(new ListRequest
                {
                    Skip = (page - 1) * count,
                    Take = count
                });
            }
            ViewData["Page"] = page;
            ViewData["Count"] = count;
            ViewData["MaxRating"] = 10;
            ViewData["Title"] = "";
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Dashboard";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        #endregion
        #region persons
        [HttpGet, Route("~/persons/")]
        public ActionResult PersonsAction(int count = 10, int page = 1)
        {
            model.Persons = Persons.List(new ListRequest
            {
                Skip = (page - 1) * count,
                Take = count
            });
            ViewData["MaxRating"] = 10;
            ViewData["Title"] = "";
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Persons";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
        [HttpGet, Route("~/persons/{name}")]
        public ActionResult PersonAction(Int64? id, string name = "")
        {
            if (id != null)
            {
                model.Person = Persons.Person(new RetrieveRequest() { EntityId = (Int64)id }).Entity;
                ViewData["MaxRating"] = 10;
                ViewData["Title"] = "";
                ViewData["Footer"] = "";
                ViewData["PageId"] = "Dashboard/Persons/"+name;
                return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        #endregion
    }
}