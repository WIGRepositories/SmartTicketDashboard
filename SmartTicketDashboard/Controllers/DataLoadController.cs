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
        [Route("api/DataLoad/GetDataLoad")]
        public DataTable GetDataLoad()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetDataLoad credentials....");
            SqlConnection conn = new SqlConnection();
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





        
        [HttpPost]
        [Route("api/DataLoad/SaveCompanyGroups1")]
        public DataTable SaveCompanyGroups1(List<CompanyGroups> list)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            DataTable tbl = new DataTable();

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCompanyGroups";
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

                    DataSet ds = new DataSet();
                    SqlDataAdapter db = new SqlDataAdapter(cmd);
                    db.Fill(tbl);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
                return tbl;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                
                string str = ex.Message;

                
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
                
                return tbl;


                // int found = 0;
               
            }
         
        }
        


        


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
                cmd.CommandText = "InsUpdUsersGroups";
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
                cmd.CommandText = "HVInsUpddriversGroup";
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

                    SqlParameter dgVehicleModelId = new SqlParameter();
                    dgVehicleModelId.ParameterName = "@VehicleModelId";
                    dgVehicleModelId.SqlDbType = SqlDbType.VarChar;
                    dgVehicleModelId.Value = p.VehicleModelId;
                    cmd.Parameters.Add(dgVehicleModelId);
                    

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
                cmd.CommandText = "HVInsUpdVehiclesGroups";
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
                vgVehicleModelId.SqlDbType = SqlDbType.VarChar;
                vgVehicleModelId.Value = o.VehicleModelId;
                cmd.Parameters.Add(vgVehicleModelId);

                SqlParameter vgServiceTypeId = new SqlParameter();
                vgServiceTypeId.ParameterName = "@ServiceTypeId";
                vgServiceTypeId.SqlDbType = SqlDbType.VarChar;
                vgServiceTypeId.Value = o.ServiceTypeId;
                cmd.Parameters.Add(vgServiceTypeId);

                SqlParameter vgVehicleGroupId = new SqlParameter();
                vgVehicleGroupId.ParameterName = "@VehicleGroupId";
                vgVehicleGroupId.SqlDbType = SqlDbType.VarChar;
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

        [HttpPost]
        [Route("api/DataLoad/SaveCardsGroup")]
        public HttpResponseMessage SaveCardsGroup(List<CardsGroup> list4)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveVehicleGroups credentials....");

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdCardsGroup";
                cmd.Connection = conn;

                conn.Open();
                foreach (CardsGroup cg in list4)
                {
                    SqlParameter cgCardNumber = new SqlParameter("@CardNumber", SqlDbType.Int);
                    cgCardNumber.Value = cg.CardNumber;
                    cmd.Parameters.Add(cgCardNumber);

                    SqlParameter cgCardModel = new SqlParameter();
                    cgCardModel.ParameterName = "@CardModel";
                    cgCardModel.SqlDbType = SqlDbType.VarChar;
                    cgCardModel.Value = cg.CardModel;
                    cmd.Parameters.Add(cgCardModel);

                    SqlParameter cgCardType = new SqlParameter();
                    cgCardType.ParameterName = "@CardType";
                    cgCardType.SqlDbType = SqlDbType.VarChar;
                    cgCardType.Value = cg.CardType;
                    cmd.Parameters.Add(cgCardType);

                    SqlParameter cgCardCategory = new SqlParameter();
                    cgCardCategory.ParameterName = "@CardCategory";
                    cgCardCategory.SqlDbType = SqlDbType.VarChar;
                    cgCardCategory.Value = cg.CardCategory;
                    cmd.Parameters.Add(cgCardCategory);

                    SqlParameter cgStatusId = new SqlParameter();
                    cgStatusId.ParameterName = "@StatusId";
                    cgStatusId.SqlDbType = SqlDbType.Int;
                    cgStatusId.Value = cg.StatusId;
                    cmd.Parameters.Add(cgStatusId);

                    SqlParameter cgUserId = new SqlParameter();
                    cgUserId.ParameterName = "@UserId";
                    cgUserId.SqlDbType = SqlDbType.Int;
                    cgUserId.Value = cg.UserId;
                    cmd.Parameters.Add(cgUserId);

                    SqlParameter cgCustomer = new SqlParameter();
                    cgCustomer.ParameterName = "@Customer";
                    cgCustomer.SqlDbType = SqlDbType.VarChar;
                    cgCustomer.Value = cg.Customer;
                    cmd.Parameters.Add(cgCustomer);

                    SqlParameter cgEffectiveFrom = new SqlParameter();
                    cgEffectiveFrom.ParameterName = "@EffectiveFrom";
                    cgEffectiveFrom.SqlDbType = SqlDbType.DateTime;
                    cgEffectiveFrom.Value = cg.EffectiveFrom;
                    cmd.Parameters.Add(cgEffectiveFrom);

                    SqlParameter cgEffectiveTo = new SqlParameter();
                    cgEffectiveTo.ParameterName = "@EffectiveTo";
                    cgEffectiveTo.SqlDbType = SqlDbType.DateTime;
                    cgEffectiveTo.Value = cg.EffectiveTo;
                    cmd.Parameters.Add(cgEffectiveTo);

                    SqlParameter insupdflag1 = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag1.Value = cg.insupdflag;
                    cmd.Parameters.Add(insupdflag1);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCardGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCardsGroups:" + ex.Message);
                ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return null;
            }
        }

        [HttpPost]
        [Route("api/DataLoad/SaveDriverVehicleAssignGroup")]
        public HttpResponseMessage SaveDriverVehicleAssignGroup(List<DriverVehicleAssignGroup> list5)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DriverVehicleAssignGroup credentials....");

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DriversVehicleAssignGroup";
                cmd.Connection = conn;

                conn.Open();
                foreach (DriverVehicleAssignGroup dva in list5)
                {
                    SqlParameter dvaCompanyId = new SqlParameter("@CompanyId", SqlDbType.VarChar);
                    dvaCompanyId.Value = dva.CompanyId;
                    cmd.Parameters.Add(dvaCompanyId);

                    SqlParameter dvaName = new SqlParameter();
                    dvaName.ParameterName = "@NAme";
                    dvaName.SqlDbType = SqlDbType.VarChar;
                    dvaName.Value = dva.NAme;
                    cmd.Parameters.Add(dvaName);

                    SqlParameter dvaAddress = new SqlParameter();
                    dvaAddress.ParameterName = "@Address";
                    dvaAddress.SqlDbType = SqlDbType.VarChar;
                    dvaAddress.Value = dva.Address;
                    cmd.Parameters.Add(dvaAddress);

                    SqlParameter dvaCity = new SqlParameter();
                    dvaCity.ParameterName = "@City";
                    dvaCity.SqlDbType = SqlDbType.VarChar;
                    dvaCity.Value = dva.City;
                    cmd.Parameters.Add(dvaCity);

                    SqlParameter dvaPin = new SqlParameter();
                    dvaPin.ParameterName = "@Pin";
                    dvaPin.SqlDbType = SqlDbType.VarChar;
                    dvaPin.Value = dva.Pin;
                    cmd.Parameters.Add(dvaPin);

                    SqlParameter dvaPAddress = new SqlParameter();
                    dvaPAddress.ParameterName = "@PAddress";
                    dvaPAddress.SqlDbType = SqlDbType.VarChar;
                    dvaPAddress.Value = dva.PAddress;
                    cmd.Parameters.Add(dvaPAddress);

                    SqlParameter dvaPCity = new SqlParameter();
                    dvaPCity.ParameterName = "@PCity";
                    dvaPCity.SqlDbType = SqlDbType.VarChar;
                    dvaPCity.Value = dva.PCity;
                    cmd.Parameters.Add(dvaPCity);

                    SqlParameter dvaPPin = new SqlParameter();
                    dvaPPin.ParameterName = "@PPin";
                    dvaPPin.SqlDbType = SqlDbType.VarChar;
                    dvaPPin.Value = dva.PPin;
                    cmd.Parameters.Add(dvaPPin);

                    SqlParameter dvaOffMobileNo = new SqlParameter();
                    dvaOffMobileNo.ParameterName = "@OffMobileNo";
                    dvaOffMobileNo.SqlDbType = SqlDbType.VarChar;
                    dvaOffMobileNo.Value = dva.OffMobileNo;
                    cmd.Parameters.Add(dvaOffMobileNo);

                    SqlParameter dvaMobNo = new SqlParameter();
                    dvaMobNo.ParameterName = "@PMobNo";
                    dvaMobNo.SqlDbType = SqlDbType.VarChar;
                    dvaMobNo.Value = dva.PMobNo;
                    cmd.Parameters.Add(dvaMobNo);

                    SqlParameter dvaDOB = new SqlParameter();
                    dvaDOB.ParameterName = "@DOB";
                    dvaDOB.SqlDbType = SqlDbType.DateTime;
                    dvaDOB.Value = dva.DOB;
                    cmd.Parameters.Add(dvaDOB);

                    SqlParameter dvaDOJ = new SqlParameter();
                    dvaDOJ.ParameterName = "@DOJ";
                    dvaDOJ.SqlDbType = SqlDbType.DateTime;
                    dvaDOJ.Value = dva.DOJ;
                    cmd.Parameters.Add(dvaDOJ);

                    SqlParameter dvaBloodGroup = new SqlParameter();
                    dvaBloodGroup.ParameterName = "@BloodGroup";
                    dvaBloodGroup.SqlDbType = SqlDbType.VarChar;
                    dvaBloodGroup.Value = dva.BloodGroup;
                    cmd.Parameters.Add(dvaBloodGroup);

                    SqlParameter dvaLicenceNo = new SqlParameter();
                    dvaLicenceNo.ParameterName = "@LicenceNo";
                    dvaLicenceNo.SqlDbType = SqlDbType.VarChar;
                    dvaLicenceNo.Value = dva.LicenceNo;
                    cmd.Parameters.Add(dvaLicenceNo);

                    SqlParameter dvaLiCExpDate = new SqlParameter();
                    dvaLiCExpDate.ParameterName = "@LiCExpDate";
                    dvaLiCExpDate.SqlDbType = SqlDbType.DateTime;
                    dvaLiCExpDate.Value = dva.LiCExpDate;
                    cmd.Parameters.Add(dvaLiCExpDate);

                    SqlParameter dvaBadgeNo = new SqlParameter();
                    dvaBadgeNo.ParameterName = "@BadgeNo";
                    dvaBadgeNo.SqlDbType = SqlDbType.VarChar;
                    dvaBadgeNo.Value = dva.BadgeNo;
                    cmd.Parameters.Add(dvaBadgeNo);

                    SqlParameter dvaBadgeExpDate = new SqlParameter();
                    dvaBadgeExpDate.ParameterName = "@BadgeExpDate";
                    dvaBadgeExpDate.SqlDbType = SqlDbType.DateTime;
                    dvaBadgeExpDate.Value = dva.BadgeExpDate;
                    cmd.Parameters.Add(dvaBadgeExpDate);

                    SqlParameter dvaRemarks = new SqlParameter();
                    dvaRemarks.ParameterName = "@Remarks";
                    dvaRemarks.SqlDbType = SqlDbType.VarChar;
                    dvaRemarks.Value = dva.Remarks;
                    cmd.Parameters.Add(dvaRemarks);


                    //Vehicle Table
                    SqlParameter dvaVID = new SqlParameter();
                    dvaVID.ParameterName = "@VID";
                    dvaVID.SqlDbType = SqlDbType.Int;
                    dvaVID.Value = dva.VID;
                    cmd.Parameters.Add(dvaVID);

                    SqlParameter dvaRegistrationNo = new SqlParameter();
                    dvaRegistrationNo.ParameterName = "@RegistrationNo";
                    dvaRegistrationNo.SqlDbType = SqlDbType.NVarChar;
                    dvaRegistrationNo.Value = dva.RegistrationNo;
                    cmd.Parameters.Add(dvaRegistrationNo);

                    SqlParameter dvaType = new SqlParameter();
                    dvaType.ParameterName = "@Type";
                    dvaType.SqlDbType = SqlDbType.NVarChar;
                    dvaType.Value = dva.Type;
                    cmd.Parameters.Add(dvaType);

                    SqlParameter dvaOwnerName = new SqlParameter();
                    dvaOwnerName.ParameterName = "@OwnerName";
                    dvaOwnerName.SqlDbType = SqlDbType.NVarChar;
                    dvaOwnerName.Value = dva.OwnerName;
                    cmd.Parameters.Add(dvaOwnerName);

                    SqlParameter dvaChasisNo = new SqlParameter();
                    dvaChasisNo.ParameterName = "@ChasisNo";
                    dvaChasisNo.SqlDbType = SqlDbType.NVarChar;
                    dvaChasisNo.Value = dva.ChasisNo;
                    cmd.Parameters.Add(dvaChasisNo);

                    SqlParameter dvaEngineno = new SqlParameter();
                    dvaEngineno.ParameterName = "@Engineno";
                    dvaEngineno.SqlDbType = SqlDbType.NVarChar;
                    dvaEngineno.Value = dva.Engineno;
                    cmd.Parameters.Add(dvaEngineno);

                    SqlParameter dvaRoadTaxDate = new SqlParameter();
                    dvaRoadTaxDate.ParameterName = "@RoadTaxDate";
                    dvaRoadTaxDate.SqlDbType = SqlDbType.DateTime;
                    dvaRoadTaxDate.Value = dva.RoadTaxDate;
                    cmd.Parameters.Add(dvaRoadTaxDate);

                    SqlParameter dvaInsuranceNo = new SqlParameter();
                    dvaInsuranceNo.ParameterName = "@InsuranceNo";
                    dvaInsuranceNo.SqlDbType = SqlDbType.NVarChar;
                    dvaInsuranceNo.Value = dva.InsuranceNo;
                    cmd.Parameters.Add(dvaInsuranceNo);

                    SqlParameter dvaInsDate = new SqlParameter();
                    dvaInsDate.ParameterName = "@InsDate";
                    dvaInsDate.SqlDbType = SqlDbType.DateTime;
                    dvaInsDate.Value = dva.InsDate;
                    cmd.Parameters.Add(dvaInsDate);

                    SqlParameter dvaPolutionNo = new SqlParameter();
                    dvaPolutionNo.ParameterName = "@PolutionNo";
                    dvaPolutionNo.SqlDbType = SqlDbType.NVarChar;
                    dvaPolutionNo.Value = dva.PolutionNo;
                    cmd.Parameters.Add(dvaPolutionNo);

                    SqlParameter dvaPolExpDate = new SqlParameter();
                    dvaPolExpDate.ParameterName = "@PolExpDate";
                    dvaPolExpDate.SqlDbType = SqlDbType.DateTime;
                    dvaPolExpDate.Value = dva.PolExpDate;
                    cmd.Parameters.Add(dvaPolExpDate);

                    SqlParameter dvaRCBookNo = new SqlParameter();
                    dvaRCBookNo.ParameterName = "@RCBookNo";
                    dvaRCBookNo.SqlDbType = SqlDbType.NVarChar;
                    dvaRCBookNo.Value = dva.RCBookNo;
                    cmd.Parameters.Add(dvaRCBookNo);

                    SqlParameter dvaRCExpDate = new SqlParameter();
                    dvaRCExpDate.ParameterName = "@RCExpDate";
                    dvaRCExpDate.SqlDbType = SqlDbType.DateTime;
                    dvaRCExpDate.Value = dva.RCExpDate;
                    cmd.Parameters.Add(dvaRCExpDate);

                    SqlParameter dvaCompanyVechile = new SqlParameter();
                    dvaCompanyVechile.ParameterName = "@CompanyVechile";
                    dvaCompanyVechile.SqlDbType = SqlDbType.Int;
                    dvaCompanyVechile.Value = dva.CompanyVechile;
                    cmd.Parameters.Add(dvaCompanyVechile);

                    SqlParameter dvaOwnerPhoneNo = new SqlParameter();
                    dvaOwnerPhoneNo.ParameterName = "@OwnerPhoneNo";
                    dvaOwnerPhoneNo.SqlDbType = SqlDbType.NVarChar;
                    dvaOwnerPhoneNo.Value = dva.OwnerPhoneNo;
                    cmd.Parameters.Add(dvaOwnerPhoneNo);

                    SqlParameter dvaHomeLandmark = new SqlParameter();
                    dvaHomeLandmark.ParameterName = "@HomeLandmark";
                    dvaHomeLandmark.SqlDbType = SqlDbType.NVarChar;
                    dvaHomeLandmark.Value = dva.HomeLandmark;
                    cmd.Parameters.Add(dvaHomeLandmark);

                    SqlParameter dvaModelYear = new SqlParameter();
                    dvaModelYear.ParameterName = "@ModelYear";
                    dvaModelYear.SqlDbType = SqlDbType.NVarChar;
                    dvaModelYear.Value = dva.ModelYear;
                    cmd.Parameters.Add(dvaModelYear);

                    SqlParameter dvaDayOnly = new SqlParameter();
                    dvaDayOnly.ParameterName = "@DayOnly";
                    dvaDayOnly.SqlDbType = SqlDbType.NVarChar;
                    dvaDayOnly.Value = dva.DayOnly;
                    cmd.Parameters.Add(dvaDayOnly);

                    SqlParameter dvaVechMobileNo = new SqlParameter();
                    dvaVechMobileNo.ParameterName = "@VechMobileNo";
                    dvaVechMobileNo.SqlDbType = SqlDbType.NVarChar;
                    dvaVechMobileNo.Value = dva.VechMobileNo;
                    cmd.Parameters.Add(dvaVechMobileNo);

                    SqlParameter dvaEntryDate = new SqlParameter();
                    dvaEntryDate.ParameterName = "@EntryDate";
                    dvaEntryDate.SqlDbType = SqlDbType.DateTime;
                    dvaEntryDate.Value = dva.EntryDate;
                    cmd.Parameters.Add(dvaEntryDate);

                    SqlParameter dvaNewEntry = new SqlParameter();
                    dvaNewEntry.ParameterName = "@NewEntry";
                    dvaNewEntry.SqlDbType = SqlDbType.NVarChar;
                    dvaNewEntry.Value = dva.NewEntry;
                    cmd.Parameters.Add(dvaNewEntry);

                    SqlParameter dvaVehicleModelId = new SqlParameter();
                    dvaVehicleModelId.ParameterName = "@VehicleModelId";
                    dvaVehicleModelId.SqlDbType = SqlDbType.VarChar;
                    dvaVehicleModelId.Value = dva.VehicleModelId;
                    cmd.Parameters.Add(dvaVehicleModelId);

                    SqlParameter dvaServiceTypeId = new SqlParameter();
                    dvaServiceTypeId.ParameterName = "@ServiceTypeId";
                    dvaServiceTypeId.SqlDbType = SqlDbType.VarChar;
                    dvaServiceTypeId.Value = dva.ServiceTypeId;
                    cmd.Parameters.Add(dvaServiceTypeId);

                    SqlParameter dvaVehicleGroupId = new SqlParameter();
                    dvaVehicleGroupId.ParameterName = "@VehicleGroupId";
                    dvaVehicleGroupId.SqlDbType = SqlDbType.VarChar;
                    dvaVehicleGroupId.Value = dva.VehicleGroupId;
                    cmd.Parameters.Add(dvaVehicleGroupId);

                    //Assign Table

                    SqlParameter dvaBookingNo = new SqlParameter();
                    dvaBookingNo.ParameterName = "@BookingNo";
                    dvaBookingNo.SqlDbType = SqlDbType.Int;
                    dvaBookingNo.Value = dva.BookingNo;
                    cmd.Parameters.Add(dvaBookingNo);

                    SqlParameter dvaReqDate = new SqlParameter();
                    dvaReqDate.ParameterName = "@ReqDate";
                    dvaReqDate.SqlDbType = SqlDbType.DateTime;
                    dvaReqDate.Value = dva.ReqDate;
                    cmd.Parameters.Add(dvaReqDate);

                    SqlParameter dvaReqTime = new SqlParameter();
                    dvaReqTime.ParameterName = "@ReqTime";
                    dvaReqTime.SqlDbType = SqlDbType.DateTime;
                    dvaReqTime.Value = dva.ReqTime;
                    cmd.Parameters.Add(dvaReqTime);

                    SqlParameter dvaCallTime = new SqlParameter();
                    dvaCallTime.ParameterName = "@CallTime";
                    dvaCallTime.SqlDbType = SqlDbType.DateTime;
                    dvaCallTime.Value = dva.CallTime;
                    cmd.Parameters.Add(dvaCallTime);

                    SqlParameter dvaCustomerName = new SqlParameter();
                    dvaCustomerName.ParameterName = "@CustomerName";
                    dvaCustomerName.SqlDbType = SqlDbType.NVarChar;
                    dvaCustomerName.Value = dva.CustomerName;
                    cmd.Parameters.Add(dvaCustomerName);

                    SqlParameter dvaCusID = new SqlParameter();
                    dvaCusID.ParameterName = "@CusID";
                    dvaCusID.SqlDbType = SqlDbType.NVarChar;
                    dvaCusID.Value = dva.CusID;
                    cmd.Parameters.Add(dvaCusID);

                    SqlParameter dvaPhoneNo = new SqlParameter();
                    dvaPhoneNo.ParameterName = "@PhoneNo";
                    dvaPhoneNo.SqlDbType = SqlDbType.NVarChar;
                    dvaPhoneNo.Value = dva.PhoneNo;
                    cmd.Parameters.Add(dvaPhoneNo);

                    SqlParameter dvaAltPhoneNo = new SqlParameter();
                    dvaAltPhoneNo.ParameterName = "@AltPhoneNo";
                    dvaAltPhoneNo.SqlDbType = SqlDbType.NVarChar;
                    dvaAltPhoneNo.Value = dva.AltPhoneNo;
                    cmd.Parameters.Add(dvaAltPhoneNo);

                    SqlParameter dvaPickupAddress = new SqlParameter();
                    dvaPickupAddress.ParameterName = "@PickupAddress";
                    dvaPickupAddress.SqlDbType = SqlDbType.NVarChar;
                    dvaPickupAddress.Value = dva.PickupAddress;
                    cmd.Parameters.Add(dvaPickupAddress);

                    SqlParameter dvaLandMark = new SqlParameter();
                    dvaLandMark.ParameterName = "@LandMark";
                    dvaLandMark.SqlDbType = SqlDbType.NVarChar;
                    dvaLandMark.Value = dva.LandMark;
                    cmd.Parameters.Add(dvaLandMark);

                    SqlParameter dvaPickupPlace = new SqlParameter();
                    dvaPickupPlace.ParameterName = "@PickupPlace";
                    dvaPickupPlace.SqlDbType = SqlDbType.NVarChar;
                    dvaPickupPlace.Value = dva.PickupPlace;
                    cmd.Parameters.Add(dvaPickupPlace);

                    SqlParameter dvaDropPlace = new SqlParameter();
                    dvaDropPlace.ParameterName = "@DropPlace";
                    dvaDropPlace.SqlDbType = SqlDbType.NVarChar;
                    dvaDropPlace.Value = dva.DropPlace;
                    cmd.Parameters.Add(dvaDropPlace);

                    SqlParameter dvaPackage = new SqlParameter();
                    dvaPackage.ParameterName = "@Package";
                    dvaPackage.SqlDbType = SqlDbType.NVarChar;
                    dvaPackage.Value = dva.Package;
                    cmd.Parameters.Add(dvaPackage);

                    SqlParameter dvaVehicleType = new SqlParameter();
                    dvaVehicleType.ParameterName = "@VehicleType";
                    dvaVehicleType.SqlDbType = SqlDbType.NVarChar;
                    dvaVehicleType.Value = dva.VehicleType;
                    cmd.Parameters.Add(dvaVehicleType);

                    SqlParameter dvaNoofVehicle = new SqlParameter();
                    dvaNoofVehicle.ParameterName = "@NoofVehicle";
                    dvaNoofVehicle.SqlDbType = SqlDbType.Int;
                    dvaNoofVehicle.Value = dva.NoofVehicle;
                    cmd.Parameters.Add(dvaNoofVehicle);

                    SqlParameter dvaVechID = new SqlParameter();
                    dvaVechID.ParameterName = "@VechID";
                    dvaVechID.SqlDbType = SqlDbType.Int;
                    dvaVechID.Value = dva.VechID;
                    cmd.Parameters.Add(dvaVechID);

                    SqlParameter dvaDriverName = new SqlParameter();
                    dvaDriverName.ParameterName = "@DriverName";
                    dvaDriverName.SqlDbType = SqlDbType.NVarChar;
                    dvaDriverName.Value = dva.DriverName;
                    cmd.Parameters.Add(dvaDriverName);

                    SqlParameter dvaPresentDriverLandMark = new SqlParameter();
                    dvaPresentDriverLandMark.ParameterName = "@PresentDriverLandMark";
                    dvaPresentDriverLandMark.SqlDbType = SqlDbType.NVarChar;
                    dvaPresentDriverLandMark.Value = dva.PresentDriverLandMark;
                    cmd.Parameters.Add(dvaPresentDriverLandMark);

                    SqlParameter dvaExecutiveName = new SqlParameter();
                    dvaExecutiveName.ParameterName = "@ExecutiveName";
                    dvaExecutiveName.SqlDbType = SqlDbType.NVarChar;
                    dvaExecutiveName.Value = dva.ExecutiveName;
                    cmd.Parameters.Add(dvaExecutiveName);

                    SqlParameter dvaEffectiveDate = new SqlParameter();
                    dvaEffectiveDate.ParameterName = "@EffectiveDate";
                    dvaEffectiveDate.SqlDbType = SqlDbType.DateTime;
                    dvaEffectiveDate.Value = dva.EffectiveDate;
                    cmd.Parameters.Add(dvaEffectiveDate);

                    SqlParameter dvaEffectiveTill = new SqlParameter();
                    dvaEffectiveTill.ParameterName = "@EffectiveTill";
                    dvaEffectiveTill.SqlDbType = SqlDbType.DateTime;
                    dvaEffectiveTill.Value = dva.EffectiveTill;
                    cmd.Parameters.Add(dvaEffectiveTill);

                    SqlParameter dvaDriverId = new SqlParameter();
                    dvaDriverId.ParameterName = "@DriverId";
                    dvaDriverId.SqlDbType = SqlDbType.Int;
                    dvaDriverId.Value = dva.DriverId;
                    cmd.Parameters.Add(dvaDriverId);

                    SqlParameter dvaflag = new SqlParameter("@flag", SqlDbType.VarChar);
                    dvaflag.Value = dva.inspudflag;
                    cmd.Parameters.Add(dvaflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DriverVehicleAssignGroup Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str2 = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriverVehicleAssignGroup:" + ex.Message);
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return null;

            }
        }
    }
}
