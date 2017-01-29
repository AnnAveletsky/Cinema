

namespace Cinema.Movie.Movie.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Person"), InstanceName("Person"), TwoLevelCached]
    [JsonConverter(typeof(JsonRowConverter))]
    [ModifyPermission("Administration")]
    [LookupScript("Movie.Person")]
    public sealed class PersonRow : Row, IIdRow, INameRow
    {
        [DisplayName("Person Id"), Identity]
        public Int64? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("FullName"), Size(100), QuickSearch]
        public String FullName
        {
            get { return Fields.FullName[this]; }
            set { Fields.FullName[this] = value; }
        }

        [DisplayName("NameOther"), Size(100), QuickSearch]
        public String NameOther
        {
            get { return Fields.NameOther[this]; }
            set { Fields.NameOther[this] = value; }
        }
        [DisplayName("FullNameOther"), Size(100), QuickSearch]
        public String FullNameOther
        {
            get { return Fields.FullNameOther[this]; }
            set { Fields.FullNameOther[this] = value; }
        }
        [DisplayName("Url"), Size(110), NotNull]
        public String Url
        {
            get { return Fields.Url[this]; }
            set { Fields.Url[this] = value; }
        }
        [DisplayName("Birth Date")]
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


        [DisplayName("Gender"), DefaultValue(Movie.Gender.Male)]
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
        public List<CastRow> CastList { get; set; }
        public SortedList<string, ListResponse<MovieRow>> CastSortList { get; set; }
        IIdField IIdRow.IdField
        {
            get { return Fields.PersonId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public PersonRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field PersonId;
            public StringField Name;
            public StringField FullName;
            public StringField NameOther;
            public StringField FullNameOther;
            public StringField Url;
            public DateTimeField BirthDate;
            public DateTimeField DeathDate;
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