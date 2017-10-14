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
    public class NotificationsController : ApiController
    {
        [HttpPost]
        [Route("api/Notifications/GetNotifications")]
        public DataTable GetNotifications(Notifications  not)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetNotifications credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PsGetNotifications";
            cmd.Connection = conn;

            SqlParameter rid = new SqlParameter("@roleid", SqlDbType.Int);
            rid.Value = not.RoleId;
            cmd.Parameters.Add(rid);

            SqlParameter uid = new SqlParameter("@userid", SqlDbType.Int);
            uid.Value = not.UserId;
            cmd.Parameters.Add(uid);

            SqlParameter fdate = new SqlParameter("@fromdate", SqlDbType.DateTime);
            fdate.Value = not.fromdate;
            cmd.Parameters.Add(fdate);

            SqlParameter tdate = new SqlParameter("@todate", SqlDbType.DateTime);
            tdate.Value = not.todate;
            cmd.Parameters.Add(tdate);

            SqlParameter stid = new SqlParameter("@statusid", SqlDbType.Int);
            stid.Value = not.StatusId;
            cmd.Parameters.Add(stid);

            SqlParameter catid = new SqlParameter("@categoryid", SqlDbType.Int);
            catid.Value = not.CategoryId;
            cmd.Parameters.Add(catid);

            SqlParameter scatid = new SqlParameter("@subcategoryid", SqlDbType.Int);
            scatid.Value = not.SubCategoryId;
            cmd.Parameters.Add(scatid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetNotifications Credentials completed.");

            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        [Route("api/Notifications/SaveNotifications")]
        public DataTable SaveNotifications(Notifications n)
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNotifications credentials....");

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDeLNotifications";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
            flag.Value = n.flag;
            cmd.Parameters.Add(flag);

            SqlParameter Aid = new SqlParameter("@Id", SqlDbType.Int);
            Aid.Value = n.Id;
            cmd.Parameters.Add(Aid);

            SqlParameter roleid = new SqlParameter("@RoleId", SqlDbType.Int);
            roleid.Value = n.RoleId;
            cmd.Parameters.Add(roleid);

            SqlParameter userid = new SqlParameter("@UserId", SqlDbType.Int);
            userid.Value = n.UserId;
            cmd.Parameters.Add(userid);

            SqlParameter Title = new SqlParameter("@Title", SqlDbType.VarChar);
            Title.Value = n.Title;
            cmd.Parameters.Add(Title);

            SqlParameter Message = new SqlParameter("@Message", SqlDbType.VarChar);
            Message.Value = n.Message;
            cmd.Parameters.Add(Message);

            SqlParameter CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
            CreatedOn.Value = n.CreatedOn;
            cmd.Parameters.Add(CreatedOn);

            SqlParameter UpdatedOn = new SqlParameter("@UpdatedOn", SqlDbType.DateTime);
            UpdatedOn.Value = n.UpdatedOn;
            cmd.Parameters.Add(UpdatedOn);

            SqlParameter updBy = new SqlParameter("@UpdatedBy", SqlDbType.Int);
            updBy.Value = n.UpdatedBy;
            cmd.Parameters.Add(updBy);

            SqlParameter StateId = new SqlParameter("@StateId", SqlDbType.Int);
            StateId.Value = n.StateId;
            cmd.Parameters.Add(StateId);

            SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
            StatusId.Value = n.StatusId;
            cmd.Parameters.Add(StatusId);

            SqlParameter CategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
            CategoryId.Value = n.CategoryId;
            cmd.Parameters.Add(CategoryId);

            SqlParameter subcatId = new SqlParameter("@SubCategoryId", SqlDbType.Int);
            subcatId.Value = n.SubCategoryId;
            cmd.Parameters.Add(subcatId);

            SqlParameter Active = new SqlParameter("@Active", SqlDbType.Int);
            Active.Value = n.Active;
            cmd.Parameters.Add(Active);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNotifications Credentials completed.");

            return Tbl;
        }
    }
}








