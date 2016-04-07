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
            TempData["hide_login"] = true;
            return View();
        }

        [HttpPost]
        public ActionResult signup(user user, int user_type_dropdown = 0)
        {
            TempData["hide_login"] = true;
            if (ModelState.IsValid)
            {
                user.user_type = new user_type(user_type_dropdown);
                if (user_model.does_user_exist(user))
                {
                    user = user_model.remove_passwords(user);
                    ModelState.AddModelError("username", "This username is already in use. Please choose a different one.");
                    return View(user);
                }
                else if (user_model.is_email_in_use(user))
                {
                    user = user_model.remove_passwords(user);
                    ModelState.AddModelError("email", "This email is already in use. Please login with your credentials. Or use a different email to create this account.");
                    return View(user);
                }
                else if (!user_model.do_passwords_match(user))
                {
                    user = user_model.remove_passwords(user);
                    ModelState.AddModelError("password", "These passwords do not match.");
                    return View(user);
                }
                else {
                    user_model.add_user(user);
                    TempData["success"] = "Your user was successfully created";
                    return RedirectToAction("Index", "Home");
                }
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

        public ActionResult Profile()
        {
            if (general.user.id == 0) return RedirectToAction("Index", "Home", new { error = "You are not logged in. Please login before you go to your profile." });
            else return View(general.user);
        }

        [HttpPost]
        public ActionResult Profile(user user)
        {
            
            if (general.user.id == 0) return RedirectToAction("Index", "Home", new { error = "You are not logged in. Please login before you go to your profile." });
            else if (user.id != general.user.id) return RedirectToAction("Index", "Home", new { error = "You are not logged in. Please login before you go to your profile." });
            else {
                //update user
                return View(user);
            }
        }
        
    }
}