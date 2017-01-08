using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160607115101)]
    public class DefaultDB_20160607_115101_Movie : Migration
    {
        public override void Up()
        {

            Create.Table("Movie").InSchema("mov")
                .WithColumn("MovieId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("TitleOriginal").AsString(400).NotNullable()
                .WithColumn("TitleTranslation").AsString(400).Nullable()
                .WithColumn("Url").AsString(400).NotNullable()
                .WithColumn("Description").AsString(10000).Nullable()
                .WithColumn("YearStart").AsInt16().Nullable()
                .WithColumn("YearEnd").AsInt16().NotNullable().WithDefaultValue(DateTime.Now.Year)
                .WithColumn("ReleaseWorldDate").AsDate().Nullable()
                .WithColumn("ReleaseOtherDate").AsDate().Nullable()
                .WithColumn("ReleaseDVD").AsDateTime().Nullable()
                .WithColumn("Runtime").AsString(300).Nullable()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("UpdateDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("PublishDateTime").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow)
                .WithColumn("Kind").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Rating").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("MPAA").AsString(6).Nullable()
                .WithColumn("PathImage").AsString(300).Nullable()
                .WithColumn("Nice").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ContSeason").AsInt16().Nullable()
                .WithColumn("Tagline").AsString(400).Nullable()
                .WithColumn("Budget").AsCurrency().Nullable();

            Create.Table("MovieCountry").InSchema("mov")
                .WithColumn("MovieCountryId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieCountry_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("CountryId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieCountry_CountryId", "mov", "Country", "CountryId");

            Create.Table("MovieGenre").InSchema("mov")
                .WithColumn("MovieGenreId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieGenre_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("GenreId").AsInt16().NotNullable()
                    .ForeignKey("FK_MovieGenre_GenreId", "mov", "Genre", "GenreId");

            Create.Table("MovieTag").InSchema("mov")
                .WithColumn("MovieTagId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("TagId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieTag_TagId", "mov", "Tag", "TagId")
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieTag_MovieId", "mov", "Movie", "MovieId");

            Create.Table("Cast").InSchema("mov")
                .WithColumn("CastId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("CharacterEn").AsString(100).NotNullable()
                .WithColumn("CharacterOther").AsString(100).NotNullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_Cast_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt64().NotNullable()
                    .ForeignKey("FK_Cast_PersonId", "mov", "Person", "PersonId");

            Create.Table("Image").InSchema("mov")
                .WithColumn("ImageId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("Path").AsString(1000).NotNullable()
                .WithColumn("MovieId").AsInt64().Nullable()
                    .ForeignKey("FK_MovieImage_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt64().Nullable()
                    .ForeignKey("FK_PersonImage_PersonId", "mov", "Person", "PersonId");
        }
        public override void Down()
        {
        }
    }
}