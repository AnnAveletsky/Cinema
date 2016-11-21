using FluentMigrator;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160609181800)]
    public class DefaultDB_20160609_181800_Sample : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Genre").InSchema("mov")
                .Row(new
                {
                    Name = "Action"
                })
                .Row(new
                {
                    Name = "Drama"
                })
                .Row(new
                {
                    Name = "Comedy"
                })
                .Row(new
                {
                    Name = "Sci-fi"
                })
                .Row(new
                {
                    Name = "Fantasy"
                })
                .Row(new
                {
                    Name = "Documentary"
                });

            Insert.IntoTable("Cast").InSchema("mov")
                .Row(new
                {
                    Character = "Producer"
                })
                .Row(new
                {
                    Character = "Scenario"
                })
                .Row(new
                {
                    Character = "Director"
                })
                .Row(new
                {
                    Character = "Operator"
                })
                .Row(new
                {
                    Character = "Composer"
                })
                .Row(new
                {
                    Character = "Painter"
                })
                .Row(new
                {
                    Character = "Montage"
                });
        }

        public override void Down()
        {
        }
    }
}