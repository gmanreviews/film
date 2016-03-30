﻿using System;
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

        public ActionResult Team(int id, int year = 0)
        {
            return View(mamo_team_model.get_mamo_team(id));
        }

        public ActionResult new_team_member(int id = 0)
        {
            ViewData["team_id"] = id;
            return View(new mamo());
        }

        public ActionResult years_dropdown()
        {
            return View(mamo_year_model.get_years());
        }

        [HttpPost]
        public ActionResult years_dropdown(int mamo_year_dropdown)
        {
            if (user_model.am_i_logged_in()) return RedirectToAction("Team", new { id = general.user.id, year = mamo_year_dropdown });
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult mamo_team_member(int id = 0)
        {
            if (id == 0) return new EmptyResult();
            else return View(mamo_team_model.get_mamo_team_member(id)); 
        }

        public ActionResult mamo_film_picker(int id = 0, int year = 0)
        {
            if (year == 0) year = mamo_year_model.get_current_game().id;
            return View(mamo_model.all_posible_films_for_mamo_game(new mamo_team(id, new mamo_year(year))));
        }

        public ActionResult mamo_team_member_create(int id, int year = 0)
        {
            if (year == 0) year = mamo_year_model.get_current_game().id;
            return View(new mamo_team(id, new mamo_year(year)));
        }

        public ActionResult myscore(int id, int year = 0)
        {
            mamo_team team = new mamo_team();
            team.owner = new user(id);
            if (year == 0) team.year = mamo_year_model.get_current_game();
            else team.year = new mamo_year(year);
            ViewData["year_id"] = team.year.id;
            return View(mamo_team_model.my_team_score(team));
        }

        public ActionResult scoreboard(int id = 0)
        {
            if (id == 0) id = mamo_year_model.get_current_game().id;
            return View(mamo_team_model.scoreboard(new mamo_year(id)));
        }

        public ActionResult rowthreelink()
        {
            return View();
        }

    }
}