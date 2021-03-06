﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace film.Models
{
    public class person
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("[A-Za-z-_ ]+")]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Required]
        [RegularExpression("[A-Za-z-_ ]+")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Required]
        [RegularExpression("[A-Za-z-_ ']+")]
        [Display(Name = "Country")]
        public string country { get; set; }

        public person() { }
        public person(int id)
        {
            this.id = id;
        }
        public person(int id, string first_name, string last_name, string country)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.country = country;
        }
        public person (string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
        }
    }
    public class person_model
    {
        public static person add_person(person person)
        {
            int country_id = add_country(person.country);
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC create_person '" + general.clean(person.first_name) + "','"
                                                                      + general.clean(person.last_name) + "',"
                                                                      + country_id);
            while (reader.Read())
            {
                person.id = int.Parse(reader["result"].ToString());
            }
            reader.Close();
            db.disconnect();
            return person;
        }

        private static int add_country(string country)
        {
            int country_id = 0;
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC create_country '" + general.clean(country) + "'");
            while (reader.Read())
            {
                country_id = int.Parse(reader["result"].ToString());
            }
            reader.Close();
            db.disconnect();
            return country_id;
        }

    }
}