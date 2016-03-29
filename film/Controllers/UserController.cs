using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using film.Models;

namespace film.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginForm()
        {
            return View(new user());
        }

        public ActionResult LoggedInDisplay()
        {
            return View(general.user);
        }

        [HttpPost]
        public ActionResult LoginForm(user user)
        {
            if (user_model.login_authenticate(user))
            {
                general.user = user_model.get_user(user);
            }
            else
            {
                ModelState.AddModelError("error.error", "Bad login");
                user.password = null;
                //return View(user);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup(user user, int user_type_dropdown = 0)
        {
            if (ModelState.IsValid)
            {
                user.user_type = new user_type(user_type_dropdown);
                user_model.add_user(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("error.error", "Something's wrong with the data you put in");
                user = user_model.remove_passwords(user);
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            user_model.logout();
            return RedirectToAction("Index", "Home");
        }
        
    }
}