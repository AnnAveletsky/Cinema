using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace CinemaServer.Models
{
    public abstract class Essence
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public Change Create { get; set; }

        [Required]
        public IEnumerable<Change> Updates { get; set; }
    }
    public abstract class EssenceView:Essence
    {
        [Required]
        public Image Image { get; set; }

        [Required]
        public Image IconImage { get; set; }

        public IEnumerable<Uri> Links { get; set; }
    }
}
