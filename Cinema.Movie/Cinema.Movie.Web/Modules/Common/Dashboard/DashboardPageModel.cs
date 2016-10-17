
using Cinema.Movie.Movie.Entities;
using System.Collections.Generic;

namespace Cinema.Movie.Common
{
    public class DashboardPageModel
    {
        public List<GenreRow> Genres { get; set; }

        public string Html { get; set; }

        public List<MovieRow> Movies { get; set; }
    }
}