﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

using System.Data.SqlClient;
using SmartTicketDashboard.Models;
using SmartTicketDashboard;
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
    public class InventoryMasterController : ApiController
    {
        [HttpGet]
        public DataTable master()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventoryMaster credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInventoryMaster";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventoryMaster Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage test (master b)
       {

           LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveInventoryMaster credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
            //connect to database
           
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelInventoryMaster";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Name";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.Name;
            cmd.Parameters.Add(ss);

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@Desc";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.Desc;
            cmd.Parameters.Add(ii);
         
            SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@Code";
            nn.SqlDbType = SqlDbType.VarChar;
            nn.Value = b.Code;
            cmd.Parameters.Add(nn);
            SqlParameter mm = new SqlParameter();
            mm.ParameterName = "@Subcat";
            mm.SqlDbType = SqlDbType.VarChar;
            mm.Value = b.Subcat;
            cmd.Parameters.Add(mm);
            SqlParameter jj = new SqlParameter();
            jj.ParameterName = "@Active";
            jj.SqlDbType = SqlDbType.VarChar;
            jj.Value = b.Active;
            cmd.Parameters.Add(jj);
            
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveInventoryMaster Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveInventoryMaster:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
       }
        public void Options()
        {

        }
    }
}
