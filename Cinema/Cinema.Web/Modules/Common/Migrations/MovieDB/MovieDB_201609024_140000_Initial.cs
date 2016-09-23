using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace Cinema.Migrations.MovieDB
{

    [Migration(201609024140000)]
    public class MovieDB_201609024_140000_Initial : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Schema("mov");
            Create.Table("Movie").InSchema("mov")
                .WithColumn("MovieId").AsInt32()
                    .Identity().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Storyline").AsString(Int32.MaxValue).Nullable()
                .WithColumn("Year").AsInt32().Nullable()
                .WithColumn("ReleaseDate").AsDateTime().Nullable()
                .WithColumn("Runtime").AsInt32().Nullable();
        }
    }
}