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
    public class UserDL
    {
        public DataSet GetAllCategory()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_UP_GetAllCategory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int RegisterCustomer(CustomerCls customer)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("@sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.sName);
            parameter[1] = new LbSprocParameter("@sEmail", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.Email);
            parameter[2] = new LbSprocParameter("@sPassword", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.Password);
            parameter[3] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, customer.idCountry);
            parameter[4] = new LbSprocParameter("@VerificationCode", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.VerificationCode);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_UP_RegisterCustomer", parameter));
            return Response;
        }

        public DataSet LoginCustomer(CustomerCls customer)
        {
            DataSet ds = new DataSet();
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("@sEmail", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.Email);
            parameter[1] = new LbSprocParameter("@sPassword", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.Password);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            ds = elhelper.ExecuteDataset("USP_UP_LoginCustomer", parameter);
            return ds;
        }

        public DataSet GetAllProductByCategory(string sCategory, int idCountry, int isB2B, int pageSize, int pageNo, string sortBy, string sortDirection, int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[8];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

                parameter[0] = new LbSprocParameter("@sCategory", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sCategory);
                parameter[1] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
                parameter[2] = new LbSprocParameter("@isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
                parameter[3] = new LbSprocParameter("@pageSize", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageSize);
                parameter[4] = new LbSprocParameter("@pageNo", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageNo);
                parameter[5] = new LbSprocParameter("@sortBy", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sortBy);
                parameter[6] = new LbSprocParameter("@sortDirection", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sortDirection);
                parameter[7] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetAllProductByCategory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetProductById(string sName, int idCountry, int isB2B, int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
                parameter[1] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
                parameter[2] = new LbSprocParameter("@isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
                parameter[3] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetProductById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string SaveProductInCart(int idProduct, int idCountry, int isB2B, int idCustomer, int Quantity)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
            parameter[1] = new LbSprocParameter("idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
            parameter[2] = new LbSprocParameter("isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
            parameter[3] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
            parameter[4] = new LbSprocParameter("Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Quantity);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_SaveProductInCart", parameter));
            return Response;
        }

        public DataSet GetCustomerCart(int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetCustomerCart", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAdditionalLinkByLink(string Link)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@Link", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Link);
                ds = elhelper.ExecuteDataset("USP_UP_GetAdditionalLinkByLink", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllBlogs(int pageNum, int pageSize)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@PageNum", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageNum);
                parameter[1] = new LbSprocParameter("@PageSize", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageSize);
                ds = elhelper.ExecuteDataset("USP_UP_GetAllBlogs", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        public DataSet GetBlog(string name)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, name);
                ds = elhelper.ExecuteDataset("USP_UP_GetBlogById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBlogSidebar(int NumberOfPost = 0)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@NumberOfPost", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, NumberOfPost);
                ds = elhelper.ExecuteDataset("USP_UP_GetBlogSidebar", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetTopProduct(int idCountry, int isB2B)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
                parameter[1] = new LbSprocParameter("@isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
                ds = elhelper.ExecuteDataset("USP_UP_GetTopProducts", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetHomePageSlide()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_UP_GetHomePageSlide", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

       

        public DataSet GetHomePageProduct(int idCountry, int isB2B, int NewProductDuration, int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
                parameter[1] = new LbSprocParameter("@isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
                parameter[2] = new LbSprocParameter("@NewProductDuration", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, NewProductDuration);
                parameter[3] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetHomePageProduct", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet GetCustomerCardDetail(int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetCustomerCardDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string AddEditAddress(CustomerAddress objCustomerAddress)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[13];
            parameter[0] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.idCustomer);
            parameter[1] = new LbSprocParameter("idCustomerAddress", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.idCustomerAddress);
            parameter[2] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.sName);
            parameter[3] = new LbSprocParameter("Mobile", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.Mobile);
            parameter[4] = new LbSprocParameter("PinCode", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.PinCode);
            parameter[5] = new LbSprocParameter("sAddress1", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.sAddress1);
            parameter[6] = new LbSprocParameter("sAddress2", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.sAddress2);
            parameter[7] = new LbSprocParameter("sCity", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.sCity);
            parameter[8] = new LbSprocParameter("sState", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.sState);
            parameter[9] = new LbSprocParameter("sLandMark", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.sLandMark);
            parameter[10] = new LbSprocParameter("AddressType", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.AddressType);
            parameter[11] = new LbSprocParameter("AlternateNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.AlternateNo);
            parameter[12] = new LbSprocParameter("CountryName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerAddress.CountryName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_AddEditAddress", parameter));
            return Response;
        }

        public DataSet GetMasterPageById(int idMasterPage)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("idMasterPage", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, idMasterPage);
                ds = elhelper.ExecuteDataset("USP_UP_GetMasterPageById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int EditCustomer(CustomerCls objCustomerClst)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objCustomerClst.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_UP_EditCustomer", parameter));
            return Response;
        }

        public int DeleteAddress(int idCustomerAddress)
        {
            int result;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("idCustomerAddress", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerAddress);
                result = (int)elhelper.ExecuteScalar("USP_UP_DeleteAddress", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataSet GetCustomerDetail(int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetCustomerDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string CreateOrder(CustomerOrderCls objCustomerOrderCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objCustomerOrderCls.ToXML());
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_CreateOrder", parameter));
            return Response;
        }
        public DataSet GetAllAddress(int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetAllAddress", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public void SetDefaultAddress(int idCustomerAddress)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCustomerAddress", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerAddress);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            elhelper.ExecuteNonQuery("USP_UP_SetDefaultAddress", parameter);
        }


        public string UpdateDeleteCart(int idCustomerCart, int Quantity, string sStatus)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[3];
            parameter[0] = new LbSprocParameter("idCustomerCart", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerCart);
            parameter[1] = new LbSprocParameter("Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Quantity);
            parameter[2] = new LbSprocParameter("sStatus", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sStatus);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_UpdateDeleteCart", parameter));
            return Response;
        }

        public DataSet GetAllOrder(int idCustomer,int pageSize,int pageNo)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[3];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                parameter[1] = new LbSprocParameter("@pageSize", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageSize);
                parameter[2] = new LbSprocParameter("@pageNo", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageNo);
                ds = elhelper.ExecuteDataset("USP_UP_GetAllOrder", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string UpdateCustomerCountry(int idCustomer)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_UpdateCustomerCountry", parameter));
            return Response;
        }

        public DataSet GetWishlistCart(int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetWishListCart", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public string UpdateDeleteWishlist(int idWishList, int Quantity, string sStatus)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[3];
            parameter[0] = new LbSprocParameter("idWishList", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idWishList);
            parameter[1] = new LbSprocParameter("Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Quantity);
            parameter[2] = new LbSprocParameter("sStatus", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sStatus);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_UpdateDeleteWishlist", parameter));
            return Response;
        }
                
        public string SaveProductInWishlist(int idProduct, int idCountry, int idCustomer, int isB2B)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[4];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
            parameter[1] = new LbSprocParameter("idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
            parameter[2] = new LbSprocParameter("isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
            parameter[3] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
            // parameter[3] = new LbSprocParameter("Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Quantity);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_SaveProductInWishList", parameter));
            return Response;
        }

        public string SaveSubscribe(string sEmail, int bStatus)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("sEmail", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sEmail);
            parameter[1] = new LbSprocParameter("bStatus", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bStatus);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            string Response = "";
            Response = Convert.ToString(elhelper.ExecuteScalar("USP_UP_SaveSubscribe", parameter));
            return Response;
        }

        public bool ValidateUser(string Email)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Email);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_UP_ValidateUser", parameter);
                return (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToString(ds.Tables[0].Rows[0][0]) == "1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                Response = elhelper.ExecuteNonQuery("USP_UP_ResetPassword", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Response;
        }

        public DataSet GetInvoiceDetails(int idCustomerOrder)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idCustomerOrder", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerOrder);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetInvoiceDetails", parameter);
            return ds;
        }

        public DataSet GetFilterProductsByidMasterCategory(FilterProductsCls objFilterProductsCls, int idCountry, int isB2B, int pageSize, int pageNo, string sortBy, string sortDirection,string sText,int minPrice, int maxPrice, int NewProductDuration, int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[12];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

                parameter[0] = new LbSprocParameter("@XMLData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objFilterProductsCls.ToXML());
                parameter[1] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
                parameter[2] = new LbSprocParameter("@isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
                parameter[3] = new LbSprocParameter("@pageSize", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageSize);
                parameter[4] = new LbSprocParameter("@pageNo", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageNo);
                parameter[5] = new LbSprocParameter("@sortBy", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sortBy);
                parameter[6] = new LbSprocParameter("@sortDirection", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sortDirection);
                parameter[7] = new LbSprocParameter("@sText", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sText);
                parameter[8] = new LbSprocParameter("@minPrice", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, minPrice);
                parameter[9] = new LbSprocParameter("@maxPrice", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, maxPrice);
                parameter[10] = new LbSprocParameter("@NewProductDuration", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, NewProductDuration);
                parameter[11] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
                ds = elhelper.ExecuteDataset("USP_UP_GetFilterProductsByidMasterCategory", parameter);
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

        public DataSet GetMasterCategoryByName(string sName)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);

                ds = elhelper.ExecuteDataset("USP_UP_GetMasterCategoryByName", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool UserVerification(string verificationCode)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("verificationCode", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, verificationCode);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_UP_UserVerification", parameter);
                return (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToString(ds.Tables[0].Rows[0][0]) == "1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int VerifyCustomer(CustomerCls customer)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[2];            
            parameter[0] = new LbSprocParameter("@sEmail", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.Username);
            parameter[1] = new LbSprocParameter("@isEmailVerified", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, customer.isEmailVerified);           
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_UP_VerifyCustomer", parameter));
            return Response;
        }

        public DataSet GetOrderById(string sOrderNo)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@sOrderNo", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, sOrderNo);
                ds = elhelper.ExecuteDataset("USP_UP_GetOrderById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetVerificationCodeById(string verificationCode)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;

                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@verificationCode", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, verificationCode);
                ds = elhelper.ExecuteDataset("USP_UP_GetVerificationCodeById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertUpdateReview(CustomerReview objCustomerReview)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[6];
            //parameter[0] = new LbSprocParameter("idCustomerReview", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.idCustomerReview);
            parameter[0] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.idCustomer);
            parameter[1] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.idProduct);
            parameter[2] = new LbSprocParameter("starRating", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.starRating);
            parameter[3] = new LbSprocParameter("imageURL", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.imageURL);
            parameter[4] = new LbSprocParameter("headline", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.headline);
            parameter[5] = new LbSprocParameter("review", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objCustomerReview.review);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int response = elhelper.ExecuteNonQuery("USP_UP_InsertUpdateReview", parameter);
            return response;
        }

        public DataSet GetCustomerReview(int idCustomerReview, int idCustomer)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("idCustomerReview", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomerReview);
            parameter[1] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetCustomerReview", parameter);
            return ds;
        }

        public DataSet GetAllCustomerReview(int idProduct)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetAllCustomerReview", parameter);
            return ds;
        }

        public DataSet GetProductNameWithImage(int idProduct)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("idProduct", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idProduct);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetProductNameWithImage", parameter);
            return ds;
        }

        public DataSet GetCategoryByName(string sName)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetCategoryByName", parameter);
            return ds;
        }

        //public DataSet GetColorAndSize()
        //{
        //    LbSprocParameter[] parameter;
        //    parameter = new LbSprocParameter[0];
        //    ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
        //    DataSet ds = elhelper.ExecuteDataset("USP_UP_GetColorAndSize", parameter);
        //    return ds;
        //}

        //public int CustomerChangePassword(CustomerCls Customer)
        //{
        //    LbSprocParameter[] parameter;
        //    parameter = new LbSprocParameter[2];
        //    parameter[0] = new LbSprocParameter("idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Customer.idCustomer);
        //  //  parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Customer.ConfirmPassword);
        //    ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
        //    int Response = 0;
        //    Response = Convert.ToInt32(elhelper.ExecuteNonQuery("USP_UP_CustomerChangePassword", parameter));
        //    return Response;
        //}

        public DataSet GetRelatedProduct(string sCategory, int idCountry, int isB2B, int idCustomer)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

                parameter[0] = new LbSprocParameter("@sCategory", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sCategory);
                parameter[1] = new LbSprocParameter("@idCountry", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCountry);
                parameter[2] = new LbSprocParameter("@isB2B", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, isB2B);
                parameter[3] = new LbSprocParameter("@idCustomer", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idCustomer);
               
                ds = elhelper.ExecuteDataset("", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetMasterCategorysByName(string sName)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetMasterCategorysByName", parameter);
            return ds;
        }

        public DataSet GetCollectionByName(string sName)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetCollectionByName", parameter);
            return ds;
        }

        public DataSet GetGenderByName(string sName)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetGenderByName", parameter);
            return ds;
        }

        public DataSet GetMaterialByName(string sName)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetMaterialByName", parameter);
            return ds;
        }

        public DataSet GetGemstoneByName(string sName)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("sName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, sName);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetGemstoneByName", parameter);
            return ds;
        }

         public DataSet GetFeatureCategory()
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[0];
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            DataSet ds = elhelper.ExecuteDataset("USP_UP_GetFeaturedCategory", parameter);
            return ds;
        }

        public DataSet GetHomePageSlider(int IsB2B)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("isB2B", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, IsB2B);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_UP_GetHomePageSlider", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllBlogsbyduration(int pageNum, int pageSize, int month, int year)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@PageNum", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageNum);
                parameter[1] = new LbSprocParameter("@PageSize", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, pageSize);
                parameter[2] = new LbSprocParameter("@month", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, month);
                parameter[3] = new LbSprocParameter("@year", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, year);
                ds = elhelper.ExecuteDataset("USP_UP_GetAllBlogsbyduration", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
