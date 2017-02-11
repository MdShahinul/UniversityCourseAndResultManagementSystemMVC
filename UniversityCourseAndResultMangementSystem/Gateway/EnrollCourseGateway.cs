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
            string query = "insert into EnrollCourse values('"+enrollCourseModel.StudentId+"','"+enrollCourseModel.CourseId+"','"+enrollCourseModel.Date+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery(); 
            con.Close();
            return rowAffect;
        }

        public string IsExist(EnrollCourseModel enrollCourseModel)
        {
            string message = null; 

            SqlConnection con = new SqlConnection(connectingString);
            string query = "select * from EnrollCourse Where StudentId='" + enrollCourseModel.StudentId +
                           "' AND CourseId='" + enrollCourseModel.CourseId + "' "; 
            SqlCommand cmd =new SqlCommand(query,con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                message = "Sorry, Already Enrolled"; 
            }
            con.Close();
            return message; 
            }


        public EnrollCourseModel GateRegisterNumberByStudentId(int StudentId)
        {
            SqlConnection con = new SqlConnection(connectingString);
            string query = "select * from EnrollByDepartment where StudentId = '" + StudentId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            EnrollCourseModel enrollCourseModel = new EnrollCourseModel();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    enrollCourseModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentID"]);
                    enrollCourseModel.RegistationNumber = dataReader["RegistationNumber"].ToString();
                    enrollCourseModel.StudentName = dataReader["StudentName"].ToString();
                    enrollCourseModel.StudentEmail = dataReader["StudentEmail"].ToString();
                    enrollCourseModel.DepartmentName = dataReader["DepartName"].ToString(); 
                }
                dataReader.Close();
            }
            con.Close();
            return enrollCourseModel; 
        }

       public int GetDepertmentIdByStudentId(int? StudentId)
        {
            SqlConnection con = new SqlConnection(connectingString);
            int depert = 0; 
            string query = "select * from EnrollByDepartment where StudentId = '" + StudentId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    depert = Convert.ToInt32(dataReader["DepartmentID"]);
                   
                }
                dataReader.Close();
            }
            con.Close();
            return depert; 
        }

    }
}