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
    public class PackagesController : ApiController
    {
        [HttpGet]
        [Route("api/Packages/GetPackages")]
        public DataTable GetPackages()
        {
            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetOperations credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPackages";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            // traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetOperations Credentials completed.");
            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        [Route("api/Packages/PackagesPost")]

        public DataTable PackagesPost(Packages P)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelPackages";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = P.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = P.Id;
                cmd.Parameters.Add(i);

                SqlParameter vgi = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
                vgi.Value = P.VehicleGroupId;
                cmd.Parameters.Add(vgi);

                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 15);
                Code.Value = P.Code;
                cmd.Parameters.Add(Code);

                SqlParameter n = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                n.Value = P.Name;
                cmd.Parameters.Add(n);

                SqlParameter dc = new SqlParameter("@Description", SqlDbType.VarChar, 250);
                dc.Value = P.Description;
                cmd.Parameters.Add(dc);
                SqlParameter fd = new SqlParameter("@FromDate", SqlDbType.Date);
                fd.Value = P.FromDate;
                cmd.Parameters.Add(fd);
                SqlParameter td = new SqlParameter("@ToDate", SqlDbType.Date);
                td.Value = P.ToDate;
                cmd.Parameters.Add(td);
                SqlParameter co = new SqlParameter("@CreatedOn", SqlDbType.Int);
                co.Value = P.CreatedOn;
                cmd.Parameters.Add(co);
                SqlParameter cb = new SqlParameter("@CreatedBy", SqlDbType.Int);
                cb.Value = P.CreatedBy;
                cmd.Parameters.Add(cb);
                SqlParameter uo = new SqlParameter("@UpdatedOn", SqlDbType.Int);
                uo.Value = P.UpdatedOn;
                cmd.Parameters.Add(uo);
                SqlParameter ub = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                ub.Value = P.UpdatedBy;
                cmd.Parameters.Add(ub);
                SqlParameter ti = new SqlParameter("@Title", SqlDbType.VarChar, 150);
                ti.Value = P.Title;
                cmd.Parameters.Add(ti);
                SqlParameter io = new SqlParameter("@ImageOne", SqlDbType.VarChar);
                io.Value = P.ImageOne;
                cmd.Parameters.Add(io);
                SqlParameter it = new SqlParameter("@ImageTwo", SqlDbType.VarChar);
                it.Value = P.ImageTwo;
                cmd.Parameters.Add(it);
                SqlParameter vt = new SqlParameter("@VehicleType", SqlDbType.VarChar, 150);
                vt.Value = P.VehicleType;
                cmd.Parameters.Add(vt);
                SqlParameter ci = new SqlParameter("@CountryId", SqlDbType.Int);
                ci.Value = P.CountryId;
                cmd.Parameters.Add(ci);
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
