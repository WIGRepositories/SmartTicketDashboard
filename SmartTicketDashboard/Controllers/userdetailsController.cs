using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using SmartTicketDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class userdetailsController : ApiController
    {

        [HttpGet]
        public DataTable GetUsers(int cmpId)//Main Method
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUsers ....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "getUsersdetails";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter("@cmpId", SqlDbType.Int);
            cmpid.Value = cmpId;
            cmd.Parameters.Add(cmpid);

            //SqlParameter empid= new SqlParameter("@EmpNo", SqlDbType.Int);
            //cmpid.Value = empid;
            //cmd.Parameters.Add(empid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUsers  completed.");

            return Tbl;
        }


        [HttpPost]
        public DataTable SaveUserdetails(Userdetails U)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers ....");

            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDeluserdetails";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter UId = new SqlParameter("@Id", SqlDbType.Int);
                UId.Value = U.Id;
                cmd.Parameters.Add(UId);

                SqlParameter UFirstName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
                UFirstName.Value = U.username;
                cmd.Parameters.Add(UFirstName);

                SqlParameter LastName = new SqlParameter("@Accountnumber", SqlDbType.VarChar, 50);
                LastName.Value = U.Accountnumber;
                cmd.Parameters.Add(LastName);

                SqlParameter Balance = new SqlParameter("@Balance", SqlDbType.VarChar, 50);
                Balance.Value = U.balance;
                cmd.Parameters.Add(Balance);

                SqlParameter UUserType = new SqlParameter("@expirydate", SqlDbType.Int);
                UUserType.Value = U.expirydate;
                cmd.Parameters.Add(UUserType);

                SqlParameter uEmpNo = new SqlParameter("@Startdate", SqlDbType.VarChar, 15);
                uEmpNo.Value = U.startdate;
                cmd.Parameters.Add(uEmpNo);

                SqlParameter UEmail = new SqlParameter("@status", SqlDbType.VarChar, 15);
                UEmail.Value = U.status;
                cmd.Parameters.Add(UEmail);

              

                //  SqlParameter WUserName = new SqlParameter("@WUserName",SqlDbType.VarChar,15);
                //WUserName.Value = U.WUserName;
                //cmd.Parameters.Add(WUserName);

                //SqlParameter WPassword = new SqlParameter("@WPassword",SqlDbType.VarChar,15);
                //WPassword.Value = U.WPassword;
                //cmd.Parameters.Add(WPassword);


            
                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers completed.");

            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUsers:" + ex.Message);
                throw ex;
            }



            // int found = 0;
            return Tbl;
        }
    }
}
