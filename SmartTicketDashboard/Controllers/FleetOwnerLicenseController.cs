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


namespace SmartTicketDashboard.Controllers
{
    public class FleetOwnerLicenseController : ApiController
    {
        [HttpGet]
        public DataTable FleetOwner()//Main Method
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetOwner credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetFleetOwnerLicense";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetOwner Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage FleetOL(FleetOL B)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetOwnerLicense credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

               
                //connect to database
                
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insFleetOwnerLicense";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter FId = new SqlParameter();
                FId.ParameterName = "@Id";
                FId.SqlDbType = SqlDbType.Int;
                FId.Value = Convert.ToString(B.Id);
                cmd.Parameters.Add(FId);
                SqlParameter FFleetOwnerId = new SqlParameter();
                FFleetOwnerId.ParameterName = "@FleetOwnerId";
                FFleetOwnerId.SqlDbType = SqlDbType.Int;
                FFleetOwnerId.Value = Convert.ToString(B.FleetOwnerId);
                cmd.Parameters.Add(FFleetOwnerId);
                SqlParameter FlicenseId = new SqlParameter();
                FlicenseId.ParameterName = "@LicenseId";
                FlicenseId.SqlDbType = SqlDbType.Int;
                FlicenseId.Value = B.LicenseId;
                cmd.Parameters.Add(FlicenseId);
                SqlParameter FCode = new SqlParameter();
                FCode.ParameterName = "@Code";
                FCode.SqlDbType = SqlDbType.Int;
                FCode.Value =Convert.ToString( B.Code);
                cmd.Parameters.Add(FCode);
                SqlParameter FOFromDate = new SqlParameter();
                FOFromDate.ParameterName = "@FromDate";
                FOFromDate.SqlDbType = SqlDbType.DateTime;
                FOFromDate.Value = B.FromDate;
                cmd.Parameters.Add(FOFromDate);
                SqlParameter FOEndDate = new SqlParameter();
                FOEndDate.ParameterName = "@EndDate";
                FOEndDate.SqlDbType = SqlDbType.DateTime;
                FOEndDate.Value = B.EndDate;
                cmd.Parameters.Add(FOEndDate);
                SqlParameter FONotificationDate = new SqlParameter();
                FONotificationDate.ParameterName = "@NotificationDate";
                FONotificationDate.SqlDbType = SqlDbType.DateTime;
                FONotificationDate.Value = B.NotificationDate;
                cmd.Parameters.Add(FONotificationDate);
                SqlParameter FTransactionId = new SqlParameter();
                FTransactionId.ParameterName = "@TransactionId";
                FTransactionId.SqlDbType = SqlDbType.Int;
                FTransactionId.Value = Convert.ToString(B.TransactionId);
                cmd.Parameters.Add(FTransactionId);
                SqlParameter FRenewedOn = new SqlParameter();
                FRenewedOn.ParameterName = "@RenewedOn ";
                FRenewedOn.SqlDbType = SqlDbType.DateTime;
                FRenewedOn.Value = B.RenewedOn;
                cmd.Parameters.Add(FRenewedOn);

                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetOwnerLicense Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveFleetOwnerLicense:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        public int validatefleetowner(string fleetownercode)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getvalidatefleetowner credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ValidateFleetOwnerCode";
            cmd.Connection = conn;

            conn.Open();
            SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
            code.Value = fleetownercode;
            cmd.Parameters.Add(code);

            SqlParameter mm = new SqlParameter("@result", SqlDbType.Int);
            mm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(mm);

            cmd.ExecuteNonQuery();

            conn.Close();
           
            int result = -1;
            result = Convert.ToInt32(mm.Value);

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getvalidatefleetowner Credentials completed.");
            return result;

        }


        [HttpGet]
        public int updatebtpos(string fleetownercode, string units)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getupdatebtpos credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updatebtpos";
            cmd.Connection = conn;

            conn.Open();
            SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
            code.Value = fleetownercode;
            cmd.Parameters.Add(code);

            SqlParameter posunits = new SqlParameter("@units", SqlDbType.Int);
            posunits.Value =  Convert.ToInt32(units);
            cmd.Parameters.Add(posunits);


            SqlParameter mm = new SqlParameter("@result", SqlDbType.Int);
            mm.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(mm);

            cmd.ExecuteNonQuery();

            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getupdatebtpos Credentials completed.");
            int result = -1;
            result = Convert.ToInt32(mm.Value);
            return result;

        }

        [HttpGet]
        public int registerpos(string fleetownercode, string ipconfig)
        {


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getregisterpos credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "registerbtpos";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter code = new SqlParameter("@fleetownercode", SqlDbType.VarChar, 10);
                code.Value = fleetownercode.Trim();
                cmd.Parameters.Add(code);

                SqlParameter posunits = new SqlParameter("@ipconfig", SqlDbType.VarChar, 20);
                posunits.Value = ipconfig.Trim();
                cmd.Parameters.Add(posunits);


                SqlParameter mm = new SqlParameter("@result", SqlDbType.Int);
                mm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mm);

                cmd.ExecuteNonQuery();

                conn.Close();

                int result = -1;
                result = Convert.ToInt32(mm.Value);
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getregisterpos Credentials completed.");
                return result;
            }
            catch {
                return -1;
            }
        }
        public void Options()
        {

        }

    }
}
