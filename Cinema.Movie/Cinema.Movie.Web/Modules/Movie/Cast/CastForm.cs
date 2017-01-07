
namespace Cinema.Movie.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Cast")]
    [BasedOnRow(typeof(Entities.CastRow))]
    public class CastForm
    {
        public String CharacterEn { get; set; }
        public String CharacterOther { get; set; }
        public Int64 MovieId { get; set; }
        public Int64 PersonId { get; set; }
    }
}