using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud_Property.Models;

namespace Cloud_Property.Controllers
{
    public class RegisterController : AppController
    {

        public RegisterController()
        {
            ViewData["HighLight_Menu_AccountReports"] = "High Light Menu";
        }




        // GET: /Register/
        public ActionResult ChequeRegisterIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChequeRegisterIndex(PageModel model)
        {


            TempData["ChequeRegister"] = model;
            return RedirectToAction("ChequeRegisterReport");
        }
        public ActionResult ChequeRegisterReport()
        {
            PageModel model = (PageModel)TempData["ChequeRegister"];
            return View(model);
        }



        public ActionResult JournalRegisterIndex()
        {
            return View();
        }
        
    }
}
