
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.MovieGenres")]
    [BasedOnRow(typeof(Entities.MovieGenresRow))]
    public class MovieGenresColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 MovieGenreId { get; set; }
        public Int64 MovieId { get; set; }
        public Int16 GenreId { get; set; }
    }
}