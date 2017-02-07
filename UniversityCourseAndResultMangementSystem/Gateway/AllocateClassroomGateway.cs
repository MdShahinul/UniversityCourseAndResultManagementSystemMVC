using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class AllocateClassroomGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        public int AllocateClassRoomGateway(AllocateClassroomModel allocateRoom)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into AllocateClassroom values ('" + allocateRoom.DepartmentId + "','" +
                           allocateRoom.CourseId + "','" + allocateRoom.RoomNoId + "','" + allocateRoom.DayId + "','" +
                           allocateRoom.FromDate + "','" + allocateRoom.ToDate + "','" + allocateRoom.FromAmOrPm + "','" +
                           allocateRoom.ToAmOrPm + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffcet = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffcet;
        }
        
      }
}