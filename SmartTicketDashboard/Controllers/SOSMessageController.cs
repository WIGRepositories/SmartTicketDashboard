using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;


namespace SmartTicketDashboard.Controllers
{
    public class SOSMessageController : ApiController
    {
        [HttpGet]
        [Route("api/GetSOSMessage")]
        public DataTable GetSOSMessage(int utypeId, int userId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0",TraceLevel.Info, "{0}", "GetSOSMessage ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetSOSMessages";
            cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = utypeId;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            cmd.Connection = conn;

            //DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetSOSMessage completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/SaveSOSMessage")]
        public DataTable SaveSOSMessage(SOSMessage sos)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSOSMessage ...");

            //connect to database
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelSOSMessage";
                cmd.Connection = conn;
                conn.Open();

                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@flag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = sos.flag;
                cmd.Parameters.Add(flag);

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@Id";
                id.SqlDbType = SqlDbType.Int;
                id.Value = sos.Id;
                cmd.Parameters.Add(id);

                SqlParameter UserId = new SqlParameter();
                UserId.ParameterName = "@UserId";
                UserId.SqlDbType = SqlDbType.Int;
                UserId.Value = sos.UserId;
                cmd.Parameters.Add(UserId);

                SqlParameter ustid = new SqlParameter();
                ustid.ParameterName = "@UserTypeId";
                ustid.SqlDbType = SqlDbType.Int;
                ustid.Value = sos.UserTypeId;
                cmd.Parameters.Add(ustid);

                SqlParameter SentTo = new SqlParameter();
                SentTo.ParameterName = "@SentTo";
                SentTo.SqlDbType = SqlDbType.VarChar;
                SentTo.Value = sos.SentTo;
                cmd.Parameters.Add(SentTo);

                 SqlParameter MessageId = new SqlParameter();
                MessageId.ParameterName = "@MessageId";
                MessageId.SqlDbType = SqlDbType.Int;
                MessageId.Value = sos.MessageId;
                cmd.Parameters.Add(MessageId);

                SqlParameter msg = new SqlParameter();
                msg.ParameterName = "@Message";
                msg.SqlDbType = SqlDbType.VarChar;
                msg.Value = sos.Message;
                cmd.Parameters.Add(msg);

                SqlParameter SentOn = new SqlParameter();
                SentOn.ParameterName = "@SentOn";
                SentOn.SqlDbType = SqlDbType.DateTime;
                SentOn.Value = sos.SentOn;
                cmd.Parameters.Add(SentOn);

                SqlParameter SentTime = new SqlParameter();
                SentTime.ParameterName = "@SentTime";
                SentTime.SqlDbType = SqlDbType.Time;
                SentTime.Value = sos.SentTime;
                cmd.Parameters.Add(SentTime);

                SqlParameter Status = new SqlParameter();
                Status.ParameterName = "@StatusId";
                Status.SqlDbType = SqlDbType.Int;
                Status.Value = sos.StatusId;
                cmd.Parameters.Add(Status);

                SqlParameter otp = new SqlParameter();
                otp.ParameterName = "@Otp";
                otp.SqlDbType = SqlDbType.VarChar;
                otp.Value = sos.Otp;
                cmd.Parameters.Add(otp);

                SqlParameter UpdatedOn = new SqlParameter();
                UpdatedOn.ParameterName = "@UpdatedOn";
                UpdatedOn.SqlDbType = SqlDbType.DateTime;
                UpdatedOn.Value = sos.UpdatedOn;
                cmd.Parameters.Add(UpdatedOn);

                SqlParameter UpdatedBy = new SqlParameter();
                UpdatedBy.ParameterName = "@UpdatedBy";
                UpdatedBy.SqlDbType = SqlDbType.Int;
                UpdatedBy.Value = sos.UpdatedBy;
                cmd.Parameters.Add(UpdatedBy);

                 SqlParameter Lat = new SqlParameter("@Latitude", SqlDbType.Float);
            Lat.Value = sos.Latitude;
            cmd.Parameters.Add(Lat);

            SqlParameter Lng = new SqlParameter("@Longitude", SqlDbType.Float);
            Lng.Value = sos.Longitude;
            cmd.Parameters.Add(Lng);

                cmd.ExecuteScalar();

                conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandUserDocs  completed.");

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveMandUserDocs:" + ex.Message);

            }
            return dt;
        }
    }
}
