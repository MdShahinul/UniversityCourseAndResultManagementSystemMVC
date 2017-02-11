using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class StudentResultModel
    {
        public int StudentId { get; set; }
        public string RegisterNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail{ get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName {get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int GradeId { get; set; }
    }
}