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
    public class ScheduleController : ApiController
    {


        [HttpGet]
        [Route("api/Schedule/GetSchedulelist")]

        public DataTable GetSchedulelist(int Id)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetSchedulelist";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter("@Id", SqlDbType.Int);
            cmpid.Value = Id;
            cmd.Parameters.Add(cmpid);

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }


        [HttpPost]
        [Route("api/Schedule/Schedulelist")]

        public DataTable Schedulelist(Schedule s)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelScheduleList";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = s.flag;
                cmd.Parameters.Add(ff);

                SqlParameter f = new SqlParameter("@Id", SqlDbType.Int);
                f.Value = s.Id;
                cmd.Parameters.Add(f);


                SqlParameter mn = new SqlParameter("@Src", SqlDbType.VarChar);
                mn.Value = s.Src;
                cmd.Parameters.Add(mn);

                SqlParameter em = new SqlParameter("@Dest", SqlDbType.VarChar);
                em.Value = s.Dest;
                cmd.Parameters.Add(em);


                SqlParameter St = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
                St.Value =s.VehicleGroupId;
                cmd.Parameters.Add(St);

                SqlParameter vtt = new SqlParameter("@VehicleTypeId", SqlDbType.Int);
                vtt.Value = s.VehicleTypeId;
                cmd.Parameters.Add(vtt);

                SqlParameter sss = new SqlParameter("@StatusId", SqlDbType.Int);
                sss.Value = s.StatusId;
                cmd.Parameters.Add(sss);

                SqlParameter sfd = new SqlParameter("@FromDate", SqlDbType.DateTime);
                sfd.Value = s.Fromdate;
                cmd.Parameters.Add(sfd);

                SqlParameter std = new SqlParameter("@ToDate", SqlDbType.DateTime);
                std.Value = s.Todate;
                cmd.Parameters.Add(std);

                SqlParameter ctt = new SqlParameter("@RouteId", SqlDbType.Int);
                ctt.Value = s.RouteId;
                cmd.Parameters.Add(ctt);

                SqlParameter srct = new SqlParameter("@SrcLat", SqlDbType.Decimal);
                srct.Value = s.SrcLat;
                cmd.Parameters.Add(srct);

                SqlParameter srcl = new SqlParameter("@SrcLong", SqlDbType.Decimal);
                srcl.Value = s.SrcLong;
                cmd.Parameters.Add(srcl);

                SqlParameter des = new SqlParameter("@DestLat", SqlDbType.Decimal);
                des.Value = s.DestLat;
                cmd.Parameters.Add(des);

                SqlParameter desl = new SqlParameter("@DestLong", SqlDbType.Decimal);
                desl.Value = s.DestLong;
                cmd.Parameters.Add(desl);
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


        [HttpGet]
        [Route("api/Schedule/GetScheduleTiming")]

        public DataTable GetScheduleTiming()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetScheduleTimings";
            cmd.Connection = conn;

            //SqlParameter cmpid = new SqlParameter("@Id", SqlDbType.Int);
            //cmpid.Value = Id;
            //cmd.Parameters.Add(cmpid);

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }


        [HttpPost]
        [Route("api/Schedule/ScheduleTimings")]

        public DataTable ScheduleTimings(ScheduleTiming st)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelScheduleTimings";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = st.flag;
                cmd.Parameters.Add(ff);

                SqlParameter f = new SqlParameter("@Id", SqlDbType.Int);
                f.Value = st.Id;
                cmd.Parameters.Add(f);


                SqlParameter mn = new SqlParameter("@StopName", SqlDbType.VarChar);
                mn.Value = st.StopName;
                cmd.Parameters.Add(mn);

                SqlParameter em = new SqlParameter("@SDId", SqlDbType.Int);
                em.Value = st.SDId;
                cmd.Parameters.Add(em);
               

                SqlParameter sfd = new SqlParameter("@ArrivalTime", SqlDbType.Time);
                sfd.Value = st.ArrivalTime;
                cmd.Parameters.Add(sfd);

                SqlParameter std = new SqlParameter("@DepartureTime", SqlDbType.Time);
                std.Value = st.DepartureTime;
                cmd.Parameters.Add(std);

               
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
