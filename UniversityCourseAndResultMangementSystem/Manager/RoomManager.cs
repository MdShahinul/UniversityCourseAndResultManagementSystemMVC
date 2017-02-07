using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class RoomManager
    {
        RoomGateway roomGateway = new RoomGateway();

        public List<RoomModel> GateAllRoomNoManager()
        {
            return roomGateway.GateAllRoomNoGateway();
        }
    }
}