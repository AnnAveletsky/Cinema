using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace Admin.Migrations.DefaultDB
{

    [Migration(20141003140000)]
    public class DefaultDB_20141003_140000_DB : AutoReversingMigration
    {
        public override void Up()
        {

            this.CreateTableWithId32("DataBase", "DataBaseId", s => s
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("ConnectionString").AsString(600).NotNullable()
                .WithColumn("ProviderName").AsString(100).NotNullable()
                .WithColumn("Active").AsBoolean().Nullable()
                .WithColumn("TagDataBaseMovie").AsString(200).Nullable()
                .WithColumn("Type").AsString(100).Nullable());

            Insert.IntoTable("DataBase").Row(new
            {
                Name = "Movie",
                ConnectionString= @"Data Source=(LocalDb)\MSSqlLocalDB; Initial Catalog=Admin_Movie_v1; Integrated Security=True",
                ProviderName= "System.Data.SqlClient",
            });
        }

        private void CreateTableWithId16(string v1, string v2, Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}