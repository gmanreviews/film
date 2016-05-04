using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class league
    {
        public int id { get; set; }
        public string league_name { get; set; }
        public List<team> teams { get; set; }
    }
    public class league_model
    {
        public static league get_league(int id)
        {
            league league = new league();

            return league;
        }
    }
}