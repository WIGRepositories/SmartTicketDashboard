using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace SmartTicketDashboard.Controllers
{
    public class TrackingController : ApiController
    {
        [HttpGet]
        [Route("api/Tracking/GetLatLongHistory")]
        public DataTable GetLatLongHistory()
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "GetLatLongHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter m = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 50);
            //m.Value = ocr.Mobilenumber;
            //cmd.Parameters.Add(m);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Tbl);

            return Tbl;
        }

        //[HttpGet]
        //[Route("api/Tracking/GetVehicleLocation")]
        //public DataTable GetVehicleLocation(int VehicleGroupId)
        //{
        //    DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString(); ;

        //    SqlCommand cmd = new SqlCommand();


        //    cmd.CommandText = "PSVehicleGroup";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@VehicleGroupId", SqlDbType.Int).Value = VehicleGroupId;
        //    cmd.Connection = conn;

        //    //cmd.CommandType = CommandType.StoredProcedure;



        //    //SqlParameter m = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 50);
        //    //m.Value = ocr.Mobilenumber;
        //    //cmd.Parameters.Add(m);

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(Tbl);

        //    return Tbl;
        //}
    }
}
