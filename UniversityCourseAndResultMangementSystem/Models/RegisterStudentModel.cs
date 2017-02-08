using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultMangementSystem.Models
{
    public class RegisterStudentModel
    {
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is must currect Format")]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string RegistationNumber { get; set; }

    }
}