using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class mamo
    {
        public static void update_mamo_top_ten()
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC update_mamo_top_ten");
            reader.Close();
            db.disconnect();
        }

        public static List<movie> get_mamo_top_ten()
        {
            List<movie> movies = new List<movie>();
            return movies;
        }
    }
}