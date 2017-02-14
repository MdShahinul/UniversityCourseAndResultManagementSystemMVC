using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using Newtonsoft.Json.Schema;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        RegisterStudentManager registerStudentManager = new RegisterStudentManager();
        CourseAssignManager courseManager = new CourseAssignManager();
        //CourseManager courseManager = new CourseManager();
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
        public JsonResult GateRegisterNumberByStudentId(int StudentId)
        {
            EnrollCourseModel register = enrollCourseManager.GateRegisterNumberByStudentId(StudentId); 
            return Json(register, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GateAllCourse(int? StudentId)
        {
            var department = GetDepertmentIdByStudentId(StudentId);
            var course = courseManager.GateAllCourseManager();
            var courseList = course.Where(a => a.DepartmentId == department).ToList(); 
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        
        int GetDepertmentIdByStudentId(int? StudentId)
        {
            return enrollCourseManager.GetDepertmentIdByStudentId(StudentId);
        }

	}
}