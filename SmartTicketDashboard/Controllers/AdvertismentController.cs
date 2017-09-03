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

        [HttpPost]
        [Route("api/Advertisment/Advertismentsectionone")]

        public DataTable Advertismentsectionone(Advertisment A)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDeladvertisement";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = A.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = A.Id;
                cmd.Parameters.Add(i);

                SqlParameter im = new SqlParameter("@image", SqlDbType.VarChar);
                im.Value = A.Image;
                cmd.Parameters.Add(im);

                SqlParameter at = new SqlParameter("@AdvertisementTitle", SqlDbType.VarChar, 100);
                at.Value = A.AdvertisementTitle;
                cmd.Parameters.Add(at);

                SqlParameter d = new SqlParameter("@Description", SqlDbType.VarChar,250);
                d.Value = A.Description;
                cmd.Parameters.Add(d);

                SqlParameter cl = new SqlParameter("@Clarification", SqlDbType.VarChar, 250);
                cl.Value = A.Clarification;
                cmd.Parameters.Add(cl);

                SqlParameter co = new SqlParameter("@Conclusion", SqlDbType.VarChar, 250);
                co.Value = A.Conclusion;
                cmd.Parameters.Add(co);

                SqlParameter Price = new SqlParameter("@Price", SqlDbType.Float);
                Price.Value = A.Price;
                cmd.Parameters.Add(Price);

                SqlParameter ati = new SqlParameter("@AdvertisementTypeId", SqlDbType.Int);
                ati.Value = A.AdvertisementTypeId;
                cmd.Parameters.Add(ati);

                SqlParameter pd = new SqlParameter("@PublishDate", SqlDbType.DateTime);
                pd.Value = A.PublishDate;
                cmd.Parameters.Add(pd);

                SqlParameter ed = new SqlParameter("@ExpiredDate", System.Data.SqlDbType.DateTime);
                ed.Value = A.ExpiredDate;
                cmd.Parameters.Add(ed);

                SqlParameter aa = new SqlParameter("@AdvertisementAmount", SqlDbType.Float);
                aa.Value = A.AdvertisementAmount;
                cmd.Parameters.Add(aa);
                SqlParameter cn = new SqlParameter("@CompanyName", SqlDbType.VarChar,100);
                cn.Value = A.CompanyName;
                cmd.Parameters.Add(cn);
                SqlParameter ar = new SqlParameter("@Area", SqlDbType.VarChar, 50);
                ar.Value = A.Area;
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
