

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

    [ConnectionKey("Default"), DisplayName("Service"), InstanceName("Service"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class ServiceRow : Row, IIdRow, INameRow
    {
        [DisplayName("Service Id"), Identity]
        public Int16? ServiceId
        {
            get { return Fields.ServiceId[this]; }
            set { Fields.ServiceId[this] = value; }
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Api"), Size(300), NotNull]
        public String Api
        {
            get { return Fields.Api[this]; }
            set { Fields.Api[this] = value; }
        }

        [DisplayName("Max Rating")]
        public Int16? MaxRating
        {
            get { return Fields.MaxRating[this]; }
            set { Fields.MaxRating[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ServiceId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ServiceRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field ServiceId;
            public StringField Name;
            public StringField Api;
            public Int16Field MaxRating;

            public RowFields()
                : base("[mov].[Service]")
            {
                LocalTextPrefix = "Movie.Service";
            }
        }
    }
}