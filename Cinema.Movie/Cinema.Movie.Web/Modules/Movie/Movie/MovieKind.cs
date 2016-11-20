using System;
using Serenity.ComponentModel;
using System.ComponentModel;

namespace Cinema.Movie.Movie
{
    [EnumKey("Movie.Movie.MovieKind")]
    public enum MovieKind
    {
        [Description("Film")]
        Film = 1,
        [Description("TV Series")]
        TvSeries = 2,
        [Description("Mini Series")]
        MiniSeries = 3
    }
}