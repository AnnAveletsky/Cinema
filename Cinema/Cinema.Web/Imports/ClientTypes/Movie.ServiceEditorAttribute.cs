using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cinema.Movie
{
    public partial class ServiceEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Cinema.Movie.ServiceEditor";

        public ServiceEditorAttribute()
            : base(Key)
        {
        }
    }
}

