
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Service")]
    [BasedOnRow(typeof(Entities.ServiceRow))]
    public class ServiceColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 ServiceId { get; set; }
        [EditLink]
        public String Name { get; set; }
        public String Api { get; set; }
        public String Url { get; set; }
        public Boolean Active { get; set; }
        public Int32 IntervalRequest { get; set; }
        public Int16 MaxRating { get; set; }
        public List<Int16> PathList { get; set; }
        public List<string> PathListPath { get; set; }
    }
}