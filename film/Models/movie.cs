using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace film.Models
{
    public class movie
    {
        public int id { get; set; }
        [Display(Name = "Film Title")]
        public string film_name { get; set; }
        [Display(Name = "Total Box Office")]
        public string box_office_total { get; set; }
        [Display(Name = "Opening Weekend Box Office")]
        public string box_office_opening { get; set; }
        public int release_month { get; set; }
        [Display(Name = "Release Date")]
        public DateTime release_date { get; set; }
        public string bo_mojo_slug { get; set; }

        public movie() { }
        public movie(int id)
        {
            this.id = id;
        }
        public movie(int id, string film_name)
        {
            this.id = id;
            this.film_name = film_name;
        }
        public movie(int id, string film_name, string box_office_total, string box_office_opening, DateTime release_date)
        {
            this.id = id;
            this.film_name = film_name;
            this.box_office_total = box_office_total;
            this.box_office_opening = box_office_opening;
            this.release_date = release_date;
        }
    }

    public class movie_model
    {
        public static movie add_movie(movie movie)
        {
            try
            {
                db db = new db();
                db.connect();
                SqlDataReader reader = db.query_db("EXEC add_movie '" + general.clean(movie.film_name) + "','" 
                                                                      + general.clean(movie.bo_mojo_slug) + "'");
                while (reader.Read())
                {
                    if ((bool)reader["result"]) movie.id = int.Parse(reader["id"].ToString());
                    else throw new Exception("db failure");
                }
                reader.Close();
                db.disconnect();
            }
            catch (Exception)
            {
                //an exception log
            }
            return movie;
        }

        public static void update_bo_data(movie movie)
        {
            movie.id = get_movie_on_slug(movie);

            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC update_bo_data " + movie.id + "," +
                                                                      + movie.release_month + ",'"
                                                                      + String.Format("{0:M/d/yyyy}", movie.release_date) + "','"
                                                                      + general.clean(movie.film_name) + "','"
                                                                      + general.clean(movie.box_office_total) + "','"
                                                                      + general.clean(movie.box_office_opening) + "'");
            reader.Close();
            db.disconnect();
            //return true;
        }

        private static int get_movie_on_slug(movie movie)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_movie_on_slug '" + general.clean(movie.bo_mojo_slug) + "'");
            while (reader.Read())
            {
                movie.id = int.Parse(reader["id"].ToString());
            }
            reader.Close();
            db.disconnect();
            return movie.id;
        }

        public static DateTime get_movie_release_date(movie movie)
        {
            DateTime date = new DateTime();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_movie_release_date " + movie.id);
            while (reader.Read())
            {
                date = DateTime.Parse(reader["release_date"].ToString());
            }
            reader.Close();
            db.disconnect();
            return date;
        }
    }

}