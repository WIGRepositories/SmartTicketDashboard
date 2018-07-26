﻿using SmartTicketDashboard.Models;
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
    public class ObjectAccessController : ApiController
    {
         [HttpGet]
        public DataTable getObjectAccess()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getObjectAccess credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetObjectAccesses";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getObjectAccess Credentials completed.");
            
            // int found = 0;
            return Tbl;
        }



        [HttpPost]
         public HttpResponseMessage SaveObjectAccess(ObjectAccess b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveObjectAccess credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
            //connect to database
           
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelObjectAccess";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Gidd = new SqlParameter();
            Gidd.ParameterName = "@Id";
            Gidd.SqlDbType = SqlDbType.Int;
            Gidd.Value = Convert.ToInt32(b.Id);
            cmd.Parameters.Add(Gidd);
            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@Name";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.Name;
            cmd.Parameters.Add(cname);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@AccessId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = Convert.ToInt32(b.TypeId);
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@ObjectId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToInt32(b.ObjectId);
            cmd.Parameters.Add(lid);


           

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveObjectAccess Credentials completed.");
            
              return new HttpResponseMessage(HttpStatusCode.OK);
              }
              catch (Exception ex)
              {
                  if (conn != null && conn.State == ConnectionState.Open)
                  {
                      conn.Close();
                  }
                  string str = ex.Message;
                  traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveObjectAccess:" + ex.Message);
                  return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
              }
        }
        public void Options() { }

    }
    }

