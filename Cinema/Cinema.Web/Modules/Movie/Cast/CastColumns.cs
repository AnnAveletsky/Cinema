
namespace Cinema.Movie.Columns
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
        public String CharacterEn { get; set; }
        public String CharacterOther { get; set; }
        public Int64 MovieId { get; set; }
        public Int64 PersonId { get; set; }
    }
}