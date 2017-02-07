using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class DayOfWeekManager
    {
        DayOfWeekGateway dayOfWeekGateway = new DayOfWeekGateway();
        public List<DayOfWeekModel> GateAllDayManager()
        {
            return dayOfWeekGateway.GateAllDayGateway(); 
        }
    }
}