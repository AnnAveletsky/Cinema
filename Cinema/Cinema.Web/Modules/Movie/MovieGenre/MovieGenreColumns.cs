
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.MovieGenre")]
    [BasedOnRow(typeof(Entities.MovieGenreRow))]
    public class MovieGenreColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 MovieGenreId { get; set; }
        public Int64 MovieId { get; set; }
        public Int32 GenreId { get; set; }
    }
}