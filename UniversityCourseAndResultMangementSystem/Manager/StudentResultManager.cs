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
            if (studentResultGateway.IsExistNotEnorllResult(studentResultModel) != null)
            {
                if (studentResultGateway.IsExistResult(studentResultModel) == null)
                {
                    if (studentResultGateway.StudentResultSaveGateway(studentResultModel) > 0)
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
                    return studentResultGateway.IsExistResult(studentResultModel);
                }
            }
            else
            {
                return "This Student are Not Enroll !"; 
            }
        }

        public List<GradeModel> GatAllGradeManager()
        {
            return studentResultGateway.GatAllGradeGateway();
        }

       
    }
}