using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace film.Models
{
    public class moviedb
    {
       
    }
    public class moviedb_model
    {
        private static string apikey = "cb37ebeb9a594967021ae6cef0810c58";

        /*
        public static string get_film_poster()
        {
            string output;
            string url = "http://api.themoviedb.org/3/movie/id/images";
            return output;
        }
        */
        public static int get_movie_db_id(string movie_name)
        {
            /*
            List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();
            parameters.Add(new Tuple<string, string>("api_key", apikey));
            parameters.Add(new Tuple<string, string>("query", movie_name));
            string url = build_api_query("http://api.themoviedb.org/3/search/movie?", parameters);
            */

            string text = "";
            var request = WebRequest.Create("http://api.themoviedb.org/3/search/movie?");
            request.ContentType = "application/json";
            request.Headers.Add("api_key", apikey);
            request.Headers.Add("query", movie_name);

            var response = (HttpWebResponse)request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            JObject json = JsonConvert.DeserializeObject(text) as JObject;
            

            return 0;
            
        }

        private static string build_api_query(string base_url, List<Tuple<string,string>> parameters)
        {
            string full_url = base_url;
            for(int x = 0; x < parameters.Count; x++)
            {
                if (x != 1) full_url += "&";
                full_url += parameters.ElementAt(x).Item1 + "=" + parameters.ElementAt(x).Item2;
            }
            return full_url;
        }
    }
    public class moviedb_query_object
    {

    }
}