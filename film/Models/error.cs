using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class error
    {
        public int id { get; set; }
        public user user { get; set; }
        public DateTime error_logged { get; set; }
        public string error_message { get; set; }
    }
    public class error_model
    {

    }
}