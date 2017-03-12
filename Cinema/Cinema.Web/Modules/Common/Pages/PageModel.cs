
using Cinema.Movie.Entities;
using Serenity.Services;

namespace Cinema.Common
{
    public class PageModel
    {
        public ListResponse<GenreRow> Genres { get; set; }
        public RetrieveResponse<MovieRow> Movie { get; set; }
        public ListResponse<MovieRow> Movies { get; set; }
        public ListResponse<MovieRow> PopularMovies { get; set; }
        public ListResponse<MovieRow> NewSeries { get; set; }
        public ListResponse<MovieRow> PopularSeries { get; set; }
        public ListResponse<MovieRow> SimilarMovies { get; set; }
        public ListResponse<MovieRow> SimilarSeries { get; set; }
        public RetrieveResponse<PersonRow> Person { get; set; }
        public ListResponse<PersonRow> Persons { get; set; }

    }
    public enum TypePage
    {
        Movie=0,
        Movies=1,
        Admin=2
    }
}