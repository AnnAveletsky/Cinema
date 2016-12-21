
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Tag")]
    [BasedOnRow(typeof(Entities.TagRow))]
    public class TagColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 TagId { get; set; }
        [EditLink]
        public String Name { get; set; }
    }
}