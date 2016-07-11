using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace KinoServer.Models
{
    public class Person: EssenceView
    {

        [Required]
        public string NameRU { get; set; }

        [Required]
        public string NameEN { get; set; }
        
        public DateTime BirthDay { get; set; }

        public IEnumerable<Profession> Profession { get; set; }
    }
    public enum Profession
    {
        Producer,
        Actors,
        Scenario,
        Composer
    }
}
