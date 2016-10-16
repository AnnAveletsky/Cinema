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
                .WithColumn("Path").AsString(200).NotNullable()
                .WithColumn("Size").AsString(2).NotNullable();

        }
        public override void Down()
        {
        }
    }
}