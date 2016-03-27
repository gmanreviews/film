using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class mamo_team
    {
        public int id { get; set; }
        public user owner { get; set; }
        public bool submitted { get; set; }
        public mamo_year year { get; set; }
        public List<mamo> films { get; set; }
        public int score { get; set; }

        public mamo_team() { }
        public mamo_team(int id, mamo_year year)
        {
            this.id = id;
            this.year = year;
        }
    }
    public class mamo_team_model
    {
        public static void create_team(mamo_team team)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC create_team " + team.owner.id + ",'"
                                                                   + team.year.year + "'");
            while (reader.Read())
            {
                team.id = int.Parse(reader["id"].ToString());
            }
            reader.Close();
            db.disconnect();

            add_mamo_team(team);
            if (team.submitted) submit_team(team);
        }

        public static void submit_team(mamo_team team)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC submit_team " + team.id);
            reader.Close();
            db.disconnect();
            add_mamo_team(team);
        }

        public static bool is_team_submitted(mamo_team team)
        {
            bool submitted = true;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC is_team_submitted " + team.id);
            while (reader.Read())
            {
                submitted = (bool)reader["submitted"];
            }
            reader.Close();
            db.disconnect();
            return submitted;
        }

        private static void add_mamo_team(mamo_team team)
        {
            foreach(mamo film in team.films)
            {
                add_team_member(team, film);
            }
        }

        public static void add_team_member(mamo_team team, mamo film)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC add_team_member " + team.id + "," 
                                                                       + film.id + ","
                                                                       + film.rank + ","
                                                                       + film.mamo_bo_open + "','"
                                                                       + film.mamo_bo_total + "'");
            reader.Close();
            db.disconnect();
        }

        public static mamo get_mamo_team_member(int mamo_id)
        {
            mamo mamo = new mamo();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_mamo_team_member " + mamo_id);
            while (reader.Read())
            {
                mamo.id = int.Parse(reader["film_id"].ToString());
                mamo.film_name = reader["name"].ToString();
                mamo.rank = int.Parse(reader["rank"].ToString());
                mamo.mamo_bo_open = reader["box_office_opening"].ToString();
                mamo.mamo_bo_total = reader["box_office_total"].ToString();
            }
            reader.Close();
            db.disconnect();
            return mamo;
        }

        public static int my_score(mamo_team team)
        {
            return 0;
        }

        public static List<mamo> my_team_score(mamo_team team)
        {
            List<mamo> mamos = new List<mamo>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC mamo_team_point_break_down " + team.owner.id + "," + team.year.id);
            while (reader.Read())
            {
                int actual_gross = int.Parse(reader["actual_gross_total"].ToString()) / 1000000;
                int actual_open = int.Parse(reader["actual_opening"].ToString()) / 1000000;
                int pred_gross = int.Parse(reader["predicted_total"].ToString());
                int pred_open = int.Parse(reader["predicted_opening"].ToString());
                int rank = calculate_rank_point(int.Parse(reader["rank_point_diff"].ToString()));

                mamos.Add(new mamo(int.Parse(reader["film_id"].ToString()),
                                   reader["film_name"].ToString(),
                                   pred_open.ToString(),
                                   pred_gross.ToString(),
                                   rank,
                                   calculate_gross_points(actual_gross, pred_gross),
                                   calculate_opening_points(actual_open, pred_open),
                                   calculate_open_gross_points(actual_open, actual_gross, pred_open, pred_gross, is_rank_correct(rank))
                                   ));
            }
            reader.Close();
            db.disconnect();

            return mamos;
        }

        private static int calculate_gross_points(int actual_gross, int predicted_gross)
        {
            int points = 0;
            if ((uint)(actual_gross - predicted_gross) <= 5) points += 10;
            if ((uint)(actual_gross - predicted_gross) <= 10) points += 5;
            if ((uint)(actual_gross - predicted_gross) <= 20) points += 1;
            return points;
        }

        private static int calculate_opening_points(int actual_open, int pred_open)
        {
            int points = 0;
            if ((uint)(actual_open - pred_open) <= 1) points += 10;
            if ((uint)(actual_open - pred_open) <= 5) points += 5;
            if ((uint)(actual_open - pred_open) <= 10) points += 1;
            return points;
        }

        private static int calculate_rank_point(int rank_diff)
        {
            int point = 0;
            if ((uint)rank_diff > 10) point = 0;
            else point = 10 - (int)((uint)rank_diff);
            return point;
        }

        private static bool is_rank_correct(int rank_point)
        {
            return rank_point == 10;
        }

        private static int calculate_open_gross_points(int actual_open, int actual_gross, int pred_open, int pred_gross, bool rank_correct)
        {
            int point = 0;
            if (rank_correct && (uint)(actual_gross - pred_gross) <= 5 && (uint)(actual_open - pred_open) <= 1) point += 10;
            return point;
        }

        /*
        public static mamo_team get_user_mamo_team(user user, mamo_year year)
        {
            mamo_team team = new mamo_team();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_user_mamo_team " + user.id + "," + year.id);
            while (reader.Read())
            {
                team.id = int.Parse(reader["id"].ToString());
                team.owner = user;
                team.year = year;
            }
            reader.Close();
            db.disconnect();

            if (team.id != 0)
            { 
                team.submitted = is_team_submitted(team);
                team.films = get_team_films(team);
            }
            return team;
        }

        public static List<mamo> get_team_films(mamo_team team)
        {
            List <mamo> films = new List<mamo>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_team_films " + team.id);
            while (reader.Read())
            {
                films.Add(new mamo(int.Parse(reader["film_id"].ToString()),
                                   reader["name"].ToString(),
                                   reader["box_office_total"].ToString(),
                                   reader["box_office_opening"].ToString(),
                                   DateTime.Now,
                                   int.Parse(reader["rank"].ToString())));
            }
            reader.Close();
            db.disconnect();
            return films;

        }
        */
    }
}