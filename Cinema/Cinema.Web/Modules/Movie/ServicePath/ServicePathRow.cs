

namespace Cinema.Movie.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Movie"), DisplayName("ServicePath"), InstanceName("ServicePath"), TwoLevelCached]
    [ModifyPermission("Administration")]
    public sealed class ServicePathRow : Row, IIdRow, INameRow
    {
        [DisplayName("Service Path Id"), Identity]
        public Int32? ServicePathId
        {
            get { return Fields.ServicePathId[this]; }
            set { Fields.ServicePathId[this] = value; }
        }
        [DisplayName("Kind")]
        public MovieKind? Kind
        {
            get { return (MovieKind?)Fields.Kind[this]; }
            set { Fields.Kind[this] = (Int32?)value; }
        }
        [DisplayName("Path"), Size(300), NotNull, QuickSearch]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }

        [DisplayName("Service"), NotNull, ForeignKey("[dbo].[Service]", "ServiceId"), LeftJoin("jService"), TextualField("ServiceName")]
        public Int32? ServiceId
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

        [DisplayName("Service Url"), Expression("jService.[Url]")]
        public String ServiceUrl
        {
            get { return Fields.ServiceUrl[this]; }
            set { Fields.ServiceUrl[this] = value; }
        }

        [DisplayName("Service Active"), Expression("jService.[Active]")]
        public Boolean? ServiceActive
        {
            get { return Fields.ServiceActive[this]; }
            set { Fields.ServiceActive[this] = value; }
        }

        [DisplayName("Service Interval Request"), Expression("jService.[IntervalRequest]")]
        public Int32? ServiceIntervalRequest
        {
            get { return Fields.ServiceIntervalRequest[this]; }
            set { Fields.ServiceIntervalRequest[this] = value; }
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
            public Int32Field ServicePathId;
            public Int32Field Kind;
            public StringField Path;
            public Int32Field ServiceId;

            public StringField ServiceName;
            public StringField ServiceApi;
            public StringField ServiceUrl;
            public BooleanField ServiceActive;
            public Int32Field ServiceIntervalRequest;
            public Int16Field ServiceMaxRating;

            public RowFields()
                : base("[dbo].[ServicePath]")
            {
                LocalTextPrefix = "Movie.ServicePath";
            }
        }
    }
}