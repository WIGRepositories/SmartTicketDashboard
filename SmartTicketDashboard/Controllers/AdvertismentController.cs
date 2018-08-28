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
            try { 
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
            }
            catch (Exception ex)
            {
                traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "GetAdvertisment Credentials error" + ex.Message);
            }
            return Tbl;

        }

        [HttpPost]
        [Route("api/Advertisment/Advertismentsectionone")]

        public DataTable Advertismentsectionone(Advertisment A)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            LogTraceWriter traceWriter = new LogTraceWriter();
            DataTable dt = new DataTable();
            try
            {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Advertismentsectionone....");
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

                SqlParameter im = new SqlParameter("@Image", SqlDbType.VarChar);
                im.Value = A.Image;
                cmd.Parameters.Add(im);

                SqlParameter at = new SqlParameter("@AdvertisementTitle", SqlDbType.VarChar, 100);
                at.Value = A.AdvertisementTitle;
                cmd.Parameters.Add(at);

                SqlParameter d = new SqlParameter("@Description", SqlDbType.VarChar, 250);
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
                SqlParameter cn = new SqlParameter("@CompanyName", SqlDbType.VarChar, 100);
                cn.Value = A.CompanyName;
                cmd.Parameters.Add(cn);
                SqlParameter ar = new SqlParameter("@Area", SqlDbType.VarChar, 50);
                ar.Value = A.Area;
                cmd.Parameters.Add(ar);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Advertismentsectionone completed....");
                }
                catch (Exception ex)
                {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetAdvertisment credentials error."+ ex.Message);
                }
                return dt;
        }


        [HttpGet]
        [Route("api/Advertisement/GetActivityLog")]

        public DataTable GetActivityLog()
        {
            SqlConnection conn = new SqlConnection();
            DataTable tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetActivityLog ...");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetActivityLog";
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(tbl);
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetActivityLog completed ...");
            }
            catch (Exception ex) {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetActivityLog error." + ex.Message);
            }
            return tbl;

        }
 
        [HttpPost]
        [Route("api/Advertisement/ActivityLog")]
        public int ActivityLog(Activity ac)
        {
            SqlConnection conn = new SqlConnection();
            LogTraceWriter traceWriter = new LogTraceWriter();
            try
            {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ActivityLog....");
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelActivityLog";

                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = ac.Id;
                cmd.Parameters.Add(id);

                SqlParameter Ti = new SqlParameter("@Title", SqlDbType.VarChar,100);
                Ti.Value = ac.Title;
                cmd.Parameters.Add(Ti);

                SqlParameter rt = new SqlParameter("@Rating", SqlDbType.VarChar,20);
                rt.Value = ac.Rating;
                cmd.Parameters.Add(rt);

                SqlParameter im = new SqlParameter("@Image", SqlDbType.VarChar);
                im.Value = ac.Image;
                cmd.Parameters.Add(im);

                SqlParameter co = new SqlParameter("@CreatedOn", SqlDbType.Date);
                co.Value = ac.CreatedOn;
                cmd.Parameters.Add(co);

                SqlParameter cb = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
                cb.Value = ac.CreatedBy;
                cmd.Parameters.Add(cb);

                SqlParameter uo = new SqlParameter("@UpdatedOn", SqlDbType.Date);
                uo.Value = ac.UpdatedOn;
                cmd.Parameters.Add(uo);

                SqlParameter ub = new SqlParameter("@UpdatedBy", SqlDbType.VarChar, 50);
                ub.Value = ac.UpdatedBy;
                cmd.Parameters.Add(ub);

                SqlParameter fl = new SqlParameter("@flag", SqlDbType.VarChar);
                fl.Value = ac.flag;
                cmd.Parameters.Add(fl);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ActivityLog completed.");
            }
            catch(Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ActivityLog error." + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "ActivityLog...");
            }
            return 7;
        }
    }

}
