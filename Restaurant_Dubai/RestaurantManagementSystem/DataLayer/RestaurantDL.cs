
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ELHelper;
using System.Data;
namespace DataLayer
{
    public class RestaurantDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddRestaurant(Restaurant para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[14];
            try
            {
                parameter[0] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Name);
                parameter[1] = new LbSprocParameter("@Logo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Logo);
                parameter[2] = new LbSprocParameter("@MAP", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.MAP);
                parameter[3] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[4] = new LbSprocParameter("@Contact", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Contact);
                //parameter[5] = new LbSprocParameter("@Policy", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Policy);
                parameter[5] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[6] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[7] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StateID);
                parameter[8] = new LbSprocParameter("@CityID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CityID);
                parameter[9] = new LbSprocParameter("@TimeFrom", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TimeFrom);
                parameter[10] = new LbSprocParameter("@TimeTo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TimeTo);
                parameter[11] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[12] = new LbSprocParameter("@ParentBranchID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ParentBranchID);
                parameter[13] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result=elHelper.ExecuteScalar("usp_InsertRestaurant", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
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

        public ApiResponse UpdateRestaurant(Restaurant para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[15];
            try
            {
                parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[1] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Name);
                parameter[2] = new LbSprocParameter("@Logo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Logo);
                parameter[3] = new LbSprocParameter("@MAP", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.MAP);
                parameter[4] = new LbSprocParameter("@Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Address);
                parameter[5] = new LbSprocParameter("@Contact", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Contact);
                //parameter[6] = new LbSprocParameter("@Policy", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Policy);
                parameter[6] = new LbSprocParameter("@Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Email);
                parameter[7] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CountryID);
                parameter[8] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StateID);
                parameter[9] = new LbSprocParameter("@CityID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CityID);
                parameter[10] = new LbSprocParameter("@TimeFrom", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TimeFrom);
                parameter[11] = new LbSprocParameter("@TimeTo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.TimeTo);
                parameter[12] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, para.Status);
                parameter[13] = new LbSprocParameter("@ParentBranchID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ParentBranchID);
                parameter[14] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result=elHelper.ExecuteScalar("usp_UpdateRestaurant", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
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

        public ApiResponse GetRestaurant()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                //DataSet ds = new DataSet();
                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetRestaurant", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
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

        public ApiResponse DeleteRestaurant(int RestaurantID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteRestaurant", parameter);
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

        public ApiResponse GetRestaurantById(int RestaurantID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds =elHelper.ExecuteDataset("usp_GetRestaurantById", parameter);
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

        public ApiResponse GetRestaurantContactUs(Restaurant objRestaurant)
        {
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurant.RestaurantID);

            try
            {

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                RestaurantDL objRestaurantDL = new RestaurantDL();


                int RestaurantID = 0;
                ds = elHelper.ExecuteDataset("usp_GetRestaurantContactUs", parameter);

                if (ds != null)
                {
                    if (ds.Tables.Count > 1)
                    {

                     objApiResponse.Result = ds.Tables[1];
                    }
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
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

        public ApiResponse GetRestaurantCMS(CMS objCMS)
        {
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            LbSprocParameter[] parameter = new LbSprocParameter[2];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCMS.RestaurantID);
            parameter[1] = new LbSprocParameter("@CMSTypeID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCMS.CMSTypeID);

            try
            {

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
               
                ds = elHelper.ExecuteDataset("usp_GetRestaurantCMS", parameter);

                if (ds != null)
                {
                    if (ds.Tables.Count > 1)
                    {

                        objApiResponse.Result = ds.Tables[1];
                    }
                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                }
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

        public ApiResponse GetStateByCountryID(int CountryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@CountryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CountryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetStateByCountryID", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {

                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

        public ApiResponse GetCityByStateID(int StateID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@StateID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, StateID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();

                objApiResponse.Result = elHelper.ExecuteDataset("usp_GetCityByStateID", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
            }
            catch (Exception ex)
            {

                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;
            }
            return objApiResponse;
        }

    }
}




