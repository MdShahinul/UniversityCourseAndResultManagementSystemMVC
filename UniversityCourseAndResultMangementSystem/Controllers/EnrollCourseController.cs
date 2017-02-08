using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        RegisterStudentManager registerStudentManager = new RegisterStudentManager();
       
        public ActionResult EnrollCourseSave()
        {
            ViewBag.registerList = registerStudentManager.GateRegistationNumberManager(); 
            return View();
        }

       
	}
}