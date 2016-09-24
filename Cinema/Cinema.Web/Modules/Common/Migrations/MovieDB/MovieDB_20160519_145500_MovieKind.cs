using FluentMigrator;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160519145500)]
    public class MovieDB_20160519_145500_MovieKind : Migration
    {
        public override void Up()
        {
            Alter.Table("Movie").InSchema("mov")
                .AddColumn("Kind").AsInt32().NotNullable()
                    .WithDefaultValue(1);
        }

        public override void Down()
        {
        }
    }
}