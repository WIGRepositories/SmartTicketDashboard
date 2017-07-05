﻿using System;
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
    public class PurchaseOrderController : ApiController
    {     
   
        [HttpGet]
        public DataTable GetPurchaseOrder()
        {
            
            
          DataTable Tbl = new DataTable();

          LogTraceWriter traceWriter = new LogTraceWriter();
          traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetPurchaseOrder credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPurchaseOrder";
            cmd.Connection = conn;
            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            // Tbl = ds.Tables[0];

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetPurchaseOrder Credentials completed.");
            
            // int found = 0;
            return Tbl;

        }
    }
}
