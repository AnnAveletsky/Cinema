using Cinema.Migrations;
using FluentMigrator;
using System;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160607115105)]
    public class MovieDB_20160607_115105_Contents : Migration
    {
        public override void Up()
        {
            this.CreateTableWithId32("Content", "ContentId", s => s
                .WithColumn("Url").AsString(400).NotNullable().Unique()
                .WithColumn("HtmlContent").AsString().NotNullable(), checkExists: true);
        }
        public override void Down()
        {
        }
    }
}