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
    public class landmarkController : ApiController
    {
         [HttpPost]
        [Route("api/landmark/markingland")]

        public DataTable markingland(land l)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdlandmark";
            cmd.Connection = conn;

            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = l.flag;
            cmd.Parameters.Add(f);

            SqlParameter i = new SqlParameter("@Zno", SqlDbType.Int);
            i.Value = l.Zno;
            cmd.Parameters.Add(i);

            SqlParameter ll = new SqlParameter("@Landmark", SqlDbType.NVarChar,255);
            ll.Value = l.landmark;
            cmd.Parameters.Add(ll);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
