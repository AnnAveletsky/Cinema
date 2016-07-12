using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaServer.Models
{
    public class Cinema : EssenceView
    {
        [Required]
        public string NameRU { get; set; }

        [Required]
        public string NameEN { get; set; }

        [Required]
        public IEnumerable<Country> Countries { get; set; }

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
        public IEnumerable<Person> Persons { get; set; }

        [Required]
        public int Views { get; set; }

        public IEnumerable<Plaint> Plaints { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public int CountSeason { get; set; }

        [Required]
        public IEnumerable<DateTime> Years { get; set; }

        [Required]
        public IEnumerable<IEnumerable<Video>> Video { get; set; }

        public void Update(Cinema cinema)
        {

        }
    }
    public enum Type
    {
        Film,
        Series
    }

    public class Tag : Essence
    {
        public string Name { get; set; }
    }
    public class Video : Essence
    {
        [Url]
        public string Url { get; set; }

        [Required]
        public bool SubtitleRU { get; set; }

        [Required]
        public bool SubtitleEN { get; set; }

        public IEnumerable<Person> AudioDubbing { get; set; }

        public TransleteGrup TransleteGrup { get; set; }
    }
    public class Genre : Essence
    {
        [Required]
        public int Name { get; set; }
    }
    public class Country : Essence
    {
        [Required]
        public string Name { get; set; }
    }
}