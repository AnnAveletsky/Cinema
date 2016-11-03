
namespace Cinema.Movie.Common.Pages
{
    using Movie.Entities;
    using Serenity;
    using Serenity.Data;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

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
        private static List<MovieRow> MoviesShot(Pagination pagination)
        {
            using (var connection = SqlConnections.NewFor<MovieRow>())
            {
                if(connection.Count<MovieRow>()< pagination.Count)
                {
                    return connection.List<MovieRow>();
                }
                return connection.List<MovieRow>(i => i.Skip((pagination.Page - 1) * pagination.Count).Take(pagination.Count));
            }
        }
        private static MovieRow MovieFull(int id)
        {
            return TwoLevelCache.GetLocalStoreOnly("Movie"+id, TimeSpan.FromMinutes(200),
              MovieRow.Fields.GenerationKey, () =>
              {
                  using (var connection = SqlConnections.NewFor<MovieRow>())
                  {
                      return connection.ById<MovieRow>(id);
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
            model.Movies = MoviesShot(new Pagination(count, page) { Genre = genre });
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
            model.Movies = MoviesShot(new Pagination(count, page));
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
            model.Movies = MoviesShot(new Pagination(count, page));
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
        public ActionResult Movie(int? id,string name="")
        {
            if (id != null)
            {
                model.Content = "";
                model.Movie = MovieFull((int)id);
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