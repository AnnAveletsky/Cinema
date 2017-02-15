
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.ServicePath")]
    [BasedOnRow(typeof(Entities.ServicePathRow))]
    public class ServicePathColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ServicePathId { get; set; }
        [EditLink]
        public String Path { get; set; }
        public Int32 ServiceId { get; set; }
    }
}