using Cloud_Property.Models;
using Cloud_Property.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cloud_Property.Controllers.GL
{
    public class CostpoolChildController : AppController
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;

        PropertyDbContext db = new PropertyDbContext();
        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;

        public CostpoolChildController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            ViewData["HighLight_Menu_AccountForm"] = "highlight menu";
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CostPoolDTO model)
        {
            //.........................................................Create Permission Check
            var LoggedCompId = System.Web.HttpContext.Current.Session["loggedCompID"].ToString();
            var loggedUserID = System.Web.HttpContext.Current.Session["loggedUserID"].ToString();

            var createStatus = "";

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());
            string query = string.Format("SELECT STATUS, INSERTR, UPDATER, DELETER FROM ASL_ROLE WHERE  CONTROLLERNAME='CostpoolChild' AND COMPID='{0}' AND USERID = '{1}'", LoggedCompId, loggedUserID);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            foreach (DataRow row in ds.Rows)
            {
                createStatus = row["INSERTR"].ToString();
            }

            conn.Close();

            if (createStatus == 'I'.ToString())
            {
                //TempData["ShowAddButton"] = "Show Add Button";
                TempData["costpool"] = model;
                TempData["CostCID"] = model.COSTCID;

                TempData["message"] = "Permission not granted!";
                return RedirectToAction("Index");
            }
            //...............................................................................................

        

            if (model.COSTCID == null)
            {
                TempData["message"] = "Enter COSTCID First";
                return View("Index");
            }
            model.USERPC = strHostName;
            model.INSIPNO = ipAddress.ToString();
            model.INSTIME = td;
            model.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
            model.INSLTUDE = model.INSLTUDE;


            try
            {


                GL_COSTPMST mst_CompID = db.GLCostPMSTDbSet.FirstOrDefault(r => (r.COMPID == model.COMPID));

                Int64 CostCID = Convert.ToInt64(model.COSTCID);

                GL_COSTPMST mst_CostCID = db.GLCostPMSTDbSet.FirstOrDefault(r => (r.COSTCID == CostCID));

                if (mst_CompID == null && mst_CostCID == null)
                {
                    //TempData["ShowAddButton"] = "Show Add Button";
                    TempData["message"] = "COSTCID not found ";
                    return View("Index");
                }
                else
                {
                    Int64 maxData = Convert.ToInt64((from n in db.GlCostPoolDbSet where n.COMPID == model.COMPID && n.COSTCID == model.COSTCID select n.COSTPID).Max());

                    Int64 R = Convert.ToInt64(CostCID + "9999");

                    if (maxData == 0)
                    {
                        model.COSTPID = Convert.ToInt64(CostCID + "0001");
                        GL_COSTPOOL obj = new GL_COSTPOOL();
                        obj.COMPID = model.COMPID;
                        obj.COSTCID = model.COSTCID;
                        obj.COSTPID = model.COSTPID;
                        obj.COSTPNM = model.COSTPNM;
                        obj.COSTPSID = model.COSTPSID;
                        obj.EHODT = Convert.ToDateTime(model.EHODT);
                        obj.INSIPNO = model.INSIPNO;
                        obj.INSLTUDE = model.INSLTUDE;
                        obj.INSTIME = model.INSTIME;
                        obj.INSUSERID = model.INSUSERID;
                        obj.LOCATION = model.LOCATION;
                        obj.PCITY = model.PCITY;
                        obj.PROJECTFY = model.PROJECTFY;
                        obj.PSIZE = model.PSIZE;
                        obj.PTYPE = model.PTYPE;
                        obj.REMARKS = model.REMARKS;
                        obj.USERPC = model.USERPC;




                        db.GlCostPoolDbSet.Add(obj);
                        if (db.SaveChanges() > 0)
                        {
                            TempData["message"] = "Project List Successfully Saved";
                            model.COSTPNM = "";
                            model.COSTPSID = "";
                            model.REMARKS = "";




                        }

                    }
                    else if (maxData <= R)
                    {

                        model.COSTPID = maxData + 1;

                        //Insert_GL_CostPool_LogData(model);
                        GL_COSTPOOL obj = new GL_COSTPOOL();
                        obj.COMPID = model.COMPID;
                        obj.COSTCID = model.COSTCID;
                        obj.COSTPID = model.COSTPID;
                        obj.COSTPNM = model.COSTPNM;
                        obj.COSTPSID = model.COSTPSID;
                        obj.EHODT = Convert.ToDateTime(model.EHODT);
                        obj.INSIPNO = model.INSIPNO;
                        obj.INSLTUDE = model.INSLTUDE;
                        obj.INSTIME = model.INSTIME;
                        obj.INSUSERID = model.INSUSERID;
                        obj.LOCATION = model.LOCATION;
                        obj.PCITY = model.PCITY;
                        obj.PROJECTFY = model.PROJECTFY;
                        obj.PSIZE = model.PSIZE;
                        obj.PTYPE = model.PTYPE;
                        obj.REMARKS = model.REMARKS;
                        obj.USERPC = model.USERPC;
                        db.GlCostPoolDbSet.Add(obj);
                        db.SaveChanges();
                        TempData["message"] = "Project List Successfully Saved";
                        model.COSTPNM = "";
                        model.COSTPSID = "";
                        model.REMARKS = "";



                    }
                    else
                    {
                        TempData["message"] = "Project List entry not possible";
                        //TempData["ShowAddButton"] = "Show Add Button";

                    }
                }


            }
            catch (Exception ex)
            {

            }
            //TempData["ShowAddButton"] = "Show Add Button";
            TempData["costpool"] = model;
            TempData["CostCID"] = model.COSTCID;

            return RedirectToAction("Index");


           
        }

        public ActionResult Update()
        {
            return View();
        }


        public JsonResult TagSearch(string term, string Costcid)
        {
            //var compid = Convert.ToInt16(System.Web.HttpContext.Current.Request.Cookies["CI"].Value);
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"]);
            Int64 costcid = Convert.ToInt64(Costcid);

            var tags = from p in db.GlCostPoolDbSet
                       where p.COMPID == compid && p.COSTCID == costcid
                       select new { p.COSTPID,p.COSTPNM,p.COSTPSID,p.PROJECTFY,p.PCITY,p.LOCATION,p.PSIZE,p.PTYPE,p.REMARKS,
                           p.EHODT};

            return this.Json(tags.Where(t => t.COSTPNM.StartsWith(term)),
                            JsonRequestBehavior.AllowGet);
        }
         [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult DateFetch(string changedText)
        {
            Int64 Costpid = Convert.ToInt64(changedText);
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"]);
            var search_date = (from n in db.GlCostPoolDbSet where n.COMPID == compid && n.COSTPID == Costpid select n).ToList();
            string ehodt = "";
             foreach(var ss in search_date)
             {
                 string xx = Convert.ToString(ss.EHODT);
                 DateTime eee = DateTime.Parse(xx);
                 ehodt = eee.ToString("dd-MMM-yyyy");
             }
             var result = new { EHODT = ehodt };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[AcceptVerbs(HttpVerbs.Get)]  x = p.EHODT.ToString("dd-MMM-yyyy")
        //public JsonResult ItemNameChanged(string changedText)
        //{
        //    var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());


        //    String itemId = "";

        //    var rt = db.GlCostPoolDbSet.Where(n => n.COSTPNM.StartsWith(changedText) &&
        //                                                 n.COMPID == compid).Select(n => new
        //                                                 {
        //                                                     costname = n.COSTPNM

        //                                                 }).ToList();
        //    int lenChangedtxt = changedText.Length;

        //    Int64 cont = rt.Count();
        //    Int64 k = 0;
        //    string status = "";
        //    if (changedText != "" && cont != 0)
        //    {
        //        while (status != "no")
        //        {
        //            k = 0;
        //            foreach (var n in rt)
        //            {
        //                string ss = Convert.ToString(n.costname);
        //                string subss = "";
        //                if (ss.Length >= lenChangedtxt)
        //                {
        //                    subss = ss.Substring(0, lenChangedtxt);
        //                    subss = subss.ToUpper();
        //                }
        //                else
        //                {
        //                    subss = "";
        //                }


        //                if (subss == changedText.ToUpper())
        //                {
        //                    k++;
        //                }
        //                if (k == cont)
        //                {
        //                    status = "yes";
        //                    lenChangedtxt++;
        //                    if (ss.Length > lenChangedtxt - 1)
        //                    {
        //                        changedText = changedText + ss[lenChangedtxt - 1];
        //                    }

        //                }
        //                else
        //                {
        //                    status = "no";
        //                    //lenChangedtxt--;
        //                }

        //            }

        //        }
        //        if (lenChangedtxt == 1)
        //        {
        //            itemId = changedText.Substring(0, lenChangedtxt);
        //        }

        //        else
        //        {
        //            itemId = changedText.Substring(0, lenChangedtxt - 1);
        //        }



        //    }
        //    else
        //    {
        //        itemId = changedText;
        //    }

                
        //    String itemId2 = "";

        //    var rt2 = db.GlCostPoolDbSet.Where(n => n.COSTPNM == changedText &&
        //                                                 n.COMPID == compid).Select(n => new
        //                                                 {
        //                                                     costpid = n.COSTPID,

        //                                                 });
        //    foreach (var n in rt2)
        //    {
        //        itemId2 = Convert.ToString(n.costpid);

        //    }

        //    var result = new { Costname = itemId, Costpid = itemId2 };
        //    return Json(result, JsonRequestBehavior.AllowGet);

        //}


    }
}
