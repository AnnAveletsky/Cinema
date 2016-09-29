using FluentMigrator;
using System;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160319115100)]
    public class MovieDB_20160319_115100_Config : Migration
    {
        public override void Up()
        {
            Create.Schema("conf");

            Create.Table("Background").InSchema("conf")
                .WithColumn("BackgroundId").AsInt16().NotNullable().PrimaryKey().Identity()
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