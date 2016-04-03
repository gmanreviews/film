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

        public JsonResult lock_team(int id)
        {
            mamo_team team = mamo_team_model.get_mamo_team(id);
            if (!mamo_team_model.is_team_submitted(team) && mamo_team_model.is_this_my_team(team))
            {
                mamo_team_model.submit_team(new mamo_team(id));
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Team(int id, int year = 0)
        {
            if (mamo_team_model.is_this_my_team(new mamo_team(id)) && mamo_team_model.is_team_submitted(new mamo_team(id))){
                ViewData["editable"] = (!mamo_team_model.is_team_submitted(new mamo_team(id)) && mamo_team_model.is_this_my_team(new mamo_team(id)));
                return View(mamo_team_model.get_mamo_team(id));
            }
            else return RedirectToAction("Index", "Mamo", new { error = "This is not your team" });
        }

        [HttpPost]
        public ActionResult Team(int id, mamo_team team, mamo_year year, user owner)
        {
            if (id != 0) team.id = id;
            if (year != null) team.year = year;
            if (owner != null) team.owner = owner;

            if (!mamo_team_model.is_team_submitted(team) && mamo_team_model.is_this_my_team(team)) mamo_team_model.create_team(team);
            ViewData["editable"] = (!mamo_team_model.is_team_submitted(team) && mamo_team_model.is_this_my_team(team));
            return View(mamo_team_model.get_mamo_team(team.id));
        }

        public ActionResult new_team_member(int id = 0)
        {
            if (id == 0) return new EmptyResult();
            else {
                ViewData["team_id"] = id;
                return View(new mamo());
            }
        }

        public ActionResult old_team_member(int id = 0, mamo film = null)
        {
            if (film == null || id == 0) return new EmptyResult();
            else {
                ViewData["team_id"] = id;
                return View(film);
            }
        }

        [HttpPost]
        public JsonResult update_team_member(int id, int film_id, int rank, int bo_total, int bo_open)
        {
            mamo_team team = new mamo_team(id);
            mamo film = new mamo(film_id, null, bo_open.ToString(), bo_total.ToString(), rank, new DateTime());
            if (mamo_team_model.is_team_submitted(team)) return Json(new { success = false, submitted = true }, JsonRequestBehavior.DenyGet);
            else return Json(new { success = mamo_team_model.update_mamo_team_member(team, film), submitted = false }, JsonRequestBehavior.DenyGet);
        }

        

        public ActionResult years_dropdown()
        {
            return View(mamo_year_model.get_years());
        }

        [HttpPost]
        public ActionResult years_dropdown(int mamo_year_dropdown, string scoreboard = null, string team = null)
        {
            if (user_model.am_i_logged_in() && team != null) return RedirectToAction("Team", new { id = mamo_team_model.get_mamo_team_by_user_year(general.user, new mamo_year(mamo_year_dropdown)).id });
            else if (scoreboard != null) return RedirectToAction("Scoreboard", new { id = mamo_year_dropdown });
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult mamo_team_member(int id = 0)
        {
            if (id == 0) return new EmptyResult();
            else return View(mamo_team_model.get_mamo_team_member(id)); 
        }

        public JsonResult release_date(int id = 0)
        {
            DateTime date = new DateTime();
            if (id != 0) date = movie_model.get_movie_release_date(new movie(id));
            return Json(new { date = date.ToShortDateString() }, JsonRequestBehavior.AllowGet);
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