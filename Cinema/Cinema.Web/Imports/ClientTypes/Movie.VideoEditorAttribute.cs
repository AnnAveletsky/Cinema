using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cinema.Movie
{
    public partial class VideoEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Cinema.Movie.VideoEditor";

        public VideoEditorAttribute()
            : base(Key)
        {
        }
    }
}

