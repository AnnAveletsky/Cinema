
namespace Cinema.Administration.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Administration.Site")]
    [BasedOnRow(typeof(Entities.SiteRow))]
    public class SiteForm
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public String Title { get; set; }
        public String Background { get; set; }
        public String Logo { get; set; }
        public String Color { get; set; }
        public Int32 DataBaseId { get; set; }
    }
}