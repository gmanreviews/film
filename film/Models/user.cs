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
        public int id { get; set; }
        [Display(Name = "Username")]
        [Required]
        [RegularExpression("[0-9a-zA-Z_-]+", ErrorMessage = "Please type in a valid username. You can use only numbers, letters and _ or -")]
        public string username { get; set; }
        [Required]
        [RegularExpression("[0-9a-zA-Z_!?$-]+", ErrorMessage = "Please type in a valid password. You can use only numbers, letters and !,_,-,$,?.")]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Verify Password")]
        [RegularExpression("[0-9a-zA-Z_!?$-]+", ErrorMessage ="Please type in a valid password. You can use only numbers, letters and !,_,-,$,?.")]
        public string password2 { get; set; }
        [Display(Name = "E-Mail")]
        [RegularExpression("[a-zA-Z0-9_.-]+@[a-z0-9A-Z_-]+([.][a-zA-Z]{2,3})+", ErrorMessage ="Please type in a valid email address")]
        public string email { get; set; }
        public person person { get; set; }
        [Display(Name = "User Type")]
        public user_type user_type { get; set; }
        [Display(Name ="Subscribe To Email")]
        public bool subscribe_mail { get; set; }

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
        public user(int id, string username, person person)
        {
            this.id = id;
            this.username = username;
            this.person = person;
        }
        public user(int id, person person)
        {
            this.id = id;
            this.person = person;
        }
    }
    public class user_model
    {
        public static bool does_user_exist(user user)
        {
            bool result = false;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC does_user_exist '" + general.clean(user.username) + "'");
            while (reader.Read())
            {
                result = (bool)reader["result"];
            }
            reader.Close();
            db.disconnect();
            return result;
        }

        public static bool is_email_in_use(user user)
        {
            bool result = false;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC is_email_in_use '" + general.clean(user.email) + "'");
            while (reader.Read())
            {
                result = (bool)reader["result"];
            }
            reader.Close();
            db.disconnect();
            return result;
        }

        public static bool do_passwords_match(user user)
        {
            return user.password == user.password2;
        }

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
        
        public static bool login_authenticate(user user)
        {
            if (user.password == null) return false;
            else return bcrypt.test_password(user.password, get_hashed_password(user));
        }

        private static string get_hashed_password(user user)
        {
            string output = "";
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_hashed_password '" + general.clean(user.username) + "'");
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
                SqlDataReader reader = db.query_db("EXEC create_user '" + general.clean(user.username) + "','"
                                                                        + general.clean(bcrypt.encrypt(user.password)) + "','"
                                                                        + general.clean(user.email) + "',"
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
            SqlDataReader reader = db.query_db("EXEC get_user '" + general.clean(user.username) + "'");
            while (reader.Read())
            {
                user.id = int.Parse(reader["user_id"].ToString());
                user.person = new person(int.Parse(reader["person_id"].ToString()),
                                         reader["first_name"].ToString(),
                                         reader["last_name"].ToString(),
                                         reader["country_name"].ToString());
                user.email = reader["email"].ToString();
                user.subscribe_mail = (bool)reader["mail"];
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

        public static void unsubscribe_from_emails(user user)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC unsubscribe_from_emails " + user.id);
            reader.Close();
            db.disconnect();
        }

        public static void subscribe_to_emails(user user)
        {
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC subscribe_to_emails " + user.id);
            reader.Close();
            db.disconnect();
        }

    }

}