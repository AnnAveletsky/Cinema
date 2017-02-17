
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.MovieCountry")]
    [BasedOnRow(typeof(Entities.MovieCountryRow))]
    public class MovieCountryColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 MovieCountryId { get; set; }
        public Int64 MovieId { get; set; }
        public Int32 CountryId { get; set; }
    }
}