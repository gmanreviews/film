using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace film.Models
{
    public class mamo: movie
    {
        [Display(Name = "Rank")]
        public int rank { get; set; }
        [Display(Name = "Team Locked")]
        public bool submitted { get; set; }
        public string mamo_bo_total { get; set; }
        public string mamo_bo_open { get; set; }
        public int mamo_id { get; set; }

        public mamo() { }
        public mamo(int id, string film_name, string box_office_total, string box_office_opening, DateTime release_date, int rank)
        {
            this.id = id;
            this.film_name = film_name;
            this.box_office_total = box_office_total;
            this.box_office_opening = box_office_opening;
            this.release_date = release_date;
            this.rank = rank;
        }
        public mamo(int id, string film_name, string box_office_total, string box_office_opening, DateTime release_date, int rank, bool submitted)
        {
            this.id = id;
            this.film_name = film_name;
            this.box_office_total = box_office_total;
            this.box_office_opening = box_office_opening;
            this.release_date = release_date;
            this.rank = rank;
            this.submitted = submitted;
        }

    }

    public class mamo_model
    {
        public static void update_mamo_top_ten()
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC update_mamo_top_ten");
            reader.Close();
            db.disconnect();
        }

        public static List<mamo> get_mamo_top_ten()
        {
            List<mamo> movies = new List<mamo>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_mamo_top_ten");
            while (reader.Read())
            {
                movies.Add(new mamo(int.Parse(reader["id"].ToString()),
                                     reader["name"].ToString(),
                                     reader["box_office_total"].ToString(),
                                     reader["box_office_total"].ToString(),
                                     DateTime.Parse(reader["release_date"].ToString()),
                                     int.Parse(reader["rank"].ToString())));
            }
            reader.Close();
            db.disconnect();
            return movies;
        }

        public static List<mamo> get_player_mamo_team(user user, mamo_year year)
        {
            List<mamo> team = new List<mamo>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_player_mamo_team " + user.id + "," + year.id);
            while (reader.Read())
            {
                team.Add(new mamo(int.Parse(reader["id"].ToString()),
                                  reader["name"].ToString(),
                                  reader["box_office_total"].ToString(),
                                  reader["box_office_total"].ToString(),
                                  DateTime.Parse(reader["release_date"].ToString()),
                                  int.Parse(reader["rank"].ToString()),
                                  (bool)reader["lock"]));
            }
            reader.Close();
            db.disconnect();
            return team;
        }

        public static bool is_there_a_game_this_year()
        {
            bool result = false;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC is_there_a_game_this_year");
            while (reader.Read())
            {
                result = (bool)reader["result"];
            }
            reader.Close();
            db.disconnect();
            return result;
        }

        public static bool are_there_past_games()
        {
            bool result = false;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC are_there_past_games");
            while (reader.Read())
            {
                result = (bool)reader["result"];
            }
            reader.Close();
            db.disconnect();
            return result;
        }

        public static bool am_i_playing(user user, mamo_year year)
        {
            bool result = false;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC am_i_playing " + user.id + "," + year.year);
            while (reader.Read())
            {
                result = (bool)reader["result"];
            }
            reader.Close();
            db.disconnect();
            return result;
        }

        public static List<movie> all_posible_films_for_mamo_game(mamo_year year)
        {
            List<movie> movies = new List<movie>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC all_posible_films_for_mamo_game " + year.id);
            while (reader.Read())
            {
                movies.Add(new movie(int.Parse(reader["id"].ToString()), reader["name"].ToString()));
            }
            reader.Close();
            db.disconnect();
            return movies;
        }
    }
}