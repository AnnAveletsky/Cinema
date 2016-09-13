
namespace Admin.MovieDB.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("MovieDB.Person")]
    [BasedOnRow(typeof(Entities.PersonRow))]
    public class PersonColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 PersonId { get; set; }
        [EditLink]
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public String BirthPlace { get; set; }
        public Gender Gender { get; set; }
        public Int32 Height { get; set; }
    }
}