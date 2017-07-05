﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using SmartTicketDashboard.Models;
using System.Web.Http.Tracing;


namespace SmartTicketDashboard.Controllers
{
    public class registrationformController : ApiController
    {


        [HttpGet]

        public DataTable getregdata()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getregistrationform credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Getregistrationform";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Getregistrationform Credentials completed.");
            
            // int found = 0;
            return Tbl;
        }
    

        [HttpPost]
        public HttpResponseMessage pos(Registrationform b)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveRegistrationform credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelregisterform";
                cmd.Connection = conn;
                conn.Open();
                //string insertquery = "insert into login(UserName,Password,FirstName,LastName,MobileNo) values (@UserName,@Password,@FirstName,@lastName,@MobileNo)";



                //SqlCommand con=new SqlCommand(insertquery,conn);

                SqlParameter Aid = new SqlParameter();
                Aid.ParameterName = "@UserName";
                Aid.SqlDbType = SqlDbType.VarChar;
                Aid.Value = b.UserName;
                cmd.Parameters.Add(Aid);



                SqlParameter lid = new SqlParameter();
                lid.ParameterName = "@Password";
                lid.SqlDbType = SqlDbType.VarChar;
                lid.Value = b.Password;
                cmd.Parameters.Add(lid);

                SqlParameter bb = new SqlParameter();
                bb.ParameterName = "@ConfirmPassword";
                bb.SqlDbType = SqlDbType.VarChar;
                bb.Value = b.ConfirmPassword;
                cmd.Parameters.Add(bb);

                SqlParameter Gid = new SqlParameter();
                Gid.ParameterName = "@Emailaddress";
                Gid.SqlDbType = SqlDbType.VarChar;
                Gid.Value = b.Emailaddress;
                cmd.Parameters.Add(Gid);

                SqlParameter pid = new SqlParameter();
                pid.ParameterName = "@FirstName ";
                pid.SqlDbType = SqlDbType.VarChar;
                pid.Value = b.FirstName;
                cmd.Parameters.Add(pid);

                SqlParameter aa = new SqlParameter();
                aa.ParameterName = "@LastName";
                aa.SqlDbType = SqlDbType.VarChar;
                aa.Value = b.LastName;
                cmd.Parameters.Add(aa);

                SqlParameter aa1 = new SqlParameter();
                aa1.ParameterName = "@Gender";
                aa1.SqlDbType = SqlDbType.VarChar;
                aa1.Value = b.Gender;
                cmd.Parameters.Add(aa1);




                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveRegistrationform Credentials completed.");
            
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveRegistrationform:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {


        }


    }     
   
}
