
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.History")]
    [BasedOnRow(typeof(Entities.HistoryRow))]
    public class HistoryColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 HistoryId { get; set; }
        [EditLink]
        public String UserName { get; set; }
        public DateTime? EventDataTime { get; set; }
        public String Message { get; set; }
        public Boolean Status { get; set; }
        public Int64 CastId { get; set; }
        public Int32 CountryId { get; set; }
        public Int16 GenreId { get; set; }
        public Int16 ServiceId { get; set; }
        public Int64 MovieId { get; set; }
        public Int64 PersonId { get; set; }
        public Int64 ImageId { get; set; }
        public Int64 MovieCountryId { get; set; }
        public Int32 ServicePathId { get; set; }
        public Int64 ServiceRatingId { get; set; }
        public Int64 MovieTagId { get; set; }
        public Int64 TagId { get; set; }
        public Int64 VideoId { get; set; }
        public Int64 MovieGenreId { get; set; }
    }
}