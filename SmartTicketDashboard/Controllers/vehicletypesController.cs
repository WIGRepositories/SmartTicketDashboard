using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;
using System.Configuration;

namespace SmartTicketDashboard.Controllers
{
    public class vehicletypesController : ApiController
    {
        [HttpGet]

        [Route("api/vehicletype/vehicle")]
        public DataTable vehicle(int VID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetvehilcetypes";
            cmd.Parameters.Add("@VID", SqlDbType.Int).Value = VID;
            cmd.Connection = conn;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;
        }

      
    }
}
