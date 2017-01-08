
using Cinema.Movie.Movie.Entities;
using Serenity.Services;
using System.Collections.Generic;

namespace Cinema.Movie.Common
{
    public class DashboardPageModel
    {
        public List<GenreRow> Genres { get; set; }
        public string Content { get; set; }
        public MovieRow Movie{ get; set; }
        public ListResponse<MovieRow> Movies { get; set; }
        public PersonRow Person{ get; set; }
        public ListResponse<PersonRow> Persons{ get; set; }
}
}