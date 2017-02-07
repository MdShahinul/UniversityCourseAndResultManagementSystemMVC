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



        public List<AllocateClassroomModel> GateAllRoomNoGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Room";
            SqlCommand cmd = new SqlCommand(query, con);
            List<AllocateClassroomModel> allocateClassroomModels = new List<AllocateClassroomModel>();
            AllocateClassroomModel allocateClassroom = new AllocateClassroomModel();
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    allocateClassroom.RoomNoId = Convert.ToInt32(dataReader["RoomId"]);
                    allocateClassroom.RoomNo = dataReader["RoomNo"].ToString();
                    allocateClassroomModels.Add(allocateClassroom);
                }
                dataReader.Close();
            }
            con.Close();
            return allocateClassroomModels;
        }

      }
}