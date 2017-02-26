

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

    [ConnectionKey("Movie"), DisplayName("Image"), InstanceName("Image"), TwoLevelCached]
    [ModifyPermission("Administration")]
    [JsonConverter(typeof(JsonRowConverter))]
    [LookupScript("Movie.Image")]
    public sealed class ImageRow : Row, IIdRow, INameRow
    {
        [DisplayName("Image Id"), Identity]
        public Int64? ImageId
        {
            get { return Fields.ImageId[this]; }
            set { Fields.ImageId[this] = value; }
        }

        [DisplayName("Path"), Size(1000), NotNull, QuickSearch]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }

        [DisplayName("Movie"), ForeignKey("[dbo].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleOriginal")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Person"), ForeignKey("[dbo].[Person]", "PersonId"), LeftJoin("jPerson"), TextualField("PersonName")]
        public Int64? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
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

        [DisplayName("Person Name"), Expression("jPerson.[Name]")]
        public String PersonName
        {
            get { return Fields.PersonName[this]; }
            set { Fields.PersonName[this] = value; }
        }

        [DisplayName("Person Url"), Expression("jPerson.[Url]")]
        public String PersonUrl
        {
            get { return Fields.PersonUrl[this]; }
            set { Fields.PersonUrl[this] = value; }
        }

        [DisplayName("Person Full Name"), Expression("jPerson.[FullName]")]
        public String PersonFullName
        {
            get { return Fields.PersonFullName[this]; }
            set { Fields.PersonFullName[this] = value; }
        }

        [DisplayName("Person Name Other"), Expression("jPerson.[NameOther]")]
        public String PersonNameOther
        {
            get { return Fields.PersonNameOther[this]; }
            set { Fields.PersonNameOther[this] = value; }
        }

        [DisplayName("Person Full Name Other"), Expression("jPerson.[FullNameOther]")]
        public String PersonFullNameOther
        {
            get { return Fields.PersonFullNameOther[this]; }
            set { Fields.PersonFullNameOther[this] = value; }
        }

        [DisplayName("Person Birth Date"), Expression("jPerson.[BirthDate]")]
        public DateTime? PersonBirthDate
        {
            get { return Fields.PersonBirthDate[this]; }
            set { Fields.PersonBirthDate[this] = value; }
        }

        [DisplayName("Person Death Date"), Expression("jPerson.[DeathDate]")]
        public DateTime? PersonDeathDate
        {
            get { return Fields.PersonDeathDate[this]; }
            set { Fields.PersonDeathDate[this] = value; }
        }

        [DisplayName("Person Gender"), Expression("jPerson.[Gender]")]
        public Int16? PersonGender
        {
            get { return Fields.PersonGender[this]; }
            set { Fields.PersonGender[this] = value; }
        }

        [DisplayName("Person About"), Expression("jPerson.[About]")]
        public String PersonAbout
        {
            get { return Fields.PersonAbout[this]; }
            set { Fields.PersonAbout[this] = value; }
        }

        [DisplayName("Person Path Image"), Expression("jPerson.[PathImage]")]
        public String PersonPathImage
        {
            get { return Fields.PersonPathImage[this]; }
            set { Fields.PersonPathImage[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ImageId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Path; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ImageRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field ImageId;
            public StringField Path;
            public Int64Field MovieId;
            public Int64Field PersonId;

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

            public StringField PersonName;
            public StringField PersonUrl;
            public StringField PersonFullName;
            public StringField PersonNameOther;
            public StringField PersonFullNameOther;
            public DateTimeField PersonBirthDate;
            public DateTimeField PersonDeathDate;
            public Int16Field PersonGender;
            public StringField PersonAbout;
            public StringField PersonPathImage;

            public RowFields()
                : base("[dbo].[Image]")
            {
                LocalTextPrefix = "Movie.Image";
            }
        }
    }
}