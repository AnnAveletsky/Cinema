using Cinema.Migrations;
using FluentMigrator;
using System;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160607115101)]
    public class MovieDB_20160607_115101_Movie : Migration
    {
        public override void Up()
        {

            this.CreateTableWithId64("Movie", "MovieId", s => s
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
                .WithColumn("Budget").AsCurrency().Nullable());

            this.CreateTableWithId64("MovieCountry", "MovieCountryId", s => s
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieCountry_MovieId", "Movie", "MovieId")
                .WithColumn("CountryId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieCountry_CountryId", "Country", "CountryId"));

            this.CreateTableWithId64("MovieGenre", "MovieGenreId", s => s
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieGenre_MovieId", "Movie", "MovieId")
                .WithColumn("GenreId").AsInt32().NotNullable()
                    .ForeignKey("FK_MovieGenre_GenreId", "Genre", "GenreId"));

            this.CreateTableWithId64("MovieTag", "MovieTagId", s => s
                .WithColumn("TagId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieTag_TagId", "Tag", "TagId")
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_MovieTag_MovieId", "Movie", "MovieId"));

            this.CreateTableWithId64("Cast", "CastId", s => s
                .WithColumn("CharacterEn").AsString(100).NotNullable()
                .WithColumn("CharacterOther").AsString(100).NotNullable()
                .WithColumn("MovieId").AsInt64().NotNullable()
                    .ForeignKey("FK_Cast_MovieId", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt64().NotNullable()
                    .ForeignKey("FK_Cast_PersonId", "Person", "PersonId"));

            this.CreateTableWithId64("Image", "ImageId", s => s
                .WithColumn("Path").AsString(1000).NotNullable()
                .WithColumn("MovieId").AsInt64().Nullable()
                    .ForeignKey("FK_MovieImage_MovieId", "Movie", "MovieId")
                .WithColumn("PersonId").AsInt64().Nullable()
                    .ForeignKey("FK_PersonImage_PersonId", "Person", "PersonId"));
        }
        public override void Down()
        {
        }
    }
}