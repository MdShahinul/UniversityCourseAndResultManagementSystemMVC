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
            if (allocateClassroomGateway.CanAllocateClassRoom(allocateClassroomModel) > 0 || allocateClassroomGateway.CanAllocateClassRoom2(allocateClassroomModel) > 0)
            {
                return
                    "Sorry, You can't Allocate room in this schedule, This Schedule Haven ,Please Try with Anther Shedule."; 
            }
            else
            {
                if (allocateClassroomGateway.AllocateClassRoomGateway(allocateClassroomModel) > 0 && allocateClassroomGateway.UnAllocateClassRoomGateway(allocateClassroomModel) >0) 
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
}