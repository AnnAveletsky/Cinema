using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20160610181800)]
    public class DefaultDB_20160610_181800_SampleMovie : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Movie").InSchema("mov")
                .Row(new
                {
                    TitleEn = "Harry Potter and the Sorcerer's Stone",
                    Description = "Rescued from the outrageous neglect of his aunt and uncle, a young boy with a great destiny proves his worth while attending Hogwarts School of Witchcraft and Wizardry.",
                    YearStart = 2001,
                    YearEnd = 2001,
                    ReleaseWorldDate = new DateTime(2001,11,1),
                    ReleaseOtherDate = new DateTime(2002, 3, 21),
                    ReleaseDVD = new DateTime(2002, 8, 28),
                    Runtime = 152,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = DateTime.UtcNow,
                    PublishDateTime = DateTime.UtcNow,
                    Rating = 10,
                    MPAA = 12,
                    PathImage = "https://www.kinopoisk.ru/images/film_big/689.jpg",
                    PathMiniImage = "https://www.kinopoisk.ru/images/film_big/689.jpg",
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
                 PathMiniImage = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_.jpg",
                 Nice = true,
             });
        }

        public override void Down()
        {
        }
    }
}