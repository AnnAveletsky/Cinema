
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.MovieCountry")]
    [BasedOnRow(typeof(Entities.MovieCountryRow))]
    public class MovieCountryForm
    {
        public Int64 MovieId { get; set; }
        public Int32 CountryId { get; set; }
    }
}