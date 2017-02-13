using Admin.Migrations;
using FluentMigrator;
using System;

namespace Admin.Migrations.MovieDB
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
                .WithColumn("MaxRating").AsInt16().Nullable());

            this.CreateTableWithId32("ServicePath", "ServicePathId", s => s
               .WithColumn("Path").AsString(300).NotNullable()
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServicePath_ServiceId", "mov", "Service", "ServiceId").NotNullable());

            this.CreateTableWithId64("ServiceRating", "ServiceRatingId", s => s
               .WithColumn("Rating").AsDouble().Nullable()
               .WithColumn("Id").AsInt64().Nullable()
               .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_ServiceRating_MovieId", "mov", "Movie", "MovieId")
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServiceRating_ServiceId", "mov", "Service", "ServiceId").NotNullable());
            
        }
        public override void Down()
        {
        }
    }
}