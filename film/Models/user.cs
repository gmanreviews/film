using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace film.Models
{
    public class user
    {
        [Required]
        public int id {get; set;}
        [Display(Name = "Username")]
        [Required]
        public string username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Verify Password")]
        public string password2 { get; set; }
        [Display(Name = "E-Mail")]
        public string email { get; set; }
        public person person { get; set; }
        //public List<usergroup> usergroups { get; set; }
        [Display(Name = "User Type")]
        public user_type user_type { get; set; }

        public user() { }
        public user(int id)
        {
            this.id = id;
        }
        public user(int id, string username, string password, string email, person person)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.person = person;
        }
    }
    public class user_model
    {
        public static List<user> get_all_users()
        {
            List<user> users = new List<user>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("SELECT * FROM users");
            while (reader.Read())
            {
                users.Add(new user(int.Parse(reader["id"].ToString())));
            }
            reader.Close();
            db.disconnect();
            return users;
        }

        private static string get_password(user user)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_user_password " + user.id + ",'" + user.username + "'");
            while (reader.Read())
            {
                if ((bool)reader["success"]) user.password = reader["password"].ToString();
            }
            reader.Close();
            db.disconnect();
            return user.password;
        }

        public static bool login_authenticate(user user)
        {
            if (user.password == null || get_password(user) == null) return false;
            else return bcrypt.test_password(user.password, get_hashed_password(user));
        }

        private static string get_hashed_password(user user)
        {
            string output = "";
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_hashed_password '" + user.username + "'");
            while (reader.Read())
            {
                if ((bool)reader["result"]) output = reader["password"].ToString();
            }
            reader.Close();
            db.disconnect();
            return output;
        }

        public static user add_user(user user)
        {
            try {
                if ((user.password != user.password2) && user.password2 != null && user.password2 != "") throw new Exception("passwords don't match");
                user.person = person_model.add_person(user.person);
                db db = new db();
                db.connect();
                SqlDataReader reader = db.query_db("EXEC create_user '" + user.username + "','"
                                                                        + bcrypt.encrypt(user.password) + "','"
                                                                        + user.email + "',"
                                                                        + user.person.id + ","
                                                                        + user.user_type.id);
                while (reader.Read())
                {
                    if ((bool)reader["success"]) user.id = int.Parse(reader["result"].ToString());
                    else throw new Exception("username not unique");
                }
                reader.Close();
                db.disconnect();
                return user;
            }
            catch (Exception)
            {
                return user;
            }
        }

        public static user remove_passwords(user user)
        {
            user.password = null;
            user.password2 = null;
            return user;
        }

        public static user get_user(user user)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_user '" + user.username + "'");
            while (reader.Read())
            {
                user.id = int.Parse(reader["user_id"].ToString());
                user.person = new person(int.Parse(reader["person_id"].ToString()),
                                         reader["first_name"].ToString(),
                                         reader["last_name"].ToString(),
                                         reader["country_name"].ToString());
                remove_passwords(user);
            }
            reader.Close();
            db.disconnect();
            return user;
        }

        public static void logout()
        {
            general.user = new user();
        }

        public static bool am_i_logged_in()
        {
            return general.user.id != 0;
        }

    }

}