
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
        public Int16 MaxRating { get; set; }
    }
}