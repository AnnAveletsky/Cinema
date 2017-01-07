

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

    [ConnectionKey("Default"), DisplayName("Cast"), InstanceName("Cast"), TwoLevelCached]
    [JsonConverter(typeof(JsonRowConverter))]
    [ModifyPermission("Administration")]
    [LookupScript("Movie.Cast")]
    public sealed class CastRow : Row, IIdRow, INameRow
    {
        [DisplayName("Cast Id"), Identity]
        public Int64? CastId
        {
            get { return Fields.CastId[this]; }
            set { Fields.CastId[this] = value; }
        }

        [DisplayName("CharacterEn"), Size(100), NotNull, QuickSearch]
        public String CharacterEn
        {
            get { return Fields.CharacterEn[this]; }
            set { Fields.CharacterEn[this] = value; }
        }
        [DisplayName("CharacterOther"), Size(100), NotNull, QuickSearch]
        public String CharacterOther
        {
            get { return Fields.CharacterOther[this]; }
            set { Fields.CharacterOther[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("TitleOriginal")]
        [LookupEditor(typeof(MovieRow))]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Person"), NotNull, ForeignKey("[mov].[Person]", "PersonId"), LeftJoin("jPerson"), TextualField("PersonName")]
        [LookupEditor(typeof(PersonRow))]
        public Int64? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("Movie Title En"), Expression("jMovie.[TitleOriginal]")]
        public String MovieTitleOriginal
        {
            get { return Fields.MovieTitleOriginal[this]; }
            set { Fields.MovieTitleOriginal[this] = value; }
        }
        [DisplayName("Movie Title Other"), Expression("jMovie.[TitleTranslation]")]
        public String MovieTitleTranslation
        {
            get { return Fields.MovieTitleTranslation[this]; }
            set { Fields.MovieTitleTranslation[this] = value; }
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

        [DisplayName("Movie Path Image"), Expression("jMovie.[PathImage]")]
        public String MoviePathImage
        {
            get { return Fields.MoviePathImage[this]; }
            set { Fields.MoviePathImage[this] = value; }
        }
        [DisplayName("Person Name"), Expression("jPerson.[Name]")]
        public String PersonName
        {
            get { return Fields.PersonName[this]; }
            set { Fields.PersonName[this] = value; }
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

        [DisplayName("Person Birth Place"), Expression("jPerson.[BirthPlace]")]
        public String PersonBirthPlace
        {
            get { return Fields.PersonBirthPlace[this]; }
            set { Fields.PersonBirthPlace[this] = value; }
        }

        [DisplayName("Person Gender"), Expression("jPerson.[Gender]")]
        public Int16? PersonGender
        {
            get { return Fields.PersonGender[this]; }
            set { Fields.PersonGender[this] = value; }
        }

        [DisplayName("Person Path Image"), Expression("jPerson.[PathImage]")]
        public String PersonPathImage
        {
            get { return Fields.PersonPathImage[this]; }
            set { Fields.PersonPathImage[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.CastId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CharacterEn; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CastRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field CastId;
            public StringField CharacterEn;
            public StringField CharacterOther;
            public Int64Field MovieId;
            public Int64Field PersonId;

            public StringField MovieTitleOriginal;
            public StringField MovieTitleTranslation;
            public Int16Field MovieYearStart;
            public Int16Field MovieYearEnd;
            public StringField MoviePathImage;

            public StringField PersonName;
            public StringField PersonFullName;
            public StringField PersonNameOther;
            public StringField PersonFullNameOther;
            public DateTimeField PersonBirthDate;
            public DateTimeField PersonDeathDate;
            public StringField PersonBirthPlace;
            public Int16Field PersonGender;
            public StringField PersonPathImage;
            

            public RowFields()
                : base("[mov].[Cast]")
            {
                LocalTextPrefix = "Movie.Cast";
            }
        }
    }
}