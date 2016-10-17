
using Cinema.Movie.Movie.Entities;
using System.Collections.Generic;

namespace Cinema.Movie.Common
{
    public class DashboardPageModel
    {
        public List<GenreRow> Genres { get; set; }
        public SortedList<string,string> Widgets { get; set; }
        public string Content { get; set; }
    }
}