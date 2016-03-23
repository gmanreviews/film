using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class general
    {
        public static string clean(string input)
        {
            return input.Replace("'", "''");
        }

        public static user user
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session["user"] != null)
                        return (user)HttpContext.Current.Session["user"];
                    else
                        return new user();
                }
                catch
                {
                    return new user();
                }
            }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }
    }
}