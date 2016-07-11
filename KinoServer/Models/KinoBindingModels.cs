using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace KinoServer.Models
{
    public class Kino: EssenceView
    {
        [Required]
        public string NameRU { get; set; }

        [Required]
        public string NameEN { get; set; }

        [Required]
        public IEnumerable<Country> Country { get; set; }

        [Required]
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PremiereWorld { get; set; }

        [Required]
        public DateTime ReleaseDVD { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime Duration { get; set; }

        [Required]
        public IEnumerable<Tag> Tags { get; set; }
        
        [Required]
        public IEnumerable<Person> Producer { get; set; }
        
        public IEnumerable<Person> Actors { get; set; }

        [Required]
        public IEnumerable<Person> Scenario { get; set; }

        [Required]
        public IEnumerable<Person> Composer { get; set; }
    }
    public class Film : Kino
    {
        [Required]
        public IEnumerable<Video> Video { get; set; }

        [Required]
        public DateTime Year { get; set; }
    }
    public class Series : Kino
    {
        [Required]
        public int CountSeason { get; set; }

        [Required]
        public IEnumerable<DateTime> Years { get; set; }

        [Required]
        public IEnumerable<IEnumerable<Video>> Video { get; set; }
    }

    public class Tag: Essence
    {
        public string Name { get; set; }
    }
    public class Video: Essence
    {
        [Url]
        public string Url { get; set; }

        [Required]
        public bool Subtitle { get; set; }

        public IEnumerable<Person> AudioDubbing { get; set; }
    }
    public class Genre: Essence
    {
        [Required]
        public int Name { get; set; }
    }
    public class Country: Essence
    {
        [Required]
        public string Name { get; set; }
    }
}