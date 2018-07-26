using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Tracing;

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
            DataTable dt = new DataTable();
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




                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                #region transaction otp
                string Totp = dt.Rows[0]["Transactionotp"].ToString();
                if (Totp != null)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        string emailserver = System.Configuration.ConfigurationManager.AppSettings["emailserver"].ToString();

                        string username = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                        string pwd = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                        string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"].ToString();
                        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();

                        SmtpClient SmtpServer = new SmtpClient(emailserver);

                        mail.From = new MailAddress(fromaddress);
                        mail.To.Add(fromaddress);
                        mail.Subject = "Transaction - Transaction OTP";
                        mail.IsBodyHtml = true;

                        string verifcodeMail = @"<table>
                                                        <tr>
                                                            <td>
                                                                <h2>Thank you for Your Transaction</h2>
                                                                <table width=\""760\"" align=\""center\"">
                                                                    <tbody style='background-color:#F0F8FF;'>
                                                                        <tr>
                                                                            <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#F0F8FF;\"" >
<div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />
                                                                             
                                                       Your Transaction OTP is:<h3>" + Totp + @" </h3>

                                                        If you didn't make this request, <a href='http://154.120.237.198:52800'>click here</a> to cancel.

                                                                                <br/>
                                                                                <br/>             
                                                                       
                                                                                Warm regards,<br>
                                                                                Webingate Customer Service Team<br/><br />
</div>
                                                                            </td>
                                                                        </tr>

                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                    </table>";


                        mail.Body = verifcodeMail;
                        //SmtpServer.Port = 465;
                        //SmtpServer.Port = 587;
                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, pwd);
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                        SmtpServer.Send(mail);
                        //Status = 1;

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    #endregion transaction otp


                }
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
            return dt;
        }

        [HttpPost]
        [Route("api/TransactionMaster/TotpVerification")]
        public DataTable TotpVerification(TransDetails tdd)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();            
           
            try
            {

               conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdTransactionOtp";

                cmd.Connection = conn;


                SqlParameter q1 = new SqlParameter("@Id", SqlDbType.Int);
                q1.Value = tdd.Id;
                cmd.Parameters.Add(q1);

                SqlParameter tms = new SqlParameter("@TransmasterId", SqlDbType.Int);
                tms.Value = tdd.TransmasterId;
                cmd.Parameters.Add(tms);

                SqlParameter e = new SqlParameter("@TOtp", SqlDbType.VarChar, 10);
                e.Value = tdd.Totp;
                cmd.Parameters.Add(e);


                SqlDataAdapter ds = new SqlDataAdapter(cmd);
                ds.Fill(dt);           
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                
                throw ex;                
            }            

            return dt;

        }
    }
}
