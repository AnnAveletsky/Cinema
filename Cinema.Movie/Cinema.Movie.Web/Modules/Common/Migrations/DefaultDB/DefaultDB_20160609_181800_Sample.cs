using FluentMigrator;
using Serenity;
using System;
using System.Data.SqlClient;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160609181800)]
    public class DefaultDB_20160609_181800_Sample : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Genre").InSchema("mov")
                .Row(new { Name = "Action", Icon="" })
                .Row(new { Name = "Drama", Icon = "" })
                .Row(new { Name = "Comedy", Icon = "" })
                .Row(new { Name = "Sci-fi", Icon = "" })
                .Row(new { Name = "Fantasy", Icon = "" })
                .Row(new { Name = "Documentary", Icon = "" });

            Insert.IntoTable("Movie").InSchema("mov")
                .Row(new
                {
                    TitleEn = "Harry Potter and the Sorcerer's Stone",
                    Description = "Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry.",
                    YearStart = 2001,
                    YearEnd = 2001,
                    ReleaseWorldDate = new DateTime(2001, 11, 1),
                    ReleaseOtherDate = new DateTime(2002, 3, 21),
                    ReleaseDVD = new DateTime(2002, 8, 28),
                    Runtime = 152,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = DateTime.UtcNow,
                    PublishDateTime = DateTime.UtcNow,
                    Rating = 10,
                    MPAA = 12,
                    PathImage = "https://www.kinopoisk.ru/images/film_big/689.jpg",
                    Nice = true,
                })
                .Row(new
                {
                    TitleEn = "Harry Potter and the Chamber of Secrets",
                    Description = "Harry ignores warnings not to return to Hogwarts, only to find the school plagued by a series of mysterious attacks and a strange voice haunting him.",
                    YearStart = 2002,
                    YearEnd = 2002,
                    ReleaseWorldDate = new DateTime(2002, 11, 24),
                    ReleaseOtherDate = new DateTime(2002, 12, 24),
                    ReleaseDVD = new DateTime(2002, 12, 24),
                    Runtime = 161,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = DateTime.UtcNow,
                    PublishDateTime = DateTime.UtcNow,
                    Rating = 10,
                    MPAA = 12,
                    PathImage = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_.jpg",
                    Nice = true,
                });
            Insert.IntoTable("Tag").InSchema("mov").Row(new { Name = "Madgic" });

            Insert.IntoTable("Person").InSchema("mov")
                .Row(new
                {
                    NameEn = "Rupert Grint",
                    FullNameEn = "Rupert Alexander Lloyd Grint",
                    BirthDate = new DateTime(2002, 8, 28),
                    Gender = 0,
                    About = "Actor who rose to prominence playing Ron Weasley, one of the three main characters in the Harry Potter film series. Grint was cast as Ron Weasley at the age of 11, having previously acted only in school plays and at his local theatre group. From 2001 to 2011, he starred in all eight Harry Potter films alongside Daniel Radcliffe playing as Harry Potter and Emma Watson playing as Hermione Granger",
                    PathImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/db/Rupert_Grint_2012.jpg/220px-Rupert_Grint_2012.jpg"
                });

            Execute.Sql(
              @"INSERT INTO mov.MovieGenres (MovieId, GenreId) 
                    SELECT MovieId, GenreId 
                    FROM mov.Movie, mov.Genre");
            Execute.Sql(
              @"INSERT INTO mov.MovieTag (MovieId, TagId) 
                    SELECT MovieId, TagId 
                    FROM mov.Movie, mov.Tag");

            Insert.IntoTable("Cast").InSchema("mov")
               .Row(new
               {
                   Character = "Actor",
                   MovieId = 1,
                   PersonId = 1,
               });
            Insert.IntoTable("Cast").InSchema("mov")
               .Row(new
               {
                   Character = "Actor",
                   MovieId = 1,
                   PersonId = 1,
               });
            Insert.IntoTable("Cast").InSchema("mov")
               .Row(new
               {
                   Character = "Producer",
                   MovieId = 1,
                   PersonId = 1,
               });
        }
        public override void Down()
        {
        }
    }
}