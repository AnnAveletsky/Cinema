using CinemaServer.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaServer.Models
{
    public abstract class Message : Essence
    {
        [Required]
        public Cinema Сinemas { get; set; }

        [Required]
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
