using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGateway courseAssignGateway = new CourseAssignGateway();

        public List<CourseModel> GateAllCourseManager()
        {
            return courseAssignGateway.GateAllCourseGateway();
        }

        public string SaveCourseAssignManager(CourseAssignModel courseAssignModel)
        {

            if (courseAssignGateway.IsExistCourseGateway(courseAssignModel) == null)
            {
                if (courseAssignGateway.SaveCourseAssignGateway(courseAssignModel) > 0)
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
                return courseAssignGateway.IsExistCourseGateway(courseAssignModel); 
            }

        }

        public CourseAssignModel GateCourseCredit(int? courseId)
        {
            return courseAssignGateway.GateCourseCredit(courseId);
        }

        public List<CourseAssignModel> GatAllViewCourseStaticManager()
        {
            return courseAssignGateway.GatAllViewCourseStaticGateway();
        } 

    }
}