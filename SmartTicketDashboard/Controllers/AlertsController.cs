﻿using SmartTicketDashboard;
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
        public DataTable GetAlerts()
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
    }
}

//        [HttpPost]
//        public DataTable SaveAlerts(Alerts n)
//        {
//            DataTable Tbl = new DataTable();


//            //connect to database
//            SqlConnection conn = new SqlConnection();
//            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
//            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
//            SqlCommand cmd = new SqlCommand();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "InsUpdDeLAlerts";
//            cmd.Connection = conn;
//            conn.Open();

         
//            SqlParameter Aid = new SqlParameter();
//            Aid.ParameterName = "@Id";
//            Aid.SqlDbType = SqlDbType.Int;
//            Aid.Value = Convert.ToString(n.Id);
//            SqlParameter gsac = new SqlParameter("@Date", SqlDbType.DateTime);
//            gsac.Value = n.Date;
//            cmd.Parameters.Add(gsac);

//            SqlParameter mm = new SqlParameter();
//            mm.ParameterName = "@Message";
//            mm.SqlDbType = SqlDbType.VarChar;
//            mm.Value = n.Message;
//            cmd.Parameters.Add(mm);
//            SqlParameter md = new SqlParameter();
//            md.ParameterName = "@MessageTypeId";
//            md.SqlDbType = SqlDbType.Int;
//            md.Value = Convert.ToString(n.MessageTypeId);
//            cmd.Parameters.Add(md);
//            SqlParameter ss = new SqlParameter();
//            ss.ParameterName = "@StatusId";
//            ss.SqlDbType = SqlDbType.Int;
//            ss.Value =Convert.ToString( n.StatusId);
//            cmd.Parameters.Add(ss);
//            SqlParameter ssi = new SqlParameter();
//            ssi.ParameterName = "@UserId";
//            ssi.SqlDbType = SqlDbType.Int;
//            ssi.Value = Convert.ToString(n.UserId);
//            cmd.Parameters.Add(ssi);

//            SqlParameter nmm = new SqlParameter();
//            nmm.ParameterName = "@Name";
//            nmm.SqlDbType = SqlDbType.VarChar;
//            nmm.Value = n.Name;
//            cmd.Parameters.Add(nmm);
//            //DataSet ds = new DataSet();
//            //SqlDataAdapter db = new SqlDataAdapter(cmd);
//            //db.Fill(ds);
//           // Tbl = Tables[0];
//            cmd.ExecuteScalar();
//            conn.Close();
//            // int found = 0;
//            return Tbl;
//        }
//              public void Options(){}
           
//    }
//}


