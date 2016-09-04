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

        private static string get_league_name(int id)
        {
            string league_name = "";
            if (id > 0) {
                db db = new db();
                SqlDataReader reader = db.query_db("EXEC get_league_name " + id);
                while (reader.Read())
                {
                    league_name = reader["league_name"].ToString();
                }
            }
            return league_name;
        }

        public static List<team> get_league_members(int id)
        {
            List<team> teams = new List<team>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_tump_league_members " + id);
            while (reader.Read())
            {
                player player = new player(new user(int.Parse(reader["id"].ToString()),reader["username"].ToString(),new person(reader["first_name"].ToString(), reader["last_name"].ToString())),(bool)reader["league_admin"]);
                team team = new team(id, player);

            }
            db.disconnect();

            return teams;
        }
    }
}