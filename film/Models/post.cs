using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace chess.Models
{
    public class post
    {
        public int id { get; set; }
        public user user_created { get; set; }
        public string title { get; set; }
        public DateTime date_created { get; set;}
        public DateTime date_published { get; set; }
        public bool sticky { get; set; }
        public string content { get; set; }
        public post_category post_category { get; set; }
        public string post_state { get; set; }

        public post() { }
        public post(int id)
        {
            this.id = id;
        }


    }

    public class post_model
    {
        public static void save_post_draft(post post)
        {
            //send post id to db
        }
        
        public static post create_new_post()
        {
            //go to db, create blank record, with date created and return id.
            post post = new post();
            return post;
        }
    }
}