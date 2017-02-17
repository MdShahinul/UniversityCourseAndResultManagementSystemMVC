using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class UnAllocateClassroomGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        public int UnAllocate(AllocateClassroomViewModel allocateClassroomViewModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Delete from UnAllocateClassrooms"; 
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffect; 
        }
    }
}