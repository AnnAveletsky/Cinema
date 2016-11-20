﻿

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

    [ConnectionKey("Default"), DisplayName("MovieGenres"), InstanceName("MovieGenres"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class MovieGenresRow : Row, IIdRow
    {
        [DisplayName("Movie Genre Id"), Identity]
        public Int64? MovieGenreId
        {
            get { return Fields.MovieGenreId[this]; }
            set { Fields.MovieGenreId[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleEn")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Genre"), NotNull, ForeignKey("[mov].[Genre]", "GenreId"), LeftJoin("jGenre"), TextualField("GenreName")]
        public Int16? GenreId
        {
            get { return Fields.GenreId[this]; }
            set { Fields.GenreId[this] = value; }
        }

        [DisplayName("Movie Title En"), Expression("jMovie.[TitleEn]")]
        public String MovieTitleEn
        {
            get { return Fields.MovieTitleEn[this]; }
            set { Fields.MovieTitleEn[this] = value; }
        }

        [DisplayName("Movie Title Other"), Expression("jMovie.[TitleOther]")]
        public String MovieTitleOther
        {
            get { return Fields.MovieTitleOther[this]; }
            set { Fields.MovieTitleOther[this] = value; }
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
        public Int16? MovieRuntime
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

        [DisplayName("Movie Path Mini Image"), Expression("jMovie.[PathMiniImage]")]
        public String MoviePathMiniImage
        {
            get { return Fields.MoviePathMiniImage[this]; }
            set { Fields.MoviePathMiniImage[this] = value; }
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

        [DisplayName("Movie Last Event"), Expression("jMovie.[LastEvent]")]
        public String MovieLastEvent
        {
            get { return Fields.MovieLastEvent[this]; }
            set { Fields.MovieLastEvent[this] = value; }
        }

        [DisplayName("Movie Last Event Publish Date Time"), Expression("jMovie.[LastEventPublishDateTime]")]
        public DateTime? MovieLastEventPublishDateTime
        {
            get { return Fields.MovieLastEventPublishDateTime[this]; }
            set { Fields.MovieLastEventPublishDateTime[this] = value; }
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

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieGenreId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieGenresRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field MovieGenreId;
            public Int64Field MovieId;
            public Int16Field GenreId;

            public StringField MovieTitleEn;
            public StringField MovieTitleOther;
            public StringField MovieDescription;
            public Int16Field MovieYearStart;
            public Int16Field MovieYearEnd;
            public DateTimeField MovieReleaseWorldDate;
            public DateTimeField MovieReleaseOtherDate;
            public DateTimeField MovieReleaseDvd;
            public Int16Field MovieRuntime;
            public DateTimeField MovieCreateDateTime;
            public DateTimeField MovieUpdateDateTime;
            public DateTimeField MoviePublishDateTime;
            public Int32Field MovieKind;
            public Int32Field MovieRating;
            public StringField MovieMpaa;
            public StringField MoviePathImage;
            public StringField MoviePathMiniImage;
            public BooleanField MovieNice;
            public Int16Field MovieContSeason;
            public StringField MovieLastEvent;
            public DateTimeField MovieLastEventPublishDateTime;
            public StringField MovieTagline;
            public DecimalField MovieBudget;

            public StringField GenreName;

            public RowFields()
                : base("[mov].[MovieGenres]")
            {
                LocalTextPrefix = "Movie.MovieGenres";
            }
        }
    }
}