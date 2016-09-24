using FluentMigrator;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160603206000)]
    public class MovieDB_20160603_206000_Service : Migration
    {
        public override void Up()
        {
            Create.Table("Service").InSchema("mov")
                .WithColumn("ServiceId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(100).Nullable()
                .WithColumn("Api").AsString().Nullable();

            Create.Table("Service.Path").InSchema("mov")
               .WithColumn("ServiceId").AsInt32().Identity()
                    .ForeignKey("FK_Service_ServiceId", "mov", "Service", "ServiceId").NotNullable()
               .WithColumn("Path").AsString(300).Identity().Nullable();
        }

        public override void Down()
        {
        }
    }
}