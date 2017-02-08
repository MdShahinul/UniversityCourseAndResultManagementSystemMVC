﻿using System;
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
            string query = "select * from StudentRegister";
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
    }
}