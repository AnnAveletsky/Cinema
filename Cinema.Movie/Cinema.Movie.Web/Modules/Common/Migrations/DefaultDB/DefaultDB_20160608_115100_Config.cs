using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160608115100)]
    public class DefaultDB_20160608_115100_Config : Migration
    {
        public override void Up()
        {
            Create.Schema("conf");

            Create.Table("Background").InSchema("conf")
                .WithColumn("BackgroundId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Color").AsString(12).NotNullable()
                .WithColumn("Path").AsString(200).NotNullable()
                .WithColumn("Size").AsString(2).NotNullable();

            Create.Table("Settings").InSchema("conf")
                .WithColumn("SettingId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Setting").AsString(500).NotNullable()
                .WithColumn("Value").AsString(500).NotNullable()
                .WithColumn("Type").AsString(30).NotNullable();

            Insert.IntoTable("Settings").InSchema("conf")
                .Row(new
                {
                    Setting = "Language",
                    Value = "ru",
                    Type = "string"
                })
                .Row(new
                {
                    Setting = "Theme",
                    Value = "red",
                    Type = "string"
                })
                .Row(new
                {
                    Setting = "MaxRaiting",
                    Value = "10",
                    Type = "Int32"
                });
        }
        public override void Down()
        {
        }
    }
}