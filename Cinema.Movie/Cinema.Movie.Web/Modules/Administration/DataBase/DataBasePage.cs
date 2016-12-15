

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Administration/DataBase", typeof(Cinema.Movie.Administration.Pages.DataBaseController))]

namespace Cinema.Movie.Administration.Pages
{
    using Movie;
    using Movie.Entities;
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.IO;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using Videos = Movie.Pages.VideoController;
    using Movies = Movie.Pages.MovieController;
    using System.Collections.Generic;
    using Common.Init;

    [RoutePrefix("Administration/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
        [PageAuthorize("Administration")]
        public ActionResult Init()
        {
            InitJson(Path.Combine(HostingEnvironment.MapPath("~/App_Data/films.json")), MovieKind.Film);
            InitJson(Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials.json")), MovieKind.TvSeries);
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml");
        }
        

        public static bool InitJson(string Path, MovieKind movieKind)
        {
            //try
            //{
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            string line = file.ReadToEnd();
            MovieJson[] data = JsonConvert.DeserializeObject<MovieJson[]>(line);
            foreach (MovieJson item in data)
            {
                CreateMovieVideo(
                    new SaveRequest<MovieRow>() { Entity = item.ToMovie(movieKind) },
                    new SaveRequest<VideoRow>() { Entity = item.ToVideo() });
            }
            file.Close();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        public static SaveResponse CreateMovieVideo(SaveRequest<MovieRow> movie, SaveRequest<VideoRow> video)
        {
            SaveResponse response = Movies.Create(movie);
            video.Entity.MovieId = (Int64)response.EntityId;
            Videos.Create(video);
            return response;
        }
    }
}