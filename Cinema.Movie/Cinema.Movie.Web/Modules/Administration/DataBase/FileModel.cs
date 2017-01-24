using Cinema.Movie.Movie;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace Cinema.Movie.Modules.Administration.DataBase
{
    public class FileModel
    {
        public string Name { get; set; }
        public MovieKind MovieKind { get; set; }
        public string Service { get; set; }
    }
    public class FilesModel
    {
        public List<FileModel> files = new List<FileModel>();
        public FilesModel()
        {
            if (files.Count == 0)
            {
                files.Add(new FileModel() { Name = Path.Combine(HostingEnvironment.MapPath("~/App_Data/films.json")), MovieKind = MovieKind.Film, Service = "Kodik" });
                files.Add(new FileModel() { Name = Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials.json")), MovieKind = MovieKind.TvSeries, Service = "Kodik" });
                files.Add(new FileModel() { Name = "http://getmovie.cc/get/movies.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "http://getmovie.cc/get/movies-russian.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "http://getmovie.cc/get/movies-anime.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "http://getmovie.cc/get/serials.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "http://getmovie.cc/get/serials-russian.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "http://getmovie.cc/get/serials-anime.xml", Service = "GetMovieCC" });
            }
        }
    }
}