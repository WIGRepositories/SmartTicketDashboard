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
    public class VehiclePricingController : ApiController
    {


        [HttpGet]
        [Route("api/VehiclePricing/GetVehiclePrices")]

        public DataTable GetVehiclePrices()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTariff";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);           

            return dt;
        }

        [HttpPost]
        [Route("api/VehiclePricing/VehiclePrices")]

        public DataTable Vehicles(Pricing m)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdDelTariff";
            cmd.Connection = conn;

            

            SqlParameter s = new SqlParameter("@SrNo", SqlDbType.Int);
            s.Value = m.SrNo;
            cmd.Parameters.Add(s);


            SqlParameter i = new SqlParameter("@Duration", SqlDbType.Int);
            i.Value = m.Duration;
            cmd.Parameters.Add(i);

            SqlParameter n = new SqlParameter("@KiloMtr", SqlDbType.Int);
            n.Value = m.KiloMtr;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@IndicaRate", SqlDbType.Int);
            r.Value = m.IndicaRate;
            cmd.Parameters.Add(r);



            SqlParameter a = new SqlParameter("@IndigoRate", SqlDbType.Int);
            a.Value = m.IndigoRate;
            cmd.Parameters.Add(a);

            SqlParameter sn = new SqlParameter("@InnovaRate", SqlDbType.Int);
            sn.Value = m.InnovaRate;
            cmd.Parameters.Add(sn);

            SqlParameter f = new SqlParameter("@Tag", SqlDbType.VarChar,255);
            f.Value = m.Tag;
            cmd.Parameters.Add(f);

          

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
