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
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
    public class AdvertismentController : ApiController
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

        //[HttpPost]
        //[Route("api/Advertisment/Advertismentsectionone")]

        //public DataTable Advertismentsectionone(Advertisment A)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {


        //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "InsUpdDeladvertisement";
        //        cmd.Connection = conn;

        //        SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
        //        f.Value = A.flag;
        //        cmd.Parameters.Add(f);

        //        SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
        //        i.Value = A.Id;
        //        cmd.Parameters.Add(i);

        //        SqlParameter im = new SqlParameter("@image", SqlDbType.VarChar);
        //        im.Value = A.image;
        //        cmd.Parameters.Add(im);

        //        SqlParameter ic = new SqlParameter("@imgcontent", SqlDbType.VarChar, 150);
        //        ic.Value = A.imagcontent;
        //        cmd.Parameters.Add(ic);

        //        SqlParameter price = new SqlParameter("@price", SqlDbType.Float);
        //        price.Value = A.price;
        //        cmd.Parameters.Add(price);

        //        SqlParameter ds = new SqlParameter("@description", SqlDbType.VarChar, 150);
        //        ds.Value = A.description;
        //        cmd.Parameters.Add(ds);



        //    }
        //    catch
        //    {
        //        Exception ex;
        //    }
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);

        //    return dt;
        //}
    }
}
