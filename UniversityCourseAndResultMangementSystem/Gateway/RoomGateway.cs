using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Gateway
{
    public class RoomGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        public List<RoomModel> GateAllRoomNoGateway()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from Room";
            SqlCommand cmd = new SqlCommand(query, con);
            List<RoomModel> roomModels = new List<RoomModel>();
           
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RoomModel roomModel = new RoomModel();
                    roomModel.RoomNoId = Convert.ToInt32(dataReader["RoomId"]);
                    roomModel.RoomNo = dataReader["RoomNo"].ToString();
                    roomModels.Add(roomModel);
                }
                dataReader.Close();
            }
            con.Close();
            return roomModels;
        }
    }
}