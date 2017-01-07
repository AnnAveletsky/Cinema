using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160607115100)]
    public class DefaultDB_20160607_115100_Initial : Migration
    {
        public override void Up()
        {
            Create.Schema("mov");

            Create.Table("Genre").InSchema("mov")
                .WithColumn("GenreId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Icon").AsString(100).Nullable();

            Create.Table("Country").InSchema("mov")
                .WithColumn("CountryId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(300).NotNullable();

            Create.Table("Tag").InSchema("mov")
                .WithColumn("TagId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("Person").InSchema("mov")
               .WithColumn("PersonId").AsInt64().Identity().PrimaryKey().NotNullable()
               .WithColumn("Name").AsString(100).NotNullable()
               .WithColumn("FullName").AsString(100).Nullable()
               .WithColumn("NameOther").AsString(100).Nullable()
               .WithColumn("FullNameOther").AsString(100).Nullable()
               .WithColumn("BirthDate").AsDate().Nullable()
               .WithColumn("DeathDate").AsDate().Nullable()
               .WithColumn("Gender").AsInt16().Nullable()
               .WithColumn("About").AsString(1400).Nullable()
               .WithColumn("PathImage").AsString(300).Nullable();
        }
        public override void Down()
        {
        }
    }
}