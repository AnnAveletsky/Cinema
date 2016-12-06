

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

    [ConnectionKey("Default"), DisplayName("Person"), InstanceName("Person"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class PersonRow : Row, IIdRow, INameRow
    {
        [DisplayName("Person Id"), Identity]
        public Int64? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("FirstNameEn"), Size(100), NotNull, QuickSearch]
        public String FirstNameEn
        {
            get { return Fields.FirstNameEn[this]; }
            set { Fields.FirstNameEn[this] = value; }
        }

        [DisplayName("MiddleNameEn"), Size(100), NotNull, QuickSearch]
        public String MiddleNameEn
        {
            get { return Fields.MiddleNameEn[this]; }
            set { Fields.MiddleNameEn[this] = value; }
        }
        [DisplayName("LastNameEn"), Size(100), NotNull, QuickSearch]
        public String LastNameEn
        {
            get { return Fields.LastNameEn[this]; }
            set { Fields.LastNameEn[this] = value; }
        }

        [DisplayName("FirstNameOther"), Size(100), NotNull, QuickSearch]
        public String FirstNameOther
        {
            get { return Fields.FirstNameOther[this]; }
            set { Fields.FirstNameOther[this] = value; }
        }
        [DisplayName("MiddleNameOther"), Size(100), NotNull, QuickSearch]
        public String MiddleNameOther
        {
            get { return Fields.MiddleNameOther[this]; }
            set { Fields.MiddleNameOther[this] = value; }
        }

        [DisplayName("LastNameOther"), Size(100), NotNull, QuickSearch]
        public String LastNameOther
        {
            get { return Fields.LastNameOther[this]; }
            set { Fields.LastNameOther[this] = value; }
        }

        [DisplayName("Birth Date"), NotNull]
        public DateTime? BirthDate
        {
            get { return Fields.BirthDate[this]; }
            set { Fields.BirthDate[this] = value; }
        }
        [DisplayName("Death Date")]
        public DateTime? DeathDate
        {
            get { return Fields.DeathDate[this]; }
            set { Fields.DeathDate[this] = value; }
        }

        [DisplayName("Birth Place"), Size(100)]
        public String BirthPlace
        {
            get { return Fields.BirthPlace[this]; }
            set { Fields.BirthPlace[this] = value; }
        }

        [DisplayName("Gender"), NotNull, DefaultValue(Movie.Gender.Male)]
        public Movie.Gender? Gender
        {
            get { return (Movie.Gender?)Fields.Gender[this]; }
            set { Fields.Gender[this] = (Int16)value; }
        }

        [DisplayName("About"), Size(1400)]
        public String About
        {
            get { return Fields.About[this]; }
            set { Fields.About[this] = value; }
        }

        [DisplayName("Path Image"), Size(300)]
        public String PathImage
        {
            get { return Fields.PathImage[this]; }
            set { Fields.PathImage[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.PersonId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.FirstNameOther; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public PersonRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field PersonId;
            public StringField FirstNameEn;
            public StringField MiddleNameEn;
            public StringField LastNameEn;
            public StringField FirstNameOther;
            public StringField MiddleNameOther;
            public StringField LastNameOther;
            public DateTimeField BirthDate;
            public DateTimeField DeathDate;
            public StringField BirthPlace;
            public Int16Field Gender;
            public StringField About;
            public StringField PathImage;

            public RowFields()
                : base("[mov].[Person]")
            {
                LocalTextPrefix = "Movie.Person";
            }
        }
    }
}