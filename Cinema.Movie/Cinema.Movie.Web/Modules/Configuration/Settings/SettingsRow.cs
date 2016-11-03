

namespace Cinema.Movie.Configuration.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("Settings"), InstanceName("Settings"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class SettingsRow : Row, IIdRow, INameRow
    {
        [DisplayName("Setting Id"), Identity]
        public Int16? SettingId
        {
            get { return Fields.SettingId[this]; }
            set { Fields.SettingId[this] = value; }
        }

        [DisplayName("Setting"), Size(500), NotNull, QuickSearch]
        public String Setting
        {
            get { return Fields.Setting[this]; }
            set { Fields.Setting[this] = value; }
        }

        [DisplayName("Value"), Size(500), NotNull]
        public String Value
        {
            get { return Fields.Value[this]; }
            set { Fields.Value[this] = value; }
        }

        [DisplayName("Type"), Size(30), NotNull]
        public String Type
        {
            get { return Fields.Type[this]; }
            set { Fields.Type[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.SettingId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Setting; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public SettingsRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int16Field SettingId;
            public StringField Setting;
            public StringField Value;
            public StringField Type;

            public RowFields()
                : base("[conf].[Settings]")
            {
                LocalTextPrefix = "Configuration.Settings";
            }
        }
    }
}