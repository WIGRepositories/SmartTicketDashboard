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

            SqlParameter sn = new SqlParameter("@ChasisNo", SqlDbType.VarChar, 50);
            sn.Value = v.ChasisNo;
            cmd.Parameters.Add(sn);

            SqlParameter f = new SqlParameter("@Engineno", SqlDbType.VarChar, 50);
            f.Value = v.Engineno;
            cmd.Parameters.Add(f);
                  

            SqlParameter k = new SqlParameter("@RoadTaxDate", System.Data.SqlDbType.Date);
            k.Value = v.RoadTaxDate;
            cmd.Parameters.Add(k);

            SqlParameter y = new SqlParameter("@InsuranceNo", SqlDbType.VarChar, 50);
            y.Value = v.InsuranceNo;
            cmd.Parameters.Add(y);

            SqlParameter r1 = new SqlParameter("@InsDate", System.Data.SqlDbType.Date);
            r1.Value = v.InsDate;
            cmd.Parameters.Add(r1);

            SqlParameter t = new SqlParameter("@PolutionNo", SqlDbType.VarChar, 50);
            t.Value = v.PolutionNo;
            cmd.Parameters.Add(t);

            SqlParameter u = new SqlParameter("@PolExpDate", System.Data.SqlDbType.Date);
            u.Value = v.PolExpDate;
            cmd.Parameters.Add(u);

            SqlParameter o = new SqlParameter("@RCBookNo", SqlDbType.VarChar, 50);
            o.Value = v.RCBookNo;
            cmd.Parameters.Add(o);

            SqlParameter p = new SqlParameter("@RCExpDate", System.Data.SqlDbType.Date);
            p.Value = v.RCExpDate;
            cmd.Parameters.Add(p);

            SqlParameter jw = new SqlParameter("@CompanyVechile", SqlDbType.Int);
            jw.Value = v.CompanyVechile;
            cmd.Parameters.Add(jw);

            SqlParameter wj = new SqlParameter("@OwnerPhoneNo", SqlDbType.VarChar, 50);
            wj.Value = v.OwnerPhoneNo;
            cmd.Parameters.Add(wj);

            SqlParameter wh = new SqlParameter("@HomeLandmark", SqlDbType.VarChar, 50);
            wh.Value = v.HomeLandmark;
            cmd.Parameters.Add(wh);

            SqlParameter wg = new SqlParameter("@ModelYear", System.Data.SqlDbType.Date);
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


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
