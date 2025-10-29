
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EntityLayer;
//using ELHelper;
//using System.Data;
//namespace DataLayer
//{
//    public class SpecialFoodDL
//    {
//        public void AddSpecialFood(SpecialFood para)
//        {
//            LbSprocParameter[] parameter = new LbSprocParameter[8];
//            try
//            {
//                parameter[0] = new LbSprocParameter("@SpecialFoodID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.SpecialFoodID);
//                parameter[1] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Name);
//                parameter[2] = new LbSprocParameter("@Desc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Desc);
//                parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
//                parameter[4] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
//                parameter[5] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
//                parameter[6] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
//                parameter[7] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
//                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
//                elHelper.ExecuteNonQuery("usp_InsertSpecialFood", parameter);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        public void UpdateSpecialFood(SpecialFood para)
//        {
//            LbSprocParameter[] parameter = new LbSprocParameter[8];
//            try
//            {
//                parameter[0] = new LbSprocParameter("@SpecialFoodID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.SpecialFoodID);
//                parameter[1] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Name);
//                parameter[2] = new LbSprocParameter("@Desc", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Desc);
//                parameter[3] = new LbSprocParameter("@RestaurantID", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.RestaurantID);
//                parameter[4] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedBy);
//                parameter[5] = new LbSprocParameter("@CreatedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.CreatedDate);
//                parameter[6] = new LbSprocParameter("@ModifiedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedBy);
//                parameter[7] = new LbSprocParameter("@ModifiedDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, para.ModifiedDate);
//                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
//                elHelper.ExecuteNonQuery("usp_UpdateSpecialFood", parameter);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        public List<SpecialFood> GetSpecialFood()
//        {
//            LbSprocParameter[] parameter = new LbSprocParameter[0];
//            List<SpecialFood> SpecialFoodList = null;
//            try
//            {
//                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
//                DataSet ds = new DataSet();
//                ds = elHelper.ExecuteDataset("usp_GetSpecialFood", parameter);
//                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//                {
//                    DataTable dt = ds.Tables[0];
//                    SpecialFood objSpecialFood = null;
//                    SpecialFoodList = new List<SpecialFood>();
//                    for (int i = 0; i < dt.Rows.Count; i++)
//                    {
//                        objSpecialFood = new SpecialFood();
//                        objSpecialFood.SpecialFoodID = Convert.ToInt32(dt.Rows[i]["SpecialFoodID"]);
//                        objSpecialFood.Name = Convert.ToString(dt.Rows[i]["Name"]);
//                        objSpecialFood.Desc = Convert.ToString(dt.Rows[i]["Desc"]);
//                        objSpecialFood.RestaurantID = Convert.ToInt32(dt.Rows[i]["RestaurantID"]);
//                        objSpecialFood.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
//                        objSpecialFood.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
//                        objSpecialFood.ModifiedBy = Convert.ToInt32(dt.Rows[i]["ModifiedBy"]);
//                        objSpecialFood.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
//                        SpecialFoodList.Add(objSpecialFood);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return SpecialFoodList;
//        }
//        public void DeleteSpecialFood(int )
//        {
//            LbSprocParameter[] parameter = new LbSprocParameter[1];

//            parameter[0] = new LbSprocParameter("@", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, );
//            try
//            {
//                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
//                elHelper.ExecuteDataset("usp_DeleteSpecialFood", parameter);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        public SpecialFood GetSpecialFoodById(int )
//        {
//            LbSprocParameter[] parameter = new LbSprocParameter[1];
//            SpecialFood objSpecialFood = null;

//            parameter[0] = new LbSprocParameter("@", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, );
//            try
//            {
//                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
//                DataSet ds = new DataSet();
//                ds=elHelper.ExecuteDataset("usp_GetSpecialFoodById", parameter);
//                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//                {
//                    DataTable dt = ds.Tables[0];
//                    for (int i = 0; i < dt.Rows.Count; i++)
//                    {
//                        objSpecialFood = new SpecialFood();
//                        objSpecialFood.SpecialFoodID = Convert.ToInt32(dt.Rows[i]["SpecialFoodID"]);
//                        objSpecialFood.Name = Convert.ToString(dt.Rows[i]["Name"]);
//                        objSpecialFood.Desc = Convert.ToString(dt.Rows[i]["Desc"]);
//                        objSpecialFood.RestaurantID = Convert.ToInt32(dt.Rows[i]["RestaurantID"]);
//                        objSpecialFood.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
//                        objSpecialFood.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
//                        objSpecialFood.ModifiedBy = Convert.ToInt32(dt.Rows[i]["ModifiedBy"]);
//                        objSpecialFood.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return objSpecialFood;
//        }
//    }
//}