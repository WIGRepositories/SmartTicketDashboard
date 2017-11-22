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
    public class OperationChargesDiscountController : ApiController
    {
        [HttpGet]
        [Route("api/OperationChargesDiscount/GetOperationChargesDiscount")]
        public DataTable GetOperationChargesDiscount()
        {
            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetOperationChargesDiscount credentials....");


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetOperationChargesDiscount";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetOperationChargesDiscount Credentials completed.");
            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        [Route("api/OperationChargesDiscount/OperationChargesDiscountPost")]

        public DataTable OperationChargesDiscountPost(OperationChargesDiscount O)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelOperationChargesDiscount";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = O.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = O.Id;
                cmd.Parameters.Add(i);

                SqlParameter ci = new SqlParameter("@ChargeDisId", SqlDbType.VarChar, 15);
                ci.Value = O.ChargeDisId;
                cmd.Parameters.Add(ci);

                SqlParameter oi = new SqlParameter("@OperationId", SqlDbType.VarChar, 15);
                oi.Value = O.OperationId;
                cmd.Parameters.Add(oi);

                SqlParameter fd = new SqlParameter("@FromDate", SqlDbType.Date);
                fd.Value = O.FromDate;
                cmd.Parameters.Add(fd);

                SqlParameter td = new SqlParameter("@ToDate", SqlDbType.Date);
                td.Value = O.ToDate;
                cmd.Parameters.Add(td);


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
