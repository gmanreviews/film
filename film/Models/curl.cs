﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Text.RegularExpressions;

namespace film.Models
{
    public class curl
    {
        public static void update_film_list()
        {
            string url = "http://www.boxofficemojo.com/schedule/?view=bydate&release=theatrical&yr=2016&p=.htm";
            WebClient webclient = new WebClient();
            string page = webclient.DownloadString(url);

        }

        public static void update_box_office_data()
        {
            int count = 0;
            bool keep_running = true;
            string url_pt1 = "http://www.boxofficemojo.com/yearly/chart/?page=";
            string url_pt2 = "&view=releasedate&view2=domestic&yr=2016&p=.htm";
            // http://www.boxofficemojo.com/yearly/chart/?page=3&view=releasedate&view2=domestic&yr=2016&p=.htm
            while (keep_running)
            {
                count++;
                WebClient webclient = new WebClient();
                string websiteinstring = webclient.DownloadString(url_pt1 + count + url_pt2);
                List<movie> movies = parse_film_data(websiteinstring);
                if (movies.Count == 0) keep_running = false;
            }
        }
        
        private static List<movie> parse_film_data(string webpage)
        {
            List<movie> movies = new List<movie>();

            Regex regex = new Regex("<td>.*</td>");
            foreach (Match m in regex.Matches(webpage))
            {
                movies.AddRange(parse_film_data_lvl2(m.Value.ToString()));
            }


            return movies;
        }
        

        private static List<movie> parse_film_data_lvl2(string table)
        {
            List<movie> movies = new List<movie>();
            movie current_movie = new movie();

            int count = 0;

            // notes
            // 1 - name + slug
            // 2 - studio
            // 3 - total box office
            // 4 - theatre count(current)
            // 5 - opening box office
            // 6 - theatre count (opening)
            // 7 - release date
            // 8 - nonsense
            // 9 - release month (1 - January)

            Regex regex = new Regex("<td(.*?)?>.*?</td>");
            foreach (Match m in regex.Matches(table))
            {
                count++;
                if (count % 9 == 1)
                {
                    if (current_movie.id != 0)
                    {
                        current_movie = new movie();
                    }
                    current_movie.film_name = get_movie_name(m.Value.ToString());
                    current_movie.bo_mojo_slug = get_bo_mojo_slug(m.Value.ToString());
                }
                else if (count % 9 == 3) current_movie.box_office_total = get_box_office(m.Value.ToString());
                else if (count % 9 == 5) current_movie.box_office_opening = get_box_office(m.Value.ToString());
                else if (count % 9 == 0)
                {
                    current_movie.release_month = get_release_month(m.Value.ToString());
                    current_movie = movie_model.add_movie(current_movie);
                    movie_model.update_bo_data(current_movie);
                    movies.Add(current_movie);
                }
                m.Value.ToString();
            }

            return movies;
        }

        private static string get_movie_name(string text)
        {
            Regex regex = new Regex("htm\">[A-Za-z0-9 -.():,!'&?]+</a>");
            Match m = regex.Match(text);
            string output = m.Value.ToString().Replace("</a>", "").Replace("htm\">", "");
            return output;
        }

        private static string get_bo_mojo_slug(string text)
        {
            Regex regex = new Regex("id=[a-z0-9,]+[.]htm");
            Match m = regex.Match(text);
            string output = m.Value.ToString().Replace("id=", "").Replace(".htm", "");
            return output;
        }

        private static string get_box_office(string text)
        {
            Regex regex = new Regex("[$]([0-9]+(,)?)+");
            Match m = regex.Match(text);
            string output = m.Value.ToString().Replace(",", "").Replace("$", "");
            return output;
        }

        private static int get_release_month(string text)
        {
            try {
                Regex regex = new Regex("<font [a-z]+=\"[0-9]+\">[0-9]+");
                Regex font = new Regex("<font [a-z]+=\"[0-9]+\">");
                Match m = regex.Match(text);
                string output = m.Value.ToString();
                output = font.Replace(output, "");
                return int.Parse(output);
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}