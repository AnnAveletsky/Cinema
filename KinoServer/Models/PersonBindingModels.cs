using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace KinoServer.Models
{
    public class Person: Essence
    {

        [Required]
        public string NameRU { get; set; }

        [Required]
        public string NameEN { get; set; }

        [Required]
        public Image Image { get; set; }

        [Required]
        public Image IconImage { get; set; }

        public DateTime BirthDay { get; set; }

        public Profession Profession { get; set; }

        public IEnumerable<Uri> Links { get; set; }
    }
    public class Profession:Essence
    {
        public string Name { get; set; }
    }
}
