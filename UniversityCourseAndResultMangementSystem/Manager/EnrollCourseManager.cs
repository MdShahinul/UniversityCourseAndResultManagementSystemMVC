using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();

        public string GateAllEnrollCourseManager(EnrollCourseModel enrollCourseModel)
        {
            if (enrollCourseGateway.IsExist(enrollCourseModel) == null)
            {
                if (enrollCourseGateway.GateAllEnrollCourseGateway(enrollCourseModel) > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Save Fail";
                }
            }
            else
            {
                return enrollCourseGateway.IsExist(enrollCourseModel); 
            }
          
        }

        public EnrollCourseModel GateRegisterNumberByStudentId(int StudentId)
        {
            return enrollCourseGateway.GateRegisterNumberByStudentId(StudentId); 
        }

       

        public int GetDepertmentIdByStudentId(int? StudentId)
        {
            return enrollCourseGateway.GetDepertmentIdByStudentId(StudentId); 
        }
      
    }
}