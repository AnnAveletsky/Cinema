namespace Cinema.Movie.Movie.Entities
{
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Movie"), DisplayName("MovieGenre"), InstanceName("MovieGenre"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class MovieGenreRow : Row, IIdRow
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

        public MovieGenreRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field MovieGenreId;
            public Int64Field MovieId;
            public Int16Field GenreId;
            

            public StringField GenreName;

            public RowFields()
                : base("[mov].[MovieGenre]")
            {
                LocalTextPrefix = "Movie.MovieGenre";
            }
        }
    }
}