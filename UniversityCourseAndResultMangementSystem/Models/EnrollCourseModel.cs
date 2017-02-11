using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Newtonsoft.Json.Linq;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class EnrollCourseModel
    {
        public int EnrollCourseId { get; set; }
        public int StudentId { get; set; }
        public string RegistationNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
    }
}