using FluentMigrator;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160606212900)]
    public class DefaultDB_20160606_212900_UserImage : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Users")
                .AddColumn("UserImage").AsString(100).Nullable();
        }
    }
}