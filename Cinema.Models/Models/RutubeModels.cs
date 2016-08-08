using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class RutubePage
    {
        [Key]
        int page { get; set; }
        bool has_next { get; set; }
        string next { get; set; }
        string previous { get; set; }
        int per_page { get; set; }
        IEnumerable<RutubeTVInfo> results { get; set; }
    }
    public class RutubeType
    {
        [Key]
        int id { get; set; }
        string name { get; set; }
        string title { get; set; }
    }
    public class RutubeTVInfo{
        [Key]
        int id { get; set; }
        string content { get; set; }
        RutubeType type { get; set; }
        string original_title { get; set; }
        string countries { get; set; }
        string year{ get; set; }
        string year_start{ get; set; }
        string year_end{ get; set; }
        bool is_active{ get; set; }
        string related_showcase{ get; set; }
        string age_restriction{ get; set; }
        string slogan{ get; set; }
        string poster_url{ get; set; }
        string name{ get; set; }
        bool can_subscribe{ get; set; }
        string description{ get; set; }
        string picture{ get; set; }
    }
}
