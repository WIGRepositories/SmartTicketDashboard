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
    public class TransactionMasterController : ApiController
    {

        [HttpGet]
        [Route("api/TransactionMaster/GetTransactionMaster")]
        public DataTable GetTransactionMaster()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTransactionMaster";

            //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/TransactionMaster/GetTransactionCharges")]
        public DataTable GetTransactionCharges()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTransactionCharges";

            //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/TransactionMaster/GetTransactionDiscounts")]
        public DataTable GetTransactionDiscounts()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTransactionDiscounts";

            //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/TransactionMaster/GetTransactionDetails")]
        public DataTable GetTransactionDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTransactionDetails";

            //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/TransactionMaster/GetTransactionInfo")]
        public DataTable GetTransactionInfo()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTransactionInfo";

            //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpPost]
        [Route("api/TransactionMaster/SaveTransactionMaster")]
        public DataTable SaveTransactionMaster(Transmaster tm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTransactionMaster";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = tm.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = tm.Id;
                cmd.Parameters.Add(i);               

                SqlParameter n = new SqlParameter("@GateWayTransId", SqlDbType.VarChar, 50);
                n.Value = tm.GateWayTransId;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@BaseAmount", SqlDbType.Decimal);
                r.Value = tm.BaseAmount;
                cmd.Parameters.Add(r);

                SqlParameter f = new SqlParameter("@StatusId", SqlDbType.Int);
                f.Value = tm.StatusId;
                cmd.Parameters.Add(f);

                SqlParameter s = new SqlParameter("@Discount", SqlDbType.Decimal);
                s.Value = tm.Discount;
                cmd.Parameters.Add(s);

                SqlParameter g = new SqlParameter("@Charges", SqlDbType.Decimal);
                g.Value = tm.Charges;
                cmd.Parameters.Add(g);

                SqlParameter j = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
                j.Value = tm.TotalAmount;
                cmd.Parameters.Add(j);

                SqlParameter fr = new SqlParameter("@OpCode", SqlDbType.VarChar, 50);
                fr.Value = tm.OpCode;
                cmd.Parameters.Add(fr);

                SqlParameter lk = new SqlParameter("@CreatedBy", SqlDbType.Int);
                lk.Value = tm.CreatedBy;
                cmd.Parameters.Add(lk);


                SqlParameter ed = new SqlParameter("@PaymentTypeId", SqlDbType.Int);
                ed.Value = tm.PaymentTypeId;
                cmd.Parameters.Add(ed);

                SqlParameter dc = new SqlParameter("@Desc", SqlDbType.VarChar);
                dc.Value = tm.Description;
                cmd.Parameters.Add(dc);


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/TransactionMaster/SaveTransactionCharges")]
        public DataTable SaveTransactionCharges(TransCharges tc)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTransactionCharges";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = tc.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = tc.Id;
                cmd.Parameters.Add(i);

                SqlParameter n = new SqlParameter("@TransactionMasterId", SqlDbType.Int);
                n.Value = tc.TransmasterId;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@ChargeId", SqlDbType.Int);
                r.Value = tc.ChargedId;
                cmd.Parameters.Add(r);

                SqlParameter f = new SqlParameter("@Amount", SqlDbType.Decimal);
                f.Value = tc.Amount;
                cmd.Parameters.Add(f);

                SqlParameter s = new SqlParameter("@AppliedOndate", SqlDbType.Date);
                s.Value = tc.AppliedOndate;
                cmd.Parameters.Add(s);
               


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/TransactionMaster/SaveTransactionDiscounts")]
        public DataTable SaveTransactionDiscounts(TransDiscounts td)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTransactionDiscounts";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = td.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = td.Id;
                cmd.Parameters.Add(i);

                SqlParameter n = new SqlParameter("@TransactionMasterId", SqlDbType.Int);
                n.Value = td.TransmasterId;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@DiscountId", SqlDbType.Int);
                r.Value = td.DiscountId;
                cmd.Parameters.Add(r);

                SqlParameter f = new SqlParameter("@Amount", SqlDbType.Decimal);
                f.Value = td.Amount;
                cmd.Parameters.Add(f);

                SqlParameter s = new SqlParameter("@AppliedOndate", SqlDbType.DateTime);
                s.Value = td.AppliedOndate;
                cmd.Parameters.Add(s);



                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/TransactionMaster/SaveTransactionInfo")]
        public DataTable SaveTransactionInfo(TransInfo ti)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTransactionInfo";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = ti.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = ti.Id;
                cmd.Parameters.Add(i);

                SqlParameter n = new SqlParameter("@TransactionMasterId", SqlDbType.Int);
                n.Value = ti.TransmasterId;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@Emailsent", SqlDbType.Int);
                r.Value = ti.Emailsent;
                cmd.Parameters.Add(r);

                SqlParameter f = new SqlParameter("@smssent", SqlDbType.Int);
                f.Value = ti.smssent;
                cmd.Parameters.Add(f);

                SqlParameter s = new SqlParameter("@NumberOfRetries", SqlDbType.Int);
                s.Value = ti.noofretries;
                cmd.Parameters.Add(s);

                SqlParameter g = new SqlParameter("@statusId", SqlDbType.Int);
                g.Value = ti.statusId;
                cmd.Parameters.Add(g);

                SqlParameter j = new SqlParameter("@Emailsenton", SqlDbType.DateTime);
                j.Value = ti.Emailsenton;
                cmd.Parameters.Add(j);

                SqlParameter fr = new SqlParameter("@smssenton", SqlDbType.DateTime);
                fr.Value = ti.smssenton;
                cmd.Parameters.Add(fr);

                SqlParameter lk = new SqlParameter("@sendphno", SqlDbType.VarChar);
                lk.Value = ti.sendphno;
                cmd.Parameters.Add(lk);


                SqlParameter ed = new SqlParameter("@Email", SqlDbType.VarChar);
                ed.Value = ti.Email;
                cmd.Parameters.Add(ed);

                SqlParameter dc = new SqlParameter("@TransactionDocument", SqlDbType.VarChar);
                dc.Value = ti.TransactionDocument;
                cmd.Parameters.Add(dc);


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/TransactionMaster/SaveTransactionDetails")]
        public DataTable SaveTransactionDetails(TransDetails tdd)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTransactionDetails";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = tdd.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = tdd.Id;
                cmd.Parameters.Add(i);

                SqlParameter n = new SqlParameter("@TransactionMasterId", SqlDbType.Int);
                n.Value = tdd.TransmasterId;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@PaymentTypeId", SqlDbType.Int);
                r.Value = tdd.PaymentTypeId;
                cmd.Parameters.Add(r);

                SqlParameter f = new SqlParameter("@AccountNumber", SqlDbType.VarChar);
                f.Value = tdd.AccountNumber;
                cmd.Parameters.Add(f);

                SqlParameter s = new SqlParameter("@StatusId", SqlDbType.Int);
                s.Value = tdd.StatusId;
                cmd.Parameters.Add(s);



                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
        }
    }
}
