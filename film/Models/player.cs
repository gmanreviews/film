using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class player: user
    {
        public player_type type { get; set; }
    }
}