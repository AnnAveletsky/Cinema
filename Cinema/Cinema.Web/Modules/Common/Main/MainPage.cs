
namespace Cinema.Common.Pages
{
    using Serenity;
    using System;
    using System.Web.Mvc;

    [RoutePrefix("Main"), Route("{action=index}")]
    public class MainController : Controller
    {
        PageModel model = new PageModel();
        [HttpGet, Route("~/")]
        public ActionResult Index(int count = 10, int page = 1, string movie = "", string year1 = "", string year2 = "", string year3 = "")
        {
            model.Movies = PageController.GetPageMovies(count, page, movie, year1, year2, year3);
            model.Genres = PageController.GetPageGenres();
            ViewData["Page"] = page;
            ViewData["Count"] = count;
            ViewData["Url"] = (movie != "" ? "&&movie=" : "") + movie + (year1 != "" ? "&&year1=" + year1 : "") + (year2 != "" ? "&&year2=" + year2 : "") + (year3 != "" ? "&&year3=" + year3 : "");
            ViewData["Title"] = LocalText.Get("Site.Dashboard.ResultSearch");
            ViewData["Footer"] = "";
            ViewData["TypePage"] = TypePage.Movies;
            return View(MVC.Views.Common.Pages.Index, model);
        }

        [HttpGet, Route("~/movies/{movie}")]
        public ActionResult Movie(Int64? id, string movie = "")
        {
            if (id != null&& movie != "")
            {
                model.Genres = PageController.GetPageGenres();
                model.Movie = PageController.GetPageMovie(id, movie);
                if (model.Movie == null)
                {
                    return HttpNotFound();
                }
                PageController.SetPageMovie(model.Movie);
                ViewData["Title"] = LocalText.Get("Site.Dashboard.ResultSearch");
                ViewData["TypePage"] = TypePage.Movie;
            }
            else
            {
                return HttpNotFound();
            }
            return View(MVC.Views.Common.Pages.Index, model);
        }
    }
}
