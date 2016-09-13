
namespace Admin.MovieDB.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("MovieDB.MovieCast")]
    [BasedOnRow(typeof(Entities.MovieCastRow))]
    public class MovieCastForm
    {
        [LookupEditor(typeof(Entities.PersonRow))]
        public Int32 PersonId { get; set; }
        public String Character { get; set; }
    }
}