
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Video")]
    [BasedOnRow(typeof(Entities.VideoRow))]
    public class VideoForm
    {
        public String Path { get; set; }
        public Int16 Player { get; set; }
        public String PathTorrent { get; set; }
        public String Name { get; set; }
        public Int16 Translation { get; set; }
        public Int16 Season { get; set; }
        public Int16 Serie { get; set; }
        public String Image { get; set; }
        public String Title { get; set; }
        public String Storyline { get; set; }
        public DateTime PlannePublishDate { get; set; }
        public DateTime ActualPublishDateTime { get; set; }
        public Int64 MovieId { get; set; }
        public Int32 ServiceId { get; set; }
    }
}