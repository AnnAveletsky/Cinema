
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.ServiceRating")]
    [BasedOnRow(typeof(Entities.ServiceRatingRow))]
    public class ServiceRatingColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 ServiceRatingId { get; set; }
        public Double Rating { get; set; }
        public Int64 Id { get; set; }
        public Int64 MovieId { get; set; }
        public Int32 ServiceId { get; set; }
    }
}