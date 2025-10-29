using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ELHelper;
using System.Data;
using System.Web;
using System.Configuration;

namespace DataLayer
{
    public class FoodDetailDL
    {
        ApiResponse objApiResponse = new ApiResponse();
        public ApiResponse AddFoodDetail(FoodDetail para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[12];
            try
            {
                parameter[0] = new LbSprocParameter("@Title", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Title);
                parameter[1] = new LbSprocParameter("@Description", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Description);
                parameter[2] = new LbSprocParameter("@Price", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.Price);
                parameter[3] = new LbSprocParameter("@DiscountPrice", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.DiscountPrice);
                parameter[4] = new LbSprocParameter("@FoodCategoryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.FoodCategoryID);
                parameter[5] = new LbSprocParameter("@Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.Quantity);
                parameter[6] = new LbSprocParameter("@FoodType", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.FoodType);
                //parameter[7] = new LbSprocParameter("@images", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.images);
                parameter[7] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, true);
                parameter[8] = new LbSprocParameter("@SearchTag", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SearchTag);
                parameter[9] = new LbSprocParameter("@SpecialFoodID", DbType.Byte, LbSprocParameter.LbParameterDirection.INPUT, para.SpecialFoodID);
                parameter[10] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[11] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
                //parameter[12] = new LbSprocParameter("@ApplyToAll", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.ApplyToAll);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_InsertFoodDetail", parameter);
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
        public ApiResponse UpdateFoodDetail(FoodDetail para)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[13];
            try
            {
                parameter[0] = new LbSprocParameter("@FoodID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.FoodID);
                parameter[1] = new LbSprocParameter("@Title", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Title);
                parameter[2] = new LbSprocParameter("@Description", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Description);
                parameter[3] = new LbSprocParameter("@Price", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.Price);
                parameter[4] = new LbSprocParameter("@DiscountPrice", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, para.DiscountPrice);
                parameter[5] = new LbSprocParameter("@FoodCategoryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.FoodCategoryID);
                parameter[6] = new LbSprocParameter("@Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.Quantity);
                parameter[7] = new LbSprocParameter("@FoodType", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.FoodType);
                //parameter[8] = new LbSprocParameter("@images", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.images);
                parameter[8] = new LbSprocParameter("@IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.IsActive);
                parameter[9] = new LbSprocParameter("@SearchTag", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.SearchTag);
                parameter[10] = new LbSprocParameter("@SpecialFoodID", DbType.Byte, LbSprocParameter.LbParameterDirection.INPUT, para.SpecialFoodID);
                parameter[11] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
                parameter[12] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
                //parameter[13] = new LbSprocParameter("@ApplyToAll", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.ApplyToAll);
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_UpdateFoodDetail", parameter);
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
        public ApiResponse GetFoodDetail(int RestaurantID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurantID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetFoodDetail", parameter);
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
        public ApiResponse DeleteFoodDetail(int FoodID)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[1];

            parameter[0] = new LbSprocParameter("@FoodID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, FoodID);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                objApiResponse.Result = elHelper.ExecuteScalar("usp_DeleteFoodDetail", parameter);
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
        public ApiResponse GetFoodDetailById(int FoodID, int RestaurentId= 0)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];

            parameter[0] = new LbSprocParameter("@FoodID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, FoodID);
            parameter[1] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RestaurentId);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                objApiResponse.Result = ds = elHelper.ExecuteDataset("usp_GetFoodDetailById", parameter);
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



        public ApiResponse GetFoodDetailByName(FoodDetail objFoodDetail)
        {
            LbSprocParameter[] parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objFoodDetail.RestaurantID);
            parameter[1] = new LbSprocParameter("@FoodName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objFoodDetail.Title);
            try
            {
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();

                ds = elHelper.ExecuteDataset("usp_GetFoodDetailByName", parameter);
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
            catch (Exception ex)
            {
                objApiResponse.Result = ex.InnerException;
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = ex.HResult;

            }
            return objApiResponse;
        }
        //        if (ds != null)
        //        {
        //            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //            {
        //                objApiResponse.Message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
        //                objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
        //            }
        //            if (ds.Tables.Count > 1)
        //            {
        //                if (ds.Tables[1].Rows.Count>0)
        //                {
        //                    objApiResponse.Result = ds.Tables[1];
        //                }
        //                else
        //                {
        //                    objApiResponse.Message = "No record Found.";
        //                    objApiResponse.StatusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objApiResponse.Result = ex.InnerException;
        //        objApiResponse.Message = ex.Message;
        //        objApiResponse.StatusCode = ex.HResult;
        //        //throw ex;
        //    }
        //    return objApiResponse;
        //}


        public ApiResponse GetFoodDetailByCategoryId(FoodDetail objRestaurant)
        {
            string ResponseMessage = string.Empty;
            int ResponseCode = 0;
            LbSprocParameter[] parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@FoodCategoryID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRestaurant.FoodCategoryID);

            try
            {
                //IEnumerable<FoodDetail> FoodDetaillist = null;

                //DataTable dtFoodDetail = new DataTable();
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                DataSet ds = new DataSet();
                FoodDetailDL objRestaurantDL = new FoodDetailDL();


                int FoodCategoryID = 0;

                ds = elHelper.ExecuteDataset("usp_GetFoodDetailByCategoryId", parameter);

                //objApiResponse = objRestaurantDL.GetFoodDetailByCategoryId(objRestaurant);

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