using FluentMigrator;
using System;

namespace Cinema.Movie.Migrations.DefaultDB
{
    [Migration(20161220181800)]
    public class DefaultDB_20161220_181800_Sample : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Movie").InSchema("mov")
                .Row(new
                {
                    TitleEn = "Harry Potter and the Sorcerer's Stone",
                    TitleOther = "Гарри Поттер и философский камень",
                    Description = "Жизнь десятилетнего Гарри Поттера нельзя назвать сладкой: его родители умерли, едва ему исполнился год, а от дяди и тётки, взявших сироту на воспитание, достаются лишь тычки да подзатыльники. Но в одиннадцатый день рождения Гарри всё меняется. Странный гость, неожиданно появившийся на пороге, приносит письмо, из которого мальчик узнаёт, что на самом деле он волшебник и принят в Хогвартс — школу магии. А уже через пару недель Гарри будет мчаться в поезде Хогвартс-экспресс навстречу новой жизни, где его ждут невероятные приключения, верные друзья и самое главное — ключ к разгадке тайны смерти его родителей.",
                    Storyline = "",
                    YearStart = 2016,
                    YearEnd = 2016,
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
                });
        }

        public override void Down()
        {
        }
    }
}