

namespace Cinema.Movie.Administration.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("DB"), InstanceName("DB"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class DataBaseRow : Row, IIdRow, INameRow
    {
        [DisplayName("Db Id"), Column("DBId"), Identity]
        public Int16? DbId
        {
            get { return Fields.DbId[this]; }
            set { Fields.DbId[this] = value; }
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Connection String"), Size(600), NotNull]
        public String ConnectionString
        {
            get { return Fields.ConnectionString[this]; }
            set { Fields.ConnectionString[this] = value; }
        }

        [DisplayName("Provider Name"), Size(100), NotNull]
        public String ProviderName
        {
            get { return Fields.ProviderName[this]; }
            set { Fields.ProviderName[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }

        [DisplayName("Tag Data Base Movie"), Size(200)]
        public String TagDataBaseMovie
        {
            get { return Fields.TagDataBaseMovie[this]; }
            set { Fields.TagDataBaseMovie[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.DbId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public DataBaseRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field DbId;
            public StringField Name;
            public StringField ConnectionString;
            public StringField ProviderName;
            public BooleanField Active;
            public StringField TagDataBaseMovie;

            public RowFields()
                : base("[cdb].[DB]")
            {
                LocalTextPrefix = "Administration.DataBase";
            }
        }
    }
}