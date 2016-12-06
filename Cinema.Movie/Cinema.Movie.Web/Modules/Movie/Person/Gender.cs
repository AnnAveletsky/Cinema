using Serenity.ComponentModel;
using System.ComponentModel;

namespace Cinema.Movie.Movie
{
    [EnumKey("Movie.Person.Gender")]
    public enum Gender
    {
        [Description("Male")]
        Male =0,
        [Description("Female")]
        Female =1
    }
}