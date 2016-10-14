

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

    [ConnectionKey("Default"), DisplayName("Movie"), InstanceName("Movie"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class MovieRow : Row, IIdRow, INameRow
    {
        [DisplayName("Movie Id"), Identity]
        public Int16? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Title En"), Size(200), NotNull, QuickSearch]
        public String TitleEn
        {
            get { return Fields.TitleEn[this]; }
            set { Fields.TitleEn[this] = value; }
        }

        [DisplayName("Title Other"), Size(200)]
        public String TitleOther
        {
            get { return Fields.TitleOther[this]; }
            set { Fields.TitleOther[this] = value; }
        }

        [DisplayName("Description"), Size(1000)]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        [DisplayName("Storyline")]
        public String Storyline
        {
            get { return Fields.Storyline[this]; }
            set { Fields.Storyline[this] = value; }
        }

        [DisplayName("Year Start")]
        public Int16? YearStart
        {
            get { return Fields.YearStart[this]; }
            set { Fields.YearStart[this] = value; }
        }

        [DisplayName("Year End"), NotNull]
        public Int16? YearEnd
        {
            get { return Fields.YearEnd[this]; }
            set { Fields.YearEnd[this] = value; }
        }

        [DisplayName("Release World Date")]
        public DateTime? ReleaseWorldDate
        {
            get { return Fields.ReleaseWorldDate[this]; }
            set { Fields.ReleaseWorldDate[this] = value; }
        }

        [DisplayName("Release Other Date")]
        public DateTime? ReleaseOtherDate
        {
            get { return Fields.ReleaseOtherDate[this]; }
            set { Fields.ReleaseOtherDate[this] = value; }
        }

        [DisplayName("Release Dvd"), Column("ReleaseDVD")]
        public DateTime? ReleaseDvd
        {
            get { return Fields.ReleaseDvd[this]; }
            set { Fields.ReleaseDvd[this] = value; }
        }

        [DisplayName("Runtime")]
        public Int16? Runtime
        {
            get { return Fields.Runtime[this]; }
            set { Fields.Runtime[this] = value; }
        }

        [DisplayName("Create Date Time"), NotNull]
        public DateTime? CreateDateTime
        {
            get { return Fields.CreateDateTime[this]; }
            set { Fields.CreateDateTime[this] = value; }
        }

        [DisplayName("Update Date Time"), NotNull]
        public DateTime? UpdateDateTime
        {
            get { return Fields.UpdateDateTime[this]; }
            set { Fields.UpdateDateTime[this] = value; }
        }

        [DisplayName("Publish Date Time"), NotNull]
        public DateTime? PublishDateTime
        {
            get { return Fields.PublishDateTime[this]; }
            set { Fields.PublishDateTime[this] = value; }
        }

        [DisplayName("Kind"), NotNull]
        public Int16? Kind
        {
            get { return Fields.Kind[this]; }
            set { Fields.Kind[this] = value; }
        }

        [DisplayName("Rating"), NotNull]
        public Int16? Rating
        {
            get { return Fields.Rating[this]; }
            set { Fields.Rating[this] = value; }
        }

        [DisplayName("Mpaa"), Column("MPAA"), Size(6)]
        public String Mpaa
        {
            get { return Fields.Mpaa[this]; }
            set { Fields.Mpaa[this] = value; }
        }

        [DisplayName("Cont Suffrage"), NotNull]
        public Int16? ContSuffrage
        {
            get { return Fields.ContSuffrage[this]; }
            set { Fields.ContSuffrage[this] = value; }
        }

        [DisplayName("Path Image"), Size(300), NotNull]
        public String PathImage
        {
            get { return Fields.PathImage[this]; }
            set { Fields.PathImage[this] = value; }
        }

        [DisplayName("Path Mini Image"), Size(300), NotNull]
        public String PathMiniImage
        {
            get { return Fields.PathMiniImage[this]; }
            set { Fields.PathMiniImage[this] = value; }
        }

        [DisplayName("Nice"), NotNull]
        public Boolean? Nice
        {
            get { return Fields.Nice[this]; }
            set { Fields.Nice[this] = value; }
        }

        [DisplayName("Cont Season")]
        public Int16? ContSeason
        {
            get { return Fields.ContSeason[this]; }
            set { Fields.ContSeason[this] = value; }
        }

        [DisplayName("Last Event"), Size(300)]
        public String LastEvent
        {
            get { return Fields.LastEvent[this]; }
            set { Fields.LastEvent[this] = value; }
        }

        [DisplayName("Last Event Publish Date Time")]
        public DateTime? LastEventPublishDateTime
        {
            get { return Fields.LastEventPublishDateTime[this]; }
            set { Fields.LastEventPublishDateTime[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TitleEn; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field MovieId;
            public StringField TitleEn;
            public StringField TitleOther;
            public StringField Description;
            public StringField Storyline;
            public Int16Field YearStart;
            public Int16Field YearEnd;
            public DateTimeField ReleaseWorldDate;
            public DateTimeField ReleaseOtherDate;
            public DateTimeField ReleaseDvd;
            public Int16Field Runtime;
            public DateTimeField CreateDateTime;
            public DateTimeField UpdateDateTime;
            public DateTimeField PublishDateTime;
            public Int16Field Kind;
            public Int16Field Rating;
            public StringField Mpaa;
            public Int16Field ContSuffrage;
            public StringField PathImage;
            public StringField PathMiniImage;
            public BooleanField Nice;
            public Int16Field ContSeason;
            public StringField LastEvent;
            public DateTimeField LastEventPublishDateTime;

            public RowFields()
                : base("[mov].[Movie]")
            {
                LocalTextPrefix = "Movie.Movie";
            }
        }
    }
}