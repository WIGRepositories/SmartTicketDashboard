using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class CancelBookingController : ApiController
    {
        [HttpPost]

        [Route("api/CancelBooking/cncelbkng")]
        public DataTable cncelbkng(cancel c)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVcancelbooking";

            SqlParameter i = new SqlParameter("@BNo", SqlDbType.Int);
            i.Value = c.BNo;
            cmd.Parameters.Add(i);

            SqlParameter n = new SqlParameter("@BookingStatus", SqlDbType.VarChar, 255);
            n.Value = c.BookingStatus;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@CancelReason", SqlDbType.VarChar, 255);
            r.Value = c.CancelReason;
            cmd.Parameters.Add(r);


            SqlParameter a = new SqlParameter("@CancelBy", SqlDbType.VarChar, 255);
            a.Value = c.CancelBy;
            cmd.Parameters.Add(a);

            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }
    }
}
