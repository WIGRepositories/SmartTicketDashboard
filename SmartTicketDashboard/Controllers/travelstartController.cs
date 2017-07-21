using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;
using System.Configuration;

namespace SmartTicketDashboard.Controllers
{
    public class travelstartController : ApiController
    {
        [HttpPost]
        [Route("api/travelstart/travel")]

        public DataTable travel(travels l)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdtravelling";
            cmd.Connection = conn;

            SqlParameter ui = new SqlParameter("@flag", SqlDbType.VarChar);
            ui.Value = l.flag;
            cmd.Parameters.Add(ui);

            SqlParameter u = new SqlParameter("@SlNo", SqlDbType.Int);
            u.Value = l.SlNo;
            cmd.Parameters.Add(u);



            SqlParameter y = new SqlParameter("@VechID", SqlDbType.Int);
            y.Value = l.VechID;
            cmd.Parameters.Add(y);

            SqlParameter rg = new SqlParameter("@RegistrationNo", SqlDbType.VarChar, 255);
            rg.Value = l.RegistrationNo;
            cmd.Parameters.Add(rg);

            SqlParameter hg = new SqlParameter("@DriverName", SqlDbType.VarChar, 255);
            hg.Value = l.DriverName;
            cmd.Parameters.Add(hg);

            SqlParameter h = new SqlParameter("@PartyName", SqlDbType.VarChar, 255);
            h.Value = l.PartyName;
            cmd.Parameters.Add(h);

            SqlParameter pp = new SqlParameter("@PickupPlace", SqlDbType.VarChar, 255);
            pp.Value = l.PickupPlace;
            cmd.Parameters.Add(pp);

            SqlParameter d = new SqlParameter("@DropPlace", SqlDbType.VarChar, 255);
            d.Value = l.DropPlace;
            cmd.Parameters.Add(d);

            SqlParameter s = new SqlParameter("@StartMeter", SqlDbType.Int);
            s.Value = l.StartMeter;
            cmd.Parameters.Add(s);



            SqlParameter t = new SqlParameter("@ExecutiveName", SqlDbType.VarChar, 255);
            t.Value = l.ExecutiveName;
            cmd.Parameters.Add(t);

            SqlParameter ef = new SqlParameter("@BookingNo", SqlDbType.Decimal);
            ef.Value = l.BookingNo;
            cmd.Parameters.Add(ef);


            SqlParameter c = new SqlParameter("@CloseStatus", SqlDbType.VarChar, 255);
            c.Value = l.CloseStatus;
            cmd.Parameters.Add(c);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
