using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultMangementSystem.Manager;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Controllers
{
    public class UnallocateAllClassroomsController : Controller
    {
        UnAllocateClassroomManager unAllocateClassroomManager = new UnAllocateClassroomManager();
       [HttpGet]
        public ActionResult UnallocateClassroom()
        {
            ViewBag.message = TempData["Msg"];
            return View();
        }
        [HttpPost]
        public ActionResult UnallocateClassroom(AllocateClassroomViewModel allocateClassroomViewModel)
        {
            ViewBag.message = unAllocateClassroomManager.UnAllocate(allocateClassroomViewModel);
            TempData["Msg"] = ViewBag.message;
            return RedirectToAction("UnallocateClassroom");
        }
	}
}