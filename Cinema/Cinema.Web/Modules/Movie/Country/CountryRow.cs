

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

    [ConnectionKey("Movie"), DisplayName("Country"), InstanceName("Country"), TwoLevelCached]
    [ModifyPermission("Administration")]
    [JsonConverter(typeof(JsonRowConverter))]
    [LookupScript("Movie.Country")]
    public sealed class CountryRow : Row, IIdRow, INameRow
    {
        [DisplayName("Country Id"), Identity]
        public Int32? CountryId
        {
            get { return Fields.CountryId[this]; }
            set { Fields.CountryId[this] = value; }
        }

        [DisplayName("Name"), Size(300), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Name Other"), Size(300)]
        public String NameOther
        {
            get { return Fields.NameOther[this]; }
            set { Fields.NameOther[this] = value; }
        }

        [DisplayName("Code"), Size(100)]
        public String Code
        {
            get { return Fields.Code[this]; }
            set { Fields.Code[this] = value; }
        }

        [DisplayName("Icon"), Size(100)]
        public String Icon
        {
            get { return Fields.Icon[this]; }
            set { Fields.Icon[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.CountryId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CountryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field CountryId;
            public StringField Name;
            public StringField NameOther;
            public StringField Code;
            public StringField Icon;

            public RowFields()
                : base("[dbo].[Country]")
            {
                LocalTextPrefix = "Movie.Country";
            }
        }
    }
}