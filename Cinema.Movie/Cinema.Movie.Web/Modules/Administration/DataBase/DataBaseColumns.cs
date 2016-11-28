
namespace Cinema.Movie.Administration.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Administration.DataBase")]
    [BasedOnRow(typeof(Entities.DataBaseRow))]
    public class DataBaseColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 DbId { get; set; }
        [EditLink]
        public String Name { get; set; }
        public String ConnectionString { get; set; }
        public String ProviderName { get; set; }
        public Boolean Active { get; set; }
        public String TagDataBaseMovie { get; set; }
    }
}