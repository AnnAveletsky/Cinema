
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Site")]
    [BasedOnRow(typeof(Entities.SiteRow))]
    public class SiteColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 SiteId { get; set; }
        [EditLink]
        public String Name { get; set; }
        public String Url { get; set; }
        public String Title { get; set; }
        public String Background { get; set; }
        public String Logo { get; set; }
        public String Color { get; set; }
        public Int32 DataBaseId { get; set; }
    }
}