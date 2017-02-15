
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Image")]
    [BasedOnRow(typeof(Entities.ImageRow))]
    public class ImageColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 ImageId { get; set; }
        [EditLink]
        public String Path { get; set; }
        public Int64 MovieId { get; set; }
        public Int64 PersonId { get; set; }
    }
}