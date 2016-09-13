
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

    [ConnectionKey("Default"), DisplayName("Person"), InstanceName("Person"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    [LookupScript("MovieDB.Person")]
    public sealed class PersonRow : Row, IIdRow, INameRow
    {
        [DisplayName("Person Id"), Identity]
        public Int32? PersonId
        {
            get { return Fields.PersonId[this]; }
            set { Fields.PersonId[this] = value; }
        }

        [DisplayName("Firstname"), Size(50), NotNull, QuickSearch]
        public String Firstname
        {
            get { return Fields.Firstname[this]; }
            set { Fields.Firstname[this] = value; }
        }

        [DisplayName("Lastname"), Size(50), NotNull]
        public String Lastname
        {
            get { return Fields.Lastname[this]; }
            set { Fields.Lastname[this] = value; }
        }

        [DisplayName("Birth Date")]
        public DateTime? BirthDate
        {
            get { return Fields.BirthDate[this]; }
            set { Fields.BirthDate[this] = value; }
        }

        [DisplayName("Birth Place"), Size(100)]
        public String BirthPlace
        {
            get { return Fields.BirthPlace[this]; }
            set { Fields.BirthPlace[this] = value; }
        }

        [DisplayName("Gender")]
        public Gender? Gender
        {
            get { return (Gender?)Fields.Gender[this]; }
            set { Fields.Gender[this] = (Int32?)value; }
        }

        [DisplayName("Height")]
        public Int32? Height
        {
            get { return Fields.Height[this]; }
            set { Fields.Height[this] = value; }
        }

        [DisplayName("Full Name"),
         Expression("(t0.Firstname + ' ' + t0.Lastname)"), QuickSearch]
        public String Fullname
        {
            get { return Fields.Fullname[this]; }
            set { Fields.Fullname[this] = value; }
        }

        [DisplayName("Primary Image"), Size(100), ImageUploadEditor(FilenameFormat = "Person/PrimaryImage/~")]
        public string PrimaryImage
        {
            get { return Fields.PrimaryImage[this]; }
            set { Fields.PrimaryImage[this] = value; }
        }

        [DisplayName("Gallery Images"), MultipleImageUploadEditor(FilenameFormat = "Person/GalleryImages/~")]
        public string GalleryImages
        {
            get { return Fields.GalleryImages[this]; }
            set { Fields.GalleryImages[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.PersonId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Fullname; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public PersonRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field PersonId;
            public StringField Firstname;
            public StringField Lastname;
            public StringField Fullname;
            public DateTimeField BirthDate;
            public StringField BirthPlace;
            public Int32Field Gender;
            public Int32Field Height;
            public readonly StringField PrimaryImage;
            public readonly StringField GalleryImages;

            public RowFields()
                : base("[mov].[Person]")
            {
                LocalTextPrefix = "MovieDB.Person";
            }
        }
    }
}