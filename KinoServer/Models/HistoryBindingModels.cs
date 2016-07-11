using System;
using System.ComponentModel.DataAnnotations;

namespace KinoServer.Models
{
    public class Change :Essence
    {
        [Required]
        public DateTime DateTime{ get; set; }

        [Required]
        public UserInfoViewModel User{ get; set; }
}
}
