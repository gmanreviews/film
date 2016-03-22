using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class movie
    {
        public int id { get; set; }
        public string film_name { get; set; }
        public string box_office_total { get; set; }
        public string box_office_opening { get; set; }
        public int release_month { get; set; }
        public string bo_mojo_slug { get; set; }

        public movie() { }
        public movie(int id)
        {
            this.id = id;
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
                SqlDataReader reader = db.query_db("EXEC add_movie '" + movie.film_name + "','" + movie.bo_mojo_slug + "'");
                while (reader.Read())
                {
                    if ((bool)reader["result"]) movie.id = int.Parse(reader["id"].ToString());
                    else throw new Exception("db failure");
                }
            }
            catch (Exception)
            {
                //an exception log
            }
            return movie;
        }

        public static bool update_bo_data(movie movie)
        {
            return true;
        }
    }

}