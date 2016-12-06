using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cinema.Movie.Administration
{
    public partial class DataBaseEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Cinema.Movie.Administration.DataBaseEditor";

        public DataBaseEditorAttribute()
            : base(Key)
        {
        }
    }
}

