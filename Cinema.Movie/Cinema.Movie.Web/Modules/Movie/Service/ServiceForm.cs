
namespace Cinema.Movie.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Service")]
    [BasedOnRow(typeof(Entities.ServiceRow))]
    public class ServiceForm
    {
        public String Name { get; set; }
        public String Api { get; set; }
        public Int16 MaxRating { get; set; }
    }
}