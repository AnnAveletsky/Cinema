
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
        [HttpGet, Route("~/")]
        public ActionResult Index()
        {
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                GenreRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    using (var connection = SqlConnections.NewFor<GenreRow>())
                    {
                        model.Genres = connection.List<GenreRow>();
                    }
                    return model;
                });

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/catalog-films")]
        public ActionResult CatalogFilms()
        {
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                GenreRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    using (var connection = SqlConnections.NewFor<GenreRow>())
                    {
                        model.Genres = connection.List<GenreRow>();
                    }
                    return model;
                });

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/top")]
        public ActionResult Top()
        {
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                GenreRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    using (var connection = SqlConnections.NewFor<GenreRow>())
                    {
                        model.Genres = connection.List<GenreRow>();
                    }
                    return model;
                });

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/faq")]
        public ActionResult FAQ()
        {
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                GenreRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    using (var connection = SqlConnections.NewFor<GenreRow>())
                    {
                        model.Genres = connection.List<GenreRow>();
                    }
                    return model;
                });

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
        [HttpGet, Route("~/contacts")]
        public ActionResult Contacts()
        {
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                GenreRow.Fields.GenerationKey, () =>
                {
                    var model = new DashboardPageModel();
                    using (var connection = SqlConnections.NewFor<GenreRow>())
                    {
                        model.Genres = connection.List<GenreRow>();
                    }
                    return model;
                });

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
    }
}