using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class StudentResultGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;

        public int StudentResultSaveGateway(StudentResultModel studentResultModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "insert into Result values('" + studentResultModel.StudentId + "','" + studentResultModel.CourseId + "','" +
                           studentResultModel.GradeId + "')"; 
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery(); 
            con.Close();
            return rowAffect; 
        }

        public List<GradeModel> GatAllGradeGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Grade"; 
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            List<GradeModel> gradeModels = new List<GradeModel>();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    GradeModel gradeModel = new GradeModel();
                    gradeModel.GradeId = Convert.ToInt32(dataReader["GradeId"]);
                    gradeModel.Name = dataReader["Name"].ToString(); 
                    gradeModels.Add(gradeModel);
                }
                dataReader.Close();
            }
            con.Close();
            return gradeModels; 
        } 
    }
}