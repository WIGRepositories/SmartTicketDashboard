using SmartTicketDashboard;

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
    public class AlertsController : ApiController
    {
        [HttpGet]
        [Route("api/Alerts/GetAlerts")]
        public DataTable GetAlerts(int roleid, int userid, DateTime fromdate, DateTime todate,int statusid, int categoryid, int  subcategoryid )
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAlerts credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAlerts";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAlerts Credentials completed.");
            
            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        public DataTable SaveAlerts(Alerts a)
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveAlerts credentials....");

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDeLAlerts";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
            flag.Value = a.flag;
            cmd.Parameters.Add(flag); 

            SqlParameter Aid = new SqlParameter("@Id", SqlDbType.Int);
            Aid.Value =a.Id;
            cmd.Parameters.Add(Aid);

            SqlParameter roleid = new SqlParameter("@RoleId", SqlDbType.Int);
            roleid.Value =a.RoleId;
            cmd.Parameters.Add(roleid);

            SqlParameter userid = new SqlParameter("@UserId", SqlDbType.Int);
            userid.Value =a.UserId;
            cmd.Parameters.Add(userid);

            SqlParameter Title = new SqlParameter("@Title", SqlDbType.VarChar);
            Title.Value = a.Title;
            cmd.Parameters.Add(Title); 

            SqlParameter Message = new SqlParameter("@Message", SqlDbType.VarChar);
            Message.Value = a.Message;
            cmd.Parameters.Add(Message);

            SqlParameter CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
            CreatedOn.Value = a.CreatedOn;
            cmd.Parameters.Add(CreatedOn);

            SqlParameter UpdatedOn = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
            UpdatedOn.Value = a.UpdatedOn;
            cmd.Parameters.Add(UpdatedOn);

            SqlParameter updBy = new SqlParameter("@UpdatedBy", SqlDbType.Int);
            updBy.Value =a.UpdatedBy;
            cmd.Parameters.Add(updBy);

            SqlParameter StateId = new SqlParameter("@StateId", SqlDbType.Int);
            StateId.Value =a.StateId;
            cmd.Parameters.Add(StateId);

            SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
            StatusId.Value =a.StatusId;
            cmd.Parameters.Add(StatusId);

            SqlParameter CategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
            CategoryId.Value =a.CategoryId;
            cmd.Parameters.Add(CategoryId);

            SqlParameter subcatId = new SqlParameter("@SubCategoryId", SqlDbType.Int);
            subcatId.Value =a.SubCategoryId;
            cmd.Parameters.Add(subcatId);

            SqlParameter Active = new SqlParameter("@Active", SqlDbType.Int);
            Active.Value =a.Active;
            cmd.Parameters.Add(Active);
           
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveAlerts Credentials completed.");

            return Tbl;
        }
    }
}




