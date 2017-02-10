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
            if (enrollCourseGateway.GateAllEnrollCourseGateway(enrollCourseModel) > 0)
            {
                return "Save Successfull"; 
            }
            else
            {
                return "Save Fail"; 
            }
        }
    }
}