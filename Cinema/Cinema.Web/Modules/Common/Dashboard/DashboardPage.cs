﻿
namespace Cinema.Common.Pages
{
    using Northwind;
    using Northwind.Entities;
    using Serenity;
    using Serenity.Data;
    using System;
    using System.Web.Mvc;
    using Movies = Movie.Repositories.MovieRepository;
    using Genres = Movie.Repositories.GenreRepository;
    using Persons = Movie.Repositories.PersonRepository;
    using Serenity.Services;
    using Movie.Entities;
    using System.Collections.Generic;
    using Movie.Pages;

    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {

        [Authorize, HttpGet, Route("~/")]
        public ActionResult Index(int count = 10, int page = 1, string movie = "", string year1 = "", string year2 = "", string year3 = "")
        {
            var lr = new ListRequest
            {
                Skip = (page - 1) * count,
                Take = count,
                Sort = new[] {
                    new SortBy("UpdateDateTime", true),
                    new SortBy("PublishDateTime", true),
                    new SortBy("Rating", true),
                    new SortBy("TitleOriginal"),
                    new SortBy("TitleTranslation") }
            };
            if (year1 != "" || year2 != "" || year3 != "" || movie != "")
            {
                lr.Criteria = null;
                int y1 = 0, y2 = 0, y3 = 0;
                List<int> list = new List<int>();
                int.TryParse(year1, out y1);
                int.TryParse(year2, out y2);
                int.TryParse(year3, out y3);
                if (y1 != 0)
                {
                    list.Add(y1);
                }
                if (y2 != 0)
                {
                    list.Add(y2);
                }
                if (y3 != 0)
                {
                    list.Add(y3);
                }
                if (list.Count != 0)
                {
                    lr.Criteria = new Criteria("YearStart").In(list.ToArray()) || new Criteria("YearEnd").In(list.ToArray());
                    if (movie != "")
                    {
                        lr.Criteria = lr.Criteria && (new Criteria("TitleOriginal").Contains(movie) || new Criteria("TitleTranslation").Contains(movie));
                    }
                }
                else if (movie != "" && list.Count == 0)
                {
                    lr.Criteria = new Criteria("TitleOriginal").Contains(movie) || new Criteria("TitleTranslation").Contains(movie);
                }
                ViewData["Title"] = LocalText.Get("Site.Dashboard.ResultSearch") + " " + movie + " " + (y1 != 0 ? " " + y1 : "") + (y2 != 0 ? " " + y2 : "") + (y3 != 0 ? " " + y3 : "");
                ViewData["Url"] = (movie != "" ? "&&movie=" : "") + movie + (year1 != "" ? "&&year1=" + year1 : "") + (year2 != "" ? "&&year2=" + year2 : "") + (year3 != "" ? "&&year3=" + year3 : "");
            }
            else
            {
                ViewData["Title"] = "";
            }
            var model = new DashboardPageModel();
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("Movie_" + count + "_" + page + "_" + year1 + "_" + year2 + "_" + year3, TimeSpan.FromMinutes(5),
                MovieRow.Fields.GenerationKey, () =>
                {
                    model.Movies = MovieController.List(lr);
                    return model;
                });
            ViewData["Page"] = page;
            ViewData["Count"] = count;
            ViewData["MaxRating"] = 10;
            ViewData["Footer"] = "";
            ViewData["PageId"] = "Dashboard/Dashboard";
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }

        [HttpGet, Route("~/movies/{movie}")]
        public ActionResult Movie(Int64? id, string movie = "")
        {
            var model = new DashboardPageModel();
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("Movie_" + id + "_" + movie, TimeSpan.FromMinutes(5), MovieRow.Fields.GenerationKey, () =>
             {
                 if (id != null)
                 {
                     model.Movie = MovieController.Retrieve(new RetrieveRequest()
                     {
                         EntityId = (Int64)id
                     });
                 }
                 else if (movie != "")
                 {

                     model.Movie = MovieController.Find(new ListRequest()
                     {
                         Criteria = MovieController.Criteria(new SaveRequest<MovieRow>() { Entity = new MovieRow() { Url = movie } })
                     });
                 }
                 return model;
             });
            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
    }
}
