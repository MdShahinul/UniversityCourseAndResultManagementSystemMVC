using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        RegisterStudentManager registerStudentManager = new RegisterStudentManager();
        CourseManager courseManager = new CourseManager();
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();

       [HttpGet]
        public ActionResult EnrollCourseSave()
        {
            ViewBag.message = TempData["Msg"];
            ViewBag.registerList = registerStudentManager.GateRegistationNumberManager();
            ViewBag.courseList=courseManager.GateAllCourseManager(); 
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourseSave(EnrollCourseModel enrollCourseModel)
        {
            ViewBag.message = enrollCourseManager.GateAllEnrollCourseManager(enrollCourseModel);
            TempData["Msg"] = ViewBag.message;
            return RedirectToAction("EnrollCourseSave");
        }
	}
}