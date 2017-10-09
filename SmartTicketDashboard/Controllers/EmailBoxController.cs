using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
    public class EmailBoxController : ApiController
    {
        [HttpGet]
        public DataTable GetEmailBox()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEmailBox credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEmailBox";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEmailBox Credentials completed.");
            // int found = 0;
            return Tbl;

        }



        [HttpPost]
        [Route("api/EmailBox/Email")]

        public DataTable Email(MailBox M)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsupdEmailBox";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = M.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = M.Id;
                cmd.Parameters.Add(i);

                SqlParameter tmi = new SqlParameter("@ToMailId", SqlDbType.VarChar,100);
                tmi.Value = M.ToMailId;
                cmd.Parameters.Add(tmi);                

                SqlParameter sub = new SqlParameter("@Subject", SqlDbType.VarChar, 150);
                sub.Value = M.Subject;
                cmd.Parameters.Add(sub);

                SqlParameter cc = new SqlParameter("@CarbonCopy", SqlDbType.VarChar, 250);
                cc.Value = M.CarbonCopy;
                cmd.Parameters.Add(cc);

                SqlParameter bcc = new SqlParameter("@BlindCarbonCopy", SqlDbType.VarChar, 250);
                bcc.Value = M.BlindCarbonCopy;
                cmd.Parameters.Add(bcc);

                SqlParameter Text = new SqlParameter("@Text", SqlDbType.VarChar, 1000);
                Text.Value = M.Text;
                cmd.Parameters.Add(Text);

                SqlParameter att = new SqlParameter("@Attachments", SqlDbType.VarChar);
                att.Value = M.Attachments;
                cmd.Parameters.Add(att);

                

             
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
