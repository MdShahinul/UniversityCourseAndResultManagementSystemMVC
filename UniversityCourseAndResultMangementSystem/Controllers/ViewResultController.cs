using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class ViewResultController : Controller
    {
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        CourseManager courseManager = new CourseManager();
        RegisterStudentManager registerStudentManager = new RegisterStudentManager();

        [HttpGet]
        public ActionResult ResultView()
        {
            ViewBag.message = registerStudentManager.GateRegistationNumberManager();
            return View();
        }
        //[HttpPost]
        //public ActionResult ResultView(ViewResultModel viewResultModel)
        //{
        //    return View();
        //}

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