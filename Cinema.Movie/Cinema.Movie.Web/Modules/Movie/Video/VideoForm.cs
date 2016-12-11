
namespace Cinema.Movie.Movie.Forms
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
        public String PathTorrent { get; set; }
        public String Name { get; set; }
        public Int16 Translation { get; set; }
        public Int16 Season { get; set; }
        public Int16 Serie { get; set; }
        public String Storyline { get; set; }
        public DateTime PlannePublishDate { get; set; }
        public DateTime ActualPublishDateTime { get; set; }
        public Int16 MovieId { get; set; }
        public Int16 ServiceId { get; set; }
    }
}