using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class StudentResultManager
    {
        StudentResultGateway studentResultGateway = new StudentResultGateway();

        public string StudentResultSaveManager(StudentResultModel studentResultModel)
        {
            int rowAffect = studentResultGateway.StudentResultSaveGateway(studentResultModel);
            if (rowAffect > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save Fail"; 
            }
        }

        public List<GradeModel> GatAllGradeManager()
        {
            return studentResultGateway.GatAllGradeGateway(); 
        } 
    }
}