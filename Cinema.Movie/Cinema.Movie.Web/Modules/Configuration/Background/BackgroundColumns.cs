
namespace Cinema.Movie.Configuration.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configuration.Background")]
    [BasedOnRow(typeof(Entities.BackgroundRow))]
    public class BackgroundColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 BackgroundId { get; set; }
        [EditLink]
        public String Color { get; set; }
        public String Path { get; set; }
        public String Size { get; set; }
    }
}