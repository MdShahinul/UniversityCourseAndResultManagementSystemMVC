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
        public ActionResult StudentResultSave()
        {
            //ViewBag.registerList = registerStudentManager.GateRegistationNumberManager();
            //ViewBag.gradeList = studentResultManager.GatAllGradeManager(); 
            return View();
        }
        public ActionResult StudentResultSave(StudentResultModel studentResultModel)
        {
            return View();
        }
	}
}