namespace Cinema.Movie.Administration.Pages
{
    using Movie;
    using Serenity.Web;
    using System;
    using System.Web.Mvc;
    using Common.Init;
    using Modules.Administration.DataBase;

    [RoutePrefix("Administration/DataBase"), Route("{action=index}")]
    public class DataBaseController : Controller
    {
        FilesModel model = new FilesModel();
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/DataBase/DataBaseIndex.cshtml",model);
        }

        [PageAuthorize("Administration")]
        public ActionResult Init(string name, string service)
        {
            StatusTask.TimeStart = DateTime.UtcNow;
            var file = model.files.Find(i => i.Name == name);
            if (service == "Kodik")
            {
                JsonObjectSerialization.InitKodik("~/App_Data/" + file.Name, MovieKind.Film);
            }
            else if (service == "GetMovieCC")
            {
                JsonObjectSerialization.InitGetMovieCC("~/App_Data/" + file.Name);
            }
            StatusTask.TimeEnd = DateTime.UtcNow;
            return View("~/Modules/Movie/History/HistoryIndex.cshtml");
        }
    }
}