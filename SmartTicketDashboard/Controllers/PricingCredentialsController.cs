using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SmartTicketDashboard.Controllers
{
    public class PricingCredentialsController : ApiController
    {
        [HttpGet]
        [Route("api/PricingCredentials/AllPricingDetails")]

        public DataTable GetAllPrices()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPricingCredentials";
            cmd.Connection = conn;

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/PricingCredentials/AddEditPricing")]
        public int AddEditPricing(PricingCredentials p)
        {
            int status = 0;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelPricingCredentials";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = p.flag;
                cmd.Parameters.Add(f);

                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = p.Id;
                cmd.Parameters.Add(id);

                SqlParameter pc = new SqlParameter("@PriceCode", SqlDbType.VarChar, 150);
                pc.Value = p.PriceCode;
                cmd.Parameters.Add(pc);

                SqlParameter pt = new SqlParameter("@PriceType", SqlDbType.Int);
                pt.Value = p.PriceType;
                cmd.Parameters.Add(pt);

                SqlParameter up = new SqlParameter("@UnitPrice", SqlDbType.Float);
                up.Value = p.UnitPrice;
                cmd.Parameters.Add(up);

                SqlParameter vg = new SqlParameter("@VehicleGroup", SqlDbType.Int);
                vg.Value = p.VehicleGroup;
                cmd.Parameters.Add(vg);

                SqlParameter vm = new SqlParameter("@VehicleModel", SqlDbType.Int);
                vm.Value = p.VehicleModel;
                cmd.Parameters.Add(vm);

                SqlParameter vt = new SqlParameter("@VehicleType", SqlDbType.Int);
                vt.Value = p.VehicleType;
                cmd.Parameters.Add(vt);

                SqlParameter pkgt = new SqlParameter("@PackageType", SqlDbType.Int);
                pkgt.Value = p.PackageType;
                cmd.Parameters.Add(pkgt);

                SqlParameter fd = new SqlParameter("@FromDate", SqlDbType.Date);
                fd.Value = p.FromDate;
                cmd.Parameters.Add(fd);

                SqlParameter td = new SqlParameter("@ToDate", SqlDbType.Date);
                td.Value = p.ToDate;
                cmd.Parameters.Add(td);

                conn.Open();
                status = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
               
                throw ex;
            }
            return status;
        }

    }
}
