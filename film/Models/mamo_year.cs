using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class mamo_year
    {
        public int id { get; set; }
        public string year { get; set; }

        public mamo_year(string year)
        {
            this.year = year;
        }
        public mamo_year(int id, string year)
        {
            this.id = id;
            this.year = year;
        }
    }
    public class mamo_year_model
    {
        public static List<mamo_year> get_years()
        {
            List<mamo_year> years = new List<mamo_year>();
            db db = new db();
            db.disconnect();
            SqlDataReader reader = db.query_db("EXEC get_years");
            while (reader.Read())
            {
                years.Add(new mamo_year(int.Parse(reader["id"].ToString()), reader["year"].ToString()));
            }
            reader.Close();
            db.disconnect();
            return years;
        }
    }

}