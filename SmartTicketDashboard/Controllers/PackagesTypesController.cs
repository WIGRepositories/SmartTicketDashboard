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
    public class PackagesTypesController : ApiController
    {
        [HttpGet]
        [Route("api/PackagesTypes/GetPackagesTypes")]
        public DataTable GetPackagesTypes()
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
            cmd.CommandText = "GetPackagesTypes";
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
        [Route("api/PackagesTypes/PackagesTypesPost")]

        public DataTable PackagesTypesPost(PackagesTypes P)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelPackagesTypes";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = P.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.VarChar, 50);
                i.Value = P.Id;
                cmd.Parameters.Add(i);

                SqlParameter pi = new SqlParameter("@PackageId", SqlDbType.Int);
                pi.Value = P.PackageId;
                cmd.Parameters.Add(pi);

                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 15);
                Code.Value = P.Code;
                cmd.Parameters.Add(Code);

                SqlParameter n = new SqlParameter("@Name", SqlDbType.VarChar, 150);
                n.Value = P.Name;
                cmd.Parameters.Add(n);

               
                SqlParameter fd = new SqlParameter("@FromDate", SqlDbType.Date);
                fd.Value = P.FromDate;
                cmd.Parameters.Add(fd);
                SqlParameter td = new SqlParameter("@ToDate", SqlDbType.Date);
                td.Value = P.ToDate;
                cmd.Parameters.Add(td);
                SqlParameter co= new SqlParameter("@CreatedOn", SqlDbType.Int);
                co.Value = P.CreatedOn;
                cmd.Parameters.Add(co);
                SqlParameter cb = new SqlParameter("@CreatedBy", SqlDbType.Int);
                cb.Value = P.CreatedBy;
                cmd.Parameters.Add(cb);
                SqlParameter tk = new SqlParameter("@UpdatedOn", SqlDbType.Int);
                tk.Value = P.UpdatedOn;
                cmd.Parameters.Add(tk);
                SqlParameter pp = new SqlParameter("@UpdatedBy", SqlDbType.Int);
                pp.Value = P.UpdatedBy;
                cmd.Parameters.Add(pp);
                SqlParameter am = new SqlParameter("@Title", SqlDbType.VarChar, 150);
                am.Value = P.Title;
                cmd.Parameters.Add(am);

                SqlParameter io = new SqlParameter("@ImageOne", SqlDbType.VarChar);
                io.Value = P.ImageOne;
                cmd.Parameters.Add(io);
                SqlParameter it = new SqlParameter("@ImageTwo", SqlDbType.VarChar);
                it.Value = P.ImageTwo;
                cmd.Parameters.Add(it);

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
