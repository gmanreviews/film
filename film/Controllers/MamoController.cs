using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using film.Models;

namespace film.Controllers
{
    public class MamoController : Controller
    {
        // GET: Mamo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TopTen()
        {
            return View(mamo_model.get_mamo_top_ten());
        }

        public ActionResult Team(int id)
        {
            return View(mamo_model.get_player_mamo_team(new user(id)));
        }

        public ActionResult years_dropdown()
        {
            return View(mamo_year_model.get_years());
        }

        public ActionResult mamo_team_member(int id = 0)
        {
            if (id == 0) return new EmptyResult();
            else return View(mamo_team_model.get_mamo_team_member(id)); 
        }
    }
}