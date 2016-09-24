using FluentMigrator;

namespace Cinema.Migrations.MovieDB
{
    [Migration(20160603306000)]
    public class MovieDB_20160603_306000_Video : Migration
    {
        public override void Up()
        {
            Create.Table("Video").InSchema("mov")
                .WithColumn("VudeoId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_Movie_MovieId", "mov", "Movie", "MovieId")
                .WithColumn("ServiceId").AsInt32()
                    .ForeignKey("FK_Service_ServiceId", "mov", "Service", "ServiceId").NotNullable()
                .WithColumn("Path").AsString().Nullable();
        }

        public override void Down()
        {
        }
    }
}