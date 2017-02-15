
namespace Cinema.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.Person")]
    [BasedOnRow(typeof(Entities.PersonRow))]
    public class PersonForm
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public String FullName { get; set; }
        public String NameOther { get; set; }
        public String FullNameOther { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public Int16 Gender { get; set; }
        public String About { get; set; }
        public String PathImage { get; set; }
    }
}