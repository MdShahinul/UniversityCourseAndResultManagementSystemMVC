using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class CourseAssignGateway
    {
        private string conectionStirng = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;


        public int SaveCourseAssignGateway(CourseAssignModel courseAssignModel)
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "insert into CourseAssign values ('" + courseAssignModel.DepartmentId + "','" +
                           courseAssignModel.TeacherId + "', '" + courseAssignModel.CourseId + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffect;
        }
        public string IsExistCourseGateway(CourseAssignModel courseAssignModel)
        {
            string message = null; 
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "Select * from CourseAssign where CourseID='" + courseAssignModel.CourseId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                message = "This Course Already Assign Another Teacher"; 
            }
            con.Close();
            return message;
        }

        public CourseAssignModel GateCourseCredit(int? courseId)
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "Select * from Course where CourseID='" + courseId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            CourseAssignModel courseAssignModel = new CourseAssignModel();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                courseAssignModel.CourseId = Convert.ToInt32(dataReader["CourseID"]);
                courseAssignModel.CourseName = dataReader["CourseName"].ToString();
                courseAssignModel.CourseCredit = Convert.ToDecimal(dataReader["CourseCredit"]);
                dataReader.Close();

            }
            con.Close();
            return courseAssignModel;
        }

        public List<CourseAssignModel> GatAllViewCourseStaticGateway()
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "select * from vAssignedCourse";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<CourseAssignModel> courseAssignModels = new List<CourseAssignModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    CourseAssignModel courseAssignModel = new CourseAssignModel();
                    courseAssignModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentID"]);
                    courseAssignModel.CourseCode = dataReader["CourseCode"].ToString();
                    courseAssignModel.CourseName = dataReader["CourseName"].ToString();
                    courseAssignModel.SemesterName = dataReader["SemiName"].ToString();
                    courseAssignModel.TeacherName = dataReader["AssignedTo"].ToString();

                    courseAssignModels.Add(courseAssignModel);
                }
                dataReader.Close();
            }
            con.Close();
            return courseAssignModels;
        }

        public List<CourseModel> GateAllCourseGateway()
        {
            SqlConnection con = new SqlConnection(conectionStirng);
            string query = "select * from Course";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<CourseModel> courseModels = new List<CourseModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    CourseModel courseModel = new CourseModel();
                    courseModel.CourseId = Convert.ToInt32(dataReader["CourseID"]);
                    courseModel.CourseCode = dataReader["CourseCode"].ToString();
                    courseModel.CourseName = dataReader["CourseName"].ToString();
                    courseModel.CourseCredit = Convert.ToDecimal(dataReader["CourseCredit"]);
                    courseModel.CourseDescription = dataReader["CourseDescription"].ToString();
                    courseModel.DepartmentId = Convert.ToInt32(dataReader["DepartmentID"]);

                    courseModels.Add(courseModel);
                }
                dataReader.Close();
            }
            con.Close();
            return courseModels;
        }
    }
}