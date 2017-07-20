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
    public class ClosingReportController : ApiController
    {
        [HttpGet]

        [Route("api/ClosingReport/getClosingReport")]
        public DataTable getClosingReport(int SlNo)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getClosingReport";
            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = SlNo;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpPost]
        [Route("api/ClosingReport/closereport")]

        public DataTable closereport(close d)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpDelClosingReport";
            cmd.Connection = conn;


            SqlParameter n = new SqlParameter("@SlNo", SqlDbType.VarChar, 50);
            n.Value = d.SlNo;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@EntryDate", SqlDbType.VarChar, 50);
            r.Value = d.EntryDate;
            cmd.Parameters.Add(r);



            SqlParameter a = new SqlParameter("@VechID", SqlDbType.VarChar, 50);
            a.Value = d.VechID;
            cmd.Parameters.Add(a);

            SqlParameter s = new SqlParameter("@RegistrationNo", SqlDbType.VarChar, 50);
            s.Value = d.RegistrationNo;
            cmd.Parameters.Add(s);

            SqlParameter f = new SqlParameter("@DriverName", SqlDbType.VarChar, 50);
            f.Value = d.DriverName;
            cmd.Parameters.Add(f);

            SqlParameter j2 = new SqlParameter("@PartyName", SqlDbType.VarChar, 255);
            j2.Value = d.PartyName;
            cmd.Parameters.Add(j2);

            SqlParameter g = new SqlParameter("@PickupPlace", SqlDbType.VarChar, 50);
            g.Value = d.PickupPlace;
            cmd.Parameters.Add(g);

            SqlParameter h = new SqlParameter("@DropPlace", SqlDbType.Float);
            h.Value = d.DropPlace;
            cmd.Parameters.Add(h);

            SqlParameter j = new SqlParameter("@StartMeter", SqlDbType.VarChar, 255);
            j.Value = d.StartMeter;
            cmd.Parameters.Add(j);

            SqlParameter k = new SqlParameter("@EndMeter", SqlDbType.Date);
            k.Value = d.EndMeter;
            cmd.Parameters.Add(k);

            SqlParameter y = new SqlParameter("@OtherExp", SqlDbType.Date);
            y.Value = d.OtherExp;
            cmd.Parameters.Add(y);

            SqlParameter rj = new SqlParameter("@GeneratedAmount", SqlDbType.VarChar, 50);
            rj.Value = d.GeneratedAmount;
            cmd.Parameters.Add(rj);

            SqlParameter t = new SqlParameter("@ActualAmount", SqlDbType.VarChar, 50);
            t.Value = d.ActualAmount;
            cmd.Parameters.Add(t);

            SqlParameter u = new SqlParameter("@ExecutiveName", SqlDbType.Date);
            u.Value = d.ExecutiveName;
            cmd.Parameters.Add(u);

            SqlParameter o = new SqlParameter("@BNo", SqlDbType.VarChar, 50);
            o.Value = d.BNo;
            cmd.Parameters.Add(o);

            SqlParameter p = new SqlParameter("@DropTime", SqlDbType.Date);
            p.Value = d.DropTime;
            cmd.Parameters.Add(p);

            SqlParameter w = new SqlParameter("@PickupTime", SqlDbType.VarChar, 50);
            w.Value = d.PickupTime;
            cmd.Parameters.Add(w);


            SqlParameter ws = new SqlParameter("@EntryTime", SqlDbType.VarChar, 50);
            ws.Value = d.EntryTime;
            cmd.Parameters.Add(ws);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
