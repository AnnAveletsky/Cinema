using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cinema.Administration
{
    public partial class SiteEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Cinema.Administration.SiteEditor";

        public SiteEditorAttribute()
            : base(Key)
        {
        }
    }
}

