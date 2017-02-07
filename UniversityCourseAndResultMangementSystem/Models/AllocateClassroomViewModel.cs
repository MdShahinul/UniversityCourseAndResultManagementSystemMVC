using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class AllocateClassroomViewModel
    {
    
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int RoomNoId { get; set; }
        public string RoomNo { get; set; }
        public int DayId { get; set; }
        public string DayName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FromAmOrPm { get; set; }
        public string ToAmOrPm { get; set; }
    }
}