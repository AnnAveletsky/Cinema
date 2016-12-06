

namespace Cinema.Movie.Movie.Entities
{
    using Cinema.Movie.Migrations.DefaultDB;
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Movie"), InstanceName("Movie"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class MovieRow : Row, IIdRow, INameRow
    {
        [DisplayName("Movie Id"), Identity]
        public Int64? MovieId
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

        [DisplayName("Runtime (mins)")]
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

        [DisplayName("Kind"), NotNull, DefaultValue(MovieKind.Film)]
        public MovieKind? Kind
        {
            get { return (MovieKind?)Fields.Kind[this]; }
            set { Fields.Kind[this] = (Int16?)value; }
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
        [DisplayName("Tagline"), Size(400)]
        public String Tagline
        {
            get { return Fields.Tagline[this]; }
            set { Fields.Tagline[this] = value; }
        }
        [DisplayName("Budget")]
        public Int32? Budget
        {
            get { return Fields.Budget[this]; }
            set { Fields.Budget[this] = value; }
        }
        [DisplayName("Genres")]
        [LookupEditor(typeof(GenreRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieGenresRow), "MovieId", "GenreId")]
        public List<Int16> GenreList
        {
            get { return Fields.GenreList[this]; }
            set { Fields.GenreList[this] = value; }
        }
        [DisplayName("Genres")]
        [LookupEditor(typeof(GenreRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieGenresRow), "MovieId", "GenreName")]
        public List<string> GenreListName
        {
            get { return Fields.GenreListName[this]; }
            set { Fields.GenreListName[this] = value; }
        }
        [DisplayName("Tags")]
        [LookupEditor(typeof(TagRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieTagRow), "MovieId", "TagId")]
        public List<Int16> TagList
        {
            get { return Fields.TagList[this]; }
            set { Fields.TagList[this] = value; }
        }
        [DisplayName("Tags")]
        [LookupEditor(typeof(TagRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieTagRow), "MovieId", "TagName")]
        public List<string> TagListName
        {
            get { return Fields.TagListName[this]; }
            set { Fields.TagListName[this] = value; }
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
            public Int64Field MovieId;
            public StringField TitleEn;
            public StringField TitleOther;
            public StringField Description;
            public Int16Field YearStart;
            public Int16Field YearEnd;
            public DateTimeField ReleaseWorldDate;
            public DateTimeField ReleaseOtherDate;
            public DateTimeField ReleaseDvd;
            public readonly Int16Field Runtime;
            public DateTimeField CreateDateTime;
            public DateTimeField UpdateDateTime;
            public DateTimeField PublishDateTime;
            public readonly Int16Field Kind;
            public Int16Field Rating;
            public StringField Mpaa;
            public StringField PathImage;
            public StringField PathMiniImage;
            public BooleanField Nice;
            public Int16Field ContSeason;
            public StringField LastEvent;
            public DateTimeField LastEventPublishDateTime;
            public StringField Tagline;
            public Int32Field Budget;
            public ListField<Int16> GenreList;
            public ListField<string> GenreListName;
            public ListField<Int16> TagList;
            public ListField<string> TagListName;

            public RowFields()
                : base("[mov].[Movie]")
            {
                LocalTextPrefix = "Movie.Movie";
            }
        }
    }
}