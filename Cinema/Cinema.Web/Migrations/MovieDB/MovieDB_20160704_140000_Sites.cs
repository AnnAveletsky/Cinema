using Cinema.Migrations;
using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace Cinema.Migrations.MovieDB
{

    [Migration(20141004140000)]
    public class MovieDB_20141004_140000_Sites : AutoReversingMigration
    {
        public override void Up()
        {
            this.CreateTableWithId32("Site", "SiteId", s => s
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Url").AsString(200).NotNullable()
                .WithColumn("Title").AsString(500).NotNullable()
                .WithColumn("Background").AsString(500).NotNullable().WithDefaultValue("")
                .WithColumn("Logo").AsString(500).NotNullable().WithDefaultValue("")
                .WithColumn("Color").AsString(20).NotNullable().WithDefaultValue("")
                .WithColumn("BackgroundColor").AsString(20).NotNullable().WithDefaultValue("")
                .WithColumn("DataBaseId").AsInt32().NotNullable()
                    .ForeignKey("FK_SiteDataBase_DataBaseId", "DataBase", "DataBaseId"), checkExists: true);

            Insert.IntoTable("Site").Row(new
            {
                Name = "Movie",
                Url= "http://localhost:50559/",
                Title="Kino",
                Color = "#fff",
                Logo= "/Content/img/icon.png",
                Background = "/Content/img/background.png",
                BackgroundColor = "#000",
                DataBaseId =1
            });
        }
    }
}