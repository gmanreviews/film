using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class league
    {
        public int id { get; set; }
        public string league_name { get; set; }
        public List<team> teams { get; set; }
    }
}