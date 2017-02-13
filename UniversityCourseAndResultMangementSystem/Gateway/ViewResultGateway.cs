using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class ViewResultGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString; 
        public List<ViewResultModel> GateListOfStudentResult(int StudentId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from GetResult where StudentId = '" + StudentId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<ViewResultModel> viewResultModels = new List<ViewResultModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ViewResultModel viewResultModel = new ViewResultModel();
                    viewResultModel.StudentId = Convert.ToInt32(dataReader["StudentID"]);
                    viewResultModel.RegisterNumber = dataReader["RegistationNumber"].ToString();
                    viewResultModel.StudentName = dataReader["StudentName"].ToString();
                    viewResultModel.StudentEmail = dataReader["StudentEmail"].ToString();
                    //viewResultModel.DepartmentName = dataReader["DepartName"].ToString();
                    viewResultModel.CourseCode = dataReader["CourseCode"].ToString();
                    viewResultModel.CourseName = dataReader["CourseName"].ToString();
                    viewResultModel.Grade = dataReader["Grade"].ToString();
                    viewResultModels.Add(viewResultModel);
                }
                dataReader.Close();
            }
            con.Close();
            return viewResultModels;
        }
      }
}