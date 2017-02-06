

namespace Cinema.Movie.Movie.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Movie"), DisplayName("Genre"), InstanceName("Genre"), TwoLevelCached]
    [ModifyPermission("Administration")]
    [JsonConverter(typeof(JsonRowConverter))]
    [LookupScript("Movie.Genre")]
    public sealed class GenreRow : Row, IIdRow, INameRow
    {
        [DisplayName("Genre Id"), Identity]
        public Int16? GenreId
        {
            get { return Fields.GenreId[this]; }
            set { Fields.GenreId[this] = value; }
        }

        [DisplayName("Name"), Size(100), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Icon"), Size(100), QuickSearch]
        public String Icon
        {
            get { return Fields.Icon[this]; }
            set { Fields.Icon[this] = value; }
        }
       
        [DisplayName("Style"),DefaultValue("width:50%;font-size:1.2vw;")]
        public String Style
        {
            get { return Fields.Style[this]; }
            set { Fields.Style[this] = value; }
        }
        [DisplayName("Movies")]
        [LookupEditor(typeof(MovieRow), Multiple = true), NotMapped]
        [LinkingSetRelation(typeof(MovieGenreRow), "GenreId", "MovieId")]
        public List<Int64> MovieList
        {
            get { return Fields.MovieList[this]; }
            set { Fields.MovieList[this] = value; }
        }
        IIdField IIdRow.IdField
        {
            get { return Fields.GenreId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public GenreRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field GenreId;
            public StringField Name;
            public StringField Icon;
            public StringField Style;
            public ListField<Int64> MovieList;

            public RowFields()
                : base("[mov].[Genre]")
            {
                LocalTextPrefix = "Movie.Genre";
            }
        }
    }
}