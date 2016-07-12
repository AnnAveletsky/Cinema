using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaServer.Models
{
    public class Person: EssenceView
    {

        [Required]
        public string NameRU { get; set; }

        [Required]
        public string NameEN { get; set; }
        
        public DateTime BirthDay { get; set; }

        public IEnumerable<RolePersonCinema> Roles { get; set; }
    }
    public enum Profession
    {
        Producer,
        Actors,
        Scenario,
        Composer
    }
    public class RolePersonCinema
    {
        [Required]
        public Profession Profession { get; set; }

        [Required]
        public Cinema Сinema { get; set; }
    }
    public class TransleteGrup:Essence
    {
        [Required]
        public string Name { get; set; }

        [Url]
        [Required]
        public Uri Url { get; set; }
    }
}
