
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Cast")]
    [BasedOnRow(typeof(Entities.CastRow))]
    public class CastColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 CastId { get; set; }
        [EditLink]
        public String Character { get; set; }
        public Int64 MovieId { get; set; }
        [EditLink, Width(200)]
        public String MovieTitleEn { get; set; }
        public Int64 PersonId { get; set; }
        [EditLink, Width(200)]
        public String PersonNameEn { get; set; }
        public String PersonNameOther { get; set; }
    }
}