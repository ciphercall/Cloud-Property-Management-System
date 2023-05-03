using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud_Property.Models;
using Cloud_Property.Models.ASL;
//using DHTMLX.Common;
//using DHTMLX.Scheduler;
//using DHTMLX.Scheduler.Data;

namespace Cloud_Property.Controllers.ASL
{
    public class CalendarController : AppController
    {
        private PropertyDbContext db = new PropertyDbContext();

        //public ActionResult Index()
        //{
        //    //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
        //    var scheduler = new DHXScheduler(this);

        //    /*
        //     * It's possible to use different actions of the current controller
        //     *      var scheduler = new DHXScheduler(this);     
        //     *      scheduler.DataAction = "ActionName1";
        //     *      scheduler.SaveAction = "ActionName2";
        //     * 
        //     * Or to specify full paths
        //     *      var scheduler = new DHXScheduler();
        //     *      scheduler.DataAction = Url.Action("Data", "Calendar");
        //     *      scheduler.SaveAction = Url.Action("Save", "Calendar");
        //     */

        //    /*
        //     * The default codebase folder is ~/Scripts/dhtmlxScheduler. It can be overriden:
        //     *      scheduler.Codebase = Url.Content("~/customCodebaseFolder");
        //     */


        //    scheduler.LoadData = true;
        //    scheduler.EnableDataprocessor = true;

        //    return View(scheduler);
        //}


        //public ContentResult Data()
        //{
        //    Int64 insertUserid = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
        //    var data = new SchedulerAjaxData(new PropertyDbContext().CalendarDbSet.Where(a => a.USERID == insertUserid));
        //    return (ContentResult)data;
        //}

        //public ContentResult Save(int? id, FormCollection actionValues)
        //{
        //    var action = new DataAction(actionValues);
        //    Int64 insertUserid = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
        //    try
        //    {
        //        var changedEvent = (ASL_CALENDAR)DHXEventsHelper.Bind(typeof(ASL_CALENDAR), actionValues);
        //        var data = new PropertyDbContext();


        //        switch (action.Type)
        //        {
        //            case DataActionTypes.Insert:
        //                changedEvent.USERID = insertUserid;
        //                data.CalendarDbSet.Add(changedEvent);
        //                //do insert
        //                //action.TargetId = changedEvent.id;//assign postoperational id
        //                break;
        //            case DataActionTypes.Delete:
        //                changedEvent = data.CalendarDbSet.SingleOrDefault(ev => ev.id == action.SourceId && ev.USERID == insertUserid);
        //                data.CalendarDbSet.Remove(changedEvent);
        //                //do delete
        //                break;
        //            default:
        //                var eventToUpdate = data.CalendarDbSet.SingleOrDefault(ev => ev.id == action.SourceId && ev.USERID == insertUserid);
        //                changedEvent.USERID = insertUserid;
        //                DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "id" });
        //                // "update"                          
        //                //do update
        //                break;
        //        }
        //        data.SaveChanges();
        //        action.TargetId = changedEvent.id;
        //    }
        //    catch
        //    {
        //        action.Type = DataActionTypes.Error;
        //    }
        //    return (ContentResult)new AjaxSaveResponse(action);
        //}


    }
}
