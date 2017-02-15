

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

    [ConnectionKey("Movie"), DisplayName("Video"), InstanceName("Video"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class VideoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Video Id"), Identity]
        public Int64? VideoId
        {
            get { return Fields.VideoId[this]; }
            set { Fields.VideoId[this] = value; }
        }

        [DisplayName("Path"), QuickSearch]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }

        [DisplayName("Player")]
        public Int16? Player
        {
            get { return Fields.Player[this]; }
            set { Fields.Player[this] = value; }
        }

        [DisplayName("Path Torrent"), Size(300)]
        public String PathTorrent
        {
            get { return Fields.PathTorrent[this]; }
            set { Fields.PathTorrent[this] = value; }
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

        [DisplayName("Storyline")]
        public String Storyline
        {
            get { return Fields.Storyline[this]; }
            set { Fields.Storyline[this] = value; }
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

        [DisplayName("Movie"), NotNull, ForeignKey("[dbo].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleOriginal")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Service"), ForeignKey("[dbo].[Service]", "ServiceId"), LeftJoin("jService"), TextualField("ServiceName")]
        public Int32? ServiceId
        {
            get { return Fields.ServiceId[this]; }
            set { Fields.ServiceId[this] = value; }
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

        [DisplayName("Service Url"), Expression("jService.[Url]")]
        public String ServiceUrl
        {
            get { return Fields.ServiceUrl[this]; }
            set { Fields.ServiceUrl[this] = value; }
        }

        [DisplayName("Service Active"), Expression("jService.[Active]")]
        public Boolean? ServiceActive
        {
            get { return Fields.ServiceActive[this]; }
            set { Fields.ServiceActive[this] = value; }
        }

        [DisplayName("Service Interval Request"), Expression("jService.[IntervalRequest]")]
        public Int32? ServiceIntervalRequest
        {
            get { return Fields.ServiceIntervalRequest[this]; }
            set { Fields.ServiceIntervalRequest[this] = value; }
        }

        [DisplayName("Service Max Rating"), Expression("jService.[MaxRating]")]
        public Int16? ServiceMaxRating
        {
            get { return Fields.ServiceMaxRating[this]; }
            set { Fields.ServiceMaxRating[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.VideoId; }
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
            public Int64Field VideoId;
            public StringField Path;
            public Int16Field Player;
            public StringField PathTorrent;
            public StringField Name;
            public Int16Field Translation;
            public Int16Field Season;
            public Int16Field Serie;
            public StringField Storyline;
            public DateTimeField PlannePublishDate;
            public DateTimeField ActualPublishDateTime;
            public Int64Field MovieId;
            public Int32Field ServiceId;

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

            public StringField ServiceName;
            public StringField ServiceApi;
            public StringField ServiceUrl;
            public BooleanField ServiceActive;
            public Int32Field ServiceIntervalRequest;
            public Int16Field ServiceMaxRating;

            public RowFields()
                : base("[dbo].[Video]")
            {
                LocalTextPrefix = "Movie.Video";
            }
        }
    }
}