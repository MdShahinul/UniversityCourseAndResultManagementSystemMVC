using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class AllocateClassroomViewController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        AllocateClassroomViewManager allocateClassroomViewManager = new AllocateClassroomViewManager();
        public ActionResult ViewClassRoomSchedule()
        {
            ViewBag.departmentList = departmentManager.GateAllDepertmentManager();
            return View();
        }





        public JsonResult GatCourseNameByDepartmentId(int? DepartmentId)
        {
            var courseSataticsList = allocateClassroomViewManager.GatAllAllocateRoomViewManager(DepartmentId);
            List<ScheduleInfoModel> schInfo = new List<ScheduleInfoModel>();
            foreach (var item in courseSataticsList)
            {
                if (schInfo.Any(x => x.CourseCode == item.CourseCode))
                {
                    var scinfo = schInfo.Single(x => x.CourseCode == item.CourseCode);
                    scinfo.ScheduleInfo += ";<br/>" + "R. No. " + item.RoomNo + ", " + item.DayName + ", " + item.FromDate+ item.FromAmOrPm + " - " + item.ToDate + item.ToAmOrPm;
                }
                else
                {
                    schInfo.Add(new ScheduleInfoModel()
                    {
                        CourseCode = item.CourseCode,
                        CourseName = item.CourseName,
                        ScheduleInfo = item.RoomNo != null ? "R. No. " + item.RoomNo + ", " + item.DayName + ", " + item.FromDate + item.FromAmOrPm + " - " + item.ToDate + item.ToAmOrPm : "Not Scheduled Yet",
                    });
                }
            }

            //var courseList = course.Where(a => a.DepartmentId == DepartmentId).ToList();
            return Json(schInfo, JsonRequestBehavior.AllowGet); 
        }

        public string ScheduleInfo { get; set; }
    }
}