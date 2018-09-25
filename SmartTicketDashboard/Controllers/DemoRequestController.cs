using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class DemoRequestController : ApiController
    {
        [HttpGet]
        [Route("api/DemoRequest/GetDemoRequest")]
        public DataTable GetDemoRequest()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDemorequest";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
    }
}
