using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{

    [Migration(20141003140000)]
    public class DefaultDB_20141003_140000_DB : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Schema("cdb");

            Create.Table("DB").InSchema("cdb")
                .WithColumn("DBId").AsInt16().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("ConnectionString").AsString(600).NotNullable()
                .WithColumn("ProviderName").AsString(100).NotNullable()
                .WithColumn("Active").AsBoolean().Nullable()
                .WithColumn("TagDataBaseMovie").AsString(200).Nullable()
                .WithColumn("Type").AsString(100).Nullable();

            Insert.IntoTable("DB").InSchema("cdb")
            .Row(new
            {
                Name = "Movie",
                ConnectionString= @"Data Source=(LocalDb)\v11.0; Initial Catalog=Cinema.Movie_Movie_v1; Integrated Security=True",
                ProviderName= "System.Data.SqlClient",
            });
        }
    }
}