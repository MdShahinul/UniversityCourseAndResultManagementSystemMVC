using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class RegisterStudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        RegisterStudentManager _registerStudentManager = new RegisterStudentManager();
        // GET: RegisterStudent
        [HttpGet]
        public ActionResult RegirstStudentSave()
        {
            ViewBag.message = TempData["Msg"]; 
            ViewBag.DepartmentList = departmentManager.GateAllDepertmentManager();
            return View();
        }
        [HttpPost]
        public ActionResult RegirstStudentSave(RegisterStudentModel registerStudent)
        {

            ViewBag.message = _registerStudentManager.SaveRegisterStuden(registerStudent);
            //departmentManager.GateAllDepertmentManager();
            TempData["Msg"] = ViewBag.message;
            return RedirectToAction("RegirstStudentSave"); 
        }
	}
}