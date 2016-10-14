using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20161219115100)]
    public class DefaultDB_20161219_115100_Config : Migration
    {
        public override void Up()
        {
            Create.Schema("conf");

            Create.Table("Background").InSchema("conf")
                .WithColumn("BackgroundId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Color").AsString(12).NotNullable()
                .WithColumn("PathLg").AsString(200).NotNullable()
                .WithColumn("PathMd").AsString(200).NotNullable()
                .WithColumn("PathSm").AsString(200).NotNullable()
                .WithColumn("PathXs").AsString(200).NotNullable();

        }
        public override void Down()
        {
        }
    }
}