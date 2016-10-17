
namespace Cinema.Movie.Common.Pages
{

    using Movie;
    using Movie.Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Web.Mvc;
    using System.Web.Security;

    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {
        DashboardPageModel cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                GenreRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    using (var connection = SqlConnections.NewFor<GenreRow>())
                    {
                        model.Genres = connection.List<GenreRow>();
                    }
                    model.Widgets = new System.Collections.Generic.SortedList<string, string>();
                    return model;
                });
        [HttpGet, Route("~/")]
        public ActionResult Index(int? page)
        {
            if (!cachedModel.Widgets.Keys.Contains("Dashboard/Dashboard"))
            {
                cachedModel.Widgets.Add("Dashboard/Dashboard", LocalText.Get("Site.Widget.Slider"));
            }
            cachedModel.Content = LocalText.Get("Site.Dashboard.HTMLDashboard");
            ViewData["Title"] = "";
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Dashboard";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/catalog-films")]
        public ActionResult CatalogFilms(string begin)
        {
            if (!cachedModel.Widgets.Keys.Contains("Dashboard/CatalogFilms"))
            {
                cachedModel.Widgets.Add("Dashboard/CatalogFilms", LocalText.Get("Site.Widget.Catalog"));
            }
            cachedModel.Content = LocalText.Get("Site.Dashboard.HTMLCatalogFilms");
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/CatalogFilms");
            ViewData["Footer"] = "";
            ViewData["PageId"] = LocalText.Get("Navigation.Dashboard/CatalogFilms");
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/top")]
        public ActionResult Top()
        {
            cachedModel.Content = LocalText.Get("Site.Dashboard.HTMLTop");
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/Top");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Top";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/faq")]
        public ActionResult FAQ()
        {
            cachedModel.Content = LocalText.Get("Site.Dashboard.HTMLFAQ");
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/FAQ");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/FAQ";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/contacts")]
        public ActionResult Contacts()
        {
            cachedModel.Content = LocalText.Get("Site.Dashboard.HTMLContacts");
            ViewData["Title"] = LocalText.Get("Navigation.Dashboard/Contacts");
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Contacts";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
    }
}