
namespace Cinema.Movie.Common.Pages
{
    using Modules.Common.Navigation;
    using Movie.Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Movies = Movie.Pages.MovieController;

    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {
        private DashboardPageModel model = new DashboardPageModel() { Genres = Genres() };
        

        private static List<GenreRow> Genres()
        {
            return TwoLevelCache.GetLocalStoreOnly("Genres", TimeSpan.FromMinutes(200),
              GenreRow.Fields.GenerationKey, () =>
              {
                  using (var connection = SqlConnections.NewFor<GenreRow>())
                  {
                      return connection.List<GenreRow>();
                  }
              });
        }
        
        [HttpGet, Route("~/")]
        public ActionResult Index(int count=10,int page=1,string genre="")
        {
            model.Content = TwoLevelCache.GetLocalStoreOnly("Dashboard/Dashboard", TimeSpan.FromMinutes(200),
            GenreRow.Fields.GenerationKey, () =>
            {
                return LocalText.Get("Site.Dashboard.HTMLDashboard");
            });
            //BaseCriteria criteria = new Criteria("c").StartsWith("S");
            model.Movies = Movies.Page(new ListRequest
            {
                //Criteria = criteria,
                Skip = (page - 1) * count,
                Take = count
            });
            ViewData["MaxRating"] = 10;
            ViewData["Title"] = "";
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Dashboard";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }
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

        [HttpGet, Route("~/movie")]
        public ActionResult Movie(Int64? id,string name="")
        {
            if (id != null)
            {
                model.Content = "";
                var ExcludeColumns = new HashSet<string>();
                ExcludeColumns.Add("GenreList");
                model.Movie = Movies.Movie(new RetrieveRequest() { EntityId=(Int64)id, ExcludeColumns= ExcludeColumns});
                ViewData["MaxRating"] = 10;
                ViewData["Title"] = "";
                ViewData["Footer"] = "";
                ViewData["PageId"] = "Dashboard/Movie";
                return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
            }else
            {
                return HttpNotFound();
            }
        }

    }
}