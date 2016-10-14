
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Genre")]
    [BasedOnRow(typeof(Entities.GenreRow))]
    public class GenreColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 GenreId { get; set; }
        [EditLink]
        public String Name { get; set; }
    }
}