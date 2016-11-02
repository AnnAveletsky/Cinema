
using Cinema.Movie.Movie.Entities;
using System;
using System.Collections.Generic;

namespace Cinema.Movie.Common
{
    public class DashboardPageModel
    {
        public List<GenreRow> Genres { get; set; }
        public SortedList<string,string> Widgets { get; set; }
        public string Content { get; set; }
        public MovieRow Movie{ get; set; }
        public List<MovieRow> Movies { get; set; }
    }
    public class Pagination
    {
        public string Genre { get; set; }
        public int Count { get; private set; }
        public int Page { get; private set; }
        public char? Begin { get; set; }
        public string Search { get; set; }

        public Pagination(int? count=10, int? page=1)
        {
            Count = count == null ? 10 : (int)count;
            Page= page == null ? 1 : (int)page;
        }
    }
}