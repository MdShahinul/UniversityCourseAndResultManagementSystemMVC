using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class DayOfWeekGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public List<DayOfWeekModel> GateAllDayGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from DayOfWeek";
            SqlCommand cmd = new SqlCommand(query, con);
             List<DayOfWeekModel> dayOfWeekModels = new List<DayOfWeekModel>();
            
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    DayOfWeekModel dayOfWeekModel = new DayOfWeekModel();
                    dayOfWeekModel.DayId = Convert.ToInt32(dataReader["DayId"]);
                    dayOfWeekModel.DayName = dataReader["DayName"].ToString();
                    dayOfWeekModels.Add(dayOfWeekModel);
                }
                dataReader.Close();
            }
            con.Close();
            return dayOfWeekModels;
        }
    }
}