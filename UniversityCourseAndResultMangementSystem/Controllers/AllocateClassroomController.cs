﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class AllocateClassroomController : Controller
    {
        AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseAssignManager courseManager = new CourseAssignManager();
        DayOfWeekManager dayOfWeekManager = new DayOfWeekManager();
        RoomManager roomManager = new RoomManager();
        
       [HttpGet]
        public ActionResult AllocateRoom()
       {
            ViewBag.message = TempData["Msg"]; 
            ViewBag.departmentList = departmentManager.GateAllDepertmentManager();
            ViewBag.roomList = roomManager.GateAllRoomNoManager(); 
            ViewBag.dayList = dayOfWeekManager.GateAllDayManager();
           return View();
        }
        [HttpPost]
        public ActionResult AllocateRoom(AllocateClassroomModel allocateClassroomModel)
        {
            ViewBag.message = allocateClassroomManager.AllocateClassRoomManager(allocateClassroomModel);
            TempData["Msg"] = ViewBag.message;
            return RedirectToAction("AllocateRoom"); 
        }
        public JsonResult GetCourseByDepartmentId(int? DepartmentId)
        {
            var course = courseManager.GateAllCourseManager();
            var courseList = course.Where(c => c.DepartmentId == DepartmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet); 
        }




      


       


	}
}