using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Admin.MovieDB
{
    public partial class MovieCastEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Admin.MovieDB.MovieCastEditor";

        public MovieCastEditorAttribute()
            : base(Key)
        {
        }
    }
}

