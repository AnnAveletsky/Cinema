
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.MovieGenre")]
    [BasedOnRow(typeof(Entities.MovieGenreRow))]
    public class MovieGenreForm
    {
        public Int64 MovieId { get; set; }
        public Int32 GenreId { get; set; }
    }
}