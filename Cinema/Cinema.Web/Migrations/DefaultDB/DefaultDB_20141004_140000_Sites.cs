using Cinema.Migrations;
using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace Cinema.Migrations.DefaultDB
{

    [Migration(20141004140000)]
    public class DefaultDB_20141004_140000_Sites : AutoReversingMigration
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
                .WithColumn("DataBaseId").AsInt32().NotNullable()
                    .ForeignKey("FK_SiteDataBase_DataBaseId", "DataBase", "DataBaseId"), checkExists: true);

            Insert.IntoTable("Site").Row(new
            {
                Name = "Movie",
                Url= "http://localhost:50559/",
                Title="Kino",
                Color = "#fff",
                Logo= "https://pbs.twimg.com/profile_images/594228734615375872/Nkf9AxvJ.png",
                Background = "http://www.radiohamburg.de/var/ezflow_site/storage/images/radiohh/bilder-videos/nachrichten/hamburg/2010/passage-kino-filme-im-neuen-glanz/06-passage-kino/2664961-1-ger-DE/06-passage-kino_image_1200.jpg",
                DataBaseId=1
            });
        }
    }
}