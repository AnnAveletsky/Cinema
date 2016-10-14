
namespace Cinema.Movie.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Tag")]
    [BasedOnRow(typeof(Entities.TagRow))]
    public class TagForm
    {
        public String Name { get; set; }
    }
}