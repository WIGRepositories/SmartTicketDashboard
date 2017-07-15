using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class UserlocationController : ApiController
    {
        [HttpPost]
        [Route("api/UserLocation/location")]

        public DataTable location(UserLocation l)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVUserlocations";
            cmd.Connection = conn;


            SqlParameter Latitude = new SqlParameter("@Latitude", SqlDbType.Float);
            Latitude.Value = l.lat;
            cmd.Parameters.Add(Latitude);

            SqlParameter Longitude = new SqlParameter("@Longitude", SqlDbType.Float);
            Longitude.Value = l.lng;
            cmd.Parameters.Add(Longitude);



            SqlParameter mn = new SqlParameter("@PhoneNo", SqlDbType.VarChar, 20);
            mn.Value = l.PhoneNo;
            cmd.Parameters.Add(mn);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
