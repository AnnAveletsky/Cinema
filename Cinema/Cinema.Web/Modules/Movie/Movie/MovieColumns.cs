
namespace Cinema.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Movie")]
    [BasedOnRow(typeof(Entities.MovieRow))]
    public class MovieColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 MovieId { get; set; }
        [EditLink]
        public String TitleOriginal { get; set; }
        public String TitleTranslation { get; set; }
        public String Url { get; set; }
        public String[] Description { get; set; }
        public Int16 YearStart { get; set; }
        public Int16 YearEnd { get; set; }
        public DateTime ReleaseWorldDate { get; set; }
        public DateTime ReleaseOtherDate { get; set; }
        public DateTime ReleaseDvd { get; set; }
        public String Runtime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime PublishDateTime { get; set; }
        public MovieKind Kind { get; set; }
        public Int32 Rating { get; set; }
        public String Mpaa { get; set; }
        public String PathImage { get; set; }
        public Boolean Nice { get; set; }
        public Boolean Active { get; set; }
        public Int16 ContSeason { get; set; }
        public String Tagline { get; set; }
        public Decimal Budget { get; set; }
        public Int64 Views { get; set; }
    }
}