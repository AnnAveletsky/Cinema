using FluentMigrator;
using System;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160419115100)]
    public class MovieDB_20160419_115100_MovieTable : Migration
    {
        public override void Up()
        {
            Create.Schema("mov");

            Create.Table("Genre").InSchema("mov")
                .WithColumn("GenreId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable();

            Create.Table("Movie").InSchema("mov")
                .WithColumn("MovieId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Storyline").AsString(Int32.MaxValue).Nullable()
                .WithColumn("Year").AsInt32().Nullable()
                .WithColumn("ReleaseDate").AsDateTime().Nullable()
                .WithColumn("Runtime").AsInt32().Nullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("PublishDate").AsDateTime().NotNullable()
                .WithColumn("Kind").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Image").AsString(300).NotNullable();

            Create.Table("MovieGenres").InSchema("mov")
                .WithColumn("MovieGenreId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieGenres_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("GenreId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieGenres_GenreId", "mov", "Genre", "GenreId");

            Create.Table("Person").InSchema("mov")
                .WithColumn("PersonId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Firstname").AsString(50).NotNullable()
                .WithColumn("Lastname").AsString(50).NotNullable()
                .WithColumn("BirthDate").AsDateTime().Nullable()
                .WithColumn("BirthPlace").AsString(100).Nullable()
                .WithColumn("Gender").AsInt32().Nullable()
                .WithColumn("Height").AsInt32().Nullable()
                .WithColumn("Image").AsString(100).Nullable();

            Create.Table("MovieCast").InSchema("mov")
                .WithColumn("MovieCastId").AsInt32().Identity()
                    .PrimaryKey().NotNullable()
                .WithColumn("Character").AsString(50).Nullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieCast_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieCast_PersonId", "mov", "Person", "PersonId");
                
            Create.Table("Movie.Image").InSchema("mov")
                .WithColumn("ImageId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(500).NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieImage_MovieId", "mov", "Movie", "MovieId");

            Create.Table("Person.Image").InSchema("mov")
                .WithColumn("ImageId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(500).NotNullable()
                .WithColumn("PersonId").AsInt32().NotNullable()
                    .ForeignKey("FK_PersonImage_PersonId", "mov", "Person", "PersonId");

            Create.Table("Service").InSchema("mov")
                .WithColumn("ServiceId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Api").AsString(300).NotNullable()
                .WithColumn("MaxRating").AsInt32().Nullable();

            Create.Table("Service.Path").InSchema("mov")
               .WithColumn("ServicePathId").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Path").AsString(300).NotNullable()
               .WithColumn("ServiceId").AsInt32()
                    .ForeignKey("FK_ServicePath_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("Service.Rating").InSchema("mov")
               .WithColumn("ServiceRatingId").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Rating").AsInt32().NotNullable()
               .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_ServiceRating_MovieId", "mov", "Movie", "MovieId")
               .WithColumn("ServiceId").AsInt32()
                    .ForeignKey("FK_ServiceRating_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("Video").InSchema("mov")
                .WithColumn("VudeoId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(300).Nullable()
                .WithColumn("Publish").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_Video_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("ServiceId").AsInt32()
                    .ForeignKey("FK_Video_ServiceId", "mov", "Service", "ServiceId").NotNullable();
        }
        public override void Down()
        {
        }
    }
}