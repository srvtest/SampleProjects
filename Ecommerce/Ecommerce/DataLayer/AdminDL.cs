using ELHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AdminDL
    {
        public DataSet AdminLogin(string Username, string Password)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("UserName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Username);
                parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Password);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_AdminLogin", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        public DataSet GetAllCategory()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCategory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int SetCategory(CategoryCls category)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.idCategory);
            parameter[1] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, category.sName);
            parameter[2] = new LbSprocParameter("status", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, category.bStatus);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.Createdby);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.ModifyBy);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_SetCategory", parameter));
            return Response;
        }

        public bool ValidateAdmin(string Email)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_ValidateAdmin", parameter);
                return (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToString(ds.Tables[0].Rows[0][0]) == "1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ResetPassword(string Username, string Password)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("username", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Username);
                parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Password);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_Admin_ResetPassword", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Response;
        }

        public int SaveHomeSliderImage(HomeSliderCls objHomeSliderCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[10];
            parameter[0] = new LbSprocParameter("idHomeSlider", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.idHomeSlider);
            parameter[1] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.sName);
            parameter[2] = new LbSprocParameter("bStatus", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.bStatus);
            parameter[3] = new LbSprocParameter("ImageURL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.ImageURL);
            parameter[4] = new LbSprocParameter("URL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.URL);
            parameter[5] = new LbSprocParameter("isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.isB2B);
            parameter[6] = new LbSprocParameter("sText1", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.sText1);
            parameter[7] = new LbSprocParameter("sText2", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.sText2);
            parameter[8] = new LbSprocParameter("sAlign", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.sAlign);
            parameter[9] = new LbSprocParameter("isShowHide", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objHomeSliderCls.isShowHide);
            
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_SaveHomeSliderImage", parameter));
            return Response;
        }

        public DataSet GetAllHomeImageSlider()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllHomeImageSlider", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int DeleteCategory(int idCategory)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("IdCategory", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCategory);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteCategory", parameter));
            return Response;
        }

        public int DeleteHomeSlider(int idHomePageSlider)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idHomeSlider", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idHomePageSlider);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteHomePageSlider", parameter));
            return Response;
        }

        public DataSet GetAllCountry()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCountry", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllCurrency()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCurrency", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllProductForDD()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllProductDD", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int SetProductPrice(ProductPriceCls objProductPriceCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[11];
            parameter[0] = new LbSprocParameter("idProductPrice", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.idProductPrice);
            parameter[1] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.idProduct);
            parameter[2] = new LbSprocParameter("idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.idCountry);
            parameter[3] = new LbSprocParameter("idCurrency", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.idCurrency);
            parameter[4] = new LbSprocParameter("B2Bprice", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.B2Bprice);
            parameter[5] = new LbSprocParameter("B2Cprice", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.B2Cprice);
            parameter[6] = new LbSprocParameter("bStatus", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.bStatus);
            parameter[7] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.Createdby);
            parameter[8] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.ModifyBy);
            parameter[9] = new LbSprocParameter("Discount", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.Discount);
            parameter[10] = new LbSprocParameter("ShipmentCharges", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objProductPriceCls.ShipmentCharges);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_SetProductPrice", parameter));
            return Response;
        }

        public DataSet GetAllProductForPrice()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllProductForPrice", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllProductForPriceList(int idProduct)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllProductForPriceList", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //USP_GetProductId
        public DataSet GetProductId(int Id)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetProductId", parameter);
            return ds;
        }

        public DataSet GetAllProducts()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllProducts", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int DeleteProduct(int idProduct)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

                Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteProductInfo", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Response;
        }

        public int SetProduct(ProductCls objProduct)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[8];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProduct.idProduct);
            parameter[1] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objProduct.sName);
            parameter[2] = new LbSprocParameter("SEOName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objProduct.SEOName);
            parameter[3] = new LbSprocParameter("Feature", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objProduct.Features);
            parameter[4] = new LbSprocParameter("idCategory", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProduct.idCategory);
            parameter[5] = new LbSprocParameter("status", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objProduct.bStatus);
            parameter[6] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProduct.Createdby);
            parameter[7] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objProduct.ModifyBy);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_SetProduct", parameter));
            return Response;
        }

        public DataSet GetProduct(int idProduct)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetProduct", parameter);
            return ds;
        }

        public DataSet GetCurrency()
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[0];
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetCurrency", parameter);
            return ds;
        }

        public DataSet GetCountry()
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[0];
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetCountry", parameter);
            return ds;
        }

        public int InsertUpdateProductDetail(ProductCls objProduct)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objProduct.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateProductDetail", parameter));
            return Response;
        }

        public DataSet GetProductInfo(int idProduct)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetProductInfo", parameter);
            return ds;
        }

        public int DeleteBlog(int Id)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteBlog", parameter));
            return Response;
        }

        public DataSet GetAllBlogs()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllBlogs", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertUpdateBlogs(BlogsCls blog)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[6];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, blog.Id);
            parameter[1] = new LbSprocParameter("Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, blog.Name);
            parameter[2] = new LbSprocParameter("sDescription", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, blog.Description);
            parameter[3] = new LbSprocParameter("sPhoto", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, blog.Photo);
            //parameter[4] = new LbSprocParameter("CreatedDate", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, blog.Datetime);
            parameter[4] = new LbSprocParameter("URL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, blog.URL);
            parameter[5] = new LbSprocParameter("MetaTags", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, blog.MetaTags);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateBlogs", parameter));
            return Response;
        }

        public DataSet GetBlog(int Id)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetBlogs", parameter);
            return ds;
        }

        public int DeleteProductPrice(int idProductPrice)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idProductPrice", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProductPrice);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteProductPrice", parameter));
            return Response;
        }

        public int DeleteConfig(int Id)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteConfig", parameter));
            return Response;
        }

        public DataSet GetAllConfig()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllConfig", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllCountryforConfig()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCountryforConfig", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertUpdateConfig(ConfigCls Config)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[4];
            parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Config.idConfig);
            parameter[1] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Config.sName);
            parameter[2] = new LbSprocParameter("sValue", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Config.sValue);
            parameter[3] = new LbSprocParameter("bStatus", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, Config.bStatus);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateConfig", parameter));
            return Response;
        }

        public DataSet GetConfig(int Id)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetConfig", parameter);
            return ds;
        }

        public int DeleteCountryConfig(int Id)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCountryConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteCountryConfig", parameter));
            return Response;
        }

        public DataSet GetAllCountryConfig()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCountryConfig", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertUpdateCountryConfig(CountryConfigCls Config)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[4];
            parameter[0] = new LbSprocParameter("idCountryConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Config.idCountryConfig);
            parameter[1] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Config.idConfig);
            parameter[2] = new LbSprocParameter("idCountry", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Config.idCountry);
            parameter[3] = new LbSprocParameter("sValue", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Config.sValue);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateCountryConfig", parameter));
            return Response;
        }

        public DataSet GetCountryConfig(int Id)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetCountryConfig", parameter);
            return ds;
        }

        public DataSet GetAllConfigForDD()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllConfigDD", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllConfig(int Id)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetAllConfig", parameter);
            return ds;
        }

        public int AdminChangePassword(AdminCls admin)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("idAdmin", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, admin.idAdmin);
            parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, admin.ConfirmPassword);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_AdminChangePassword", parameter));
            return Response;
        }

        public DataSet GetAllCustomerOrder()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCustomerOrder", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetCustomerOrder(int idCustomerOrder)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCustomerOrder", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerOrder);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetCustomerOrder", parameter);
            return ds;
        }

        public int DeleteCustomerOrder(int idCustomerOrder)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCustomerOrder", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerOrder);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteCustomerOrder", parameter));
            return Response;
        }

        public int InsertUpdateCustomerOrder(CustomerOrderCls CustomerOrder)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[4];
            parameter[0] = new LbSprocParameter("idCustomerOrder", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.idCustomerOrder);
            parameter[1] = new LbSprocParameter("ApproveReject", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.ApproveReject);
            parameter[2] = new LbSprocParameter("Comment", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.Comment);
            parameter[3] = new LbSprocParameter("bStatus", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.bStatus);
            //parameter[4] = new LbSprocParameter("TrackingNumber", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.TrackingNumber);
            // parameter[2] = new LbSprocParameter("idCountry", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Config.idCountry);
            // parameter[3] = new LbSprocParameter("sValue", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Config.sValue);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertUpdateCustomerOrder", parameter));
            return Response;
        }

        public DataSet GetAllAdditionalLink()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllAdditionalLink", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int DeleteAdditionalLink(int id)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idAdditionalLink", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteAdditionalLink", parameter));
            return Response;
        }

        public int InsertUpdateAdditionalLink(AdditionalLinkCls AdditionalLink)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("idAdditionalLink", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, AdditionalLink.idAdditionalLink);
            parameter[1] = new LbSprocParameter("Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, AdditionalLink.Name);
            parameter[2] = new LbSprocParameter("Link", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, AdditionalLink.Link);
            parameter[3] = new LbSprocParameter("sDescription", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, AdditionalLink.Description);
            parameter[4] = new LbSprocParameter("bStatus", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, AdditionalLink.bStatus);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertUpdateAdditionalLink", parameter));
            return Response;
        }

        public DataSet GetAdditionalLink(int idAdditionalLink)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idAdditionalLink", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idAdditionalLink);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetAdditionalLink", parameter);
            return ds;
        }

        public DataSet GetAllInventory()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllInventory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int DeleteInventory(int id)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idInventory", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteInventory", parameter));
            return Response;
        }

        public int InsertUpdateInventory(InventoryCls Inventory)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[3];
            parameter[0] = new LbSprocParameter("idInventory", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, Inventory.idInventory);
            parameter[1] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Inventory.idProduct);
            parameter[2] = new LbSprocParameter("quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Inventory.quantity);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertUpdateInventory", parameter));
            return Response;
        }

        public DataSet GetInventory(int idInventory)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idInventory", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idInventory);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            // int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetInventory", parameter);
            return ds;
        }

        public int InsertInventory(List<InventoryCls> Inventory)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, Inventory.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertInventory", parameter));
            return Response;
        }

        public int InsertProductPrice(List<ProductPriceCls> ProductPriceCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, ProductPriceCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertProductPrice", parameter));
            return Response;
        }

        public DataSet GetAllConfigForCountryConfigList(int idConfig)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idConfig);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllConfigForCountryConfigList", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertCountryConfig(List<CountryConfigCls> Config)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, Config.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertCountryConfig", parameter));
            return Response;
        }

        public DataSet GetAllProductPriceList()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllProductPriceList", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int UpdateInventory(List<InventoryCls> Inventory)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, Inventory.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_UpdateInventory", parameter));
            return Response;
        }

        public DataSet GetAllProductsForInventory()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllProductsForInventory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllProductForPriceListCountry(int idProduct)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllProductForPriceListCountry", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllCountryProductPricelist(int idProduct)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCountryProductPricelist", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllCountryConfiglist(int idConfig)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("idConfig", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idConfig);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCountryConfiglist", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertUpdateMasterPage(MasterpageCls Masterpage)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[3];
            parameter[0] = new LbSprocParameter("idMasterPage", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Masterpage.idMasterPage);
            parameter[1] = new LbSprocParameter("sMasterPage", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Masterpage.sMasterPage);
            parameter[2] = new LbSprocParameter("sContent", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Masterpage.sContent);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_Admin_InsertUpdateMasterPage", parameter));
            return Response;
        }

        public DataSet GetAllMasterPage()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllMasterPage", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int DeleteMasterPage(int idMasterPage)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idMasterPage", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idMasterPage);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_DeleteMasterPage", parameter));
            return Response;
        }

        public DataSet GetAllClientMaster(int idCountry)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetAllClientMaster", parameter);
            return ds;
        }
        public int InsertUpdateDelteClientMaster(ClientMasterCls objClientMasterCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objClientMasterCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateDelteClientMaster", parameter));
            return Response;
        }
        public DataSet GetAllBanners(string idBanners = null)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@idBanners", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idBanners);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetAllBanners", parameter);
            return ds;
        }
        public int InsertUpdateDeltePageBanners(PageBannersCls objPageBannersCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objPageBannersCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateDeltePageBanners", parameter));
            return Response;
        }
        public int GetAllTesmimonial()
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[0];
            //parameter[0] = new LbSprocParameter("idMasterPage", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idMasterPage);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_GetAllTesmimonial", parameter));
            return Response;
        }
        public int InsertUpdateDelteTesmimonial(TesmimonialCls objTesmimonialCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objTesmimonialCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateDelteTesmimonial", parameter));
            return Response;
        }

        public string UpdateCustomerOrderStatus(CustomerOrderCls CustomerOrder)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[4];
            parameter[0] = new LbSprocParameter("idCustomerOrder", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.idCustomerOrder);
            parameter[1] = new LbSprocParameter("bStatus", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.bStatus);
            parameter[2] = new LbSprocParameter("Comment", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.ShippingComment);
            parameter[3] = new LbSprocParameter("TrackingNumber", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, CustomerOrder.TrackingNumber);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            string Response = string.Empty;
            Response = Convert.ToString(elhelper.ExecuteNonQuery("USP_Admin_UpdateCustomerOrderStatus", parameter));
            return Response;
        }
        public int InsertUpdateDelteDiscountCoupon(DiscountCouponCls objDiscountCouponCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objDiscountCouponCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_Admin_InsertUpdateDelteDiscountCoupon", parameter));
            return Response;
        }
        public int InsertUserCouponRedemption(UserCouponRedemptionCls objUserCouponRedemptionCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objUserCouponRedemptionCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_UP_InsertUserCouponRedemption", parameter));
            return Response;
        }
        public DataSet GetAllDiscountCoupon()
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[0];
            //parameter[0] = new LbSprocParameter("idMasterPage", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idMasterPage);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetAllDiscountCoupon", parameter);
            return ds;
        }

        public DataSet GetDiscountCoupon(int idCoupon)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCoupon", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCoupon);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            DataSet ds = elhelper.ExecuteDataset("USP_Admin_GetDiscountCoupon", parameter);
            return ds;
        }

        public DataSet GetMasterPageById(int idMasterPage)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idMasterPage", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idMasterPage);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            //int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetMasterPageById", parameter);
            return ds;
        }

        public DataSet UpdateStatusOfTrackingNumber(string sTrackingNumber)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("XmlData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, sTrackingNumber);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            //int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_UpdateStatusOfTrackingNumber", parameter);
            return ds;
        }

        public DataSet GetAllReport()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllReports", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //public DataSet GetAllReportByFilters(string startDate, string endDate, string Status, string Country)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        LbSprocParameter[] parameter;
        //        parameter = new LbSprocParameter[1];
        //        parameter[0] = new LbSprocParameter("@Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, startDate);
        //        //parameter[1] = new LbSprocParameter("@EndDate", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, endDate);
        //        //parameter[2] = new LbSprocParameter("@Status", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Status);
        //        //parameter[3] = new LbSprocParameter("@Country", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Country);
        //        ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
        //        ds = elhelper.ExecuteDataset("USP_Admin_GetAllReportsByFilters", parameter);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet GetAllReportByFilters(ReportCls objReport)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objReport.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            //int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetAllReportsByFilters", parameter);
            return ds;
        }

        public DataSet GetAllReportCustomer()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllReportsCustomer", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetAllReportCustomersByFilters(ReportCustomerCls objReport)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("Xml", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objReport.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            //int Response = 0;
            ds = elhelper.ExecuteDataset("USP_Admin_GetAllReportsCustomersByFilters", parameter);
            return ds;
        }

        public DataSet GetAllProductForPricePagination(int pageSize, int pageNo)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("@pageSize", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageSize);
                parameter[1] = new LbSprocParameter("@pageNo", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageNo);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllProductForPricePagination", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllMasterCategory()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllMasterCategory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllCollection()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllCollection", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllMaterial()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllMaterial", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllGemstone()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllGemstone", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllGender()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllGender", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllColor()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllColor", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllSize()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllSize", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllShape()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_GetAllShape", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetSearchProduct(string SearchText)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("SearchText", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, SearchText);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_Admin_SearchProduct", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
