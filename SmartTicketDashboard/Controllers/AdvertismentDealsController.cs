using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class AdvertismentDealsController : ApiController
    {

        [HttpGet]
        [Route("api/AdvertismentDeals/GetAdvertismentDeal")]
        public DataTable GetAdvertismentDeal()
        {
            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAdvertismentDeals credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAdvertismentDeals";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAdvertismentDeals credentials....");
            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        [Route("api/AdvertismentDeals/PostAdvertismentDeals")]
        public DataTable PostAdvertismentDeals(advdeals A)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelAdvertismentDeals";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = A.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = A.Id;
                cmd.Parameters.Add(i);

                SqlParameter im = new SqlParameter("@Image", SqlDbType.VarChar);
                im.Value = A.Image;
                cmd.Parameters.Add(im);

                SqlParameter at = new SqlParameter("@AdvertisementTitle", SqlDbType.VarChar, 100);
                at.Value = A.AdvertisementTitle;
                cmd.Parameters.Add(at);

                SqlParameter d = new SqlParameter("@Description", SqlDbType.VarChar, 200);
                d.Value = A.Description;
                cmd.Parameters.Add(d);

                SqlParameter dsf = new SqlParameter("@Dealsoffer", SqlDbType.VarChar, 100);
                dsf.Value = A.Dealsoffer;
                cmd.Parameters.Add(dsf);

                SqlParameter ra = new SqlParameter("@Rating", SqlDbType.VarChar, 250);
                ra.Value = A.Rating;
                cmd.Parameters.Add(ra);

                SqlParameter pd = new SqlParameter("@PublishDate", SqlDbType.DateTime);
                pd.Value = A.PublishDate;
                cmd.Parameters.Add(pd);

                SqlParameter ed = new SqlParameter("@ExpiredDate", System.Data.SqlDbType.DateTime);
                ed.Value = A.ExpiredDate;
                cmd.Parameters.Add(ed);
              
                SqlParameter ar = new SqlParameter("@Area", SqlDbType.VarChar, 50);
                ar.Value = A.Area;
                cmd.Parameters.Add(ar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

    }
}
