using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class team
    {
        public int id { get; set; }
        public player player { get; set; }
        public List<movie> films { get; set; }
    }
}