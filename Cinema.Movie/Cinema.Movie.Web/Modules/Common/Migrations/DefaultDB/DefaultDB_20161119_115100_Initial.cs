using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20161119115100)]
    public class DefaultDB_20161119_115100_Initial : Migration
    {
        public override void Up()
        {
            Create.Schema("mov");

            Create.Table("Genre").InSchema("mov")
                .WithColumn("GenreId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable();

            Create.Table("Movie").InSchema("mov")
                .WithColumn("MovieId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("TitleEn").AsString(200).NotNullable()
                .WithColumn("TitleOther").AsString(200).Nullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Storyline").AsString(Int32.MaxValue).Nullable()
                .WithColumn("YearStart").AsInt16().Nullable()
                .WithColumn("YearEnd").AsInt16().NotNullable().WithDefaultValue(DateTime.Now.Year)
                .WithColumn("ReleaseWorldDate").AsDate().Nullable()
                .WithColumn("ReleaseOtherDate").AsDate().Nullable()
                .WithColumn("ReleaseDVD").AsDateTime().Nullable()
                .WithColumn("Runtime").AsInt16().Nullable()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("UpdateDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("PublishDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("Kind").AsInt16().NotNullable().WithDefaultValue(1)
                .WithColumn("Rating").AsInt16().NotNullable().WithDefaultValue(1)
                .WithColumn("MPAA").AsString(6).Nullable()
                .WithColumn("ContSuffrage").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("PathImage").AsString(300).NotNullable()
                .WithColumn("PathMiniImage").AsString(300).NotNullable()
                .WithColumn("Nice").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ContSeason").AsInt16().Nullable()
                .WithColumn("LastEvent").AsString(300).Nullable()
                .WithColumn("LastEventPublishDateTime").AsDateTime().Nullable();

            Create.Table("MovieGenres").InSchema("mov")
                .WithColumn("MovieGenreId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieGenres_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("GenreId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieGenres_GenreId", "mov", "Genre", "GenreId");

            Create.Table("Tag").InSchema("mov")
                .WithColumn("TagId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("MovieTag").InSchema("mov")
                .WithColumn("MovieTagId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("TagId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieTag_TagId", "mov", "Tag", "TagId")
                .WithColumn("MovieId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieTag_MovieId", "mov", "Movie", "MovieId");

            Create.Table("Person").InSchema("mov")
                .WithColumn("PersonId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Firstname").AsString(50).NotNullable()
                .WithColumn("Lastname").AsString(50).NotNullable()
                .WithColumn("BirthDate").AsDate().Nullable()
                .WithColumn("BirthPlace").AsString(100).Nullable()
                .WithColumn("Gender").AsInt16().Nullable()
                .WithColumn("Height").AsInt16().Nullable()
                .WithColumn("PathImage").AsString(300).Nullable()
                .WithColumn("PathImageMini").AsString(300).NotNullable();

            Create.Table("MovieCast").InSchema("mov")
                .WithColumn("MovieCastId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Character").AsString(50).Nullable()
                .WithColumn("MovieId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieCast_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieCast_PersonId", "mov", "Person", "PersonId");
                
            Create.Table("Movie.Image").InSchema("mov")
                .WithColumn("ImageId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(500).NotNullable()
                .WithColumn("MovieId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieImage_MovieId", "mov", "Movie", "MovieId");

            Create.Table("Person.Image").InSchema("mov")
                .WithColumn("ImageId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(500).NotNullable()
                .WithColumn("PersonId").AsInt16().NotNullable()
                    .ForeignKey("FK_PersonImage_PersonId", "mov", "Person", "PersonId");

            Create.Table("Service").InSchema("mov")
                .WithColumn("ServiceId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Api").AsString(300).NotNullable()
                .WithColumn("MaxRating").AsInt16().Nullable();

            Create.Table("Service.Path").InSchema("mov")
               .WithColumn("ServicePathId").AsInt16().Identity().PrimaryKey().NotNullable()
               .WithColumn("Path").AsString(300).NotNullable()
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServicePath_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("Service.Rating").InSchema("mov")
               .WithColumn("ServiceRatingId").AsInt16().Identity().PrimaryKey().NotNullable()
               .WithColumn("Rating").AsInt16().NotNullable().WithDefaultValue(0)
               .WithColumn("ContSuffrage").AsInt16().NotNullable().WithDefaultValue(0)
               .WithColumn("MovieId").AsInt16().NotNullable()
                    .ForeignKey("FK_ServiceRating_MovieId", "mov", "Movie", "MovieId")
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServiceRating_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("Video").InSchema("mov")
                .WithColumn("VudeoId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(300).Nullable()
                .WithColumn("Name").AsString(300).Nullable()
                .WithColumn("Translation").AsInt16().Nullable().WithDefaultValue(1)
                .WithColumn("Season").AsInt16().Nullable()
                .WithColumn("Serie").AsInt16().Nullable()
                .WithColumn("PlannePublishDate").AsDate().Nullable()
                .WithColumn("ActualPublishDateTime").AsDateTime().Nullable()
                .WithColumn("MovieId").AsInt16().NotNullable()
                    .ForeignKey("FK_Video_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_Video_ServiceId", "mov", "Service", "ServiceId").NotNullable();
            
        }
        public override void Down()
        {
        }
    }
}