

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

    [ConnectionKey("Movie"), DisplayName("Movie"), InstanceName("Movie"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class MovieRow : Row, IIdRow, INameRow
    {
        [DisplayName("Movie Id"), Identity]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Title Original"), Size(400), NotNull, QuickSearch]
        public String TitleOriginal
        {
            get { return Fields.TitleOriginal[this]; }
            set { Fields.TitleOriginal[this] = value; }
        }

        [DisplayName("Title Translation"), Size(400)]
        public String TitleTranslation
        {
            get { return Fields.TitleTranslation[this]; }
            set { Fields.TitleTranslation[this] = value; }
        }

        [DisplayName("Url"), Size(400), NotNull]
        public String Url
        {
            get { return Fields.Url[this]; }
            set { Fields.Url[this] = value; }
        }

        [DisplayName("Description")]
        public String[] Description
        {
            get { return !String.IsNullOrWhiteSpace(Fields.Description[this]) ? Fields.Description[this].Split(new[] { "<br>", "<br />" }, StringSplitOptions.None) : new string[0]; }
            set { Fields.Description[this] = String.Join("<br>", value); }
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

        [DisplayName("Runtime"), Size(300)]
        public String Runtime
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
        public MovieKind Kind
        {
            get { return (MovieKind)Fields.Kind[this]; }
            set { Fields.Kind[this] = (Int32)value; }
        }

        [DisplayName("Rating"), NotNull]
        public Int32? Rating
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

        [DisplayName("Path Image"), Size(300)]
        public String PathImage
        {
            get { return Fields.PathImage[this]; }
            set { Fields.PathImage[this] = value; }
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

        [DisplayName("Tagline"), Size(400)]
        public String Tagline
        {
            get { return Fields.Tagline[this]; }
            set { Fields.Tagline[this] = value; }
        }

        [DisplayName("Budget"), Size(19), Scale(4)]
        public Decimal? Budget
        {
            get { return Fields.Budget[this]; }
            set { Fields.Budget[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TitleOriginal; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field MovieId;
            public StringField TitleOriginal;
            public StringField TitleTranslation;
            public StringField Url;
            public StringField Description;
            public Int16Field YearStart;
            public Int16Field YearEnd;
            public DateTimeField ReleaseWorldDate;
            public DateTimeField ReleaseOtherDate;
            public DateTimeField ReleaseDvd;
            public StringField Runtime;
            public DateTimeField CreateDateTime;
            public DateTimeField UpdateDateTime;
            public DateTimeField PublishDateTime;
            public Int32Field Kind;
            public Int32Field Rating;
            public StringField Mpaa;
            public StringField PathImage;
            public BooleanField Nice;
            public Int16Field ContSeason;
            public StringField Tagline;
            public DecimalField Budget;

            public RowFields()
                : base("[dbo].[Movie]")
            {
                LocalTextPrefix = "Movie.Movie";
            }
        }
    }
}