﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Cloud_Property.Models;

namespace Cloud_Property.Controllers
{
    public class BillingReportController : AppController
    {
        private PropertyDbContext db = new PropertyDbContext();






        //Stock From (SaleController)
        public ActionResult SaleMemo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetSaleMemoReports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetSaleMemoReports_SmallSize");
            }
            else if (command == "D/C")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetSaleMemoReports_DeliveryChallan");
            }
            else
            {
                return RedirectToAction("Index", "Sale");
            }
        }

        public ActionResult GetSaleMemoReports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetSaleMemoReports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetSaleMemoReports_DeliveryChallan()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }










        //Stock From (SaleReturnController)
        public ActionResult SaleReturn_Memo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetSaleReturn_Reports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetSaleReturn_Reports_SmallSize");
            }
            else
            {
                return RedirectToAction("Index", "SaleReturn");
            }
        }

        public ActionResult GetSaleReturn_Reports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetSaleReturn_Reports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }















        //Stock From (BuyController)
        public ActionResult BuyMemo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetBuy_Reports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetBuy_Reports_SmallSize");
            }
            else
            {
                return RedirectToAction("Index", "Buy");
            }
        }

        public ActionResult GetBuy_Reports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetBuy_Reports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }





        //Stock From (BuyReturn Controller)
        public ActionResult BuyReturn_Memo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetBuyReturn_Reports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetBuyReturn_Reports_SmallSize");
            }
            else
            {
                return RedirectToAction("Index", "BuyReturn");
            }
        }

        public ActionResult GetBuyReturn_Reports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetBuyReturn_Reports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }









        //Stock From (Issue Controller)
        public ActionResult IssueMemo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetIssue_Reports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetIssue_Reports_SmallSize");
            }
            else
            {
                return RedirectToAction("Index", "Issue");
            }
        }

        public ActionResult GetIssue_Reports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetIssue_Reports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }








        //Stock From (Receive Controller)
        public ActionResult ReceiveMemo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetReceive_Reports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetReceive_Reports_SmallSize");
            }
            else
            {
                return RedirectToAction("Index", "Receive");
            }
        }

        public ActionResult GetReceive_Reports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetReceive_Reports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }









        //Stock From (Transfer Controller)
        public ActionResult TransferMemo(PageModel model)
        {
            model = (PageModel)TempData["pageModel"];
            var command = TempData["Sale_Command"].ToString();
            if (command == "A4")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetTransfer_Reports_BigSize");
            }
            else if (command == "POS")
            {
                TempData["billingReportViewModel"] = model;
                return RedirectToAction("GetTransfer_Reports_SmallSize");
            }
            else
            {
                return RedirectToAction("Index", "Transfer");
            }
        }

        public ActionResult GetTransfer_Reports_BigSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }

        public ActionResult GetTransfer_Reports_SmallSize()
        {
            var model = (PageModel)TempData["billingReportViewModel"];

            string Date = model.StkTrans.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");

            ViewBag.Date = getDate;
            ViewBag.InvoiceNo = model.StkTrans.TRANSNO.ToString();
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
    }
}
