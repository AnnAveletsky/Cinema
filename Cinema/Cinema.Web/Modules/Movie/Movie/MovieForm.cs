
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Movie")]
    [BasedOnRow(typeof(Entities.MovieRow))]
    public class MovieForm
    {
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
        public Int16 ContSeason { get; set; }
        public String Tagline { get; set; }
        public Decimal Budget { get; set; }
    }
}