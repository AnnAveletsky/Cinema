using Cinema.Migrations;
using FluentMigrator;
using Serenity.Data;
using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160607115103)]
    public class MovieDB_20160607_115103_ServicePath : Migration
    {
        public override void Up()
        {
            this.CreateTableWithId32("ServicePath", "ServicePathId", s => s
               .WithColumn("Path").AsString(300).NotNullable()
               .WithColumn("Kind").AsInt32().Nullable()
               .WithColumn("ServiceId").AsInt32().NotNullable().ForeignKey("FK_ServicePath_ServiceId", "Service", "ServiceId"), checkExists: true);

            var db = new Movie.Repositories.ServiceRepository();
            var connect = SqlConnections.NewFor<Movie.Entities.ServiceRow>();

            var kodik = db.List(connect, new Serenity.Services.ListRequest() {Criteria=new Criteria("Name") == "kodik" }).Entities.First();

            Insert.IntoTable("ServicePath").Row(new
            {
                Path = Path.Combine(HostingEnvironment.MapPath("~/App_Data/films.json")),
                Kind = (Int32)Movie.MovieKind.Film,
                ServiceId= kodik.ServiceId
            });
            Insert.IntoTable("ServicePath").Row(new
            {
                Path = Path.Combine(HostingEnvironment.MapPath("~/App_Data/serials.json")),
                Kind = (Int32)Movie.MovieKind.TvSeries,
                ServiceId = kodik.ServiceId
            });


            var GetMovieCC = db.List(connect, new Serenity.Services.ListRequest() { Criteria = new Criteria("Name") == "GetMovieCC" }).Entities.First();

            Insert.IntoTable("ServicePath").Row(new
            {
                Path = "http://getmovie.cc/get/movies.xml",
                ServiceId = GetMovieCC.ServiceId
            });
            Insert.IntoTable("ServicePath").Row(new
            {
                Path = "http://getmovie.cc/get/movies-russian.xml",
                ServiceId = GetMovieCC.ServiceId
            });
            Insert.IntoTable("ServicePath").Row(new
            {
                Path = "http://getmovie.cc/get/movies-anime.xml",
                ServiceId = GetMovieCC.ServiceId
            });
            Insert.IntoTable("ServicePath").Row(new
            {
                Path = "http://getmovie.cc/get/serials.xml",
                ServiceId = GetMovieCC.ServiceId
            });
            Insert.IntoTable("ServicePath").Row(new
            {
                Path = "http://getmovie.cc/get/serials-russian.xml",
                ServiceId = GetMovieCC.ServiceId
            });
            Insert.IntoTable("ServicePath").Row(new
            {
                Path = "http://getmovie.cc/get/serials-anime.xml",
                ServiceId = GetMovieCC.ServiceId
            });

        }
        public override void Down()
        {
        }
    }
}