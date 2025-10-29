using ELHelper;
using EntityLayer;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RegisterDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddRegister(Register para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[3];
            try
            {
                parameter[0] = new LbSprocParameter("@RegisterID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RegisterID);
                parameter[1] = new LbSprocParameter("@Username", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Username);
                parameter[2] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);
                //parameter[3] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ConfirmPassword);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertRegister", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                // throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetRegisterById(int RegisterID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RegisterID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RegisterID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                //DataSet ds = new DataSet();
                objApiResponse.Result  = elHelper.ExecuteDataset("usp_GetRegisterId", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                // return ds;
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
                //throw ex;
            }
            return objApiResponse;
        }

        public ApiResponse GetLogin(Register para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                //DataSet ds = new DataSet();
                parameter[0] = new LbSprocParameter("@Username", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Username);
                parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetLogin", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
            }
            catch (Exception ex)
            {

                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        //public class GetLogin
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["intranet"].ConnectionString;
        //    public int CheckUserLogin(Register R)
        //    {
        //        using (SqlConnection conobj = new SqlConnection(constr))
        //        {
        //            SqlCommand comobj = new SqlCommand("usp_GetLogin", conobj);
        //            comobj.CommandType = CommandType.StoredProcedure;
        //            comobj.Parameters.Add(new SqlParameter("@Username", R.Username));
        //            comobj.Parameters.Add(new SqlParameter("@Password", R.Password));
        //            conobj.Open();
        //            return Convert.ToInt32(comobj.ExecuteScalar());
        //        }
        //    }
        //}

    }
}
