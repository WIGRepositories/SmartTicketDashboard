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
    public class PackagesPricingController : ApiController
    {
        [HttpGet]
        [Route("api/PackagesPricing/GetPackagesPricing")]
        public DataTable GetPackagesPricing()
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
            cmd.CommandText = "GetPackagesPricing";
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
        [Route("api/Packages/PackagesPricingPost")]

        public DataTable PackagesPricingPost(PackagesPricing P)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelPackagesPricing";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = P.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.VarChar,50);
                i.Value = P.Id;
                cmd.Parameters.Add(i);

                SqlParameter pti = new SqlParameter("@PackageTypeId", SqlDbType.VarChar, 150);
                pti.Value = P.PackageTypeId;
                cmd.Parameters.Add(pti);

                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 15);
                Code.Value = P.Code;
                cmd.Parameters.Add(Code);

                SqlParameter n = new SqlParameter("@Name", SqlDbType.VarChar, 150);
                n.Value = P.Name;
                cmd.Parameters.Add(n);

                SqlParameter dc = new SqlParameter("@Description", SqlDbType.VarChar, 500);
                dc.Value = P.Description;
                cmd.Parameters.Add(dc);
                SqlParameter fd = new SqlParameter("@FromDate", SqlDbType.Date);
                fd.Value = P.FromDate;
                cmd.Parameters.Add(fd);
                SqlParameter td = new SqlParameter("@ToDate", SqlDbType.Date);
                td.Value = P.ToDate;
                cmd.Parameters.Add(td);
                SqlParameter fk = new SqlParameter("@FromKm", SqlDbType.VarChar, 50);
                fk.Value = P.FromKm;
                cmd.Parameters.Add(fk);
                SqlParameter tk = new SqlParameter("@ToKm", SqlDbType.VarChar, 50);
                tk.Value = P.@ToKm;
                cmd.Parameters.Add(tk);
                SqlParameter pp = new SqlParameter("@PerKmPrice", SqlDbType.VarChar, 50);
                pp.Value = P.PerKmPrice;
                cmd.Parameters.Add(pp);
                SqlParameter am = new SqlParameter("@Amount", SqlDbType.VarChar, 50);
                am.Value = P.Amount;
                cmd.Parameters.Add(am);
                SqlParameter fh = new SqlParameter("@FromHrs", SqlDbType.DateTime, 7);
                fh.Value = P.FromHrs;
                cmd.Parameters.Add(fh);
                SqlParameter th = new SqlParameter("@ToHrs", SqlDbType.DateTime, 7);
                th.Value = P.ToHrs;
                cmd.Parameters.Add(th);
                SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 150);
                Name.Value = P.Name;
                cmd.Parameters.Add(Name);
               
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
