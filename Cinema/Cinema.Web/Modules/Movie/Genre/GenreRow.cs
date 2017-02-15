

namespace Cinema.Movie.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Movie"), DisplayName("Genre"), InstanceName("Genre"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class GenreRow : Row, IIdRow, INameRow
    {
        [DisplayName("Genre Id"), Identity]
        public Int32? GenreId
        {
            get { return Fields.GenreId[this]; }
            set { Fields.GenreId[this] = value; }
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Icon"), Size(100)]
        public String Icon
        {
            get { return Fields.Icon[this]; }
            set { Fields.Icon[this] = value; }
        }

        [DisplayName("Style"), Size(300)]
        public String Style
        {
            get { return Fields.Style[this]; }
            set { Fields.Style[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.GenreId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public GenreRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field GenreId;
            public StringField Name;
            public StringField Icon;
            public StringField Style;

            public RowFields()
                : base("[dbo].[Genre]")
            {
                LocalTextPrefix = "Movie.Genre";
            }
        }
    }
}