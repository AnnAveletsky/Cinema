using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160611181800)]
    public class DefaultDB_20160611_181800_SampleServices : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Service").InSchema("mov")
                .Row(new
                {
                    Name = "kinopoisk.ru",
                    Api = "http://kinopoisk.cf/",
                    MaxRating = 10,
                });
        }

        public override void Down()
        {
        }
    }
}