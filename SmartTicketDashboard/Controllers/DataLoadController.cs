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

namespace SmartTicketDashboard.UI
{
    public class DataLoadController : ApiController
    {
        [HttpGet]
        public DataTable GetDataLoad()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetDataLoad credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDataLoad";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetDataLoad Credentials completed.");
            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        [Route("api/DataLoad/SaveCompanyGroups")]
        public HttpResponseMessage SaveCompanyGroups(List<CompanyGroups> list)
        {
            
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCompany";
                cmd.Connection = conn;

                conn.Open();
                
                foreach (CompanyGroups n in list)
                {
                    SqlParameter gsa = new SqlParameter();
                    gsa.ParameterName = "@active";
                    gsa.SqlDbType = SqlDbType.Int;
                    gsa.Value = n.active;
                    cmd.Parameters.Add(gsa);

                    SqlParameter gsn = new SqlParameter();
                    gsn.ParameterName = "@code";
                    gsn.SqlDbType = SqlDbType.VarChar;
                    gsn.Value = n.code;
                    cmd.Parameters.Add(gsn);

                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@desc";
                    gsab.SqlDbType = SqlDbType.VarChar;
                    gsab.Value = n.desc;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
                    gsac.Value = n.Id;
                    cmd.Parameters.Add(gsac);

                    SqlParameter gid = new SqlParameter();
                    gid.ParameterName = "@Name";
                    gid.SqlDbType = SqlDbType.VarChar;
                    gid.Value = n.Name;
                    cmd.Parameters.Add(gid);


                    SqlParameter gad = new SqlParameter();
                    gad.ParameterName = "@Address";
                    gad.SqlDbType = SqlDbType.VarChar;
                    gad.Value = n.Address;
                    cmd.Parameters.Add(gad);

                    SqlParameter gcn = new SqlParameter();
                    gcn.ParameterName = "@ContactNo1";
                    gcn.SqlDbType = SqlDbType.VarChar;
                    gcn.Value = n.ContactNo1;
                    cmd.Parameters.Add(gcn);

                    SqlParameter gcn1 = new SqlParameter();
                    gcn1.ParameterName = "@ContactNo2";
                    gcn1.SqlDbType = SqlDbType.VarChar;
                    gcn1.Value = n.ContactNo2;
                    cmd.Parameters.Add(gcn1);



                    SqlParameter gem = new SqlParameter();
                    gem.ParameterName = "@EmailId";
                    gem.SqlDbType = SqlDbType.VarChar;
                    gem.Value = n.EmailId;
                    cmd.Parameters.Add(gem);






                    //SqlParameter TAdd = new SqlParameter();
                    //TAdd.ParameterName = "@TemporaryAddress";
                    //TAdd.SqlDbType = SqlDbType.VarChar;
                    //TAdd.Value = n.TemporaryAddress;
                    //cmd.Parameters.Add(TAdd);


                    // ImageConverter imgCon = new ImageConverter();
                    // logo.Value = (byte[])imgCon.ConvertTo(n.Logo, typeof(byte[]));


                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag.Value = n.insupdflag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            // int found = 0;
            //  return Tbl;
        }

        [HttpPost]
        [Route("api/DataLoad/SaveUsers")]        

        public HttpResponseMessage SaveUsers(List<Users> list1)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdUsers";
                cmd.Connection = conn;

                conn.Open();


                foreach (Users U in list1)
                {
                    SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
                    UId.Value = U.Id;
                    cmd.Parameters.Add(UId);

                    SqlParameter UFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                    UFirstName.Value = U.FirstName;
                    cmd.Parameters.Add(UFirstName);

                    SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                    LastName.Value = U.LastName;
                    cmd.Parameters.Add(LastName);

                    SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
                    MiddleName.Value = U.MiddleName;
                    cmd.Parameters.Add(MiddleName);

                   
               

                    SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 15);
                    UEmail.Value = U.Email;
                    cmd.Parameters.Add(UEmail);

                   

                    SqlParameter UMobileNo = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 15);
                    UMobileNo.Value = U.ContactNo1;
                    cmd.Parameters.Add(UMobileNo);

