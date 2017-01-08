using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160607115102)]
    public class DefaultDB_20160607_115102_Service : Migration
    {
        public override void Up()
        {

            Create.Table("Service").InSchema("mov")
                .WithColumn("ServiceId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Api").AsString(300).NotNullable()
                .WithColumn("Url").AsString(300).NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("IntervalRequest").AsInt32().NotNullable().WithDefaultValue(24000)
                .WithColumn("MaxRating").AsInt16().Nullable();
            
            Create.Table("ServicePath").InSchema("mov")
               .WithColumn("ServicePathId").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Path").AsString(300).NotNullable()
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServicePath_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("ServiceRating").InSchema("mov")
               .WithColumn("ServiceRatingId").AsInt64().Identity().PrimaryKey().NotNullable()
               .WithColumn("Rating").AsDouble().Nullable()
               .WithColumn("Id").AsInt64().Nullable()
               .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_ServiceRating_MovieId", "mov", "Movie", "MovieId")
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServiceRating_ServiceId", "mov", "Service", "ServiceId").NotNullable();
            
        }
        public override void Down()
        {
        }
    }
}