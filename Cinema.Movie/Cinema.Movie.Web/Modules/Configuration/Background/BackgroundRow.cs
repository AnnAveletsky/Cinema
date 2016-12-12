

namespace Cinema.Movie.Configuration.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Background"), InstanceName("Background"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class BackgroundRow : Row, IIdRow, INameRow
    {
        [DisplayName("Background Id"), Identity]
        public Int16? BackgroundId
        {
            get { return Fields.BackgroundId[this]; }
            set { Fields.BackgroundId[this] = value; }
        }

        [DisplayName("Color"), Size(12), NotNull, QuickSearch]
        public String Color
        {
            get { return Fields.Color[this]; }
            set { Fields.Color[this] = value; }
        }

        [DisplayName("Path"), Size(200), NotNull]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }

        [DisplayName("Size"), Size(2), NotNull]
        public String Size
        {
            get { return Fields.Size[this]; }
            set { Fields.Size[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.BackgroundId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Color; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public BackgroundRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field BackgroundId;
            public StringField Color;
            public StringField Path;
            public StringField Size;

            public RowFields()
                : base("[conf].[Background]")
            {
                LocalTextPrefix = "Configuration.Background";
            }
        }
    }
}