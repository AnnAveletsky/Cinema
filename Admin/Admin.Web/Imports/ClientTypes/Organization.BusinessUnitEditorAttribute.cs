using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Admin.Organization
{
    public partial class BusinessUnitEditorAttribute : LookupEditorBaseAttribute
    {
        public const string Key = "Admin.Organization.BusinessUnitEditor";

        public BusinessUnitEditorAttribute()
            : base(Key)
        {
        }
    }
}

