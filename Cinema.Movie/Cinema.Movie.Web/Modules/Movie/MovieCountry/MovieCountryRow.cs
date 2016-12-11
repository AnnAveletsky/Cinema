

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

    [ConnectionKey("Default"), DisplayName("MovieCountry"), InstanceName("MovieCountry"), TwoLevelCached]
    [JsonConverter(typeof(JsonRowConverter))]
    [ModifyPermission("Administration")]
    [LookupScript("Movie.MovieCountry")]
    public sealed class MovieCountryRow : Row, IIdRow
    {
        [DisplayName("Movie Country Id"), Identity]
        public Int64? MovieCountryId
        {
            get { return Fields.MovieCountryId[this]; }
            set { Fields.MovieCountryId[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleEn")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Country"), NotNull, ForeignKey("[mov].[Country]", "CountryId"), LeftJoin("jCountry"), TextualField("CountryNameEn")]
        public Int32? CountryId
        {
            get { return Fields.CountryId[this]; }
            set { Fields.CountryId[this] = value; }
        }
        

        [DisplayName("Country Name"), Expression("jCountry.[Name]")]
        public String CountryName
        {
            get { return Fields.CountryName[this]; }
            set { Fields.CountryName[this] = value; }
        }
        
        IIdField IIdRow.IdField
        {
            get { return Fields.MovieCountryId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieCountryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field MovieCountryId;
            public Int64Field MovieId;
            public Int32Field CountryId;

            public StringField CountryName;

            public RowFields()
                : base("[mov].[MovieCountry]")
            {
                LocalTextPrefix = "Movie.MovieCountry";
            }
        }
    }
}