using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class team
    {
        //public int id { get; set; }
        public int league_id { get; set; }
        public player player { get; set; }
        public List<movie> films { get; set; }

        public team() { }
        public team(int league_id, player player)
        {
            this.league_id = league_id;
            this.player = player;
        }
    }

    public class team_model
    {
        public team get_team_movies(team team)
        {
            List<movie> movies = new List<movie>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_tump_team_movies " + team.league_id + "," + team.player.id);
            while (reader.Read())
            {
                movie m = new movie(int.Parse(reader["film_id"].ToString()),
                                    reader["name"].ToString(),
                                    reader["box_office_total"].ToString(),
                                    reader["box_office_opening"].ToString(),
                                    DateTime.Parse(reader["release_date"].ToString()));
                movies.Add(m);
            }
            db.disconnect();
            team.films = movies;
            return team;
        }
    }
}