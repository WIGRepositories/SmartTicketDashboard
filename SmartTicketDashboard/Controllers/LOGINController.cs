using SmartTicketDashboard;
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
using System.Net.Mail;

namespace SmartTicketDashboard.Controllers
{
    public class LOGINController : ApiController
    {
        [HttpPost]

        public DataTable ValidateCredentials(UserLogin u)
        {
            DataTable Tbl = new DataTable();

            string username = u.LoginInfo;
            string pwd = u.Passkey;

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Validating credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString = "Data Source=localhost;Initial Catalog=POSDashboard;UserID=admin;Password=admin";
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ValidateCredentials";

            cmd.Connection = conn;

            SqlParameter lUserName = new SqlParameter("@logininfo", SqlDbType.VarChar, 50);           
            lUserName.Value = username;
            lUserName.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(lUserName);


            SqlParameter lPassword = new SqlParameter("@passkey", SqlDbType.VarChar, 50); 
            lPassword.Value = pwd;
            lPassword.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(lPassword);
            //System.Threading.Thread.Sleep(10000);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Tbl);

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Validate Credentials completed.");
            
            return Tbl;

        }

    [HttpGet]
        public DataTable RetrivePassword(string email) {
        
        DataTable Tbl = new DataTable();
        SqlConnection conn = new SqlConnection();
        LogTraceWriter traceWriter = new LogTraceWriter();

            try
            {                
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Retriving password....");

                //connect to database

                //connetionString = "Data Source=localhost;Initial Catalog=POSDashboard;User ID=admin;Password=admin";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.RetrivePassword";

                cmd.Connection = conn;

                SqlParameter lUserName = new SqlParameter("@email", SqlDbType.VarChar, 50);
                lUserName.Value = email;
                lUserName.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(lUserName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Tbl);

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Retrive password completed.");
                if (Tbl.Rows.Count == 1)
                { 
                    //send the email and return success
                   
                        MailMessage mail = new MailMessage();
                        string emailserver = System.Configuration.ConfigurationManager.AppSettings["emailserver"].ToString();

                        string username = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                        string pwd = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                        string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"].ToString();
                        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();
                       string  emailAddress = email;

                        SmtpClient SmtpServer = new SmtpClient(emailserver);

                        mail.From = new MailAddress(fromaddress);
                        mail.To.Add(fromaddress);
                        mail.Subject = "Email Address verification";
                        mail.IsBodyHtml = true;

                        string mailContent = @"<table>
                                                    <tr>
                                                        <td>
                                                            <h2>Thank you for registering your email-id with INTERBUS</h2>
                                                            <table width=\""760\"" align=\""center\"">
                                                                <tbody style='background-color:#F0F8FF;'>
                                                                    <tr>
                                                                        <td style=\""font-family: 'Zurich BT',Arial,Helvetica,sans-serif; font-size: 15px; text-align: left; line-height: normal; background-color: #f0f8ff; \"">
<div style='padding:10px;border:#0000FF solid 2px;'>
Dear Mr AAAAABBBB<br><br>
                                                                            <h3>Congratulations!!</h3> <h4>We have successfully registered your email id <a href='http://154.120.237.198:52800' target='_blank'>user@gmail.com</a></h4><br/>
                                                                            We thank you for your support and look forward to sending you important information regarding your account and travel on your registered email id. <br><br>
                                                                            For any queries call us on <b>1000-000-0000</b>, (Monday to Friday, 10am to 7pm except national holidays).   <br /  <br /> 
                                                        Alternatively, write to us at <a href='http://154.120.237.198:52800' target='_blank'>admin@interbus.com</a> with your user name or email address or mobile number.                         
                                                                            <br /> <br />
                                                                            Warm regards,<br/>
                                                                            INTERBUS Customer Service Team<br /><br />
</div>
                                                                        </td>
                                                                    </tr>

                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                </table>";
                        mail.Body = mailContent;
                        //SmtpServer.Port = 465;
                        //SmtpServer.Port = 587;
                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, pwd);
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                        SmtpServer.Send(mail);
                }
                if (Tbl.Rows.Count > 1)
                {
                    throw new Exception("Multiple users found");
                }
                return Tbl;
            }
            catch (Exception ex)
            { 
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error during retrive password:." + ex.Message);
               // return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw ex;
            }

          
        }
         public void Options() { }



         public string connetionString { get; set; }
    }
}
