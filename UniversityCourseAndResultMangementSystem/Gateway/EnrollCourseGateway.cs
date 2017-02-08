using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class EnrollCourseGateway
    {

        string connectingString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public int GateAllEnrollCourseGateway(EnrollCourseModel enrollCourseModel)
        {
            SqlConnection con = new SqlConnection(connectingString);
            string query = "select * from EnrollCourse values('"+enrollCourseModel.RegistationNumberId+"','"+enrollCourseModel.CourseId+"','"+enrollCourseModel.Date+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery(); 
            con.Close();
            return rowAffect;
        }
    }
}