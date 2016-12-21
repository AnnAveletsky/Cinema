using Cinema.Movie.Movie;
using System.Collections.Generic;

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
                files.Add(new FileModel() { Name = "films.json", MovieKind = MovieKind.Film, Service = "Kodik" });
                files.Add(new FileModel() { Name = "serials.json", MovieKind = MovieKind.TvSeries, Service = "Kodik" });
                files.Add(new FileModel() { Name = "movies-word.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "movies-russian.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "movies-anime.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "serials-word.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "serials-russian.xml", Service = "GetMovieCC" });
                files.Add(new FileModel() { Name = "serials-anime.xml", Service = "GetMovieCC" });
            }
        }
    }
}