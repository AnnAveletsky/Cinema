
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.MovieTag")]
    [BasedOnRow(typeof(Entities.MovieTagRow))]
    public class MovieTagColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 MovieTagId { get; set; }
        public Int64 TagId { get; set; }
        public Int64 MovieId { get; set; }
    }
}