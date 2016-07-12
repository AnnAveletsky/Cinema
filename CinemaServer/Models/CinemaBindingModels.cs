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
        public ICollection<Country> Countries { get; set; }

        [Required]
        public ICollection<Genre> Genres { get; set; }

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
        public ICollection<Tag> Tags { get; set; }

        [Required]
        public ICollection<Person> Persons { get; set; }

        [Required]
        public int Views { get; set; }

        public ICollection<Plaint> Plaints { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int CountSeason { get; set; }

        [Required]
        public ICollection<DateTime> Years { get; set; }

        [Required]
        public ICollection<Video> Video { get; set; }

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

        public ICollection<Cinema> Cinemas { get; set; }
    }
    public class Video : Essence
    {
        [Url]
        public string Url { get; set; }

        public int? IdCinema { get; set; }

        public Cinema Cinema { get; set; }

        public int Season { get; set; }

        public int Serie { get; set; }

        [Required]
        public bool SubtitleRU { get; set; }

        [Required]
        public bool SubtitleEN { get; set; }

        public ICollection<RolePersonCinema> Roles { get; set; }

        public ICollection<Person> AudioDubbing { get; set; }

        public TransleteGrup TransleteGrup { get; set; }

        public void Update(Video video)
        {

        }
    }
    public class Genre : Essence
    {
        [Required]
        public int Name { get; set; }

        public ICollection<Cinema> Cinemas { get; set; }
    }
    public class Country : Essence
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Cinema> Cinemas { get; set; }
    }
}