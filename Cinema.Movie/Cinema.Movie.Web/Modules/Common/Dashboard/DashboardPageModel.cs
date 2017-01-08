
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
        public ListResponse<MovieRow> PopularMovies { get; set; }
        public ListResponse<MovieRow> NewSeries { get; set; }
        public ListResponse<MovieRow> PopularSeries { get; set; }
        public ListResponse<MovieRow> SimilarMovies { get; set; }
        public ListResponse<MovieRow> SimilarSeries { get; set; }
        public PersonRow Person{ get; set; }
        public ListResponse<PersonRow> Persons{ get; set; }
}
}