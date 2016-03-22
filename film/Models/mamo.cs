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
    }
}