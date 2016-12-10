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
            Insert.IntoTable("Service").InSchema("mov")
                .Row(new
                {
                    Name = "IMDb",
                    Api = "https://www.themoviedb.org/",
                    MaxRating = 10,
                });
            Insert.IntoTable("ServiceRating").InSchema("mov")
               .Row(new
               {
                   Rating = 5,
                   MovieId = 1,
                   ServiceId = 1,
               });
            Insert.IntoTable("ServiceRating").InSchema("mov")
               .Row(new
               {
                   Rating = 7,
                   MovieId = 1,
                   ServiceId = 2,
               });
        }

        public override void Down()
        {
        }
    }
}