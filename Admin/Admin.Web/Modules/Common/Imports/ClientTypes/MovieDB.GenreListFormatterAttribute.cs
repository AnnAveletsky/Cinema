using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Admin.MovieDB
{
    public partial class GenreListFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "Admin.MovieDB.GenreListFormatter";

        public GenreListFormatterAttribute()
            : base(Key)
        {
        }
    }
}

