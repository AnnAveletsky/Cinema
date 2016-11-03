
namespace Cinema.Movie.Configuration.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configuration.Background")]
    [BasedOnRow(typeof(Entities.BackgroundRow))]
    public class BackgroundForm
    {
        public String Color { get; set; }
        public String Path { get; set; }
        public String Size { get; set; }
    }
}