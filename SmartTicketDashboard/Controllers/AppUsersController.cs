using SmartTicketDashboard.Models;
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
    public class AppUsersController : ApiController
    {
        [Route("api/AppUsers/AppUsers")]
        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString=System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetAllAppUsers";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        [Route("api/AppUsers/UserDetails")]
        public DataTable GetUserById(int id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();

            SqlParameter UId = new SqlParameter("@id",SqlDbType.Int);
            UId.Value = id;
            cmd.Parameters.Add(UId);

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetAppUserdetails";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            dt = ds.Tables[0];
            
            return dt;
        }
    }
}
