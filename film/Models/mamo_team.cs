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
    }
}