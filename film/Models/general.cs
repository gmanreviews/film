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
    }
}