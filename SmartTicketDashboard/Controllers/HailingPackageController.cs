using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class HailingPackageController : ApiController
    {
        [Route("api/HailingPackage/GetHailingPackage")]
        public DataTable GetHailingPackage()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetHailingPackages";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }
        [Route("api/HailingPackage/GetHailingPackagePricing")]
        public DataTable GetMeteredTaxiPackagePricing()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetHailingPackagePricing";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/HailingPackage/SaveHailingPackages")]
        public DataTable SaveHailingPackages(HailingPackages ph)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelHailingPackage";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(ph.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(ph.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PackageName";
            Title.SqlDbType = SqlDbType.VarChar;
            Title.Value = Convert.ToString(ph.PackageName);
            cmd.Parameters.Add(Title);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(ph.Description);
            cmd.Parameters.Add(Description);

            SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@OpId";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(ph.OpId);
            cmd.Parameters.Add(Type);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@VehicleGroupId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(ph.VehicleGroupId);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@VehicleTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(ph.VehicleTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(ph.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

        [Route("api/HailingPackage/SaveHailingPackagePricing")]
        public DataTable SaveBuspackagePricing(HailingPackagepricing mp)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelHailingPackagePricings";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(mp.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(mp.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(mp.Description);
            cmd.Parameters.Add(Description);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@VehicleGroupId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(mp.VehicleGroupId);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@VehicleTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(mp.VehicleTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter PricingTypeId = new SqlParameter();
            PricingTypeId.ParameterName = "@PricingTypeId";
            PricingTypeId.SqlDbType = SqlDbType.Int;
            PricingTypeId.Value = Convert.ToString(mp.PricingTypeId);
            cmd.Parameters.Add(PricingTypeId);

            SqlParameter UnitTypeId = new SqlParameter();
            UnitTypeId.ParameterName = "@UnitTypeId";
            UnitTypeId.SqlDbType = SqlDbType.Int;
            UnitTypeId.Value = Convert.ToString(mp.UnitTypeId);
            cmd.Parameters.Add(UnitTypeId);

            SqlParameter UnitId = new SqlParameter();
            UnitId.ParameterName = "@UnitId";
            UnitId.SqlDbType = SqlDbType.Int;
            UnitId.Value = Convert.ToString(mp.UnitId);
            cmd.Parameters.Add(UnitId);

            SqlParameter Amount = new SqlParameter();
            Amount.ParameterName = "@Amount";
            Amount.SqlDbType = SqlDbType.Decimal;
            Amount.Value = Convert.ToString(mp.Amount);
            cmd.Parameters.Add(Amount);          

            SqlParameter FromValue = new SqlParameter();
            FromValue.ParameterName = "@FromValue";
            FromValue.SqlDbType = SqlDbType.Int;
            FromValue.Value = Convert.ToString(mp.FromValue);
            cmd.Parameters.Add(FromValue);

            SqlParameter ToValue = new SqlParameter();
            ToValue.ParameterName = "@ToValue";
            ToValue.SqlDbType = SqlDbType.Int;
            ToValue.Value = Convert.ToString(mp.ToValue);
            cmd.Parameters.Add(ToValue);

            SqlParameter EffectiveDate = new SqlParameter();
            EffectiveDate.ParameterName = "@EffectiveDate";
            EffectiveDate.SqlDbType = SqlDbType.DateTime;
            EffectiveDate.Value = Convert.ToString(mp.EffectiveDate);
            cmd.Parameters.Add(EffectiveDate);

            SqlParameter ExpiryDate = new SqlParameter();
            ExpiryDate.ParameterName = "@ExpiryDate";
            ExpiryDate.SqlDbType = SqlDbType.DateTime;
            ExpiryDate.Value = Convert.ToString(mp.ExpiryDate);
            cmd.Parameters.Add(ExpiryDate);

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PkgId";
            Title.SqlDbType = SqlDbType.Int;
            Title.Value = Convert.ToString(mp.PackageId);
            cmd.Parameters.Add(Title);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(mp.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }
    }
}
