using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class UnAllocateClassroomManager
    {
        UnAllocateClassroomGateway unAllocateClassroomGateway = new UnAllocateClassroomGateway();

        public string UnAllocate(AllocateClassroomViewModel allocateClassroomViewModel)
        {
            if (unAllocateClassroomGateway.UnAllocate(allocateClassroomViewModel) > 0)
            {
                return "UnAllocate All Classroom Successfull"; 
            }
            else
            {
                 return "Sorry, Nothing to UnAllocate.";
            }
           

        }

    }
}