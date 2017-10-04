using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
namespace SmartTicketDashboard.Controllers
{
    public class ChargesDiscountsController : ApiController
    {
        [Route("api/GetAllChargesDiscounts")]
        public DataTable GetAllChargesDiscounts ()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection=conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetChargesDiscounts";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }
        [Route("api/SaveChargesDiscounts")]
        public DataTable SaveChargesDiscounts(ChargesDiscounts cd)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelChargesDiscounts";

                SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(cd.Id);
            cmd.Parameters.Add(Id);

               SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(cd.Code);
            cmd.Parameters.Add(Code);

              SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@Title";
            Title.SqlDbType = SqlDbType.VarChar;
            Title.Value = Convert.ToString(cd.Title);
            cmd.Parameters.Add(Title);
           
            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(cd.Description);
            cmd.Parameters.Add(Description);

             SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@Type";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(cd.cdType);
            cmd.Parameters.Add(Type);

             SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@Category";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(cd.Category);
            cmd.Parameters.Add(Category);

             SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@ApplyAs";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(cd.ApplyAs);
            cmd.Parameters.Add(ApplyAs);

             SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@Value";
            Value.SqlDbType = SqlDbType.Int;
            Value.Value = Convert.ToString(cd.cdValue);
            cmd.Parameters.Add(Value);

             SqlParameter FromDate = new SqlParameter();
            FromDate.ParameterName = "@FromDate";
            FromDate.SqlDbType = SqlDbType.Date;
            FromDate.Value = Convert.ToString(cd.FromDate);
            cmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.ParameterName = "@ToDate";
            ToDate.SqlDbType = SqlDbType.Date;
            ToDate.Value = Convert.ToString(cd.ToDate);
            cmd.Parameters.Add(ToDate);

             SqlParameter Flag  = new SqlParameter();
            Flag .ParameterName = "@Flag ";
            Flag .SqlDbType = SqlDbType.VarChar;
            Flag .Value = Convert.ToString(cd.Flag );
            cmd.Parameters.Add(Flag );

           
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

    }
}
