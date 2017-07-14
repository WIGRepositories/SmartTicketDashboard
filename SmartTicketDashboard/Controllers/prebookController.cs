using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartTicketDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class prebookController : ApiController
    {

        [HttpGet]
        [Route("api/prebook/Details")]
        public DataTable Details(string PartyName)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetprebooking";
            cmd.Parameters.Add("@PartyName", SqlDbType.VarChar, 255).Value = PartyName;
            cmd.Connection = conn;

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);





            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        [Route("api/prebook/booking")]
        public DataTable booking(book ocr)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prebooking";

            cmd.Connection = conn;

            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = ocr.flag;
            cmd.Parameters.Add(f);


            SqlParameter q = new SqlParameter("@Id", SqlDbType.Int);
            q.Value = ocr.Id;
            cmd.Parameters.Add(q);

            SqlParameter q1 = new SqlParameter("@Username", SqlDbType.VarChar, 50);
            q1.Value = ocr.Username;
            cmd.Parameters.Add(q1);

            SqlParameter c = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 20);
            c.Value = ocr.PhoneNumber;
            cmd.Parameters.Add(c);

            SqlParameter e = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
            e.Value = ocr.EmailId;
            cmd.Parameters.Add(e);



            SqlParameter b = new SqlParameter("@src", SqlDbType.VarChar, 50);
            b.Value = ocr.src;
            cmd.Parameters.Add(b);

            SqlParameter p = new SqlParameter("@dest", SqlDbType.VarChar, 50);
            p.Value = ocr.dest;
            cmd.Parameters.Add(p);

            SqlParameter m = new SqlParameter("@Gender", SqlDbType.VarChar, 50);
            m.Value = ocr.Gender;
            cmd.Parameters.Add(m);

            SqlParameter t = new SqlParameter("@Age", SqlDbType.Int);
            t.Value = ocr.Age;
            cmd.Parameters.Add(t);

            SqlParameter e2 = new SqlParameter("@Blocked", SqlDbType.VarChar, 50);
            e2.Value = ocr.Blocked;
            cmd.Parameters.Add(e2);





            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return (dt);


        }
    }
}
