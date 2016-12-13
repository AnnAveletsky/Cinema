

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

    [ConnectionKey("Default"), DisplayName("Video"), InstanceName("Video"), TwoLevelCached]
    [JsonConverter(typeof(JsonRowConverter))]
    //[ModifyPermission("Administration")]
    [LookupScript("Movie.Video")]
    public sealed class VideoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Video Id"), Identity]
        public Int64? VideoId
        {
            get { return Fields.VideoId[this]; }
            set { Fields.VideoId[this] = value; }
        }

        [DisplayName("Path"), Size(Int32.MaxValue), QuickSearch]
        public String Path
        {
            get { return Fields.Path[this]; }
            set { Fields.Path[this] = value; }
        }
        [DisplayName("Player")]
        public Int16? Player
        {
            get { return Fields.Player[this]; }
            set { Fields.Player[this] = value; }
        }
        [DisplayName("PathTorrent"), Size(300), QuickSearch]
        public String PathTorrent
        {
            get { return Fields.PathTorrent[this]; }
            set { Fields.PathTorrent[this] = value; }
        }
        [DisplayName("Name"), Size(300)]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Translation")]
        public Int16? Translation
        {
            get { return Fields.Translation[this]; }
            set { Fields.Translation[this] = value; }
        }

        [DisplayName("Season")]
        public Int16? Season
        {
            get { return Fields.Season[this]; }
            set { Fields.Season[this] = value; }
        }

        [DisplayName("Serie")]
        public Int16? Serie
        {
            get { return Fields.Serie[this]; }
            set { Fields.Serie[this] = value; }
        }
        [DisplayName("Storyline"), Size(Int16.MaxValue)]
        public String Storyline
        {
            get { return Fields.Storyline[this]; }
            set { Fields.Storyline[this] = value; }
        }
        [DisplayName("Planne Publish Date")]
        public DateTime? PlannePublishDate
        {
            get { return Fields.PlannePublishDate[this]; }
            set { Fields.PlannePublishDate[this] = value; }
        }

        [DisplayName("Actual Publish Date Time")]
        public DateTime? ActualPublishDateTime
        {
            get { return Fields.ActualPublishDateTime[this]; }
            set { Fields.ActualPublishDateTime[this] = value; }
        }

        [DisplayName("Movie"), NotNull, ForeignKey("[mov].[Movie]", "MovieId"), LeftJoin("jMovie"), TextualField("MovieTitleEn")]
        public Int64? MovieId
        {
            get { return Fields.MovieId[this]; }
            set { Fields.MovieId[this] = value; }
        }

        [DisplayName("Service"), ForeignKey("[mov].[Service]", "ServiceId"), LeftJoin("jService"), TextualField("ServiceName")]
        public Int16? ServiceId
        {
            get { return Fields.ServiceId[this]; }
            set { Fields.ServiceId[this] = value; }
        }
        
        [DisplayName("Service Name"), Expression("jService.[Name]")]
        [LookupEditor(typeof(ServiceRow))]
        public String ServiceName
        {
            get { return Fields.ServiceName[this]; }
            set { Fields.ServiceName[this] = value; }
        }
        

        IIdField IIdRow.IdField
        {
            get { return Fields.VideoId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Path; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VideoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field VideoId;
            public StringField Path;
            public Int16Field Player;
            public StringField PathTorrent;
            public StringField Name;
            public Int16Field Translation;
            public Int16Field Season;
            public Int16Field Serie;
            public StringField Storyline;
            public DateTimeField PlannePublishDate;
            public DateTimeField ActualPublishDateTime;
            public Int64Field MovieId;
            public Int16Field ServiceId;
            

            public StringField ServiceName;

            public RowFields()
                : base("[mov].[Video]")
            {
                LocalTextPrefix = "Movie.Video";
            }
        }
    }
}