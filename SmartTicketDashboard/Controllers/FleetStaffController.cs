﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;
using SmartTicketDashboard.Models;
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
  
    
        public class FleetStaffController : ApiController
        {
            [HttpGet]
            [Route("api/FleetStaff/GetFleetStaff")]
            public DataTable GetFleetStaff(int foId, int cmpid)
            {
                DataTable Tbl = new DataTable();
                LogTraceWriter traceWriter = new LogTraceWriter();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetStaff credentials....");
                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFleetStaff";
                cmd.Connection = conn;

                SqlParameter fo = new SqlParameter();
                fo.ParameterName = "@fleetowner";
                fo.SqlDbType = SqlDbType.Int;
                fo.Value = foId;
                cmd.Parameters.Add(fo);

                SqlParameter fsc = new SqlParameter();
                fsc.ParameterName = "@cmpId";
                fsc.SqlDbType = SqlDbType.Int;
                fsc.Value = cmpid;
                cmd.Parameters.Add(fsc);

              //  DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);

                db.Fill(Tbl);
                // Tbl = ds.Tables[0];
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetStaff Credentials completed.");
            
               // int found = 0;
                return Tbl;
            }  
           
             [HttpPost]
            public HttpResponseMessage NewFleetStaff(FleetStaff f)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNewFleetStaff credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database
               
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFleetStaff";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = f.Id;
                cmd.Parameters.Add(gsa);

                SqlParameter vid = new SqlParameter();
                vid.ParameterName = "@VehicleId";
                vid.SqlDbType = SqlDbType.Int;
                vid.Value = f.vehicleId;
                cmd.Parameters.Add(vid);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@RoleId";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = f.roleId;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@UserId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = f.UserId;
                cmd.Parameters.Add(gsab);

                SqlParameter fsc = new SqlParameter();
                fsc.ParameterName = "@cmpId";
                fsc.SqlDbType = SqlDbType.Int;
                fsc.Value = f.cmpId;
                cmd.Parameters.Add(fsc);

                SqlParameter gsac = new SqlParameter("@FromDate", SqlDbType.DateTime);
                gsac.Value =  f.FromDate;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@ToDate";
                gid.SqlDbType = SqlDbType.DateTime;
                gid.Value =  f.ToDate;
                cmd.Parameters.Add(gid);

                SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
                flag.Value = f.insupddelflag;
                cmd.Parameters.Add(flag);

                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNewFleetStaff Credentials completed.");
            
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveNewFleetStaff:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        public DataSet VehicleConfiguration()
        {
            DataSet ds = new DataSet();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetVehicleConfiguration credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VehicleConfiguration";
            cmd.Connection = conn;

            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetVehicleConfiguration Credentials completed.");
            
            return ds;
        }
        public void Options()
        {
        }


    }
}

            
        
                    
