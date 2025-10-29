
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ELHelper;
using System.Data;
using System.Configuration;

namespace DataLayer
{


    public class FoodCategoryDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddFoodCategory(FoodCategory para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[8];
            try
            {
                parameter[0] = new LbSprocParameter("@CategoryTitle", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CategoryTitle);
                parameter[1] = new LbSprocParameter("@Description", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Description);
                parameter[2] = new LbSprocParameter("@Images", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Images); 
                parameter[3] = new LbSprocParameter("@CuisineID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CuisineID);
                parameter[4] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[5] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                parameter[6] = new LbSprocParameter("@ApplyToAll", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.ApplyToAll);
                parameter[7] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertFoodCategory", parameter);
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
        public ApiResponse UpdateFoodCategory(FoodCategory para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[9];
            try
            {
                parameter[0] = new LbSprocParameter("@FoodCategoryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.FoodCategoryID);
                parameter[1] = new LbSprocParameter("@CategoryTitle", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.CategoryTitle);
                parameter[2] = new LbSprocParameter("@Description", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Description);
                parameter[3] = new LbSprocParameter("@Images", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Images);
                parameter[4] = new LbSprocParameter("@CuisineID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CuisineID);
                parameter[5] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[6] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                parameter[7] = new LbSprocParameter("@ApplyToAll", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.ApplyToAll);
                parameter[8] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateFoodCategory", parameter);
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
        public ApiResponse GetFoodCategory()
        {
            LbSprocParameter[] parameter = new LbSprocParameter[0];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetFoodCategory", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
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
        public ApiResponse DeleteFoodCategory(int FoodCategoryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@FoodCategoryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, FoodCategoryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteFoodCategory", parameter);
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
        public ApiResponse GetFoodCategoryById(int FoodCategoryID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@FoodCategoryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, FoodCategoryID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetFoodCategoryById", parameter);
                objApiResponse.Message = "";
                objApiResponse.StatusCode = 0;
                //return ds;
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
           
        public ApiResponse GetFoodCategoryByRestaurantID(int RestaurantID, bool isAPI=false)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
                if (isAPI)
                {
                    ds = elHelper.ExecuteDataset("usp_GetFoodCategoryByRestaurantID", parameter);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Images"])))
                                {
                                    string url = Convert.ToString(ds.Tables[1].Rows[i]["Images"]);

                                    string SiteUrl = ConfigurationManager.AppSettings["SiteUrl"].ToString();

                                    url = SiteUrl + "Image/FoodDetail/" + url;
                                    ds.Tables[1].Rows[i]["Images"] = url;
                                }
                            }


                            objApiResponse.Result = ds.Tables[1];
                        }

                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    }

                }
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;

            }
            return objApiResponse;
        }

        public ApiResponse GetFoodCategoryByRestaurantIDAPI(RestaurantLogin objRestaurant)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurant.RestaurantID);
                
                {
                    ds = elHelper.ExecuteDataset("usp_GetFoodCategoryByRestaurantIDAPI", parameter);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[1].Rows[i]["Images"])))
                                {
                                    string url = Convert.ToString(ds.Tables[1].Rows[i]["Images"]);

                                    string SiteUrl = ConfigurationManager.AppSettings["SiteUrl"].ToString();

                                    url = SiteUrl + "Image/FoodDetail/" + url;
                                    ds.Tables[1].Rows[i]["Images"] = url;
                                }
                            }


                            objApiResponse.Result = ds.Tables[1];
                        }

                        objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                        objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    }

                }
            }
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;

            }
            return objApiResponse;
        }
        //            if (ds!=null && ds.Tables.Count>0)
        //            {
        //                objApiResponse.Result = ds.Tables[0];
        //                if (ds.Tables.Count>1)
        //                {
        //                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[1].Rows[0]["ResponseCode"]);
        //                    objApiResponse.Message = Convert.ToString(ds.Tables[1].Rows[0]["ResponseMessage"]);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetFoodCategoryByRestaurantID", parameter);
        //            objApiResponse.Message = "";
        //            objApiResponse.StatusCode = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = ex.InnerException;
        //        objApiResponse.Message = ex.Message;
        //        objApiResponse.StatusCode = ex.HResult;
        //    }
        //    return objApiResponse;
        //}

        public ApiResponse GetRestaurantMenus(FoodCategory objRestaurant)
        {
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurant.RestaurantID);

            try
            {

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                FoodCategoryDL objRestaurantDL = new FoodCategoryDL();


                int RestaurantID = 0;
                ds = elHelper.ExecuteDataset("usp_GetRestaurantMenus", parameter);

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


    }
}