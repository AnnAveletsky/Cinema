
namespace Cinema.Movie.Configuration.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configuration.Settings")]
    [BasedOnRow(typeof(Entities.SettingsRow))]
    public class SettingsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 SettingId { get; set; }
        [EditLink]
        public String Setting { get; set; }
        public String Value { get; set; }
        public String Type { get; set; }
    }
}