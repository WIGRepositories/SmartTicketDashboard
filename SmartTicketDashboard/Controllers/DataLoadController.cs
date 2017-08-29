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
using System.Collections;

namespace SmartTicketDashboard.Controllers
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

        //[HttpPost]
        //[Route("api/DataLoad/SaveCompanyGroups")]
        //public HttpResponseMessage SaveCompanyGroups(List<CompanyGroups> list)
        //{
            
        //    LogTraceWriter traceWriter = new LogTraceWriter();
        //    traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
        //    //DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();

        //    try
        //    {
        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "InsUpdDelCompany";
        //        cmd.Connection = conn;

        //        conn.Open();
                
        //        foreach (CompanyGroups n in list)
        //        {
        //            SqlParameter gsa = new SqlParameter();
        //            gsa.ParameterName = "@active";
        //            gsa.SqlDbType = SqlDbType.Int;
        //            gsa.Value = n.active;
        //            cmd.Parameters.Add(gsa);

        //            SqlParameter gsn = new SqlParameter();
        //            gsn.ParameterName = "@code";
        //            gsn.SqlDbType = SqlDbType.VarChar;
        //            gsn.Value = n.code;
        //            cmd.Parameters.Add(gsn);

        //            SqlParameter gsab = new SqlParameter();
        //            gsab.ParameterName = "@desc";
        //            gsab.SqlDbType = SqlDbType.VarChar;
        //            gsab.Value = n.desc;
        //            cmd.Parameters.Add(gsab);

        //            SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
        //            gsac.Value = n.Id;
        //            cmd.Parameters.Add(gsac);

        //            SqlParameter gid = new SqlParameter();
        //            gid.ParameterName = "@Name";
        //            gid.SqlDbType = SqlDbType.VarChar;
        //            gid.Value = n.Name;
        //            cmd.Parameters.Add(gid);


        //            SqlParameter gad = new SqlParameter();
        //            gad.ParameterName = "@Address";
        //            gad.SqlDbType = SqlDbType.VarChar;
        //            gad.Value = n.Address;
        //            cmd.Parameters.Add(gad);

        //            SqlParameter gcn = new SqlParameter();
        //            gcn.ParameterName = "@ContactNo1";
        //            gcn.SqlDbType = SqlDbType.VarChar;
        //            gcn.Value = n.ContactNo1;
        //            cmd.Parameters.Add(gcn);

        //            SqlParameter gcn1 = new SqlParameter();
        //            gcn1.ParameterName = "@ContactNo2";
        //            gcn1.SqlDbType = SqlDbType.VarChar;
        //            gcn1.Value = n.ContactNo2;
        //            cmd.Parameters.Add(gcn1);



        //            SqlParameter gem = new SqlParameter();
        //            gem.ParameterName = "@EmailId";
        //            gem.SqlDbType = SqlDbType.VarChar;
        //            gem.Value = n.EmailId;
        //            cmd.Parameters.Add(gem);






        //            //SqlParameter TAdd = new SqlParameter();
        //            //TAdd.ParameterName = "@TemporaryAddress";
        //            //TAdd.SqlDbType = SqlDbType.VarChar;
        //            //TAdd.Value = n.TemporaryAddress;
        //            //cmd.Parameters.Add(TAdd);


        //            // ImageConverter imgCon = new ImageConverter();
        //            // logo.Value = (byte[])imgCon.ConvertTo(n.Logo, typeof(byte[]));


        //            SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
        //            insupdflag.Value = n.insupdflag;
        //            cmd.Parameters.Add(insupdflag);

        //            cmd.ExecuteScalar();
        //            cmd.Parameters.Clear();
        //        }
        //        conn.Close();
        //        traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }

        //        string str = ex.Message;
        //        traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    // int found = 0;
        //    //  return Tbl;
        //}

        //[HttpPost]
        //[Route("api/DataLoad/SaveUsers")]

        //public HttpResponseMessage SaveUsers(List<Users> list1)
        //{

        //    LogTraceWriter traceWriter = new LogTraceWriter();
        //    traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers credentials....");
        //    //DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();

        //    try
        //    {
        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "InsUpdUsers";
        //        cmd.Connection = conn;

        //        conn.Open();


        //        foreach (Users U in list1)
        //        {
        //            SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
        //            UId.Value = U.Id;
        //            cmd.Parameters.Add(UId);

        //            SqlParameter UFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
        //            UFirstName.Value = U.FirstName;
        //            cmd.Parameters.Add(UFirstName);

        //            SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
        //            LastName.Value = U.LastName;
        //            cmd.Parameters.Add(LastName);

        //            SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
        //            MiddleName.Value = U.MiddleName;
        //            cmd.Parameters.Add(MiddleName);




        //            SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 15);
        //            UEmail.Value = U.Email;
        //            cmd.Parameters.Add(UEmail);



        //            SqlParameter UMobileNo = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 15);
        //            UMobileNo.Value = U.ContactNo1;
        //            cmd.Parameters.Add(UMobileNo);

        //            SqlParameter ContactNo2 = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 15);
        //            ContactNo2.Value = U.ContactNo2;
        //            cmd.Parameters.Add(ContactNo2);



        //            SqlParameter UActive = new SqlParameter("@Active", SqlDbType.Int);
        //            UActive.Value = U.Active;
        //            cmd.Parameters.Add(UActive);



        //            //  SqlParameter WUserName = new SqlParameter("@WUserName",SqlDbType.VarChar,15);
        //            //WUserName.Value = U.WUserName;
        //            //cmd.Parameters.Add(WUserName);

        //            //SqlParameter WPassword = new SqlParameter("@WPassword",SqlDbType.VarChar,15);
        //            //WPassword.Value = U.WPassword;
        //            //cmd.Parameters.Add(WPassword);


        //            SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
        //            insupdflag.Value = U.insupdflag;
        //            cmd.Parameters.Add(insupdflag);




        //            cmd.ExecuteScalar();
        //            cmd.Parameters.Clear();
        //        }
        //        conn.Close();
        //        traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers Credentials completed.");
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }

        //        string str = ex.Message;
        //        traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUsers:" + ex.Message);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    // int found = 0;
        //    //  return Tbl;
        //}





        //Jagan Updated start
        [HttpPost]
        [Route("api/DataLoad/SaveCompanyGroups1")]
        public HttpResponseMessage SaveCompanyGroups1(List<CompanyGroups> list)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            //DataTable dt = new DataTable();
            
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCompany2";
                cmd.Connection = conn;

                conn.Open();

                foreach (CompanyGroups m in list)
                {
                    SqlParameter gid = new SqlParameter();
                    gid.ParameterName = "@Name";
                    gid.SqlDbType = SqlDbType.VarChar;
                    gid.Value = m.Name;
                    cmd.Parameters.Add(gid);

                    SqlParameter gsa = new SqlParameter("@active", SqlDbType.Int);
                    gsa.Value = m.active;
                    cmd.Parameters.Add(gsa);

                    SqlParameter gsn = new SqlParameter();
                    gsn.ParameterName = "@code";
                    gsn.SqlDbType = SqlDbType.VarChar;
                    gsn.Value = m.code;
                    cmd.Parameters.Add(gsn);

                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@Description";
                    gsab.SqlDbType = SqlDbType.VarChar;
                    gsab.Value = m.desc;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gad = new SqlParameter();
                    gad.ParameterName = "@Address";
                    gad.SqlDbType = SqlDbType.VarChar;
                    gad.Value = m.Address;
                    cmd.Parameters.Add(gad);

                    SqlParameter gem = new SqlParameter();
                    gem.ParameterName = "@EmailId";
                    gem.SqlDbType = SqlDbType.VarChar;
                    gem.Value = m.EmailId;
                    cmd.Parameters.Add(gem);

                    SqlParameter gcn = new SqlParameter();
                    gcn.ParameterName = "@ContactNo1";
                    gcn.SqlDbType = SqlDbType.VarChar;
                    gcn.Value = m.ContactNo1;
                    cmd.Parameters.Add(gcn);

                    SqlParameter gcn1 = new SqlParameter();
                    gcn1.ParameterName = "@ContactNo2";
                    gcn1.SqlDbType = SqlDbType.VarChar;
                    gcn1.Value = m.ContactNo2;
                    cmd.Parameters.Add(gcn1);

                    SqlParameter gcn2 = new SqlParameter();
                    gcn2.ParameterName = "@Fax";
                    gcn2.SqlDbType = SqlDbType.VarChar;
                    gcn2.Value = m.Fax;
                    cmd.Parameters.Add(gcn2);

                    SqlParameter gem1 = new SqlParameter();
                    gem1.ParameterName = "@Title";
                    gem1.SqlDbType = SqlDbType.VarChar;
                    gem1.Value = m.Title;
                    cmd.Parameters.Add(gem1);

                    SqlParameter gem2 = new SqlParameter();
                    gem2.ParameterName = "@Caption";
                    gem2.SqlDbType = SqlDbType.VarChar;
                    gem2.Value = m.Caption;
                    cmd.Parameters.Add(gem2);

                    SqlParameter gem3 = new SqlParameter();
                    gem3.ParameterName = "@Country";
                    gem3.SqlDbType = SqlDbType.VarChar;
                    gem3.Value = m.Country;
                    cmd.Parameters.Add(gem3);

                    SqlParameter gem4 = new SqlParameter();
                    gem4.ParameterName = "@ZipCode";
                    gem4.SqlDbType = SqlDbType.VarChar;
                    gem4.Value = m.ZipCode;
                    cmd.Parameters.Add(gem4);

                    SqlParameter gem5 = new SqlParameter();
                    gem5.ParameterName = "@State";
                    gem5.SqlDbType = SqlDbType.VarChar;
                    gem5.Value = m.State;
                    cmd.Parameters.Add(gem5);

                    SqlParameter gem8 = new SqlParameter();
                    gem8.ParameterName = "@FleetSize";
                    gem8.SqlDbType = SqlDbType.Int;
                    gem8.Value = m.FleetSize;
                    cmd.Parameters.Add(gem8);

                    SqlParameter gem7 = new SqlParameter();
                    gem7.ParameterName = "@StaffSize";
                    gem7.SqlDbType = SqlDbType.Int;
                    gem7.Value = m.StaffSize;
                    cmd.Parameters.Add(gem7);

                    SqlParameter gem9 = new SqlParameter();
                    gem9.ParameterName = "@AlternateAddress";
                    gem9.SqlDbType = SqlDbType.VarChar;
                    gem9.Value = m.AlternateAddress;
                    cmd.Parameters.Add(gem9);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag.Value = m.insupdflag;
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


        //Jagan Updated On18thAug Start


        //[HttpPost]
        //[Route("api/DataLoad/SaveDriverGroups")]
        //public SqlParameter[] SaveDriverGroups(DriversGroups m)
        //{
            
        //    //List<DriversGroups> list1 = new List<DriversGroups>();
        //    LogTraceWriter traceWriter = new LogTraceWriter();
        //    traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriverGroups credentials....");
        //    //DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();

        //    try
        //    {
        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "HVInsUpddrivers2";
        //        cmd.Connection = conn;

        //        conn.Open();
        //        //list = new List<DriversGroups>();
        //        for(int i=0; i<m.DriversGroup.Length;i++)
        //        {
        //            SqlParameter dgid = new SqlParameter();
        //            dgid.ParameterName = "@CompanyId";
        //            dgid.SqlDbType = SqlDbType.Int;
        //            dgid.Value = m.CompanyId;
        //            cmd.Parameters.Add(dgid);

        //            SqlParameter dgname = new SqlParameter("@NAme", SqlDbType.VarChar, 50);
        //            dgname.Value = m.NAme;
        //            cmd.Parameters.Add(dgname);

        //            SqlParameter dgAddr = new SqlParameter();
        //            dgAddr.ParameterName = "@Address";
        //            dgAddr.SqlDbType = SqlDbType.VarChar;
        //            dgAddr.Value = m.Address;
        //            cmd.Parameters.Add(dgAddr);

        //            SqlParameter dgcity = new SqlParameter();
        //            dgcity.ParameterName = "@City";
        //            dgcity.SqlDbType = SqlDbType.VarChar;
        //            dgcity.Value = m.City;
        //            cmd.Parameters.Add(dgcity);

        //            SqlParameter dgppin = new SqlParameter();
        //            dgppin.ParameterName = "@Pin";
        //            dgppin.SqlDbType = SqlDbType.VarChar;
        //            dgppin.Value = m.Pin;
        //            cmd.Parameters.Add(dgppin);

        //            //SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
        //            //gsac.Value = n.Id;
        //            //cmd.Parameters.Add(gsac);                    

        //            SqlParameter dgpadr = new SqlParameter();
        //            dgpadr.ParameterName = "@PAddress";
        //            dgpadr.SqlDbType = SqlDbType.VarChar;
        //            dgpadr.Value = m.PAddress;
        //            cmd.Parameters.Add(dgpadr);

        //            SqlParameter dgPPin = new SqlParameter();
        //            dgPPin.ParameterName = "@PPin";
        //            dgPPin.SqlDbType = SqlDbType.VarChar;
        //            dgPPin.Value = m.PPin;
        //            cmd.Parameters.Add(dgPPin);

        //            SqlParameter dgMob1 = new SqlParameter();
        //            dgMob1.ParameterName = "@OffMobileNo";
        //            dgMob1.SqlDbType = SqlDbType.VarChar;
        //            dgMob1.Value = m.OffMobileNo;
        //            cmd.Parameters.Add(dgMob1);

        //            SqlParameter dgPM = new SqlParameter();
        //            dgPM.ParameterName = "@PMobNo";
        //            dgPM.SqlDbType = SqlDbType.VarChar;
        //            dgPM.Value = m.PMobNo;
        //            cmd.Parameters.Add(dgPM);

        //            SqlParameter dgDOB = new SqlParameter();
        //            dgDOB.ParameterName = "@DOB";
        //            dgDOB.SqlDbType = SqlDbType.DateTime;
        //            dgDOB.Value = m.DOB;
        //            cmd.Parameters.Add(dgDOB);

        //            SqlParameter dgDOJ = new SqlParameter();
        //            dgDOJ.ParameterName = "@DOJ";
        //            dgDOJ.SqlDbType = SqlDbType.DateTime;
        //            dgDOJ.Value = m.DOJ;
        //            cmd.Parameters.Add(dgDOJ);

        //            SqlParameter dgbg = new SqlParameter();
        //            dgbg.ParameterName = "@BloodGroup";
        //            dgbg.SqlDbType = SqlDbType.VarChar;
        //            dgbg.Value = m.BloodGroup;
        //            cmd.Parameters.Add(dgbg);

        //            SqlParameter dgLNo = new SqlParameter();
        //            dgLNo.ParameterName = "@LicenceNo";
        //            dgLNo.SqlDbType = SqlDbType.VarChar;
        //            dgLNo.Value = m.LicenceNo;
        //            cmd.Parameters.Add(dgLNo);

        //            SqlParameter dgLEDt = new SqlParameter();
        //            dgLEDt.ParameterName = "@LiCExpDate";
        //            dgLEDt.SqlDbType = SqlDbType.VarChar;
        //            dgLEDt.Value = m.LiCExpDate;
        //            cmd.Parameters.Add(dgLEDt);

        //            SqlParameter dgBNo = new SqlParameter();
        //            dgBNo.ParameterName = "@BadgeNo";
        //            dgBNo.SqlDbType = SqlDbType.VarChar;
        //            dgBNo.Value = m.BadgeNo;
        //            cmd.Parameters.Add(dgBNo);

        //            SqlParameter dgBED = new SqlParameter();
        //            dgBED.ParameterName = "@BadgeExpDate";
        //            dgBED.SqlDbType = SqlDbType.DateTime;
        //            dgBED.Value = m.BadgeExpDate;
        //            cmd.Parameters.Add(dgBED);

        //            SqlParameter dgRemarks = new SqlParameter();
        //            dgRemarks.ParameterName = "@Remarks";
        //            dgRemarks.SqlDbType = SqlDbType.VarChar;
        //            dgRemarks.Value = m.Remarks;
        //            cmd.Parameters.Add(dgRemarks);


        //            SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
        //            insupdflag.Value = m.flag;
        //            cmd.Parameters.Add(insupdflag);

        //            cmd.ExecuteScalar();
        //            cmd.Parameters.Clear();
        //        }
                
                
        //        return null;
        //        //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriversGroups Credentials completed.");
        //        //return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }

        //        string str = ex.Message;
        //        traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
        //        ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //        return null;
        //    }
        //    // int found = 0;
        //    //  return Tbl;
        //}
        //Jagan Updated On18thAug End


        //jaganupdated on  21st Aug Start

        [HttpPost]
        [Route("api/DataLoad/SaveUsersGroup1")]

        public HttpResponseMessage SaveUsersGroup1(List<UsersGroup> list5)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdUsers";
                cmd.Connection = conn;

                conn.Open();


                foreach (UsersGroup U in list5)
                {
                    //SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
                    //UId.Value = U.Id;
                    //cmd.Parameters.Add(UId);

                    SqlParameter UFirstName=new SqlParameter();
                    UFirstName.ParameterName="@FirstName";
                    UFirstName.SqlDbType=SqlDbType.VarChar;
                    UFirstName.Value=U.FirstName;
                    cmd.Parameters.Add(UFirstName);

                    SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                    LastName.Value = U.LastName;
                    cmd.Parameters.Add(LastName);

                    SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
                    MiddleName.Value = U.MiddleName;
                    cmd.Parameters.Add(MiddleName);

                    SqlParameter empNo = new SqlParameter("@EmpNo", SqlDbType.VarChar, 15);
                    empNo.Value = U.EmpNo;
                    cmd.Parameters.Add(empNo);

                    SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 15);
                    UEmail.Value = U.Email;
                    cmd.Parameters.Add(UEmail);

                    SqlParameter UAddress = new SqlParameter("@Address", SqlDbType.VarChar, 15);
                    UAddress.Value = U.Address;
                    cmd.Parameters.Add(UAddress);

                    SqlParameter roleId = new SqlParameter("@RoleId", SqlDbType.Int);
                    roleId.Value = U.RoleId;
                    cmd.Parameters.Add(roleId);

                    SqlParameter UActive = new SqlParameter("@Active", SqlDbType.Int);
                    UActive.Value = U.Active;
                    cmd.Parameters.Add(UActive);

                    SqlParameter UcmpId = new SqlParameter("@cmpId", SqlDbType.Int);
                    UcmpId.Value = U.cmpId;
                    cmd.Parameters.Add(UcmpId);


                    SqlParameter UMobileNo = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 15);
                    UMobileNo.Value = U.ContactNo1;
                    cmd.Parameters.Add(UMobileNo);

                    SqlParameter ContactNo2 = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 15);
                    ContactNo2.Value = U.ContactNo2;
                    cmd.Parameters.Add(ContactNo2);

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
        //jaganupdated on 21st Aug End
        [HttpPost]
        [Route("api/DataLoad/SaveVehicleGroups")]
        public SqlParameter[] SaveVehicleGroups(VehiclesGroups o)
        {
           
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveVehicleGroups credentials....");
            
            SqlConnection conn = new SqlConnection();

            try
            {
               
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpddrivers2";
                cmd.Connection = conn;

                conn.Open();
              
                ArrayList arr = new ArrayList();
               
                SqlParameter vgid = new SqlParameter();
                vgid.ParameterName = "@Id";
                vgid.SqlDbType = SqlDbType.Int;
                vgid.Value = o.Id;
                cmd.Parameters.Add(vgid);

                SqlParameter vgCompanyId = new SqlParameter("@CompanyId", SqlDbType.Int);
                vgCompanyId.Value = o.CompanyId;
                cmd.Parameters.Add(vgCompanyId);

                SqlParameter vgVId = new SqlParameter();
                vgVId.ParameterName = "@VID";
                vgVId.SqlDbType = SqlDbType.Int;
                vgVId.Value = o.VID;
                cmd.Parameters.Add(vgVId);

                SqlParameter vgRegNo = new SqlParameter();
                vgRegNo.ParameterName = "@RegistrationNo";
                vgRegNo.SqlDbType = SqlDbType.NVarChar;
                vgRegNo.Value = o.RegistrationNo;
                cmd.Parameters.Add(vgRegNo);

                SqlParameter vgType = new SqlParameter();
                vgType.ParameterName = "@Type";
                vgType.SqlDbType = SqlDbType.NVarChar;
                vgType.Value = o.Type;
                cmd.Parameters.Add(vgType);
                 
                SqlParameter vgOwnerName = new SqlParameter();
                vgOwnerName.ParameterName = "@OwnerName";
                vgOwnerName.SqlDbType = SqlDbType.NVarChar;
                vgOwnerName.Value = o.OwnerName;
                cmd.Parameters.Add(vgOwnerName);

                SqlParameter vgChasisNo = new SqlParameter();
                vgChasisNo.ParameterName = "@ChasisNo";
                vgChasisNo.SqlDbType = SqlDbType.NVarChar;
                vgChasisNo.Value = o.ChasisNo;
                cmd.Parameters.Add(vgChasisNo);

                SqlParameter vgEngineNo = new SqlParameter();
                vgEngineNo.ParameterName = "@Engineno";
                vgEngineNo.SqlDbType = SqlDbType.NVarChar;
                vgEngineNo.Value = o.Engineno;
                cmd.Parameters.Add(vgEngineNo);

                SqlParameter vgRoadTDate = new SqlParameter();
                vgRoadTDate.ParameterName = "@RoadTaxDate";
                vgRoadTDate.SqlDbType = SqlDbType.DateTime;
                vgRoadTDate.Value = o.RoadTaxDate;
                cmd.Parameters.Add(vgRoadTDate);

                SqlParameter vgInsuNo = new SqlParameter();
                vgInsuNo.ParameterName = "@InsuranceNo";
                vgInsuNo.SqlDbType = SqlDbType.NVarChar;
                vgInsuNo.Value = o.InsuranceNo;
                cmd.Parameters.Add(vgInsuNo);

                SqlParameter vgInsDate = new SqlParameter();
                vgInsDate.ParameterName = "@InsDate";
                vgInsDate.SqlDbType = SqlDbType.DateTime;
                vgInsDate.Value = o.InsDate;
                cmd.Parameters.Add(vgInsDate);

                SqlParameter vgPolutionNo = new SqlParameter();
                vgPolutionNo.ParameterName = "@PolutionNo";
                vgPolutionNo.SqlDbType = SqlDbType.NVarChar;
                vgPolutionNo.Value = o.PolutionNo;
                cmd.Parameters.Add(vgPolutionNo);

                SqlParameter vgPolExpDate = new SqlParameter();
                vgPolExpDate.ParameterName = "@PolExpDate";
                vgPolExpDate.SqlDbType = SqlDbType.DateTime;
                vgPolExpDate.Value = o.PolExpDate;
                cmd.Parameters.Add(vgPolExpDate);

                SqlParameter vgRCBookNo = new SqlParameter();
                vgRCBookNo.ParameterName = "@RCBookNo";
                vgRCBookNo.SqlDbType = SqlDbType.NVarChar;
                vgRCBookNo.Value = o.RCBookNo;
                cmd.Parameters.Add(vgRCBookNo);

                SqlParameter vgRCExpDate = new SqlParameter();
                vgRCExpDate.ParameterName = "@RCExpDate";
                vgRCExpDate.SqlDbType = SqlDbType.DateTime;
                vgRCExpDate.Value = o.RCExpDate;
                cmd.Parameters.Add(vgRCExpDate);

                SqlParameter vgCompanyVeh = new SqlParameter();
                vgCompanyVeh.ParameterName = "@CompanyVechile";
                vgCompanyVeh.SqlDbType = SqlDbType.Int;
                vgCompanyVeh.Value = o.CompanyVechile;
                cmd.Parameters.Add(vgCompanyVeh);

                SqlParameter vgOwnerPhoneNo = new SqlParameter();
                vgOwnerPhoneNo.ParameterName = "@OwnerPhoneNo";
                vgOwnerPhoneNo.SqlDbType = SqlDbType.NVarChar;
                vgOwnerPhoneNo.Value = o.OwnerPhoneNo;
                cmd.Parameters.Add(vgOwnerPhoneNo);

                SqlParameter vgHomeLandmark = new SqlParameter();
                vgHomeLandmark.ParameterName = "@HomeLandmark";
                vgHomeLandmark.SqlDbType = SqlDbType.NVarChar;
                vgHomeLandmark.Value = o.HomeLandmark;
                cmd.Parameters.Add(vgHomeLandmark);


                SqlParameter vgMYear = new SqlParameter();
                vgMYear.ParameterName = "@ModelYear";
                vgMYear.SqlDbType = SqlDbType.NVarChar;
                vgMYear.Value = o.ModelYear;
                cmd.Parameters.Add(vgMYear);

                SqlParameter vgDayOnly = new SqlParameter();
                vgDayOnly.ParameterName = "@DayOnly";
                vgDayOnly.SqlDbType = SqlDbType.NVarChar;
                vgDayOnly.Value = o.DayOnly;
                cmd.Parameters.Add(vgDayOnly);

                SqlParameter vgVechMobileNo = new SqlParameter();
                vgVechMobileNo.ParameterName = "@VechMobileNo";
                vgVechMobileNo.SqlDbType = SqlDbType.NVarChar;
                vgVechMobileNo.Value = o.DayOnly;
                cmd.Parameters.Add(vgVechMobileNo);

                SqlParameter vgEntryDate = new SqlParameter();
                vgEntryDate.ParameterName = "@EntryDate";
                vgEntryDate.SqlDbType = SqlDbType.DateTime;
                vgEntryDate.Value = o.EntryDate;
                cmd.Parameters.Add(vgEntryDate);

                SqlParameter vgNewEntry = new SqlParameter();
                vgNewEntry.ParameterName = "@NewEntry";
                vgNewEntry.SqlDbType = SqlDbType.NVarChar;
                vgNewEntry.Value = o.EntryDate;
                cmd.Parameters.Add(vgNewEntry);

                SqlParameter vgVehicleModelId = new SqlParameter();
                vgVehicleModelId.ParameterName = "@VehicleModelId";
                vgVehicleModelId.SqlDbType = SqlDbType.Int;
                vgVehicleModelId.Value = o.VehicleModelId;
                cmd.Parameters.Add(vgVehicleModelId);

                SqlParameter vgServiceTypeId = new SqlParameter();
                vgServiceTypeId.ParameterName = "@ServiceTypeId";
                vgServiceTypeId.SqlDbType = SqlDbType.Int;
                vgServiceTypeId.Value = o.VehicleModelId;
                cmd.Parameters.Add(vgServiceTypeId);

                SqlParameter vgVehicleGroupId = new SqlParameter();
                vgVehicleGroupId.ParameterName = "@VehicleGroupId";
                vgVehicleGroupId.SqlDbType = SqlDbType.Int;
                vgVehicleGroupId.Value = o.VehicleModelId;
                cmd.Parameters.Add(vgVehicleGroupId);
                
                SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
                insupdflag.Value = o.flag;
                cmd.Parameters.Add(insupdflag);

                cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                //}

                if (arr.Count > 0)
                {
                    arr.TrimToSize();
                    return (SqlParameter[])arr.ToArray(typeof(SqlParameter));
                }
                return null;
                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriversGroups Credentials completed.");
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
                ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return null;
            }
        }

        //demo purpose
        [HttpPost]
        [Route("api/DataLoad/SaveDriverGroups1")]
        public HttpResponseMessage SaveDriverGroups1(List<DriversGroups> list1)
        {

            //List<DriversGroups> list1 = new List<DriversGroups>();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriverGroups credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpddrivers2";
                cmd.Connection = conn;

                conn.Open();
                //list = new List<DriversGroups>();
                foreach (DriversGroups p in list1)
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "HVInsUpddrivers2";
                    //cmd.Connection = conn;


                    SqlParameter dgid = new SqlParameter();
                    dgid.ParameterName = "@CompanyId";
                    dgid.SqlDbType = SqlDbType.Int;
                    dgid.Value = p.CompanyId;
                    cmd.Parameters.Add(dgid);

                    SqlParameter dgname = new SqlParameter("@NAme", SqlDbType.VarChar, 50);
                    dgname.Value = p.NAme;
                    cmd.Parameters.Add(dgname);

                    SqlParameter dgAddr = new SqlParameter();
                    dgAddr.ParameterName = "@Address";
                    dgAddr.SqlDbType = SqlDbType.VarChar;
                    dgAddr.Value = p.Address;
                    cmd.Parameters.Add(dgAddr);

                    SqlParameter dgcity = new SqlParameter();
                    dgcity.ParameterName = "@City";
                    dgcity.SqlDbType = SqlDbType.VarChar;
                    dgcity.Value = p.City;
                    cmd.Parameters.Add(dgcity);

                    SqlParameter dgppin = new SqlParameter();
                    dgppin.ParameterName = "@Pin";
                    dgppin.SqlDbType = SqlDbType.VarChar;
                    dgppin.Value = p.Pin;
                    cmd.Parameters.Add(dgppin);

                    SqlParameter dgpadr = new SqlParameter();
                    dgpadr.ParameterName = "@PAddress";
                    dgpadr.SqlDbType = SqlDbType.VarChar;
                    dgpadr.Value = p.PAddress;
                    cmd.Parameters.Add(dgpadr);

                    SqlParameter dgPPin = new SqlParameter();
                    dgPPin.ParameterName = "@PPin";
                    dgPPin.SqlDbType = SqlDbType.VarChar;
                    dgPPin.Value = p.PPin;
                    cmd.Parameters.Add(dgPPin);

                    SqlParameter dgMob1 = new SqlParameter();
                    dgMob1.ParameterName = "@OffMobileNo";
                    dgMob1.SqlDbType = SqlDbType.VarChar;
                    dgMob1.Value = p.OffMobileNo;
                    cmd.Parameters.Add(dgMob1);

                    SqlParameter dgPM = new SqlParameter();
                    dgPM.ParameterName = "@PMobNo";
                    dgPM.SqlDbType = SqlDbType.VarChar;
                    dgPM.Value = p.PMobNo;
                    cmd.Parameters.Add(dgPM);

                    SqlParameter dgDOB = new SqlParameter("@DOB", SqlDbType.DateTime);
                    dgDOB.Value = p.DOB;
                    cmd.Parameters.Add(dgDOB);

                    //SqlParameter dgDOB = new SqlParameter();
                    //dgDOB.ParameterName = "@DOB";
                    //dgDOB.SqlDbType = SqlDbType.DateTime;
                    //dgDOB.Value = p.DOB;
                    //cmd.Parameters.Add(dgDOB);

                    SqlParameter dgDOJ = new SqlParameter();
                    dgDOJ.ParameterName = "@DOJ";
                    dgDOJ.SqlDbType = SqlDbType.DateTime;
                    dgDOJ.Value = p.DOJ;
                    cmd.Parameters.Add(dgDOJ);

                    SqlParameter dgbg = new SqlParameter();
                    dgbg.ParameterName = "@BloodGroup";
                    dgbg.SqlDbType = SqlDbType.VarChar;
                    dgbg.Value = p.BloodGroup;
                    cmd.Parameters.Add(dgbg);

                    SqlParameter dgLNo = new SqlParameter();
                    dgLNo.ParameterName = "@LicenceNo";
                    dgLNo.SqlDbType = SqlDbType.VarChar;
                    dgLNo.Value = p.LicenceNo;
                    cmd.Parameters.Add(dgLNo);

                    SqlParameter dgLEDt = new SqlParameter();
                    dgLEDt.ParameterName = "@LiCExpDate";
                    dgLEDt.SqlDbType = SqlDbType.DateTime;
                    dgLEDt.Value = p.LiCExpDate;
                    cmd.Parameters.Add(dgLEDt);

                    SqlParameter dgBNo = new SqlParameter();
                    dgBNo.ParameterName = "@BadgeNo";
                    dgBNo.SqlDbType = SqlDbType.VarChar;
                    dgBNo.Value = p.BadgeNo;
                    cmd.Parameters.Add(dgBNo);

                    SqlParameter dgBED = new SqlParameter();
                    dgBED.ParameterName = "@BadgeExpDate";
                    dgBED.SqlDbType = SqlDbType.DateTime;
                    dgBED.Value = p.BadgeExpDate;
                    cmd.Parameters.Add(dgBED);

                    SqlParameter dgRemarks = new SqlParameter();
                    dgRemarks.ParameterName = "@Remarks";
                    dgRemarks.SqlDbType = SqlDbType.VarChar;
                    dgRemarks.Value = p.Remarks;
                    cmd.Parameters.Add(dgRemarks);


                    SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
                    insupdflag.Value = p.flag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriversGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str1 = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        //sam
        [HttpPost]
        [Route("api/DataLoad/SaveVehicleGroups1")]
        public HttpResponseMessage SaveVehicleGroups1(List<VehiclesGroups> list3)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveVehicleGroups credentials....");
            
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpdVehicles";
                cmd.Connection = conn;

                conn.Open();
                foreach (VehiclesGroups o in list3)
                {
                //SqlParameter vgid = new SqlParameter();
                //vgid.ParameterName = "@Id";
                //vgid.SqlDbType = SqlDbType.Int;
                //vgid.Value = o.Id;
                //cmd.Parameters.Add(vgid);

                SqlParameter vgCompanyId = new SqlParameter("@CompanyId", SqlDbType.Int);
                vgCompanyId.Value = o.CompanyId;
                cmd.Parameters.Add(vgCompanyId);

                SqlParameter vgVId = new SqlParameter();
                vgVId.ParameterName = "@VID";
                vgVId.SqlDbType = SqlDbType.Int;
                vgVId.Value = o.VID;
                cmd.Parameters.Add(vgVId);

                SqlParameter vgRegNo = new SqlParameter();
                vgRegNo.ParameterName = "@RegistrationNo";
                vgRegNo.SqlDbType = SqlDbType.NVarChar;
                vgRegNo.Value = o.RegistrationNo;
                cmd.Parameters.Add(vgRegNo);

                SqlParameter vgType = new SqlParameter();
                vgType.ParameterName = "@Type";
                vgType.SqlDbType = SqlDbType.NVarChar;
                vgType.Value = o.Type;
                cmd.Parameters.Add(vgType);

                //SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
                //gsac.Value = n.Id;
                //cmd.Parameters.Add(gsac);                    

                SqlParameter vgOwnerName = new SqlParameter();
                vgOwnerName.ParameterName = "@OwnerName";
                vgOwnerName.SqlDbType = SqlDbType.NVarChar;
                vgOwnerName.Value = o.OwnerName;
                cmd.Parameters.Add(vgOwnerName);

                SqlParameter vgChasisNo = new SqlParameter();
                vgChasisNo.ParameterName = "@ChasisNo";
                vgChasisNo.SqlDbType = SqlDbType.NVarChar;
                vgChasisNo.Value = o.ChasisNo;
                cmd.Parameters.Add(vgChasisNo);

                SqlParameter vgEngineNo = new SqlParameter();
                vgEngineNo.ParameterName = "@Engineno";
                vgEngineNo.SqlDbType = SqlDbType.NVarChar;
                vgEngineNo.Value = o.Engineno;
                cmd.Parameters.Add(vgEngineNo);

                SqlParameter vgRoadTDate = new SqlParameter();
                vgRoadTDate.ParameterName = "@RoadTaxDate";
                vgRoadTDate.SqlDbType = SqlDbType.DateTime;
                vgRoadTDate.Value = o.RoadTaxDate;
                cmd.Parameters.Add(vgRoadTDate);

                SqlParameter vgInsuNo = new SqlParameter();
                vgInsuNo.ParameterName = "@InsuranceNo";
                vgInsuNo.SqlDbType = SqlDbType.NVarChar;
                vgInsuNo.Value = o.InsuranceNo;
                cmd.Parameters.Add(vgInsuNo);

                SqlParameter vgInsDate = new SqlParameter();
                vgInsDate.ParameterName = "@InsDate";
                vgInsDate.SqlDbType = SqlDbType.DateTime;
                vgInsDate.Value = o.InsDate;
                cmd.Parameters.Add(vgInsDate);

                SqlParameter vgPolutionNo = new SqlParameter();
                vgPolutionNo.ParameterName = "@PolutionNo";
                vgPolutionNo.SqlDbType = SqlDbType.NVarChar;
                vgPolutionNo.Value = o.PolutionNo;
                cmd.Parameters.Add(vgPolutionNo);

                SqlParameter vgPolExpDate = new SqlParameter();
                vgPolExpDate.ParameterName = "@PolExpDate";
                vgPolExpDate.SqlDbType = SqlDbType.DateTime;
                vgPolExpDate.Value = o.PolExpDate;
                cmd.Parameters.Add(vgPolExpDate);

                SqlParameter vgRCBookNo = new SqlParameter();
                vgRCBookNo.ParameterName = "@RCBookNo";
                vgRCBookNo.SqlDbType = SqlDbType.NVarChar;
                vgRCBookNo.Value = o.RCBookNo;
                cmd.Parameters.Add(vgRCBookNo);

                SqlParameter vgRCExpDate = new SqlParameter();
                vgRCExpDate.ParameterName = "@RCExpDate";
                vgRCExpDate.SqlDbType = SqlDbType.DateTime;
                vgRCExpDate.Value = o.RCExpDate;
                cmd.Parameters.Add(vgRCExpDate);

                SqlParameter vgCompanyVeh = new SqlParameter();
                vgCompanyVeh.ParameterName = "@CompanyVechile";
                vgCompanyVeh.SqlDbType = SqlDbType.Int;
                vgCompanyVeh.Value = o.CompanyVechile;
                cmd.Parameters.Add(vgCompanyVeh);

                SqlParameter vgOwnerPhoneNo = new SqlParameter();
                vgOwnerPhoneNo.ParameterName = "@OwnerPhoneNo";
                vgOwnerPhoneNo.SqlDbType = SqlDbType.NVarChar;
                vgOwnerPhoneNo.Value = o.OwnerPhoneNo;
                cmd.Parameters.Add(vgOwnerPhoneNo);

                SqlParameter vgHomeLandmark = new SqlParameter();
                vgHomeLandmark.ParameterName = "@HomeLandmark";
                vgHomeLandmark.SqlDbType = SqlDbType.NVarChar;
                vgHomeLandmark.Value = o.HomeLandmark;
                cmd.Parameters.Add(vgHomeLandmark);


                SqlParameter vgMYear = new SqlParameter();
                vgMYear.ParameterName = "@ModelYear";
                vgMYear.SqlDbType = SqlDbType.NVarChar;
                vgMYear.Value = o.ModelYear;
                cmd.Parameters.Add(vgMYear);

                SqlParameter vgDayOnly = new SqlParameter();
                vgDayOnly.ParameterName = "@DayOnly";
                vgDayOnly.SqlDbType = SqlDbType.NVarChar;
                vgDayOnly.Value = o.DayOnly;
                cmd.Parameters.Add(vgDayOnly);

                SqlParameter vgVechMobileNo = new SqlParameter();
                vgVechMobileNo.ParameterName = "@VechMobileNo";
                vgVechMobileNo.SqlDbType = SqlDbType.NVarChar;
                vgVechMobileNo.Value = o.VechMobileNo;
                cmd.Parameters.Add(vgVechMobileNo);

                SqlParameter vgEntryDate = new SqlParameter();
                vgEntryDate.ParameterName = "@EntryDate";
                vgEntryDate.SqlDbType = SqlDbType.DateTime;
                vgEntryDate.Value = o.EntryDate;
                cmd.Parameters.Add(vgEntryDate);

                SqlParameter vgNewEntry = new SqlParameter();
                vgNewEntry.ParameterName = "@NewEntry";
                vgNewEntry.SqlDbType = SqlDbType.NVarChar;
                vgNewEntry.Value = o.EntryDate;
                cmd.Parameters.Add(vgNewEntry);

                SqlParameter vgVehicleModelId = new SqlParameter();
                vgVehicleModelId.ParameterName = "@VehicleModelId";
                vgVehicleModelId.SqlDbType = SqlDbType.Int;
                vgVehicleModelId.Value = o.VehicleModelId;
                cmd.Parameters.Add(vgVehicleModelId);

                SqlParameter vgServiceTypeId = new SqlParameter();
                vgServiceTypeId.ParameterName = "@ServiceTypeId";
                vgServiceTypeId.SqlDbType = SqlDbType.Int;
                vgServiceTypeId.Value = o.ServiceTypeId;
                cmd.Parameters.Add(vgServiceTypeId);

                SqlParameter vgVehicleGroupId = new SqlParameter();
                vgVehicleGroupId.ParameterName = "@VehicleGroupId";
                vgVehicleGroupId.SqlDbType = SqlDbType.Int;
                vgVehicleGroupId.Value = o.VehicleGroupId;
                cmd.Parameters.Add(vgVehicleGroupId);

                SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
                insupdflag.Value = o.flag;
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
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
                ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return null;
            }
        }
        
     

        
    }
}
