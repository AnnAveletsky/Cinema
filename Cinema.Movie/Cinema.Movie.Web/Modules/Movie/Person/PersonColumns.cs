
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Person")]
    [BasedOnRow(typeof(Entities.PersonRow))]
    public class PersonColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 PersonId { get; set; }
        [EditLink]
        public String FirstNameEn { get; set; }
        public String MiddleNameEn { get; set; }
        public String LastNameEn { get; set; }
        public String FirstNameOther { get; set; }
        public String MiddleNameOther { get; set; }
        public String LastNameOther { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public String BirthPlace { get; set; }
        public Int16 Gender { get; set; }
        public String About { get; set; }
        public String PathImage { get; set; }
    }
}