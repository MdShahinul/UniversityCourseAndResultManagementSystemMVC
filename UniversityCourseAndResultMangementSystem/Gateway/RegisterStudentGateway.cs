using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class RegisterStudentGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public int InsertRegisterStudent(RegisterStudentModel registerStudentModel)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO StudentRegister VALUES ('" + registerStudentModel.RegistationNumber + "','" + registerStudentModel.Name + "','" + registerStudentModel.Email + "','" + registerStudentModel.ContactNo + "', '" + registerStudentModel.Date + "','" + registerStudentModel.Address + "','" + registerStudentModel.DepartmentId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public string IsExistEmail(RegisterStudentModel registerStudentModel)
        {
            string message = null; 
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT * FROM StudentRegister WHERE StudentEmail='"+registerStudentModel.Email+"' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
           if (reader.HasRows)
           {
               message = "This mail Already Exist"; 
           }
            connection.Close();
            return message;
        }
        public List<RegisterStudentModel> GateStudentByDepartmentId(int departmentId)
        {
            SqlConnection con = new SqlConnection(connectingString);
            string query = "select * from StudentRegister Where DepartmentID = '" + departmentId +"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<RegisterStudentModel> registerStudent = new List<RegisterStudentModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RegisterStudentModel registerStudentModel = new RegisterStudentModel();
                    registerStudentModel.RegistationNumber = dataReader["RegistationNumber"].ToString();
                    registerStudentModel.Date = (DateTime)dataReader["Date"];
                    registerStudent.Add(registerStudentModel);
                }
                dataReader.Close();
            }
            con.Close();
            return registerStudent;
        }

        public List<RegisterStudentModel> GateRegistationNumberGateway()
        {
            SqlConnection con = new SqlConnection(connectingString);
            string query = "select * from StudentRegister ORDER BY RegistationNumber ASC";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<RegisterStudentModel> registerStudent = new List<RegisterStudentModel>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RegisterStudentModel registerStudentModel = new RegisterStudentModel();
                    registerStudentModel.StudentId = Convert.ToInt32(dataReader["StudentID"]);
                    registerStudentModel.RegistationNumber = dataReader["RegistationNumber"].ToString();
                    registerStudentModel.Date = (DateTime)dataReader["Date"];
                    registerStudent.Add(registerStudentModel);
                }
                dataReader.Close();
            }
            con.Close();
            return registerStudent;
        }

     
        //public int GetDeptIdByStudentId(int studentId)
        //{
        //    SqlConnection connection = new SqlConnection(connectingString);
        //    string query = "SELECT DepartmentId FROM StudentRegister WHERE StudentID=" + studentId;
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    int dept = 0;
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            dept = Convert.ToInt32(reader["DepartmentId"].ToString());
        //        }
        //        reader.Close();
        //    }
        //    connection.Close();
        //    return dept;
        //}
    }
}