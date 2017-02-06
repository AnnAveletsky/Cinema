

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

    [ConnectionKey("Movie"), DisplayName("History"), InstanceName("History"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class HistoryRow : Row, IIdRow, INameRow
    {
        [DisplayName("History Id"), Identity]
        public Int64? HistoryId
        {
            get { return Fields.HistoryId[this]; }
            set { Fields.HistoryId[this] = value; }
        }

        [DisplayName("User Name"), Size(100), NotNull, QuickSearch]
        public String UserName
        {
            get { return Fields.UserName[this]; }
            set { Fields.UserName[this] = value; }
        }

        [DisplayName("Message"), NotNull]
        public String Message
        {
            get { return Fields.Message[this]; }
            set { Fields.Message[this] = value; }
        }
        [DisplayName("Event Data Time"), NotNull]
        public DateTime? EventDataTime
        {
            get { return Fields.EventDataTime[this]; }
            set { Fields.EventDataTime[this] = value; }
        }
        [DisplayName("Status"), NotNull]
        public Boolean? Status
        {
            get { return Fields.Status[this]; }
            set { Fields.Status[this] = value; }
        }

        [DisplayName("Cast"), ForeignKey("[mov].[Cast]", "CastId"), LeftJoin("jCast"), TextualField("CastCharacter")]
        public Int64? CastId
        {
            get { return Fields.CastId[this]; }
            set { Fields.CastId[this] = value; }
        }

        [DisplayName("Country"), ForeignKey("[mov].[Country]", "CountryId"), LeftJoin("jCountry"), TextualField("CountryName")]
        public Int32? CountryId
        {
            get { return Fields.CountryId[this]; }
            set { Fields.CountryId[this] = value; }
        }

        [DisplayName("Genre"), ForeignKey("[mov].[Genre]", "GenreId"), LeftJoin("jGenre"), TextualField("GenreName")]
        public Int16? GenreId
        {
            get { return Fields.GenreId[this]; }
            set { Fields.GenreId[this] = value; }
        }

        [DisplayName("Service"), ForeignKey("[mov].[Service]", "ServiceId"), LeftJoin("jService"), TextualField("ServiceName")]
        public Int16? ServiceId
        {
            get { return Fields.ServiceId[this]; }
            set { Fields.ServiceId[this] = value; }
        }

        [DisplayName("Movie"), ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleOriginal")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Person"), ForeignKey("[mov].[Person]", "PersonId"), LeftJoin("jPerson"), TextualField("PersonNameEn")]
        public Int64? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("Image"), ForeignKey("[mov].[Image]", "ImageId"), LeftJoin("jImage"), TextualField("ImagePath")]
        public Int64? ImageId
        {
            get { return Fields.ImageId[this]; }
            set { Fields.ImageId[this] = value; }
        }

        [DisplayName("Movie Country"), ForeignKey("[mov].[MovieCountry]", "MovieCountryId"), LeftJoin("jMovieCountry")]
        public Int64? MovieCountryId
        {
            get { return Fields.MovieCountryId[this]; }
            set { Fields.MovieCountryId[this] = value; }
        }

        [DisplayName("Service Path"), ForeignKey("[mov].[ServicePath]", "ServicePathId"), LeftJoin("jServicePath"), TextualField("ServicePathPath")]
        public Int32? ServicePathId
        {
            get { return Fields.ServicePathId[this]; }
            set { Fields.ServicePathId[this] = value; }
        }

        [DisplayName("Service Rating"), ForeignKey("[mov].[ServiceRating]", "ServiceRatingId"), LeftJoin("jServiceRating")]
        public Int64? ServiceRatingId
        {
            get { return Fields.ServiceRatingId[this]; }
            set { Fields.ServiceRatingId[this] = value; }
        }

        [DisplayName("Movie Tag"), ForeignKey("[mov].[MovieTag]", "MovieTagId"), LeftJoin("jMovieTag")]
        public Int64? MovieTagId
        {
            get { return Fields.MovieTagId[this]; }
            set { Fields.MovieTagId[this] = value; }
        }

        [DisplayName("Tag"), ForeignKey("[mov].[Tag]", "TagId"), LeftJoin("jTag"), TextualField("TagName")]
        public Int64? TagId
        {
            get { return Fields.TagId[this]; }
            set { Fields.TagId[this] = value; }
        }

        [DisplayName("Video"), ForeignKey("[mov].[Video]", "VideoId"), LeftJoin("jVideo"), TextualField("VideoPath")]
        public Int64? VideoId
        {
            get { return Fields.VideoId[this]; }
            set { Fields.VideoId[this] = value; }
        }

        [DisplayName("Movie Genre"), ForeignKey("[mov].[MovieGenre]", "MovieGenreId"), LeftJoin("jMovieGenre")]
        public Int64? MovieGenreId
        {
            get { return Fields.MovieGenreId[this]; }
            set { Fields.MovieGenreId[this] = value; }
        }
        

        IIdField IIdRow.IdField
        {
            get { return Fields.HistoryId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.UserName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public HistoryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field HistoryId;
            public StringField UserName;
            public StringField Message;
            public DateTimeField EventDataTime;
            public BooleanField Status;
            public Int64Field CastId;
            public Int32Field CountryId;
            public Int16Field GenreId;
            public Int16Field ServiceId;
            public Int64Field MovieId;
            public Int64Field PersonId;
            public Int64Field ImageId;
            public Int64Field MovieCountryId;
            public Int32Field ServicePathId;
            public Int64Field ServiceRatingId;
            public Int64Field MovieTagId;
            public Int64Field TagId;
            public Int64Field VideoId;
            public Int64Field MovieGenreId;

            

            public RowFields()
                : base("[mov].[History]")
            {
                LocalTextPrefix = "Movie.History";
            }
        }
    }
}