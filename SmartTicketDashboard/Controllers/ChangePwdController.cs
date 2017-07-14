using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;
using System.Data;

namespace SmartTicketDashboard.Controllers
{
    public class ChangePwdController : ApiController
    {
        [HttpPost]
        [Route("api/ChangePwd/change")]
        public int change(UserAccount U)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSChangePwd";

            cmd.Connection = conn;



            SqlParameter b1 = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 20);
            b1.Value = U.Mobilenumber;
            cmd.Parameters.Add(b1);

            SqlParameter e = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            e.Value = U.Email;
            cmd.Parameters.Add(e);


            SqlParameter m = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            m.Value = U.Password;
            cmd.Parameters.Add(m);

            SqlParameter m1 = new SqlParameter("@NewPassword", SqlDbType.VarChar, 50);
            m1.Value = U.NewPassword;
            cmd.Parameters.Add(m1);




            conn.Open();
            int status = cmd.ExecuteNonQuery();

            conn.Close();
            return status;

            //Verify Passwordotp

        }
    }
}
