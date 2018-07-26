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
    public class ObjectsController : ApiController
    {
        [HttpGet]
        [Route("api/Objects/getRootObjects")]
        public DataTable getRootObjects()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getObjects credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetNewObject";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getObjects Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        [Route("api/Objects/saveobj")]
        public HttpResponseMessage saveObjects(Objects b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveObjects credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            { 
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelNewObject";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = b.Id;
            cmd.Parameters.Add(cc);

            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@Name";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.Name;
            cmd.Parameters.Add(cname);

            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Description";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.Description;
            cmd.Parameters.Add(dd);

            //SqlParameter dda = new SqlParameter();
            //dda.ParameterName = "@Path";
            //dda.SqlDbType = SqlDbType.VarChar;
            //dda.Value = b.Path;
            //cmd.Parameters.Add(dda);

           

            SqlParameter fd = new SqlParameter();
            fd.ParameterName = "@ParentId";
            fd.SqlDbType = SqlDbType.Int;
            fd.Value = b.ParentID;
            cmd.Parameters.Add(fd);

            SqlParameter gd = new SqlParameter();
            gd.ParameterName = "@RootObjectId";
            gd.SqlDbType = SqlDbType.Int;
            gd.Value = b.RootObjectId;
            cmd.Parameters.Add(gd);       


            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@Active";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.Active;
            cmd.Parameters.Add(aa);

            SqlParameter flag = new SqlParameter();
            flag.ParameterName = "@flag";
            flag.SqlDbType = SqlDbType.VarChar;
            flag.Value = b.flag;
            //llid.Value = b.Active;
            cmd.Parameters.Add(flag);

                SqlParameter co = new SqlParameter();
                co.ParameterName = "@CreatedOn";
                co.SqlDbType = SqlDbType.VarChar;
                co.Value = b.CreatedOn;
                //llid.Value = b.Active;
                cmd.Parameters.Add(co);

                SqlParameter cb = new SqlParameter();
                cb.ParameterName = "@CreatedBy";
                cb.SqlDbType = SqlDbType.VarChar;
                cb.Value = b.CreatedBy;
                //llid.Value = b.Active;
                cmd.Parameters.Add(cb);

                SqlParameter uo = new SqlParameter();
                uo.ParameterName = "@UpdatedOn";
                uo.SqlDbType = SqlDbType.VarChar;
                uo.Value = b.UpdatedOn;
                //llid.Value = b.Active;
                cmd.Parameters.Add(uo);

                SqlParameter ub = new SqlParameter();
                ub.ParameterName = "@UpdatedBy";
                ub.SqlDbType = SqlDbType.VarChar;
                ub.Value = b.UpdatedBy;
                //llid.Value = b.Active;
                cmd.Parameters.Add(ub);

                //DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                // Tbl = Tables[0];
                cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveObjects Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveObjects:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("api/Objects/getChildObjects")]
        public DataSet getChildObjects(int RootObjectId)
        {
            DataSet Tbl = new DataSet();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getObjects credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetNewChildObj";
            cmd.Connection = conn;
           // DataSet ds = new DataSet();

            SqlParameter uid = new SqlParameter();
            uid.ParameterName = "@RootObjectId";
            uid.SqlDbType = SqlDbType.Int;
            uid.Value = RootObjectId;
            cmd.Parameters.Add(uid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getObjects Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpGet]
        [Route("api/Objects/getObjAccsess")]
        public DataTable getObjAccsess(int TypeGroupId)
        {
            DataTable tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAccessTypes";
            cmd.Connection = conn;

            SqlParameter uid = new SqlParameter();
            uid.ParameterName = "@TypeGroupId";
            uid.SqlDbType = SqlDbType.Int;
            uid.Value = TypeGroupId;
            cmd.Parameters.Add(uid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(tbl);

            return tbl;
        }

        [HttpPost]
        [Route("api/Objects/saveObjAcc")]
        public DataTable saveObjAcc(List<ObjectAccess> list)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            DataTable tbl = new DataTable();

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelObjectAccess";
                cmd.Connection = conn;

                conn.Open();

                foreach (ObjectAccess p in list)
                {
                    SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                    id.Value = p.Id;
                    cmd.Parameters.Add(id);

                    SqlParameter nm = new SqlParameter("@Name", SqlDbType.Int);
                    nm.Value = p.Name;
                    cmd.Parameters.Add(nm);

                    SqlParameter Oi = new SqlParameter("@ObjectId", SqlDbType.Int);
                    Oi.Value = p.ObjectId;
                    cmd.Parameters.Add(Oi);

                    SqlParameter ai = new SqlParameter("@TypeId", SqlDbType.Int);
                    ai.Value = p.TypeId;
                    cmd.Parameters.Add(ai);                   

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag.Value = p.flag;
                    cmd.Parameters.Add(insupdflag);

                    DataSet ds = new DataSet();
                    SqlDataAdapter db = new SqlDataAdapter(cmd);
                    db.Fill(tbl);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
                return tbl;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;


                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);

                return tbl;


                // int found = 0;

            }

        }
        public void Options()
        {

        }
    }
}

