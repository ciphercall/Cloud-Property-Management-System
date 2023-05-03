using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud_Property.Models;

namespace Cloud_Property.Controllers
{
    public class IncomeController : AppController
    {

        public IncomeController()
        {
            ViewData["HighLight_Menu_AccountReports"] = "High Light Menu";
        }



        // GET: /Income/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PageModel model)
        {
            TempData["Income Statement"] = model;
            return RedirectToAction("IncomeStatementReport");
        }

        public ActionResult IncomeStatementReport()
        {

            PageModel model = (PageModel)TempData["Income Statement"];
            return View(model);
        }
    }
}
