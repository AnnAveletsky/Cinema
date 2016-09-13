
namespace Admin.MovieDB.Entities
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
        public Int32? MovieGenreId
        {
            get { return Fields.MovieGenreId[this]; }
            set { Fields.MovieGenreId[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitle")]
        public Int32? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Genre"), NotNull, ForeignKey("[mov].[Genre]", "GenreId"), LeftJoin("jGenre"), TextualField("GenreName")]
        public Int32? GenreId
        {
            get { return Fields.GenreId[this]; }
            set { Fields.GenreId[this] = value; }
        }

        [DisplayName("Movie Title"), Expression("jMovie.[Title]")]
        public String MovieTitle
        {
            get { return Fields.MovieTitle[this]; }
            set { Fields.MovieTitle[this] = value; }
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

        [DisplayName("Movie Year"), Expression("jMovie.[Year]")]
        public Int32? MovieYear
        {
            get { return Fields.MovieYear[this]; }
            set { Fields.MovieYear[this] = value; }
        }

        [DisplayName("Movie Release Date"), Expression("jMovie.[ReleaseDate]")]
        public DateTime? MovieReleaseDate
        {
            get { return Fields.MovieReleaseDate[this]; }
            set { Fields.MovieReleaseDate[this] = value; }
        }

        [DisplayName("Movie Runtime"), Expression("jMovie.[Runtime]")]
        public Int32? MovieRuntime
        {
            get { return Fields.MovieRuntime[this]; }
            set { Fields.MovieRuntime[this] = value; }
        }

        [DisplayName("Movie Kind"), Expression("jMovie.[Kind]")]
        public Int32? MovieKind
        {
            get { return Fields.MovieKind[this]; }
            set { Fields.MovieKind[this] = value; }
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
            public Int32Field MovieGenreId;
            public Int32Field MovieId;
            public Int32Field GenreId;

            public StringField MovieTitle;
            public StringField MovieDescription;
            public StringField MovieStoryline;
            public Int32Field MovieYear;
            public DateTimeField MovieReleaseDate;
            public Int32Field MovieRuntime;
            public Int32Field MovieKind;

            public StringField GenreName;

            public RowFields()
                : base("[mov].[MovieGenres]")
            {
                LocalTextPrefix = "MovieDB.MovieGenres";
            }
        }
    }
}