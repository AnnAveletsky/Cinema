
namespace Cinema.Movie.Configuration.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configuration.Settings")]
    [BasedOnRow(typeof(Entities.SettingsRow))]
    public class SettingsForm
    {
        public String Setting { get; set; }
        public String Value { get; set; }
        public String Type { get; set; }
    }
}