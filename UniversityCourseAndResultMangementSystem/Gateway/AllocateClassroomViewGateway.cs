using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class AllocateClassroomViewGateway
      
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public List<AllocateClassroomViewModel> GatAllAllocateRoomViewGateway( int? DepartmentId)
        {
          
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from ViewClassScheduleNew where DepartmentID = '"+DepartmentId+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            List<AllocateClassroomViewModel> allocateClassroomViewModels = new List<AllocateClassroomViewModel>();
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    AllocateClassroomViewModel allocateClassroomViewModel = new AllocateClassroomViewModel();
                    //allocateClassroomViewModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentId"]);
                    allocateClassroomViewModel.CourseCode = dataReader["CourseCode"].ToString();
                    allocateClassroomViewModel.CourseName = dataReader["CourseName"].ToString();
                    if (dataReader["DayName"].ToString() != string.Empty)
                    {
                        allocateClassroomViewModel.RoomNo = dataReader["RoomNo"].ToString();
                        allocateClassroomViewModel.DayName = dataReader["DayName"].ToString();
                        allocateClassroomViewModel.FromDate = dataReader["FromDate"].ToString();
                        allocateClassroomViewModel.FromAmOrPm = dataReader["FromAmOrPm"].ToString();
                        allocateClassroomViewModel.ToDate = dataReader["ToDate"].ToString();
                        allocateClassroomViewModel.ToAmOrPm = dataReader["ToAmOrPm"].ToString();
                    }
                    else
                    {
                        allocateClassroomViewModel.DayName = "No day.";
                        allocateClassroomViewModel.RoomNo = null;
                    }

                    allocateClassroomViewModels.Add(allocateClassroomViewModel);
                }
                dataReader.Close();
            }
            con.Close();
            return allocateClassroomViewModels;
        }
    }
}