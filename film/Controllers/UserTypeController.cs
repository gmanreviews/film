using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chess.Models;

namespace chess.Controllers
{
    public class UserTypeController : Controller
    {
        public ActionResult user_type_dropdown()
        {
            return View(user_type_model.get_all_user_types());
        }
    }
}