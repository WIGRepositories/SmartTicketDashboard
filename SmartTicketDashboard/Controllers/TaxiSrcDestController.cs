﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class TaxiSrcDestController : ApiController
    {
        [HttpGet]
        [Route("api/GetTaxiStopsList")]
        public DataTable GetTaxiStopsList(int ctryid)
        {
            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTaxiStopsList";
            cmd.Connection = conn;
            cmd.Parameters.Add("ctryId", SqlDbType.Int).Value = ctryid;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        
    }
}
