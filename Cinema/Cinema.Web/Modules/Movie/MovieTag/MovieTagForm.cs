
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.MovieTag")]
    [BasedOnRow(typeof(Entities.MovieTagRow))]
    public class MovieTagForm
    {
        public Int64 TagId { get; set; }
        public Int64 MovieId { get; set; }
    }
}