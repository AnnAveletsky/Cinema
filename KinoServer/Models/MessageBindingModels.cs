using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoServer.Models
{
    public class Message:Essence
    {
        [Required]
        public Kino Kino { get; set; }

        [Required]
        public string Text { get; set; }
    }
    public class Claim : Message
    {

    }
    public class Comment : Message
    {

    }
}
