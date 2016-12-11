

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

    [ConnectionKey("Default"), DisplayName("Country"), InstanceName("Country"), TwoLevelCached]
    [JsonConverter(typeof(JsonRowConverter))]
    [ModifyPermission("Administration")]
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

            public RowFields()
                : base("[mov].[Country]")
            {
                LocalTextPrefix = "Movie.Country";
            }
        }
    }
}