                    SqlParameter ContactNo2 = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 15);
                    ContactNo2.Value = U.ContactNo2;
                    cmd.Parameters.Add(ContactNo2);

                   

                    SqlParameter UActive = new SqlParameter("@Active", SqlDbType.Int);
                    UActive.Value = U.Active;
                    cmd.Parameters.Add(UActive);

                  

                    //  SqlParameter WUserName = new SqlParameter("@WUserName",SqlDbType.VarChar,15);
                    //WUserName.Value = U.WUserName;
                    //cmd.Parameters.Add(WUserName);

                    //SqlParameter WPassword = new SqlParameter("@WPassword",SqlDbType.VarChar,15);
                    //WPassword.Value = U.WPassword;
                    //cmd.Parameters.Add(WPassword);

               
                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                    insupdflag.Value = U.insupdflag;
                    cmd.Parameters.Add(insupdflag);
                   

                   

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUsers:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            // int found = 0;
            //  return Tbl;
        }





        //Jagan Updated start
        [HttpPost]
        [Route("api/DataLoad/SaveCompanyGroups1")]
        public HttpResponseMessage SaveCompanyGroups1(List<CompanyGroups> list)
        {
            //DataTable dt = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            
            //SqlConnection conn = new SqlConnection();
            //list = new List<CompanyGroups>();
            //try
            //{
            //    //connect to database

            //    // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "InsUpdDelcompany2";
            //    cmd.Connection = conn;

            //    conn.Open();
                
            //    foreach (CompanyGroups n in list)
            //    {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCompany2";
                cmd.Connection = conn;

                conn.Open();

                foreach (CompanyGroups n in list)
                {
                    SqlParameter gid = new SqlParameter();
                    gid.ParameterName = "@Name";
                    gid.SqlDbType = SqlDbType.VarChar;
                    gid.Value = n.Name;
                    cmd.Parameters.Add(gid);

                    SqlParameter gsa = new SqlParameter("@active", SqlDbType.Int);
                    gsa.Value = n.active;
                    cmd.Parameters.Add(gsa);

                    SqlParameter gsn = new SqlParameter();
                    gsn.ParameterName = "@code";
                    gsn.SqlDbType = SqlDbType.VarChar;
                    gsn.Value = n.code;
                    cmd.Parameters.Add(gsn);

                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@Description";
                    gsab.SqlDbType = SqlDbType.VarChar;
                    gsab.Value = n.desc;
                    cmd.Parameters.Add(gsab);

                    //SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
                    //gsac.Value = n.Id;
                    //cmd.Parameters.Add(gsac);                    

                    SqlParameter gad = new SqlParameter();
                    gad.ParameterName = "@Address";
                    gad.SqlDbType = SqlDbType.VarChar;
                    gad.Value = n.Address;
                    cmd.Parameters.Add(gad);

                    SqlParameter gem = new SqlParameter();
                    gem.ParameterName = "@EmailId";
                    gem.SqlDbType = SqlDbType.VarChar;
                    gem.Value = n.EmailId;
                    cmd.Parameters.Add(gem);

                    SqlParameter gcn = new SqlParameter();
                    gcn.ParameterName = "@ContactNo1";
                    gcn.SqlDbType = SqlDbType.VarChar;
                    gcn.Value = n.ContactNo1;
                    cmd.Parameters.Add(gcn);

                    SqlParameter gcn1 = new SqlParameter();
                    gcn1.ParameterName = "@ContactNo2";
                    gcn1.SqlDbType = SqlDbType.VarChar;
                    gcn1.Value = n.ContactNo2;
                    cmd.Parameters.Add(gcn1);

                    SqlParameter gcn2 = new SqlParameter();
                    gcn2.ParameterName = "@Fax";
                    gcn2.SqlDbType = SqlDbType.VarChar;
                    gcn2.Value = n.Fax;
                    cmd.Parameters.Add(gcn2);

                    SqlParameter gem1 = new SqlParameter();
                    gem1.ParameterName = "@Title";
                    gem1.SqlDbType = SqlDbType.VarChar;
                    gem1.Value = n.Title;
                    cmd.Parameters.Add(gem1);

                    SqlParameter gem2 = new SqlParameter();
                    gem2.ParameterName = "@Caption";
                    gem2.SqlDbType = SqlDbType.VarChar;
                    gem2.Value = n.Caption;
                    cmd.Parameters.Add(gem2);

                    SqlParameter gem3 = new SqlParameter();
                    gem3.ParameterName = "@Country";
                    gem3.SqlDbType = SqlDbType.VarChar;
                    gem3.Value = n.Country;
                    cmd.Parameters.Add(gem3);

                    SqlParameter gem4 = new SqlParameter();
                    gem4.ParameterName = "@ZipCode";
                    gem4.SqlDbType = SqlDbType.VarChar;
                    gem4.Value = n.ZipCode;
                    cmd.Parameters.Add(gem4);

                    SqlParameter gem5 = new SqlParameter();
                    gem5.ParameterName = "@State";
                    gem5.SqlDbType = SqlDbType.VarChar;
                    gem5.Value = n.State;
                    cmd.Parameters.Add(gem5);

                    SqlParameter gem8 = new SqlParameter();
                    gem8.ParameterName = "@FleetSize";
                    gem8.SqlDbType = SqlDbType.Int;
                    gem8.Value = n.FleetSize;
                    cmd.Parameters.Add(gem8);

                    SqlParameter gem7 = new SqlParameter();
                    gem7.ParameterName = "@StaffSize";
                    gem7.SqlDbType = SqlDbType.Int;
                    gem7.Value = n.StaffSize;
                    cmd.Parameters.Add(gem7);

                    SqlParameter gem9 = new SqlParameter();
                    gem9.ParameterName = "@AlternateAddress";
                    gem9.SqlDbType = SqlDbType.VarChar;
                    gem9.Value = n.AlternateAddress;
                    cmd.Parameters.Add(gem9);


                    //SqlParameter TAdd = new SqlParameter();
                    //TAdd.ParameterName = "@TemporaryAddress";
                    //TAdd.SqlDbType = SqlDbType.VarChar;
                    //TAdd.Value = n.TemporaryAddress;
                    //cmd.Parameters.Add(TAdd);


                    // ImageConverter imgCon = new ImageConverter();
                    // logo.Value = (byte[])imgCon.ConvertTo(n.Logo, typeof(byte[]));


                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag.Value = n.insupdflag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            // int found = 0;
            //  return Tbl;
        }


        //jagan updated end
    }
}
