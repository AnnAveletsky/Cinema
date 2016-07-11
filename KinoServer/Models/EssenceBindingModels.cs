using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinoServer.Models
{
    public abstract class Essence
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public Change Create { get; set; }

        [Required]
        public IEnumerable<Change> Updates { get; set; }
    }
}
