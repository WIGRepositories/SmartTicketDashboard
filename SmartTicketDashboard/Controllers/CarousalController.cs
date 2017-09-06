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
    public class CarousalController : ApiController
    {
        [HttpGet]
        public DataTable GetCarousel()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCarousel credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCarouselImages";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCarousel Credentials completed.");
            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        [Route("api/Carousal/CarousalOperations")]

        public DataTable ProductsOperations(Carousel c)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCarouselImages";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = c.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = c.Id;
                cmd.Parameters.Add(i);

                
                SqlParameter jh = new SqlParameter("@ImageName", SqlDbType.VarChar, max);
                jh.Value = c.ImageName;
                cmd.Parameters.Add(jh);

                SqlParameter im = new SqlParameter("@Img", SqlDbType.VarChar);
                im.Value = c.Image;
                cmd.Parameters.Add(im);


                SqlParameter ic = new SqlParameter("@ImageCaption", SqlDbType.VarChar,250);
               ic.Value = c.ImageCaption;
                cmd.Parameters.Add(ic);

                SqlParameter id = new SqlParameter("@ImageDesc", SqlDbType.VarChar, 250);
                id.Value = c.ImageDesc;
                cmd.Parameters.Add(id);
               
                SqlParameter cb = new SqlParameter("@CreatedBy", SqlDbType.Int);
                cb.Value = c.CreatedBy;
                cmd.Parameters.Add(cb);
               

                SqlParameter mb = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                mb.Value = c.ModifiedBy;
                cmd.Parameters.Add(mb);

                SqlParameter ip = new SqlParameter("@ImgPath", System.Data.SqlDbType.VarChar, 250);
                ip.Value = c.ImgPath;
                cmd.Parameters.Add(ip);
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

        public int max { get; set; }
    }
}
