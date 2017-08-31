using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class BalanceController : ApiController
    {
        [HttpGet]
        [Route("api/Balance/Getcurrentbalance")]

        public DataTable Getcurrentbalance(string mobileno)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetCurrentBalance";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
            cmpid.Value = mobileno;
            cmd.Parameters.Add(cmpid);

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }
        [HttpGet]
        [Route("api/Balance/GetAddBalance")]

        public DataTable GetAddBalance(string mobileno)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetAddBalance";
            cmd.Connection = conn;
            SqlParameter cmpid = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
            cmpid.Value = mobileno;
            cmd.Parameters.Add(cmpid);


            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }
        [HttpGet]
        [Route("api/Balance/GetTrasferBalance")]

        public DataTable GetATrasferBalance(string mobileno)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetTrasferBalance";
            cmd.Connection = conn;
            SqlParameter cmpid = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
            cmpid.Value = mobileno;
            cmd.Parameters.Add(cmpid);


            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }
        [HttpPost]
        [Route("api/Balance/AddBalance")]

        public DataTable AddBalance(Appusers A)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSInsUpdBalance";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = A.flag;
                cmd.Parameters.Add(f);                

              

                SqlParameter mn = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
               mn.Value = A.Mobilenumber;
                cmd.Parameters.Add(mn);

                SqlParameter em = new SqlParameter("@Amount", SqlDbType.Decimal);
                em.Value = A.Amount;
                cmd.Parameters.Add(em);

                
                SqlParameter St = new SqlParameter("@StatusId", SqlDbType.Int);
                St.Value = A.Status;
                cmd.Parameters.Add(St);
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
        [HttpPost]
        [Route("api/Balance/TransferBalance")]

        public DataTable TransferBalance(Appusers A)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSInsUpdBalance";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = A.flag;
                cmd.Parameters.Add(f);

              

                SqlParameter mn = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
                mn.Value = A.Mobilenumber;
                cmd.Parameters.Add(mn);

                SqlParameter em = new SqlParameter("@Amount", SqlDbType.Decimal);
                em.Value = A.Amount;
                cmd.Parameters.Add(em);

               
                SqlParameter St = new SqlParameter("@StatusId", SqlDbType.Int);
                St.Value = A.Status;
                cmd.Parameters.Add(St);
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
