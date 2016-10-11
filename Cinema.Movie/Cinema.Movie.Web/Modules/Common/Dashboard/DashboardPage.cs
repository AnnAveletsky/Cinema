
namespace Cinema.Movie.Common.Pages
{
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
            var cachedModel = new DashboardPageModel()
            {
            };

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
    }
}