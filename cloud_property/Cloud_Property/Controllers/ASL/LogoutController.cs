﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloud_Property.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Index()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
