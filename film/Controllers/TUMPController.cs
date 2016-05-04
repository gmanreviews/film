using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace film.Controllers
{
    public class TUMPController : Controller
    {
        // GET: TUMP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult League(int id = 0)
        {
            if (id == 0) return RedirectToAction("Index");
            else return View();
        }
    }
}