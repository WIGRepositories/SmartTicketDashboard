using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using System.Web.Http.Tracing;


namespace SmartTicketDashboard.Controllers
{
    public class SOSMessageController : ApiController
    {
        [HttpGet]
        [Route("api/GetSOSMessage")]
        public DataTable GetSOSMessage(int utypeId, int userId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0",TraceLevel.Info, "{0}", "GetSOSMessage ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetSOSMessages";
            cmd.Parameters.Add("@UserTypeId", SqlDbType.Int).Value = utypeId;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            cmd.Connection = conn;

            //DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetSOSMessage completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/SOSMessage/SOSVerification")]
        public DataTable SOSVerification(SOSMessage sos)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SOSVerification ...");

            //connect to database
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {

                str.Append("UserTypeId:" + sos.UserTypeId + ",");
                str.Append("UserId:" + sos.UserId + ",");

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());
               
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SOSotpverification";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter id = new SqlParameter();
                id.ParameterName = "@Mobilenumber";
                id.SqlDbType = SqlDbType.VarChar;
                id.Value = sos.Mobilenumber;
                cmd.Parameters.Add(id);

                SqlParameter UserId = new SqlParameter();
                UserId.ParameterName = "@Otp";
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = sos.Otp;
                cmd.Parameters.Add(UserId);

                SqlParameter ustid = new SqlParameter();
                ustid.ParameterName = "@UserTypeId";
                ustid.SqlDbType = SqlDbType.Int;
                ustid.Value = sos.UserTypeId;
                cmd.Parameters.Add(ustid);


                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SOSVerification  completed.");

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string st = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SOSVerification:" + ex.Message);

            }
            return dt;
        }



        [HttpPost]
        [Route("api/SOSMessage/SaveSOSMessage")]
        public DataTable SaveSOSMessage(SOSMessage sos)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSOSMessage ...");

            //connect to database
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            StringBuilder str = new StringBuilder();
            try
            {

                str.Append("UserTypeId:" + sos.UserTypeId + ",");
                str.Append("UserId:" + sos.UserId + ",");

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Input sent...." + str.ToString());
                
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelSOSMessage";
                cmd.Connection = conn;
                conn.Open();

                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@flag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = sos.flag;
                cmd.Parameters.Add(flag);

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@Id";
                id.SqlDbType = SqlDbType.Int;
                id.Value = sos.Id;
                cmd.Parameters.Add(id);

                SqlParameter UserId = new SqlParameter();
                UserId.ParameterName = "@UserId";
                UserId.SqlDbType = SqlDbType.Int;
                UserId.Value = sos.UserId;
                cmd.Parameters.Add(UserId);

                SqlParameter ustid = new SqlParameter();
                ustid.ParameterName = "@UserTypeId";
                ustid.SqlDbType = SqlDbType.Int;
                ustid.Value = sos.UserTypeId;
                cmd.Parameters.Add(ustid);

                SqlParameter SentTo = new SqlParameter();
                SentTo.ParameterName = "@SentTo";
                SentTo.SqlDbType = SqlDbType.VarChar;
                SentTo.Value = sos.SentTo;
                cmd.Parameters.Add(SentTo);

                SqlParameter MessageId = new SqlParameter();
                MessageId.ParameterName = "@MessageId";
                MessageId.SqlDbType = SqlDbType.Int;
                MessageId.Value = sos.MessageId;
                cmd.Parameters.Add(MessageId);

                SqlParameter msg = new SqlParameter();
                msg.ParameterName = "@Message";
                msg.SqlDbType = SqlDbType.VarChar;
                msg.Value = sos.Message;
                cmd.Parameters.Add(msg);

                SqlParameter SentOn = new SqlParameter();
                SentOn.ParameterName = "@SentOn";
                SentOn.SqlDbType = SqlDbType.DateTime;
                SentOn.Value = sos.SentOn;
                cmd.Parameters.Add(SentOn);

                SqlParameter SentTime = new SqlParameter();
                SentTime.ParameterName = "@SentTime";
                SentTime.SqlDbType = SqlDbType.Time;
                SentTime.Value = sos.SentTime;
                cmd.Parameters.Add(SentTime);

                SqlParameter Status = new SqlParameter();
                Status.ParameterName = "@StatusId";
                Status.SqlDbType = SqlDbType.Int;
                Status.Value = sos.StatusId;
                cmd.Parameters.Add(Status);



                SqlParameter UpdatedBy = new SqlParameter();
                UpdatedBy.ParameterName = "@UpdatedBy";
                UpdatedBy.SqlDbType = SqlDbType.Int;
                UpdatedBy.Value = sos.UpdatedBy;
                cmd.Parameters.Add(UpdatedBy);

                SqlParameter Lat = new SqlParameter("@Latitude", SqlDbType.Float);
                Lat.Value = sos.Latitude;
                cmd.Parameters.Add(Lat);

                SqlParameter Lng = new SqlParameter("@Longitude", SqlDbType.Float);
                Lng.Value = sos.Longitude;
                cmd.Parameters.Add(Lng);

                SqlDataAdapter ds = new SqlDataAdapter(cmd);
                ds.Fill(dt);

                #region SOS opt
                string sotp = dt.Rows[0]["Otp"].ToString();
                if (sotp != null)
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
                        mail.Subject = "User registration - Email OTP";
                        mail.IsBodyHtml = true;

                        string verifcodeMail = @"<table>
                                                        <tr>
                                                            <td>
                                                                <h2>Your SOS Message Otp</h2>
                                                                <table width=\""760\"" align=\""center\"">
                                                                    <tbody style='background-color:#F0F8FF;'>
                                                                        <tr>
                                                                            <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#F0F8FF;\"" >
<div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />
                                                                             
                                                       Your SOS OTP is:<h3>" + sotp + @" </h3>

                                                        If you didn't make this request, <a href='http://154.120.237.198:52800'>click here</a> to cancel.

                                                                                <br/>
                                                                                <br/>             
                                                                       
                                                                                Warm regards,<br>
                                                                                PAYSMART Customer Service Team<br/><br />
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

                    }
                    catch (Exception ex)
                    {
                        //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                    }

                }

                //send mobile otp


                // return dt;

                #endregion email otp
                //  traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandUserDocs  completed.");

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string st = ex.Message;

                //traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveMandUserDocs:" + ex.Message);

            }
            return dt;
        }
    }
}
