

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

    [ConnectionKey("Default"), DisplayName("ServicePath"), InstanceName("ServicePath"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class ServicePathRow : Row, IIdRow, INameRow
    {
        [DisplayName("Service Path Id"), Identity]
        public Int16? ServicePathId
        {
            get { return Fields.ServicePathId[this]; }
            set { Fields.ServicePathId[this] = value; }
        }

        [DisplayName("Path"), Size(300), NotNull, QuickSearch]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }

        [DisplayName("Service"), NotNull, ForeignKey("[mov].[Service]", "ServiceId"), LeftJoin("jService"), TextualField("ServiceName")]
        public Int16? ServiceId
        {
            get { return Fields.ServiceId[this]; }
            set { Fields.ServiceId[this] = value; }
        }

        [DisplayName("Service Name"), Expression("jService.[Name]")]
        public String ServiceName
        {
            get { return Fields.ServiceName[this]; }
            set { Fields.ServiceName[this] = value; }
        }

        [DisplayName("Service Api"), Expression("jService.[Api]")]
        public String ServiceApi
        {
            get { return Fields.ServiceApi[this]; }
            set { Fields.ServiceApi[this] = value; }
        }

        [DisplayName("Service Max Rating"), Expression("jService.[MaxRating]")]
        public Int16? ServiceMaxRating
        {
            get { return Fields.ServiceMaxRating[this]; }
            set { Fields.ServiceMaxRating[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.ServicePathId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Path; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ServicePathRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field ServicePathId;
            public StringField Path;
            public Int16Field ServiceId;

            public StringField ServiceName;
            public StringField ServiceApi;
            public Int16Field ServiceMaxRating;

            public RowFields()
                : base("[mov].[ServicePath]")
            {
                LocalTextPrefix = "Movie.ServicePath";
            }
        }
    }
}