using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class player : user
    {
        public bool is_league_admin { get; set; }

        public player() { }
        public player(user user, bool is_league_admin)
        {
            this.id = user.id;
            this.person = user.person;
            this.username = user.username;
            this.is_league_admin = is_league_admin;
        }
        
    }
}