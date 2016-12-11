
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Country")]
    [BasedOnRow(typeof(Entities.CountryRow))]
    public class CountryColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 CountryId { get; set; }
        [EditLink]
        public String Name { get; set; }
    }
}