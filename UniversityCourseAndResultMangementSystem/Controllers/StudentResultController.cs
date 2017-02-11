using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class StudentResultController : Controller
    {

        RegisterStudentManager registerStudentManager = new RegisterStudentManager();
        StudentResultManager studentResultManager = new StudentResultManager();
        CourseManager courseManager = new CourseManager();
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        [HttpGet]
        public ActionResult StudentResultSave()
        {
            ViewBag.message = TempData["Msg"]; 
            ViewBag.registerList = registerStudentManager.GateRegistationNumberManager();
            ViewBag.gradeList = studentResultManager.GatAllGradeManager(); 
            return View();
        }

        [HttpPost]
        public ActionResult StudentResultSave(StudentResultModel studentResultModel)
        {
            ViewBag.message = studentResultManager.StudentResultSaveManager(studentResultModel);
            TempData["Msg"] = ViewBag.message;
            return RedirectToAction("StudentResultSave"); 
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