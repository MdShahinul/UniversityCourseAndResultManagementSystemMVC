using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
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
        ViewResultManager viewResultManager = new ViewResultManager();

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

        public JsonResult GateRegisterNumberByStudentId(int StudentId)
        {
            EnrollCourseModel register = enrollCourseManager.GateRegisterNumberByStudentId(StudentId);
            return Json(register, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GateListOfStudentResult(int StudentId)
        {
            var grade = viewResultManager.GateListOfStudentResult(StudentId);
            var gradeList = grade.Where(a => a.StudentId == StudentId).ToList();
            return Json(gradeList, JsonRequestBehavior.AllowGet);
        }

        //0..................................................
        [HttpPost]
        public ActionResult ExportPDF(int stdId)
        {
            return new Rotativa.MVC.ActionAsPdf("InitializeToPDF", new { id = stdId })
            {
                FileName = Server.MapPath("~/Content/Result.pdf")
            };
        }
        public ActionResult InitializeToPDF(int id)
        {
            ViewBag.StudentInfo = viewResultManager.GetIdByStudentInfo(id);
            ViewBag.ResultList = viewResultManager.GateListOfStudentResult(id);
            return View();
        }
      
	}
}