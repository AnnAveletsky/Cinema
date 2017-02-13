
namespace Admin.Default.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Default.DataBase")]
    [BasedOnRow(typeof(Entities.DataBaseRow))]
    public class DataBaseColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 DataBaseId { get; set; }
        [EditLink]
        public String Name { get; set; }
        public String ConnectionString { get; set; }
        public String ProviderName { get; set; }
        public Boolean Active { get; set; }
        public String TagDataBaseMovie { get; set; }
        public String Type { get; set; }
    }
}