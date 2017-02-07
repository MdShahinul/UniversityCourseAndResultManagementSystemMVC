using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class AllocateClassroomViewManager
        
    {

        AllocateClassroomViewGateway allocateClassroomViewGateway = new AllocateClassroomViewGateway();

        public List<AllocateClassroomViewModel> GatAllAllocateRoomViewManager(int? DepartmentId)
        {
            return allocateClassroomViewGateway.GatAllAllocateRoomViewGateway(DepartmentId);
        }
    }
}