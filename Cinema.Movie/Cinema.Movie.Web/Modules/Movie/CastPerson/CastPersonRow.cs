

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

    [ConnectionKey("Default"), DisplayName("CastPerson"), InstanceName("CastPerson"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class CastPersonRow : Row, IIdRow
    {
        [DisplayName("Cast Person Id"), Identity]
        public Int32? CastPersonId
        {
            get { return Fields.CastPersonId[this]; }
            set { Fields.CastPersonId[this] = value; }
        }

        [DisplayName("Cast"), NotNull, ForeignKey("[mov].[Cast]", "CastId"), LeftJoin("jCast"), TextualField("CastCharacter")]
        public Int16? CastId
        {
            get { return Fields.CastId[this]; }
            set { Fields.CastId[this] = value; }
        }

        [DisplayName("Person"), NotNull, ForeignKey("[mov].[Person]", "PersonId"), LeftJoin("jPerson"), TextualField("PersonFirstNameEn")]
        public Int64? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("Cast Character"), Expression("jCast.[Character]")]
        public String CastCharacter
        {
            get { return Fields.CastCharacter[this]; }
            set { Fields.CastCharacter[this] = value; }
        }

        [DisplayName("Person First Name En"), Expression("jPerson.[FirstNameEn]")]
        public String PersonFirstNameEn
        {
            get { return Fields.PersonFirstNameEn[this]; }
            set { Fields.PersonFirstNameEn[this] = value; }
        }

        [DisplayName("Person Middle Name En"), Expression("jPerson.[MiddleNameEn]")]
        public String PersonMiddleNameEn
        {
            get { return Fields.PersonMiddleNameEn[this]; }
            set { Fields.PersonMiddleNameEn[this] = value; }
        }

        [DisplayName("Person Last Name En"), Expression("jPerson.[LastNameEn]")]
        public String PersonLastNameEn
        {
            get { return Fields.PersonLastNameEn[this]; }
            set { Fields.PersonLastNameEn[this] = value; }
        }

        [DisplayName("Person First Name Other"), Expression("jPerson.[FirstNameOther]")]
        public String PersonFirstNameOther
        {
            get { return Fields.PersonFirstNameOther[this]; }
            set { Fields.PersonFirstNameOther[this] = value; }
        }

        [DisplayName("Person Middle Name Other"), Expression("jPerson.[MiddleNameOther]")]
        public String PersonMiddleNameOther
        {
            get { return Fields.PersonMiddleNameOther[this]; }
            set { Fields.PersonMiddleNameOther[this] = value; }
        }

        [DisplayName("Person Last Name Other"), Expression("jPerson.[LastNameOther]")]
        public String PersonLastNameOther
        {
            get { return Fields.PersonLastNameOther[this]; }
            set { Fields.PersonLastNameOther[this] = value; }
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

        [DisplayName("Person About"), Expression("jPerson.[About]")]
        public String PersonAbout
        {
            get { return Fields.PersonAbout[this]; }
            set { Fields.PersonAbout[this] = value; }
        }

        [DisplayName("Person Path Image"), Expression("jPerson.[PathImage]")]
        public String PersonPathImage
        {
            get { return Fields.PersonPathImage[this]; }
            set { Fields.PersonPathImage[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.CastPersonId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CastPersonRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field CastPersonId;
            public Int16Field CastId;
            public Int64Field PersonId;

            public StringField CastCharacter;

            public StringField PersonFirstNameEn;
            public StringField PersonMiddleNameEn;
            public StringField PersonLastNameEn;
            public StringField PersonFirstNameOther;
            public StringField PersonMiddleNameOther;
            public StringField PersonLastNameOther;
            public DateTimeField PersonBirthDate;
            public DateTimeField PersonDeathDate;
            public StringField PersonBirthPlace;
            public Int16Field PersonGender;
            public StringField PersonAbout;
            public StringField PersonPathImage;

            public RowFields()
                : base("[mov].[CastPerson]")
            {
                LocalTextPrefix = "Movie.CastPerson";
            }
        }
    }
}