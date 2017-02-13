using Admin.Migrations;
using FluentMigrator;
using System;

namespace Admin.Migrations.MovieDB
{
    [Migration(20160607115100)]
    public class MovieDB_20160607_115100_Initial : Migration
    {
        public override void Up()
        {
            this.CreateTableWithId32("Genre", "GenreId", s => s
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Icon").AsString(100).Nullable()
                .WithColumn("Style").AsString(300).Nullable().WithDefaultValue("width:50%;font-size:1.2vw;"));

            this.CreateTableWithId32("Country", "CountryId", s => s
                .WithColumn("Name").AsString(300).NotNullable()
                .WithColumn("NameOther").AsString(300).Nullable()
                .WithColumn("Code").AsString(100).Nullable()
                .WithColumn("Icon").AsString(100).Nullable());

            this.CreateTableWithId64("Tag", "TagId", s => s
                .WithColumn("Name").AsString(50).NotNullable());

            this.CreateTableWithId64("Person", "PersonId", s => s
               .WithColumn("Name").AsString(100).NotNullable()
               .WithColumn("Url").AsString(110).NotNullable()
               .WithColumn("FullName").AsString(100).Nullable()
               .WithColumn("NameOther").AsString(100).Nullable()
               .WithColumn("FullNameOther").AsString(100).Nullable()
               .WithColumn("BirthDate").AsDate().Nullable()
               .WithColumn("DeathDate").AsDate().Nullable()
               .WithColumn("Gender").AsInt16().Nullable()
               .WithColumn("About").AsString(1400).Nullable()
               .WithColumn("PathImage").AsString(300).Nullable());
        }
        public override void Down()
        {
        }
    }
}