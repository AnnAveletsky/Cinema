

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
    [ModifyPermission("Administration")]
    public sealed class CastRow : Row, IIdRow, INameRow
    {
        [DisplayName("Cast Id"), Identity]
        public Int16? CastId
        {
            get { return Fields.CastId[this]; }
            set { Fields.CastId[this] = value; }
        }

        [DisplayName("Character"), Size(50), NotNull, QuickSearch]
        public String Character
        {
            get { return Fields.Character[this]; }
            set { Fields.Character[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.CastId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Character; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CastRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field CastId;
            public StringField Character;

            public RowFields()
                : base("[mov].[Cast]")
            {
                LocalTextPrefix = "Movie.Cast";
            }
        }
    }
}