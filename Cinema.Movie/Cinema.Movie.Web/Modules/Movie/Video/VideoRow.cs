

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

    [ConnectionKey("Default"), DisplayName("Video"), InstanceName("Video"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class VideoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Vudeo Id"), Identity]
        public Int16? VudeoId
        {
            get { return Fields.VudeoId[this]; }
            set { Fields.VudeoId[this] = value; }
        }

        [DisplayName("Path"), Size(300), QuickSearch]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }

        [DisplayName("Name"), Size(300)]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Translation")]
        public Int16? Translation
        {
            get { return Fields.Translation[this]; }
            set { Fields.Translation[this] = value; }
        }

        [DisplayName("Season")]
        public Int16? Season
        {
            get { return Fields.Season[this]; }
            set { Fields.Season[this] = value; }
        }

        [DisplayName("Serie")]
        public Int16? Serie
        {
            get { return Fields.Serie[this]; }
            set { Fields.Serie[this] = value; }
        }

        [DisplayName("Planne Publish Date")]
        public DateTime? PlannePublishDate
        {
            get { return Fields.PlannePublishDate[this]; }
            set { Fields.PlannePublishDate[this] = value; }
        }

        [DisplayName("Actual Publish Date Time")]
        public DateTime? ActualPublishDateTime
        {
            get { return Fields.ActualPublishDateTime[this]; }
            set { Fields.ActualPublishDateTime[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleEn")]
        public Int16? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Service"), NotNull, ForeignKey("[mov].[Service]", "ServiceId"), LeftJoin("jService"), TextualField("ServiceName")]
        public Int16? ServiceId
        {
            get { return Fields.ServiceId[this]; }
            set { Fields.ServiceId[this] = value; }
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

        [DisplayName("Movie Storyline"), Expression("jMovie.[Storyline]")]
        public String MovieStoryline
        {
            get { return Fields.MovieStoryline[this]; }
            set { Fields.MovieStoryline[this] = value; }
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
        public Int16? MovieKind
        {
            get { return Fields.MovieKind[this]; }
            set { Fields.MovieKind[this] = value; }
        }

        [DisplayName("Movie Rating"), Expression("jMovie.[Rating]")]
        public Int16? MovieRating
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

        [DisplayName("Movie Cont Suffrage"), Expression("jMovie.[ContSuffrage]")]
        public Int16? MovieContSuffrage
        {
            get { return Fields.MovieContSuffrage[this]; }
            set { Fields.MovieContSuffrage[this] = value; }
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

        [DisplayName("Service Name"), Expression("jService.[Name]")]
        public String ServiceName
        {
            get { return Fields.ServiceName[this]; }
            set { Fields.ServiceName[this] = value; }
        }

        [DisplayName("Service Api"), Expression("jService.[Api]")]
        public String ServiceApi
        {
            get { return Fields.ServiceApi[this]; }
            set { Fields.ServiceApi[this] = value; }
        }

        [DisplayName("Service Max Rating"), Expression("jService.[MaxRating]")]
        public Int16? ServiceMaxRating
        {
            get { return Fields.ServiceMaxRating[this]; }
            set { Fields.ServiceMaxRating[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.VudeoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Path; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VideoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field VudeoId;
            public StringField Path;
            public StringField Name;
            public Int16Field Translation;
            public Int16Field Season;
            public Int16Field Serie;
            public DateTimeField PlannePublishDate;
            public DateTimeField ActualPublishDateTime;
            public Int16Field MovieId;
            public Int16Field ServiceId;

            public StringField MovieTitleEn;
            public StringField MovieTitleOther;
            public StringField MovieDescription;
            public StringField MovieStoryline;
            public Int16Field MovieYearStart;
            public Int16Field MovieYearEnd;
            public DateTimeField MovieReleaseWorldDate;
            public DateTimeField MovieReleaseOtherDate;
            public DateTimeField MovieReleaseDvd;
            public Int16Field MovieRuntime;
            public DateTimeField MovieCreateDateTime;
            public DateTimeField MovieUpdateDateTime;
            public DateTimeField MoviePublishDateTime;
            public Int16Field MovieKind;
            public Int16Field MovieRating;
            public StringField MovieMpaa;
            public Int16Field MovieContSuffrage;
            public StringField MoviePathImage;
            public StringField MoviePathMiniImage;
            public BooleanField MovieNice;
            public Int16Field MovieContSeason;
            public StringField MovieLastEvent;
            public DateTimeField MovieLastEventPublishDateTime;

            public StringField ServiceName;
            public StringField ServiceApi;
            public Int16Field ServiceMaxRating;

            public RowFields()
                : base("[mov].[Video]")
            {
                LocalTextPrefix = "Movie.Video";
            }
        }
    }
}