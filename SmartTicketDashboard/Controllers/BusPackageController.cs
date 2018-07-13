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
    public class BusPackageController : ApiController
    {
        [Route("api/BusPackage/GetBusPackage")]
        public DataTable GetBusPackage()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBusPackages";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/BusPackage/GetBusPackagePricing")]
        public DataTable GetBusPackagePricing()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBusPackagePricing";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }


        [Route("api/BusPackage/SaveBuspackages")]
        public DataTable SavePackageCharges(Buspackages pc)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelBusPackages";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(pc.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(pc.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PackageName";
            Title.SqlDbType = SqlDbType.VarChar;
            Title.Value = Convert.ToString(pc.PackageName);
            cmd.Parameters.Add(Title);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(pc.Description);
            cmd.Parameters.Add(Description);

            SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@OpId";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(pc.OpId);
            cmd.Parameters.Add(Type);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@VehicleGroupId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(pc.VehicleGroupId);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@VehicleTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(pc.VehicleTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@RouteId";
            Value.SqlDbType = SqlDbType.Int;
            Value.Value = Convert.ToString(pc.RouteId);
            cmd.Parameters.Add(Value);

            SqlParameter FromDate = new SqlParameter();
            FromDate.ParameterName = "@FleetOwnerId";
            FromDate.SqlDbType = SqlDbType.Int;
            FromDate.Value = Convert.ToString(pc.FleetOwnerId);
            cmd.Parameters.Add(FromDate);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(pc.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

        [Route("api/BusPackage/SaveBuspackagePricing")]
        public DataTable SaveBuspackagePricing(Buspackagepricing pp)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelBusPackagePricing";
            
            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(pp.Id);
            cmd.Parameters.Add(Id);
          

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PkgId";
            Title.SqlDbType = SqlDbType.Int;
            Title.Value = Convert.ToString(pp.PackageId);
            cmd.Parameters.Add(Title);

            SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@RouteId";
            Value.SqlDbType = SqlDbType.Int;
            Value.Value = Convert.ToString(pp.RouteId);
            cmd.Parameters.Add(Value);

           

            SqlParameter SrcStopId = new SqlParameter();
            SrcStopId.ParameterName = "@SrcStopId";
            SrcStopId.SqlDbType = SqlDbType.Int;
            SrcStopId.Value = Convert.ToString(pp.SrcStopId);
            cmd.Parameters.Add(SrcStopId);

            SqlParameter DeststopId = new SqlParameter();
            DeststopId.ParameterName = "@DeststopId";
            DeststopId.SqlDbType = SqlDbType.Int;
            DeststopId.Value = Convert.ToString(pp.DeststopId);
            cmd.Parameters.Add(DeststopId);

            SqlParameter PricingTypeId = new SqlParameter();
            PricingTypeId.ParameterName = "@PricingTypeId";
            PricingTypeId.SqlDbType = SqlDbType.Int;
            PricingTypeId.Value = Convert.ToString(pp.PricingTypeId);
            cmd.Parameters.Add(PricingTypeId);

            SqlParameter UnitTypeId = new SqlParameter();
            UnitTypeId.ParameterName = "@UnitTypeId";
            UnitTypeId.SqlDbType = SqlDbType.Int;
            UnitTypeId.Value = Convert.ToString(pp.UnitTypeId);
            cmd.Parameters.Add(UnitTypeId);

            SqlParameter UnitPrice = new SqlParameter();
            UnitPrice.ParameterName = "@UnitPrice";
            UnitPrice.SqlDbType = SqlDbType.Decimal;
            UnitPrice.Value = Convert.ToString(pp.UnitPrice);
            cmd.Parameters.Add(UnitPrice);

            SqlParameter Amount = new SqlParameter();
            Amount.ParameterName = "@Amount";
            Amount.SqlDbType = SqlDbType.Decimal;
            Amount.Value = Convert.ToString(pp.Amount);
            cmd.Parameters.Add(Amount);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(pp.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(pp.Description);
            cmd.Parameters.Add(Description);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@VehicleGroupId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(pp.VehicleGroupId);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@VehicleTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(pp.VehicleTypeId);
            cmd.Parameters.Add(ApplyAs);

             SqlParameter UnitId = new SqlParameter();
            UnitId.ParameterName = "@UnitId";
            UnitId.SqlDbType = SqlDbType.Int;
            UnitId.Value = Convert.ToString(pp.UnitId);
            cmd.Parameters.Add(UnitId);

            SqlParameter FromValue = new SqlParameter();
            FromValue.ParameterName = "@FromValue";
            FromValue.SqlDbType = SqlDbType.Int;
            FromValue.Value = Convert.ToString(pp.FromValue);
            cmd.Parameters.Add(FromValue);

            SqlParameter ToValue = new SqlParameter();
            ToValue.ParameterName = "@ToValue";
            ToValue.SqlDbType = SqlDbType.Int;
            ToValue.Value = Convert.ToString(pp.ToValue);
            cmd.Parameters.Add(ToValue);

            SqlParameter EffectiveDate = new SqlParameter();
            EffectiveDate.ParameterName = "@EffectiveDate";
            EffectiveDate.SqlDbType = SqlDbType.DateTime;
            EffectiveDate.Value = Convert.ToString(pp.EffectiveDate);
            cmd.Parameters.Add(EffectiveDate);

            SqlParameter ExpiryDate = new SqlParameter();
            ExpiryDate.ParameterName = "@ExpiryDate";
            ExpiryDate.SqlDbType = SqlDbType.DateTime;
            ExpiryDate.Value = Convert.ToString(pp.ExpiryDate);
            cmd.Parameters.Add(ExpiryDate);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(pp.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }
    }
}
