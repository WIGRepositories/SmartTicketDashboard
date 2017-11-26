using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class OperationsController : ApiController
    {
        [HttpGet]
        [Route("api/Operations/GetOperations")]
        public DataTable GetOperations()
        {
            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetOperations credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetOperations";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
           // traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetOperations Credentials completed.");
            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        [Route("api/Operations/OperationsPost")]

        public DataTable OperationsPost(Operations O)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelOperations";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = O.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = O.Id;
                cmd.Parameters.Add(i);

                SqlParameter on = new SqlParameter("@OpName", SqlDbType.VarChar,100);
                on.Value = O.OpName;
                cmd.Parameters.Add(on);

                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 15);
                Code.Value = O.Code;
                cmd.Parameters.Add(Code);

                SqlParameter d = new SqlParameter("@Description", SqlDbType.VarChar, 500);
                d.Value = O.Description;
                cmd.Parameters.Add(d);

                SqlParameter ac = new SqlParameter("@Active", SqlDbType.Int);
                ac.Value = O.Active;
                cmd.Parameters.Add(ac);

              
            }
            catch
            {
                Exception ex;
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
