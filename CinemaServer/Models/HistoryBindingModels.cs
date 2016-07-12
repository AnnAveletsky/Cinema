using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaServer.Models
{
    public class Change : Essence
    {
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public UserInfoViewModel User { get; set; }
    }
}
