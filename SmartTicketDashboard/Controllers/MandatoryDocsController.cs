using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
    public class MandatoryDocsController : ApiController
    {
        [HttpGet]
        [Route("api/GetMandatoryUserDocs")]
        public DataTable GetMandUserDocs()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryUserDocs ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMandatoryUserDocs";
            //cmd.Parameters.Add("@countryid", SqlDbType.Int).Value = ctryId;
            //cmd.Parameters.Add("@vtId", SqlDbType.Int).Value = utId;
            cmd.Connection = conn;

            //DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryUserDocs completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/SaveMandatoryUserDocs")]
        public DataTable SaveMandUserDocs(MandUserDocs mud)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandUserDocs ...");

            //connect to database
            DataTable dt=new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelMandatoryUserDocs";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@flag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = mud.flag;
                cmd.Parameters.Add(flag);

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@Id";
                id.SqlDbType = SqlDbType.Int;
                id.Value = mud.Id;
                cmd.Parameters.Add(id);

                SqlParameter DocTId = new SqlParameter();
                DocTId.ParameterName = "@DocTypeId";
                DocTId.SqlDbType = SqlDbType.Int;
                DocTId.Value = mud.DocTypeId;
                cmd.Parameters.Add(DocTId);

                SqlParameter ctrid = new SqlParameter();
                ctrid.ParameterName = "@Countryid";
                ctrid.SqlDbType = SqlDbType.Int;
                ctrid.Value = mud.Countryid;
                cmd.Parameters.Add(ctrid);

                SqlParameter ustid = new SqlParameter();
                ustid.ParameterName = "@UserTypeId";
                ustid.SqlDbType = SqlDbType.Int;
                ustid.Value = mud.UserTypeId;
                cmd.Parameters.Add(ustid);
                //DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                // Tbl = Tables[0];
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandUserDocs  completed.");
                
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveMandUserDocs:" + ex.Message);
               
            }
             return dt;
        }

        [HttpGet]
        [Route("api/GetMandatoryVehicleDocs")]
        public DataTable GetMandVehicleDocs()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryVehicleDocs ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMandatoryVehicleDocs";
            //cmd.Parameters.Add("@countryid", SqlDbType.Int).Value = ctryId;
            //cmd.Parameters.Add("@vtId", SqlDbType.Int).Value = utId;
            cmd.Connection = conn;

            //DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryVehicleDocs completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/SaveMandatoryVehicleDocs")]
        public DataTable SaveMandVehicleDocs(MandVehicleDocs mvd)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandVehicleDocs ...");

            //connect to database
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelMandatoryVehicleDocs";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@flag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = mvd.flag;
                cmd.Parameters.Add(flag);

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@Id";
                id.SqlDbType = SqlDbType.Int;
                id.Value = mvd.Id;
                cmd.Parameters.Add(id);
                
                SqlParameter DocTId = new SqlParameter();
                DocTId.ParameterName = "@DocTypeId";
                DocTId.SqlDbType = SqlDbType.Int;
                DocTId.Value = mvd.DocTypeId;
                cmd.Parameters.Add(DocTId);

                SqlParameter ctrid = new SqlParameter();
                ctrid.ParameterName = "@Countryid";
                ctrid.SqlDbType = SqlDbType.Int;
                ctrid.Value = mvd.Countryid;
                cmd.Parameters.Add(ctrid);

                SqlParameter vgrid = new SqlParameter();
                vgrid.ParameterName = "@VehicleGroupId";
                vgrid.SqlDbType = SqlDbType.Int;
                vgrid.Value = mvd.VehicleGroupId;
                cmd.Parameters.Add(vgrid);
                //DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                // Tbl = Tables[0];
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandVehiclerDocs  completed.");

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveMandVehicleDocs:" + ex.Message);

            }
            return dt;
        }
    }
}
