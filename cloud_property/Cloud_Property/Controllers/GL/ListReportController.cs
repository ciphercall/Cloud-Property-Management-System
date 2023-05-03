using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud_Property.Controllers;
using Cloud_Property.Models;
using RazorPDF;

namespace Cloud_Property.Controllers
{
    public class ListReportController : AppController
    {
        private PropertyDbContext db = new PropertyDbContext();

       

        //public ActionResult GetListOfParty()
        //{
        //    //var pdf = new PdfResult(null, "GetListOfParty");
        //    //return pdf;
        //    return View();
        //}


        //public ActionResult GetExpensesList()
        //{
        //    //var pdf = new PdfResult(null, "GetExpensesList");
        //    //return pdf;
        //    return View();
        //}

        public ActionResult Get_HeadOfAccounts_List()
        {
            //var pdf = new PdfResult(null, "Get_HeadOfAccounts_List");
            //return pdf;
            return View();
        }

        public ActionResult Get_ListofCostPool()
        {
            return View();
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
