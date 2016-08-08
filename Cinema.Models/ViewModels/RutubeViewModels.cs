using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public enum FormatRutube
    {
        json, jsonp, xml, api
    }
    public class GetRutubeTV
    {
        public FormatRutube format { get; set; }
        public int? page { get; set; }
    }
}
