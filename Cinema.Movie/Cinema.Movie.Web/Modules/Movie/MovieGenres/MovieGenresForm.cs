
namespace Cinema.Movie.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.MovieGenres")]
    [BasedOnRow(typeof(Entities.MovieGenresRow))]
    public class MovieGenresForm
    {
        public Int64 MovieId { get; set; }
        public Int16 GenreId { get; set; }
    }
}