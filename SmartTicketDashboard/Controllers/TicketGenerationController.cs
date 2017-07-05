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
    public class TicketGenerationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage saveTicketGeneration(TicketGeneration n)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveTicketGeneration credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();

            try
            {
                
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTicketGeneration";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter ga = new SqlParameter();
                ga.ParameterName = "@Source";
                ga.SqlDbType = SqlDbType.VarChar;
                ga.Value = (n.Source);
                cmd.Parameters.Add(ga);

                SqlParameter gb = new SqlParameter();
                gb.ParameterName = "@Target";
                gb.SqlDbType = SqlDbType.VarChar;
                gb.Value = (n.Target);
                cmd.Parameters.Add(gb);

                SqlParameter gc = new SqlParameter();
                gc.ParameterName = "@NoOfTickets";
                gc.SqlDbType = SqlDbType.VarChar;
                gc.Value = Convert.ToString(n.NoOfTickets);
                cmd.Parameters.Add(gc);

                // SqlParameter gd = new SqlParameter();
                //gd.ParameterName = "@RegeneratedNo";
                //gd.SqlDbType = SqlDbType.VarChar;
                //gd.Value = n.RegeneratedNo;
                //cmd.Parameters.Add(gd);

                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveTicketGeneration Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveTicketGeneration:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {
        }
    }
}
