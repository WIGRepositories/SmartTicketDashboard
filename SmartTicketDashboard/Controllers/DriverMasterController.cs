﻿using System;
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
        public DataTable Master(int DId)
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

        [HttpPost]
        [Route("api/DriverMaster/Driver")]

        public DataTable Driver(driverdetails d)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVdrivers";
            cmd.Connection = conn;


            SqlParameter i = new SqlParameter("@DId", SqlDbType.Int);
            i.Value = d.id;
            cmd.Parameters.Add(i);

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

            SqlParameter t = new SqlParameter("@LicenceNo", SqlDbType.VarChar, 50);
            t.Value = d.LicenceNo;
            cmd.Parameters.Add(t);

            SqlParameter u = new SqlParameter("@LiCExpDate", SqlDbType.Date);
            u.Value = d.LiCExpDate;
            cmd.Parameters.Add(u);

            SqlParameter o = new SqlParameter("@BadgeNo", SqlDbType.VarChar, 50);
            o.Value = d.BadgeNo;
            cmd.Parameters.Add(o);

            SqlParameter p = new SqlParameter("@BadgeExpDate", SqlDbType.Date);
            p.Value = d.BadgeExpDate;
            cmd.Parameters.Add(p);

            SqlParameter w = new SqlParameter("@Remarks", SqlDbType.VarChar, 50);
            w.Value = d.Remarks;
            cmd.Parameters.Add(w);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}