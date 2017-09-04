using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
    public class ProductsController : ApiController
    {

        [HttpGet]
        public DataTable GetAdvertisment()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAdvertisment credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Getadvertisement";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAdvertisment Credentials completed.");
            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        [Route("api/Products/ProductsOperations")]

        public DataTable ProductsOperations(Products P)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelProducts";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = P.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = P.Id;
                cmd.Parameters.Add(i);

                SqlParameter im = new SqlParameter("@image", SqlDbType.VarChar);
                im.Value = P.Image;
                cmd.Parameters.Add(im);

                SqlParameter pn = new SqlParameter("@ProductName", SqlDbType.VarChar, 50);
                pn.Value = P.ProductName;
                cmd.Parameters.Add(pn);

                SqlParameter p = new SqlParameter("@Price", SqlDbType.Float);
                p.Value = P.Price;
                cmd.Parameters.Add(p);

                SqlParameter don = new SqlParameter("@DescriptionOne", SqlDbType.VarChar, 100);
                don.Value = P.DescriptionOne;
                cmd.Parameters.Add(don);

                SqlParameter dt = new SqlParameter("@DescriptionTwo", SqlDbType.VarChar, 100);
                dt.Value = P.DescriptionTwo;
                cmd.Parameters.Add(dt);

               

                SqlParameter dth = new SqlParameter("@DescriptionThree", SqlDbType.Int);
                dth.Value = P.DescriptionThree;
                cmd.Parameters.Add(dth);

                SqlParameter dfo = new SqlParameter("@DescriptionFour", SqlDbType.DateTime);
                dfo.Value = P.DescriptionFour;
                cmd.Parameters.Add(dfo);

                SqlParameter ed = new SqlParameter("@ExpiredDate", System.Data.SqlDbType.DateTime);
                ed.Value = P.ExpiredDate;
                cmd.Parameters.Add(ed);

                SqlParameter aa = new SqlParameter("@AdvertisementAmount", SqlDbType.Float);
                aa.Value = P.AdvertisementAmount;
                cmd.Parameters.Add(aa);
                SqlParameter cn = new SqlParameter("@CompanyName", SqlDbType.VarChar, 100);
                cn.Value = P.CompanyName;
                cmd.Parameters.Add(cn);
                SqlParameter ar = new SqlParameter("@Area", SqlDbType.VarChar, 50);
                ar.Value = P.Area;
                cmd.Parameters.Add(ar);
            }
            catch
            {
                Exception ex;
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

    }
}
