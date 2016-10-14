
namespace Cinema.Movie.Movie.Columns
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
        public Int16 MovieId { get; set; }
        [EditLink]
        public String TitleEn { get; set; }
        public String TitleOther { get; set; }
        public String Description { get; set; }
        public String Storyline { get; set; }
        public Int16 YearStart { get; set; }
        public Int16 YearEnd { get; set; }
        public DateTime ReleaseWorldDate { get; set; }
        public DateTime ReleaseOtherDate { get; set; }
        public DateTime ReleaseDvd { get; set; }
        public Int16 Runtime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Int16 Kind { get; set; }
        public Int16 Rating { get; set; }
        public String Mpaa { get; set; }
        public Int16 ContSuffrage { get; set; }
        public String PathImage { get; set; }
        public String PathMiniImage { get; set; }
        public Boolean Nice { get; set; }
        public Int16 ContSeason { get; set; }
        public String LastEvent { get; set; }
        public DateTime LastEventPublishDateTime { get; set; }
    }
}