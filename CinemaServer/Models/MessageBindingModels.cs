using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CinemaServer.Models
{
    public abstract class Message : Essence
    {
        public int? IdCinema { get; set; }

        [Required]
        public Cinema Сinema { get; set; }

        [Required]
        [AllowHtml]
        public string Text { get; set; }
    }
    public class Plaint : Message
    {
        public PlaintType PlaintType { get; set; }
    }
    public enum PlaintType
    {
        NoVideo,
        Insult,
        RightsViolation,
        Other
    }
    public class Comment : Message
    {

    }
}
