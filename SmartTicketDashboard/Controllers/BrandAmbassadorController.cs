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
    public class BrandAmbassadorController : ApiController
    {
        [HttpGet]
        [Route("api/BrandAmbassador/Getbrandusers")]
        public DataTable Getbrandusers(int Id)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBrandambassador";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/BrandAmbassador/Getbranddetails")]
        public DataSet Getbranddetails(int Id)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Getbrandambassdordetails";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.Connection = conn;

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);


            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
            return ds;
        }


        [HttpPost]
        [Route("api/BrandAmbassador/SaveBrandAmbassador")]
        public DataTable SaveBrandAmbassador(brand b)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelBrandAmbassador";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = b.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = b.Id;
                cmd.Parameters.Add(i);

                SqlParameter di = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                di.Value = b.firstname;
                cmd.Parameters.Add(di);

                SqlParameter n = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                n.Value = b.lastname;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@Address", SqlDbType.VarChar, 50);
                r.Value = b.Address;
                cmd.Parameters.Add(r);

                SqlParameter f = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
                f.Value = b.middlename;
                cmd.Parameters.Add(f);

                SqlParameter s = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 50);
                s.Value = b.contact1;
                cmd.Parameters.Add(s);

                SqlParameter g = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 50);
                g.Value = b.contact2;
                cmd.Parameters.Add(g);

                SqlParameter j = new SqlParameter("@Email", SqlDbType.VarChar, 255);
                j.Value = b.email;
                cmd.Parameters.Add(j);

                SqlParameter fr = new SqlParameter("@category", SqlDbType.VarChar, 50);
                fr.Value = b.category;
                cmd.Parameters.Add(fr);

                SqlParameter lk = new SqlParameter("@Gender", SqlDbType.Int);
                lk.Value = b.gender;
                cmd.Parameters.Add(lk);

                SqlParameter ed = new SqlParameter("@Photo", SqlDbType.VarChar);
                ed.Value = b.Photo;
                cmd.Parameters.Add(ed);

                SqlParameter dc = new SqlParameter("@DOJ", SqlDbType.DateTime);
                dc.Value = b.DOJ;
                cmd.Parameters.Add(dc);

                SqlParameter pr = new SqlParameter("@EffectiveDate", SqlDbType.DateTime);
                pr.Value = b.EffectiveDate;
                cmd.Parameters.Add(pr);

                SqlParameter cdd = new SqlParameter("@Active", SqlDbType.Int);
                cdd.Value = b.Active;
                cmd.Parameters.Add(cdd);

                SqlParameter ctt = new SqlParameter("@CountryId", SqlDbType.Int);
                ctt.Value = b.CountryId;
                cmd.Parameters.Add(ctt);

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
