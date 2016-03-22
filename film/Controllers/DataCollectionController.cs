﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
//using Microsoft.
using film.Models;

namespace film.Controllers
{
    public class DataCollectionController : Controller
    {
        
        public JsonResult UpdateFilmData()
        {
            curl.update_box_office_data();
            return Json(new { work = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateFilmList()
        {
            return Json(new { work = true }, JsonRequestBehavior.AllowGet);
        }
        
        
    }
}