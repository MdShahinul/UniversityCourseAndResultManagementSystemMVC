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
        public int CanAllocateClassRoom(AllocateClassroomModel allocateClassRooms)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = " select * from AllocateClassroom where RoomNoId=" + allocateClassRooms.RoomNoId + " and DayId= '" + allocateClassRooms.DayId + "' and (FromAmOrPm='" + allocateClassRooms.FromAmOrPm + "' and '" + string.Format("{0:hh.mm}", allocateClassRooms.FromDate) + "'>=FromDate) and '" + string.Format("{0:hh.mm}", allocateClassRooms.FromDate) + "'<ToDate or RoomNoId=" + allocateClassRooms.RoomNoId + " and DayId= '" + allocateClassRooms.DayId + "'  and '" + string.Format("{0:hh.mm}", allocateClassRooms.ToDate) + "'>FromDate and ('" + string.Format("{0:hh.mm}", allocateClassRooms.ToDate) + "'<=ToDate and ToAmOrPm='" + allocateClassRooms.ToAmOrPm + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                return 1;
            }
            else
            {
                reader.Close();
                connection.Close();
                return 0;
            }
        }
        public int CanAllocateClassRoom2(AllocateClassroomModel allocateClassRooms)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = " select * from AllocateClassroom where RoomNoId='" + allocateClassRooms.RoomNoId + "' and DayId= '" + allocateClassRooms.DayId + "' and ( ('" + string.Format("{0:hh.mm}", allocateClassRooms.FromDate) + "'>=FromDate and '" + string.Format("{0:hh.mm}", allocateClassRooms.FromDate) + "'<ToDate )and (FromAmOrPm='AM' or FromAmOrPm='" + allocateClassRooms.FromAmOrPm + "')) and ('" + string.Format("{0:hh.mm}", allocateClassRooms.ToDate) + "'<=ToDate and ToAmOrPm='" + allocateClassRooms.ToAmOrPm + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                return 1;
            }
            else
            {
                reader.Close();
                connection.Close();
                return 0;
            }
        }



      }
}