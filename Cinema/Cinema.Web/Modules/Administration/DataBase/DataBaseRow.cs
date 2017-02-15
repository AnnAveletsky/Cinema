

namespace Cinema.Administration.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("DataBase"), InstanceName("DataBase"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class DataBaseRow : Row, IIdRow, INameRow
    {
        [DisplayName("Data Base Id"), Identity]
        public Int32? DataBaseId
        {
            get { return Fields.DataBaseId[this]; }
            set { Fields.DataBaseId[this] = value; }
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

        [DisplayName("Type"), Size(100)]
        public String Type
        {
            get { return Fields.Type[this]; }
            set { Fields.Type[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.DataBaseId; }
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
            public Int32Field DataBaseId;
            public StringField Name;
            public StringField ConnectionString;
            public StringField ProviderName;
            public BooleanField Active;
            public StringField TagDataBaseMovie;
            public StringField Type;

            public RowFields()
                : base("[dbo].[DataBase]")
            {
                LocalTextPrefix = "Administration.DataBase";
            }
        }
    }
}