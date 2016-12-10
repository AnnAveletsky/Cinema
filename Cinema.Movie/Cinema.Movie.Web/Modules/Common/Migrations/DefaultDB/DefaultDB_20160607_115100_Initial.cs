using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160607115100)]
    public class DefaultDB_20160607_115100_Initial : Migration
    {
        public override void Up()
        {
            Create.Schema("mov");

            Create.Table("Genre").InSchema("mov")
                .WithColumn("GenreId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Icon").AsString(100).Nullable();

            Create.Table("Movie").InSchema("mov")
                .WithColumn("MovieId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("TitleEn").AsString(200).NotNullable()
                .WithColumn("TitleOther").AsString(200).Nullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("YearStart").AsInt16().Nullable()
                .WithColumn("YearEnd").AsInt16().NotNullable().WithDefaultValue(DateTime.Now.Year)
                .WithColumn("ReleaseWorldDate").AsDate().Nullable()
                .WithColumn("ReleaseOtherDate").AsDate().Nullable()
                .WithColumn("ReleaseDVD").AsDateTime().Nullable()
                .WithColumn("Runtime").AsInt16().Nullable()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("UpdateDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("PublishDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("Kind").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Rating").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("MPAA").AsString(6).Nullable()
                .WithColumn("PathImage").AsString(300).NotNullable()
                .WithColumn("Nice").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ContSeason").AsInt16().Nullable()
                .WithColumn("LastEvent").AsString(300).Nullable()
                .WithColumn("LastEventPublishDateTime").AsDateTime().Nullable()
                .WithColumn("Tagline").AsString(400).Nullable()
                .WithColumn("Budget").AsCurrency().Nullable();

            Create.Table("MovieGenres").InSchema("mov")
                .WithColumn("MovieGenreId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieGenres_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("GenreId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieGenres_GenreId", "mov", "Genre", "GenreId");

            Create.Table("Tag").InSchema("mov")
                .WithColumn("TagId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("MovieTag").InSchema("mov")
                .WithColumn("MovieTagId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("TagId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieTag_TagId", "mov", "Tag", "TagId")
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieTag_MovieId", "mov", "Movie", "MovieId");

            Create.Table("Person").InSchema("mov")
               .WithColumn("PersonId").AsInt64().Identity().PrimaryKey().NotNullable()
               .WithColumn("NameEn").AsString(100).NotNullable()
               .WithColumn("FullNameEn").AsString(100).Nullable()
               .WithColumn("NameOther").AsString(100).Nullable()
               .WithColumn("FullNameOther").AsString(100).Nullable()
               .WithColumn("BirthDate").AsDate().NotNullable()
               .WithColumn("DeathDate").AsDate().Nullable()
               .WithColumn("BirthPlace").AsString(100).Nullable()
               .WithColumn("Gender").AsInt16().NotNullable()
               .WithColumn("About").AsString(1400).Nullable()
               .WithColumn("PathImage").AsString(300).NotNullable();

            Create.Table("Cast").InSchema("mov")
                .WithColumn("CastId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("Character").AsString(50).NotNullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_Cast_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt64().NotNullable()
                    .ForeignKey("FK_Cast_PersonId", "mov", "Person", "PersonId");

            Create.Table("Image").InSchema("mov")
                .WithColumn("ImageId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(500).NotNullable()
                .WithColumn("MovieId").AsInt64().Nullable()
                    .ForeignKey("FK_MovieImage_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt64().Nullable()
                    .ForeignKey("FK_PersonImage_PersonId", "mov", "Person", "PersonId");

            Create.Table("Service").InSchema("mov")
                .WithColumn("ServiceId").AsInt16().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Api").AsString(300).NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                .WithColumn("IntervalRequest").AsInt32().NotNullable().WithDefaultValue(24000)
                .WithColumn("LastEvent").AsString(300).Nullable()
                .WithColumn("LastEventPublishDateTime").AsDateTime().Nullable()
                .WithColumn("MaxRating").AsInt16().Nullable();

            Create.Table("ServicePath").InSchema("mov")
               .WithColumn("ServicePathId").AsInt16().Identity().PrimaryKey().NotNullable()
               .WithColumn("Path").AsString(300).NotNullable()
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServicePath_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("ServiceRating").InSchema("mov")
               .WithColumn("ServiceRatingId").AsInt16().Identity().PrimaryKey().NotNullable()
               .WithColumn("Rating").AsDouble().NotNullable().WithDefaultValue(0)
               .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_ServiceRating_MovieId", "mov", "Movie", "MovieId")
               .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_ServiceRating_ServiceId", "mov", "Service", "ServiceId").NotNullable();

            Create.Table("Video").InSchema("mov")
                .WithColumn("VideoId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(300).Nullable()
                .WithColumn("PathTorrent").AsString(300).Nullable()
                .WithColumn("Name").AsString(300).Nullable()
                .WithColumn("Translation").AsInt16().Nullable().WithDefaultValue(1)
                .WithColumn("Season").AsInt16().Nullable()
                .WithColumn("Serie").AsInt16().Nullable()
                .WithColumn("Storyline").AsString(Int16.MaxValue).Nullable()
                .WithColumn("PlannePublishDate").AsDate().Nullable()
                .WithColumn("ActualPublishDateTime").AsDateTime().Nullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_Video_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("ServiceId").AsInt16()
                    .ForeignKey("FK_Video_ServiceId", "mov", "Service", "ServiceId").NotNullable();
            
        }
        public override void Down()
        {
        }
    }
}