

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

    [ConnectionKey("Movie"), DisplayName("MovieGenre"), InstanceName("MovieGenre"), TwoLevelCached]
    [ModifyPermission("Administration")]
    [JsonConverter(typeof(JsonRowConverter))]
    [LookupScript("Movie.MovieGenre")]
    public sealed class MovieGenreRow : Row, IIdRow
    {
        [DisplayName("Movie Genre Id"), Identity]
        public Int64? MovieGenreId
        {
            get { return Fields.MovieGenreId[this]; }
            set { Fields.MovieGenreId[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[dbo].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleOriginal")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Genre"), NotNull, ForeignKey("[dbo].[Genre]", "GenreId"), LeftJoin("jGenre"), TextualField("GenreName")]
        public Int32? GenreId
        {
            get { return Fields.GenreId[this]; }
            set { Fields.GenreId[this] = value; }
        }

        [DisplayName("Movie Title Original"), Expression("jMovie.[TitleOriginal]")]
        public String MovieTitleOriginal
        {
            get { return Fields.MovieTitleOriginal[this]; }
            set { Fields.MovieTitleOriginal[this] = value; }
        }

        [DisplayName("Movie Title Translation"), Expression("jMovie.[TitleTranslation]")]
        public String MovieTitleTranslation
        {
            get { return Fields.MovieTitleTranslation[this]; }
            set { Fields.MovieTitleTranslation[this] = value; }
        }

        [DisplayName("Movie Url"), Expression("jMovie.[Url]")]
        public String MovieUrl
        {
            get { return Fields.MovieUrl[this]; }
            set { Fields.MovieUrl[this] = value; }
        }

        [DisplayName("Movie Description"), Expression("jMovie.[Description]")]
        public String MovieDescription
        {
            get { return Fields.MovieDescription[this]; }
            set { Fields.MovieDescription[this] = value; }
        }

        [DisplayName("Movie Year Start"), Expression("jMovie.[YearStart]")]
        public Int16? MovieYearStart
        {
            get { return Fields.MovieYearStart[this]; }
            set { Fields.MovieYearStart[this] = value; }
        }

        [DisplayName("Movie Year End"), Expression("jMovie.[YearEnd]")]
        public Int16? MovieYearEnd
        {
            get { return Fields.MovieYearEnd[this]; }
            set { Fields.MovieYearEnd[this] = value; }
        }

        [DisplayName("Movie Release World Date"), Expression("jMovie.[ReleaseWorldDate]")]
        public DateTime? MovieReleaseWorldDate
        {
            get { return Fields.MovieReleaseWorldDate[this]; }
            set { Fields.MovieReleaseWorldDate[this] = value; }
        }

        [DisplayName("Movie Release Other Date"), Expression("jMovie.[ReleaseOtherDate]")]
        public DateTime? MovieReleaseOtherDate
        {
            get { return Fields.MovieReleaseOtherDate[this]; }
            set { Fields.MovieReleaseOtherDate[this] = value; }
        }

        [DisplayName("Movie Release Dvd"), Expression("jMovie.[ReleaseDVD]")]
        public DateTime? MovieReleaseDvd
        {
            get { return Fields.MovieReleaseDvd[this]; }
            set { Fields.MovieReleaseDvd[this] = value; }
        }

        [DisplayName("Movie Runtime"), Expression("jMovie.[Runtime]")]
        public String MovieRuntime
        {
            get { return Fields.MovieRuntime[this]; }
            set { Fields.MovieRuntime[this] = value; }
        }

        [DisplayName("Movie Create Date Time"), Expression("jMovie.[CreateDateTime]")]
        public DateTime? MovieCreateDateTime
        {
            get { return Fields.MovieCreateDateTime[this]; }
            set { Fields.MovieCreateDateTime[this] = value; }
        }

        [DisplayName("Movie Update Date Time"), Expression("jMovie.[UpdateDateTime]")]
        public DateTime? MovieUpdateDateTime
        {
            get { return Fields.MovieUpdateDateTime[this]; }
            set { Fields.MovieUpdateDateTime[this] = value; }
        }

        [DisplayName("Movie Publish Date Time"), Expression("jMovie.[PublishDateTime]")]
        public DateTime? MoviePublishDateTime
        {
            get { return Fields.MoviePublishDateTime[this]; }
            set { Fields.MoviePublishDateTime[this] = value; }
        }

        [DisplayName("Movie Kind"), Expression("jMovie.[Kind]")]
        public Int32? MovieKind
        {
            get { return Fields.MovieKind[this]; }
            set { Fields.MovieKind[this] = value; }
        }

        [DisplayName("Movie Rating"), Expression("jMovie.[Rating]")]
        public Int32? MovieRating
        {
            get { return Fields.MovieRating[this]; }
            set { Fields.MovieRating[this] = value; }
        }

        [DisplayName("Movie Mpaa"), Expression("jMovie.[MPAA]")]
        public String MovieMpaa
        {
            get { return Fields.MovieMpaa[this]; }
            set { Fields.MovieMpaa[this] = value; }
        }

        [DisplayName("Movie Path Image"), Expression("jMovie.[PathImage]")]
        public String MoviePathImage
        {
            get { return Fields.MoviePathImage[this]; }
            set { Fields.MoviePathImage[this] = value; }
        }

        [DisplayName("Movie Nice"), Expression("jMovie.[Nice]")]
        public Boolean? MovieNice
        {
            get { return Fields.MovieNice[this]; }
            set { Fields.MovieNice[this] = value; }
        }

        [DisplayName("Movie Cont Season"), Expression("jMovie.[ContSeason]")]
        public Int16? MovieContSeason
        {
            get { return Fields.MovieContSeason[this]; }
            set { Fields.MovieContSeason[this] = value; }
        }

        [DisplayName("Movie Tagline"), Expression("jMovie.[Tagline]")]
        public String MovieTagline
        {
            get { return Fields.MovieTagline[this]; }
            set { Fields.MovieTagline[this] = value; }
        }

        [DisplayName("Movie Budget"), Expression("jMovie.[Budget]")]
        public Decimal? MovieBudget
        {
            get { return Fields.MovieBudget[this]; }
            set { Fields.MovieBudget[this] = value; }
        }

        [DisplayName("Genre Name"), Expression("jGenre.[Name]")]
        public String GenreName
        {
            get { return Fields.GenreName[this]; }
            set { Fields.GenreName[this] = value; }
        }

        [DisplayName("Genre Icon"), Expression("jGenre.[Icon]")]
        public String GenreIcon
        {
            get { return Fields.GenreIcon[this]; }
            set { Fields.GenreIcon[this] = value; }
        }

        [DisplayName("Genre Style"), Expression("jGenre.[Style]")]
        public String GenreStyle
        {
            get { return Fields.GenreStyle[this]; }
            set { Fields.GenreStyle[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieGenreId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieGenreRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field MovieGenreId;
            public Int64Field MovieId;
            public Int32Field GenreId;

            public StringField MovieTitleOriginal;
            public StringField MovieTitleTranslation;
            public StringField MovieUrl;
            public StringField MovieDescription;
            public Int16Field MovieYearStart;
            public Int16Field MovieYearEnd;
            public DateTimeField MovieReleaseWorldDate;
            public DateTimeField MovieReleaseOtherDate;
            public DateTimeField MovieReleaseDvd;
            public StringField MovieRuntime;
            public DateTimeField MovieCreateDateTime;
            public DateTimeField MovieUpdateDateTime;
            public DateTimeField MoviePublishDateTime;
            public Int32Field MovieKind;
            public Int32Field MovieRating;
            public StringField MovieMpaa;
            public StringField MoviePathImage;
            public BooleanField MovieNice;
            public Int16Field MovieContSeason;
            public StringField MovieTagline;
            public DecimalField MovieBudget;

            public StringField GenreName;
            public StringField GenreIcon;
            public StringField GenreStyle;

            public RowFields()
                : base("[dbo].[MovieGenre]")
            {
                LocalTextPrefix = "Movie.MovieGenre";
            }
        }
    }
}