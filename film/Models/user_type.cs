using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace chess.Models
{
    public class user_type
    {
        public int id { get; set; }
        [Display(Name = "User Type Code")]
        public string type_code { get; set; }
        [Display(Name = "User Type")]
        public string type_desc { get; set; }

        public user_type() { }
        public user_type(int id)
        {
            this.id = id;
        }
        public user_type(int id, string type_code, string type_desc)
        {
            this.id = id;
            this.type_code = type_code;
            this.type_desc = type_desc;
        }
    }
    public class user_type_model
    {
        public static List<user_type> get_all_user_types()
        {
            List<user_type> user_types = new List<user_type>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_all_user_types");
            while (reader.Read())
            {
                user_types.Add(new user_type(int.Parse(reader["id"].ToString()),
                                             reader["type_code"].ToString(),
                                             reader["type_desc"].ToString()));
            }
            reader.Close();
            db.disconnect();
            return user_types;
        }
    }
}