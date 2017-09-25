using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class DriverMasterController : ApiController
    {
       
        [HttpGet]
        [Route("api/DriverMaster/GetMaster")]
        public DataTable GetMaster(int DId)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetdrivermaster";
            cmd.Parameters.Add("@DId", SqlDbType.Int).Value = DId;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/DriverMaster/Getdriverdetails")]
        public DataTable Getdriverdetails(int DId)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetdriverdetails";
            cmd.Parameters.Add("@DId", SqlDbType.Int).Value = DId;
            cmd.Connection = conn;
            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);           

            return dt;

        }

        [HttpPost]
        [Route("api/DriverMaster/Driverlist")]
        public DataTable Driverlist(driverdetails d)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpddrivers";
            cmd.Connection = conn;

            SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
            ff.Value = d.flag;
            cmd.Parameters.Add(ff);

            SqlParameter i = new SqlParameter("@DId", SqlDbType.Int);
            i.Value = d.DId;
            cmd.Parameters.Add(i);

            SqlParameter di = new SqlParameter("@CompanyId", SqlDbType.Int);
            di.Value = d.CompanyId;
            cmd.Parameters.Add(di);

            SqlParameter n = new SqlParameter("@NAme", SqlDbType.VarChar, 50);
            n.Value = d.Name;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            r.Value = d.Address;
            cmd.Parameters.Add(r);



            SqlParameter a = new SqlParameter("@City", SqlDbType.VarChar, 50);
            a.Value = d.City;
            cmd.Parameters.Add(a);

            SqlParameter s = new SqlParameter("@Pin", SqlDbType.VarChar, 50);
            s.Value = d.Pin;
            cmd.Parameters.Add(s);

            SqlParameter f = new SqlParameter("@PAddress", SqlDbType.VarChar, 50);
            f.Value = d.PAddress;
            cmd.Parameters.Add(f);

            SqlParameter j2 = new SqlParameter("@PCity", SqlDbType.VarChar, 255);
            j2.Value = d.PCity;
            cmd.Parameters.Add(j2);

            SqlParameter g = new SqlParameter("@PPin", SqlDbType.VarChar, 50);
            g.Value = d.PPin;
            cmd.Parameters.Add(g);

            SqlParameter h = new SqlParameter("@OffMobileNo", SqlDbType.Float);
            h.Value = d.OffMobileNo;
            cmd.Parameters.Add(h);

            SqlParameter j = new SqlParameter("@PMobNo", SqlDbType.VarChar, 255);
            j.Value = d.PMobNo;
            cmd.Parameters.Add(j);

            SqlParameter k = new SqlParameter("@DOB", SqlDbType.Date);
            k.Value = d.DOB;
            cmd.Parameters.Add(k);

            SqlParameter y = new SqlParameter("@DOJ", SqlDbType.Date);
            y.Value = d.DOJ;
            cmd.Parameters.Add(y);

            SqlParameter rj = new SqlParameter("@BloodGroup", SqlDbType.VarChar, 50);
            rj.Value = d.BloodGroup;
            cmd.Parameters.Add(rj);            

            SqlParameter w = new SqlParameter("@Remarks", SqlDbType.VarChar, 50);
            w.Value = d.Remarks;
            cmd.Parameters.Add(w);           

            SqlParameter pr = new SqlParameter("@Photo", SqlDbType.VarChar);
            pr.Value = d.Photo;
            cmd.Parameters.Add(pr);            


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/DriverMaster/SaveDriverDoc")]
        public DataSet SaveDriverDoc(DriverDocuments a)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelDriverDocs";
                cmd.Connection = conn;

                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = a.Id;
                cmd.Parameters.Add(id);

                SqlParameter AssetId = new SqlParameter("@DriverId", SqlDbType.Int);
                AssetId.Value = a.DriverId;
                cmd.Parameters.Add(AssetId);

                SqlParameter Gid = new SqlParameter("@FileName", SqlDbType.VarChar, 100);
                Gid.Value = a.docName;
                cmd.Parameters.Add(Gid);

                SqlParameter rootassetid = new SqlParameter("@DocTypeId", SqlDbType.Int);
                rootassetid.Value = a.docTypeId;
                cmd.Parameters.Add(rootassetid);

                SqlParameter AsstMDLHierarID = new SqlParameter("@UpdatedById", SqlDbType.Int);
                AsstMDLHierarID.Value = a.UpdatedById;
                cmd.Parameters.Add(AsstMDLHierarID);

                SqlParameter assetModelId = new SqlParameter("@ExpiryDate", SqlDbType.Date);
                assetModelId.Value = a.expiryDate;
                cmd.Parameters.Add(assetModelId);


                SqlParameter LocationId = new SqlParameter("@DueDate", SqlDbType.Date);
                LocationId.Value = a.dueDate;
                cmd.Parameters.Add(LocationId);

                SqlParameter parentid = new SqlParameter("@FileContent", SqlDbType.VarChar);
                parentid.Value = a.docContent;
                cmd.Parameters.Add(parentid);

                SqlParameter flag = new SqlParameter("@change", SqlDbType.VarChar);
                flag.Value = a.insupddelflag;
                cmd.Parameters.Add(flag);

                SqlParameter loggedinUserId1 = new SqlParameter("@loggedinUserId", SqlDbType.Int);
                loggedinUserId1.Value = a.UpdatedById;
                cmd.Parameters.Add(loggedinUserId1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


                return ds;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                return ds;
            }
        }
    }
}
