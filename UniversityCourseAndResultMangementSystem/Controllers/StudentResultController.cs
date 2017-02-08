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

    }
}