
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

    [ConnectionKey("Movie"), DisplayName("Site"), InstanceName("Site"), TwoLevelCached]
    [ModifyPermission("Administration")]
    [JsonConverter(typeof(JsonRowConverter))]
    [LookupScript("Movie.Site")]
    public sealed class SiteRow : Row, IIdRow, INameRow
    {
        [DisplayName("Site Id"), Identity]
        public Int32? SiteId
        {
            get { return Fields.SiteId[this]; }
            set { Fields.SiteId[this] = value; }
        }

        [DisplayName("Name"), Size(200), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Url"), Size(200), NotNull]
        public String Url
        {
            get { return Fields.Url[this]; }
            set { Fields.Url[this] = value; }
        }

        [DisplayName("Title"), Size(500), NotNull]
        public String Title
        {
            get { return Fields.Title[this]; }
            set { Fields.Title[this] = value; }
        }

        [DisplayName("Background"), Size(500), NotNull]
        public String Background
        {
            get { return Fields.Background[this]; }
            set { Fields.Background[this] = value; }
        }

        [DisplayName("Logo"), Size(500), NotNull]
        public String Logo
        {
            get { return Fields.Logo[this]; }
            set { Fields.Logo[this] = value; }
        }

        [DisplayName("Color"), Size(20), NotNull]
        public String Color
        {
            get { return Fields.Color[this]; }
            set { Fields.Color[this] = value; }
        }
        [DisplayName("Background Color"), Size(20), NotNull]
        public String BackgroundColor
        {
            get { return Fields.BackgroundColor[this]; }
            set { Fields.BackgroundColor[this] = value; }
        }
        [DisplayName("Data Base"), NotNull, ForeignKey("[dbo].[DataBase]", "DataBaseId"), LeftJoin("jDataBase"), TextualField("DataBaseName")]
        public Int32? DataBaseId
        {
            get { return Fields.DataBaseId[this]; }
            set { Fields.DataBaseId[this] = value; }
        }

        [DisplayName("Data Base Name"), Expression("jDataBase.[Name]")]
        public String DataBaseName
        {
            get { return Fields.DataBaseName[this]; }
            set { Fields.DataBaseName[this] = value; }
        }

        [DisplayName("Data Base Connection String"), Expression("jDataBase.[ConnectionString]")]
        public String DataBaseConnectionString
        {
            get { return Fields.DataBaseConnectionString[this]; }
            set { Fields.DataBaseConnectionString[this] = value; }
        }

        [DisplayName("Data Base Provider Name"), Expression("jDataBase.[ProviderName]")]
        public String DataBaseProviderName
        {
            get { return Fields.DataBaseProviderName[this]; }
            set { Fields.DataBaseProviderName[this] = value; }
        }

        [DisplayName("Data Base Active"), Expression("jDataBase.[Active]")]
        public Boolean? DataBaseActive
        {
            get { return Fields.DataBaseActive[this]; }
            set { Fields.DataBaseActive[this] = value; }
        }

        [DisplayName("Data Base Tag Data Base Movie"), Expression("jDataBase.[TagDataBaseMovie]")]
        public String DataBaseTagDataBaseMovie
        {
            get { return Fields.DataBaseTagDataBaseMovie[this]; }
            set { Fields.DataBaseTagDataBaseMovie[this] = value; }
        }

        [DisplayName("Data Base Type"), Expression("jDataBase.[Type]")]
        public String DataBaseType
        {
            get { return Fields.DataBaseType[this]; }
            set { Fields.DataBaseType[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.SiteId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public SiteRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field SiteId;
            public StringField Name;
            public StringField Url;
            public StringField Title;
            public StringField Background;
            public StringField Logo;
            public StringField Color;
            public StringField BackgroundColor;
            public Int32Field DataBaseId;

            public StringField DataBaseName;
            public StringField DataBaseConnectionString;
            public StringField DataBaseProviderName;
            public BooleanField DataBaseActive;
            public StringField DataBaseTagDataBaseMovie;
            public StringField DataBaseType;

            public RowFields()
                : base()
            {
                LocalTextPrefix = "Default.Site";
            }
        }
    }
}
