using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cinema.Movie
{
    public partial class TagEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Cinema.Movie.TagEditor";

        public TagEditorAttribute()
            : base(Key)
        {
        }
    }
}

