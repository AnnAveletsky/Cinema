using Cinema.Migrations;
using FluentMigrator;
using System;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160607115102)]
    public class MovieDB_20160607_115102_Service : Migration
    {
        public override void Up()
        {
            this.CreateTableWithId32("Service", "ServiceId", s => s
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Api").AsString(300).NotNullable()
                .WithColumn("Url").AsString(300).NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("IntervalRequest").AsInt32().NotNullable().WithDefaultValue(24000)
                .WithColumn("MaxRating").AsInt32().Nullable());

            this.CreateTableWithId64("ServiceRating", "ServiceRatingId", s => s
               .WithColumn("Rating").AsDouble().Nullable()
               .WithColumn("Id").AsInt64().Nullable()
               .WithColumn("MovieId").AsInt64().NotNullable().ForeignKey("FK_Movie_MovieId", "Movie", "MovieId")
               .WithColumn("ServiceId").AsInt32().NotNullable().ForeignKey("FK_ServiceRating_ServiceId", "Service", "ServiceId"), checkExists: true);

            Insert.IntoTable("Service").Row(new
            {
                Name = "kinopoisk",
                Api = "http://kinopoisk.cf/",
                Url = "http://kinopoisk.ru/",
            });
            Insert.IntoTable("Service").Row(new
            {
                Name = "kodik",
                Api = "http://kodik.top/",
                Url = "http://kodik.top/",
            });
            Insert.IntoTable("Service").Row(new
            {
                Name = "GetMovieCC",
                Api = "http://getmovie.cc/",
                Url = "http://getmovie.cc/",
            });
            Insert.IntoTable("Service").Row(new
            {
                Name = "rutube",
                Api = "http://rutube.ru/api/",
                Url = "http://rutube.ru",
            });
        }
        public override void Down()
        {
        }
    }
}