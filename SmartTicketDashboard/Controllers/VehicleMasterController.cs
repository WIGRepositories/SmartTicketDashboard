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
    public class VehicleMasterController : ApiController
    {
        [HttpGet]

        [Route("api/VehicleMaster/GetVehcileMaster")]
        public DataTable GetVehcileMaster(int VID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSgetvehilcetypes";
            cmd.Parameters.Add("@VID", SqlDbType.Int).Value = VID;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]

        [Route("api/VehicleMaster/GetVehcileDetails")]
        public DataTable GetVehcileDetails(int VID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSgetvehilcedetails";
            cmd.Parameters.Add("@VID", SqlDbType.Int).Value = VID;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }
        [HttpPost]
        [Route("api/VehicleMaster/Vehicles")]

        public DataTable Vehicles(vehiclemas v)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdVehicles";
            cmd.Connection = conn;


            SqlParameter se = new SqlParameter("@flag", SqlDbType.VarChar);
            se.Value = v.flag;
            cmd.Parameters.Add(se);


            SqlParameter s = new SqlParameter("@Id", SqlDbType.Int);
            s.Value = v.Id;
            cmd.Parameters.Add(s);

            SqlParameter i = new SqlParameter("@VID", SqlDbType.Int);
            i.Value = v.VID;
            cmd.Parameters.Add(i);

            SqlParameter cd = new SqlParameter("@CompanyId", SqlDbType.Int);
            cd.Value = v.CompanyId;
            cmd.Parameters.Add(cd);

            SqlParameter n = new SqlParameter("@RegistrationNo", SqlDbType.VarChar, 50);
            n.Value = v.RegistrationNo;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            r.Value = v.Type;
            cmd.Parameters.Add(r);

            SqlParameter a = new SqlParameter("@OwnerName", SqlDbType.VarChar, 50);
            a.Value = v.OwnerName;
            cmd.Parameters.Add(a);           

            SqlParameter jw = new SqlParameter("@CompanyVechile", SqlDbType.Int);
            jw.Value = v.CompanyVechile;
            cmd.Parameters.Add(jw);

            SqlParameter wj = new SqlParameter("@OwnerPhoneNo", SqlDbType.VarChar, 50);
            wj.Value = v.OwnerPhoneNo;
            cmd.Parameters.Add(wj);

            SqlParameter wh = new SqlParameter("@HomeLandmark", SqlDbType.VarChar, 50);
            wh.Value = v.HomeLandmark;
            cmd.Parameters.Add(wh);

            SqlParameter wg = new SqlParameter("@ModelYear", SqlDbType.VarChar);
            wg.Value = v.ModelYear;
            cmd.Parameters.Add(wg);

            SqlParameter wf = new SqlParameter("@DayOnly", SqlDbType.VarChar, 50);
            wf.Value = v.DayOnly;
            cmd.Parameters.Add(wf);            

            SqlParameter ca = new SqlParameter("@VechMobileNo", SqlDbType.VarChar, 50);
            ca.Value = v.VechMobileNo;
            cmd.Parameters.Add(ca);

            SqlParameter ws = new SqlParameter("@EntryDate", System.Data.SqlDbType.Date);
            ws.Value = v.EntryDate;
            cmd.Parameters.Add(ws);

            SqlParameter wsd = new SqlParameter("@NewEntry", SqlDbType.VarChar, 50);
            wsd.Value = v.NewEntry;
            cmd.Parameters.Add(wsd);

            SqlParameter vv = new SqlParameter("@VehicleModelId", SqlDbType.Int);
            vv.Value = v.VehicleModelId;
            cmd.Parameters.Add(vv);

            SqlParameter vf = new SqlParameter("@ServiceTypeId", SqlDbType.Int);
            vf.Value = v.ServiceTypeId;
            cmd.Parameters.Add(vf);

            SqlParameter vg = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vg.Value = v.VehicleGroupId;
            cmd.Parameters.Add(vg);

            SqlParameter pp = new SqlParameter("@Photo", SqlDbType.VarChar);
            pp.Value = v.photo;
            cmd.Parameters.Add(pp);

            SqlParameter ss = new SqlParameter("@Status", SqlDbType.VarChar);
            ss.Value = v.photo;
            cmd.Parameters.Add(ss);

            SqlParameter fl = new SqlParameter("@FleetOwnerCode", SqlDbType.VarChar);
            fl.Value = v.Fleetcode;
            cmd.Parameters.Add(fl);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/VehicleMaster/SaveVehicleDoc")]
        public DataSet SaveVehicleDoc(VehicleDocuments a)
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
                cmd.CommandText = "InsUpdDelVehicleDocs";
                cmd.Connection = conn;

                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = a.Id;
                cmd.Parameters.Add(id);

                SqlParameter AssetId = new SqlParameter("@VehicleId", SqlDbType.Int);
                AssetId.Value = a.VehicleId;
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
