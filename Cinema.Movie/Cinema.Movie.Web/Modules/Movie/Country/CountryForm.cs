
namespace Cinema.Movie.Movie.Forms
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
    }
}