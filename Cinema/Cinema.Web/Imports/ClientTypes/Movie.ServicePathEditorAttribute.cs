﻿using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cinema.Movie
{
    public partial class ServicePathEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Cinema.Movie.ServicePathEditor";

        public ServicePathEditorAttribute()
            : base(Key)
        {
        }
    }
}

