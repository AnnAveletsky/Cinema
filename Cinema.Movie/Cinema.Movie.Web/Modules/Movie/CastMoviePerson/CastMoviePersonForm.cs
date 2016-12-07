
namespace Cinema.Movie.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.CastMoviePerson")]
    [BasedOnRow(typeof(Entities.CastMoviePersonRow))]
    public class CastMoviePersonForm
    {
        public Int16 CastId { get; set; }
        public Int64 MovieId { get; set; }
        public Int64 PersonId { get; set; }
    }
}