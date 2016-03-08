using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace chess.Models
{
    public class post_category
    {
        public int id { get; set; }
        public string category { get; set; }

        public post_category() { }
        public post_category(int id, string category)
        {
            this.id = id;
            this.category = category;
        }
    }

    public class post_category_model
    {
        public static post_category create_post_category(post_category post_category)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC create_post_category '" + post_category.category + "'");
            while (reader.Read())
            {
                if ((bool)reader["result"]) post_category.id = int.Parse(reader["id"].ToString());
                else throw new Exception("category already exists");
            }
            reader.Close();
            db.disconnect();
            return post_category;
        }

        public static List<post_category> get_post_categories()
        {
            List<post_category> categories = new List<post_category>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_post_categories");
            while (reader.Read())
            {
                categories.Add(new post_category(int.Parse(reader["id"].ToString()), reader["category"].ToString()));
            }
            reader.Close();
            db.disconnect();
            return categories;
        }
    }
}