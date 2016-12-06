﻿
namespace Cinema.Movie.Movie.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Movie.Cast")]
    [BasedOnRow(typeof(Entities.CastRow))]
    public class CastColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int16 CastId { get; set; }
        [EditLink]
        public String Character { get; set; }
    }
}