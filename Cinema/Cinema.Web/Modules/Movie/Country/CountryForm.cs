
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Country")]
    [BasedOnRow(typeof(Entities.CountryRow))]
    public class CountryForm
    {
        public String Name { get; set; }
        public String NameOther { get; set; }
        public String Code { get; set; }
        public String Icon { get; set; }
    }
}