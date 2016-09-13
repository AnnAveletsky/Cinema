
namespace Admin.MovieDB.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("MovieDB.MovieCast")]
    [BasedOnRow(typeof(Entities.MovieCastRow))]
    public class MovieCastColumns
    {
        [EditLink, Width(220)]
        public String PersonFullname { get; set; }
        [EditLink, Width(150)]
        public String Character { get; set; }
    }
}