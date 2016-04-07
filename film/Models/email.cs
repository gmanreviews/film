using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace film.Models
{
    public class email
    {
        private static List<string> get_all_emails_subscribed()
        {
            List<string> emails = new List<string>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_all_emails_subscribed");
            while (reader.Read())
            {
                emails.Add(reader["email"].ToString());
            }
            reader.Close();
            db.disconnect();
            return emails;
        }    
    }
}