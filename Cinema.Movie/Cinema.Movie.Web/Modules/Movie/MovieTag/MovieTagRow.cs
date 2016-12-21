

namespace Cinema.Movie.Movie.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("MovieTag"), InstanceName("MovieTag"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class MovieTagRow : Row, IIdRow
    {
        [DisplayName("Movie Tag Id"), Identity]
        public Int32? MovieTagId
        {
            get { return Fields.MovieTagId[this]; }
            set { Fields.MovieTagId[this] = value; }
        }

        [DisplayName("Tag"), NotNull, ForeignKey("[mov].[Tag]", "TagId"), LeftJoin("jTag"), TextualField("TagName")]
        public Int64? TagId
        {
            get { return Fields.TagId[this]; }
            set { Fields.TagId[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleEn")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Tag Name"), Expression("jTag.[Name]")]
        public String TagName
        {
            get { return Fields.TagName[this]; }
            set { Fields.TagName[this] = value; }
        }
        

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieTagId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieTagRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field MovieTagId;
            public Int64Field TagId;
            public Int64Field MovieId;

            public StringField TagName;
            

            public RowFields()
                : base("[mov].[MovieTag]")
            {
                LocalTextPrefix = "Movie.MovieTag";
            }
        }
    }
}