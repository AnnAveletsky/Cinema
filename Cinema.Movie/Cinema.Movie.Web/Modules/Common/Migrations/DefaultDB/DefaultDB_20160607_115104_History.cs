using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160607115104)]
    public class DefaultDB_20160607_115104_Initial : Migration
    {
        public override void Up()
        {

            Create.Table("History").InSchema("mov")
                .WithColumn("HistoryId").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserName").AsString(100).NotNullable()
                .WithColumn("Message").AsString(10000).NotNullable()
                .WithColumn("Status").AsBoolean().NotNullable()
                .WithColumn("CastId").AsInt64().ForeignKey("FK_History_CastId", "mov", "Cast", "CastId").Nullable()
                .WithColumn("CountryId").AsInt32().ForeignKey("FK_History_CountryId", "mov", "Country", "CountryId").Nullable()
                .WithColumn("GenreId").AsInt16().ForeignKey("FK_History_GenreId", "mov", "Genre", "GenreId").Nullable()
                .WithColumn("ServiceId").AsInt16().ForeignKey("FK_History_ServiceId", "mov", "Service", "ServiceId").Nullable()
                .WithColumn("MovieId").AsInt64().ForeignKey("FK_History_MovieId", "mov", "Movie", "MovieId").Nullable()
                .WithColumn("PersonId").AsInt64().ForeignKey("FK_History_PersonId", "mov", "Person", "PersonId").Nullable()
                .WithColumn("ImageId").AsInt64().ForeignKey("FK_History_ImageId", "mov", "Image", "ImageId").Nullable()
                .WithColumn("MovieCountryId").AsInt64().ForeignKey("FK_History_MovieCountryId", "mov", "MovieCountry", "MovieCountryId").Nullable()
                .WithColumn("ServicePathId").AsInt32().ForeignKey("FK_History_ServicePathId", "mov", "ServicePath", "ServicePathId").Nullable()
                .WithColumn("ServiceRatingId").AsInt64().ForeignKey("FK_History_ServiceRatingId", "mov", "ServiceRating", "ServiceRatingId").Nullable()
                .WithColumn("MovieTagId").AsInt64().ForeignKey("FK_History_MovieTagId", "mov", "MovieTag", "MovieTagId").Nullable()
                .WithColumn("TagId").AsInt64().ForeignKey("FK_History_TagId", "mov", "Tag", "TagId").Nullable()
                .WithColumn("VideoId").AsInt64().ForeignKey("FK_History_VideoId", "mov", "Video", "VideoId").Nullable()
                .WithColumn("MovieGenreId").AsInt64().ForeignKey("FK_History_MovieGenreId", "mov", "MovieGenre", "MovieGenreId").Nullable();
        }
        public override void Down()
        {
        }
    }
}