﻿using SmartTicketDashboard;
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

namespace POSDBAccess.Controllers
{
    public class TroubleTicketingDetailsController : ApiController
    {
        [HttpGet]
        
        public DataTable getTroubleTicketingDetails()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getTroubleTicketingDetails credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getTroubleTicketingDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getTroubleTicketingDetails Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpPost]

        public DataTable saveTroubleTicketingDetails(TroubleTicketingDetails n)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveTroubleTicketingDetails credentials....");
            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTroubleTicketingDetails";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@RefId";
                gs.SqlDbType = SqlDbType.Int;
                gs.Value = n.RefId;
                cmd.Parameters.Add(gs);

                SqlParameter gss = new SqlParameter();
                gss.ParameterName = "@Type";
                gss.SqlDbType = SqlDbType.Int;
                gss.Value = n.Type;
                cmd.Parameters.Add(gss);

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@createdBy";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = n.createdBy;
                cmd.Parameters.Add(gsa);

                //SqlParameter gsaz = new SqlParameter();
                //gsaz.ParameterName = "@Id";
                //gsaz.SqlDbType = SqlDbType.Int;
                //gsaz.Value = n.Id;
                //cmd.Parameters.Add(gsaz);

                SqlParameter gssa = new SqlParameter();
                gssa.ParameterName = "@Raised";
                gssa.SqlDbType = SqlDbType.Int;
                gssa.Value = n.Raised;
                cmd.Parameters.Add(gssa);

                SqlParameter gsad = new SqlParameter();
                gsad.ParameterName = "@TicketTitle";
                gsad.SqlDbType = SqlDbType.Int;
                gsad.Value = n.TicketTitle;
                cmd.Parameters.Add(gsad);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@IssueDetails";
                gid.SqlDbType = SqlDbType.NVarChar;
                gid.Value = n.IssueDetails;
                cmd.Parameters.Add(gid);

                SqlParameter gsae = new SqlParameter();
                gsae.ParameterName = "@AddInfo";
                gsae.SqlDbType = SqlDbType.NVarChar;
                gsae.Value = n.AddInfo;
                cmd.Parameters.Add(gsae);

                SqlParameter gsac = new SqlParameter();
                gsac.ParameterName = "@Status";
                gsac.SqlDbType = SqlDbType.Int;
                gsac.Value = n.Status;
                cmd.Parameters.Add(gsac);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@Asign";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = n.Asign;
                cmd.Parameters.Add(gsab);
               

               // cmd.ExecuteScalar();
               
               // DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(Tbl);
                //Tbl = ds.Tables[0];
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveTroubleTicketingDetails Credentials completed.");

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveTroubleTicketingDetails:" + ex.Message);
            }
           
            // int found = 0;
            return Tbl;

        }
        public void Options()
        {
        }

    }
}
