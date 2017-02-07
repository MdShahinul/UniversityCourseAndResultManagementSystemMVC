using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class AllocateClassroomManager
    {

        AllocateClassroomGateway allocateClassroomGateway =new AllocateClassroomGateway();

        public string AllocateClassRoomManager(AllocateClassroomModel allocateClassroomModel)
        {
            if (allocateClassroomGateway.AllocateClassRoomGateway(allocateClassroomModel) > 0)
            {
                return "Save Successfull"; 
            }
            else
            {
                return "Save Fail"; 
            }
        }

      

        public List<AllocateClassroomModel> GateAllRoomNoManager()
        {
            return allocateClassroomGateway.GateAllRoomNoGateway();
        }


    }
}