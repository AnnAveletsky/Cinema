
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

    [ConnectionKey("Default"), DisplayName("Movie Casts"), InstanceName("Cast"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class MovieCastRow : Row, IIdRow, INameRow
    {
        [DisplayName("Movie Cast Id"), Identity]
        public Int32? MovieCastId
        {
            get { return Fields.MovieCastId[this]; }
            set { Fields.MovieCastId[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitle")]
        public Int32? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Actor/Actress"), NotNull, ForeignKey("[mov].[Person]", "PersonId")]
        [LeftJoin("jPerson"), TextualField("PersonFirstname")]
        [LookupEditor(typeof(PersonRow))]
        public Int32? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("Character"), Size(50), QuickSearch]
        public String Character
        {
            get { return Fields.Character[this]; }
            set { Fields.Character[this] = value; }
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

        [DisplayName("Person Firstname"), Expression("jPerson.[Firstname]")]
        public String PersonFirstname
        {
            get { return Fields.PersonFirstname[this]; }
            set { Fields.PersonFirstname[this] = value; }
        }

        [DisplayName("Person Lastname"), Expression("jPerson.[Lastname]")]
        public String PersonLastname
        {
            get { return Fields.PersonLastname[this]; }
            set { Fields.PersonLastname[this] = value; }
        }

        [DisplayName("Actor/Actress"), Expression("(jPerson.Firstname + ' ' + jPerson.Lastname)")]
        public String PersonFullname
        {
            get { return Fields.PersonFullname[this]; }
            set { Fields.PersonFullname[this] = value; }
        }

        [DisplayName("Person Birth Date"), Expression("jPerson.[BirthDate]")]
        public DateTime? PersonBirthDate
        {
            get { return Fields.PersonBirthDate[this]; }
            set { Fields.PersonBirthDate[this] = value; }
        }

        [DisplayName("Person Birth Place"), Expression("jPerson.[BirthPlace]")]
        public String PersonBirthPlace
        {
            get { return Fields.PersonBirthPlace[this]; }
            set { Fields.PersonBirthPlace[this] = value; }
        }

        [DisplayName("Person Gender"), Expression("jPerson.[Gender]")]
        public Int32? PersonGender
        {
            get { return Fields.PersonGender[this]; }
            set { Fields.PersonGender[this] = value; }
        }

        [DisplayName("Person Height"), Expression("jPerson.[Height]")]
        public Int32? PersonHeight
        {
            get { return Fields.PersonHeight[this]; }
            set { Fields.PersonHeight[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.MovieCastId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Character; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public MovieCastRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field MovieCastId;
            public Int32Field MovieId;
            public Int32Field PersonId;
            public StringField Character;

            public StringField MovieTitle;
            public StringField MovieDescription;
            public StringField MovieStoryline;
            public Int32Field MovieYear;
            public DateTimeField MovieReleaseDate;
            public Int32Field MovieRuntime;
            public Int32Field MovieKind;

            public StringField PersonFirstname;
            public StringField PersonLastname;
            public StringField PersonFullname;
            public DateTimeField PersonBirthDate;
            public StringField PersonBirthPlace;
            public Int32Field PersonGender;
            public Int32Field PersonHeight;

            public RowFields()
                : base("[mov].[MovieCast]")
            {
                LocalTextPrefix = "MovieDB.MovieCast";
            }
        }
    }
}