using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using System.Data;
using ELHelper;
using System.Xml.Serialization;
using System.IO;
namespace DataLayer
{
    public class DL_HotalManagment
    {
        public DataSet AdminLogin(AdminCls para)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("UserName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Username);
                parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.Password);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_AdminLogin", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllRateType(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("UserId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllRateType", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllCategory(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllCategory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetEnquiry(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetEnquiry", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookedUserDetail(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet GetEnquiryById(int EnquiryId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("EnquiryId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, EnquiryId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetEnquiryById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet ChangePassword(AdminCls objAdmin)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[5];
                parameter[0] = new LbSprocParameter("UserName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objAdmin.Username);
                parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objAdmin.Password);
                parameter[2] = new LbSprocParameter("NewPassword", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objAdmin.NewPassword);
                parameter[3] = new LbSprocParameter("@nError", DbType.Int32, LbSprocParameter.LbParameterDirection.OUTPUT, 500);
                parameter[4] = new LbSprocParameter("@sMsg", DbType.String, LbSprocParameter.LbParameterDirection.OUTPUT, 256);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_AdminChangePassword", parameter);
                //int nError =Convert.ToInt32(ELHelper.GetParameterValue("@nError"));
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
            parameter = new LbSprocParameter[7];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.Id);
            parameter[1] = new LbSprocParameter("CategoryName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, category.CategoryName);
            parameter[2] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, category.IsActive);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.CreatedBy);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.ModifyBy);
            parameter[5] = new LbSprocParameter("CpCategoryId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, category.CpCategoryId);
            parameter[6] = new LbSprocParameter("CpAuthentication", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, category.CpAuthentication);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_SetCategory", parameter));
            return Response;
        }

        public int SetRateType(RateTypeCls RateType)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[7];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RateType.Id);
            parameter[1] = new LbSprocParameter("Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, RateType.Name);
            parameter[2] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RateType.CreatedBy);
            parameter[3] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RateType.ModifyBy);
            parameter[4] = new LbSprocParameter("RateTypeId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, RateType.RateTypeId);
            parameter[5] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, RateType.IsActive);
            parameter[6] = new LbSprocParameter("PlanId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, RateType.PlanId);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_SetRateType", parameter));
            return Response;
        }



        public int SetGSTSlab(GstSlabCls objGSTSlab)
        {
            int effectedRows = 0;
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[6];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objGSTSlab.Id);
            parameter[1] = new LbSprocParameter("GSTSlab", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objGSTSlab.GSTSlab);
            parameter[2] = new LbSprocParameter("Percentage", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objGSTSlab.Percentage);
            parameter[3] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objGSTSlab.IsActive);
            parameter[4] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objGSTSlab.CreatedBy);
            parameter[5] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objGSTSlab.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            effectedRows = elhelper.ExecuteNonQuery("USP_SetGSTSlab", parameter);
            return effectedRows;
        }
        public DataSet GetAllItems(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllItems", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetGSTSlab(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("Id", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, id);
                ds = elhelper.ExecuteDataset("USP_GetGSTSlab", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet BookedUserDetail(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ds = elhelper.ExecuteDataset("USP_GetBookedUserDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet BookedItemDetail(int bookingId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("BookingId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, bookingId);
                ds = elhelper.ExecuteDataset("USP_GetAllBookedItems", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        public int SetItem(ItemsCls category)
        {

            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[8];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.Id);
            parameter[1] = new LbSprocParameter("ItemName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, category.ItemName);
            parameter[2] = new LbSprocParameter("Price", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, category.Price);
            parameter[3] = new LbSprocParameter("Code", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, category.Code);
            parameter[4] = new LbSprocParameter("GSTSlabeId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.GSTSlabeId);
            parameter[5] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, category.IsActive);
            parameter[6] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.CreatedBy);
            parameter[7] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, category.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetItems", parameter);
            return Response;
        }



        public int SetBookingItem(ItemsCls item)
        {

            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[9];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.Id);
            parameter[1] = new LbSprocParameter("BookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.BookingId);
            parameter[2] = new LbSprocParameter("ItemId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.ItemId);
            parameter[3] = new LbSprocParameter("Price", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, item.Price);
            parameter[4] = new LbSprocParameter("Quantity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.Quantity);
            parameter[5] = new LbSprocParameter("Status", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.Status);
            parameter[6] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, item.IsActive);
            parameter[7] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.CreatedBy);
            parameter[8] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, item.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetBookingItem", parameter);
            return Response;
        }
        public int insertHotelDetails(hotelCls objhotelCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[15];
                parameter[0] = new LbSprocParameter("HotelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.HotelName);
                parameter[1] = new LbSprocParameter("EmailId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.EmailId);
                parameter[2] = new LbSprocParameter("Logo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Logo);
                parameter[3] = new LbSprocParameter("Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Address);
                parameter[4] = new LbSprocParameter("PhoneNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.PhoneNo);
                parameter[5] = new LbSprocParameter("GSTNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.GSTNo);
                parameter[6] = new LbSprocParameter("MobileNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.MobileNo);
                parameter[7] = new LbSprocParameter("IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.IsActive);
                parameter[8] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.CreatedBy);
                parameter[9] = new LbSprocParameter("StateId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.StateId);
                parameter[10] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Password);
                parameter[11] = new LbSprocParameter("CpHotelId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.CpHotelId);
                parameter[12] = new LbSprocParameter("CpAuthenticationCode", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.CpAuthenticationCode);
                parameter[13] = new LbSprocParameter("PropertyName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.PropertyName);
                parameter[14] = new LbSprocParameter("ReviewLink", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.ReviewLink);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_InsertHotelDetails", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public DataSet GetState()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetState", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetHotelDetailsByUserId(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetHotelDetailsByUserId", parameter);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dr["Logo"])))
                            dr["Logo"] = "no_image.png";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int UpdateHotelDetails(hotelCls objhotelCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[16];
                parameter[0] = new LbSprocParameter("HotelName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.HotelName);
                parameter[1] = new LbSprocParameter("EmailId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.EmailId);
                parameter[2] = new LbSprocParameter("Logo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Logo);
                parameter[3] = new LbSprocParameter("Address", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Address);
                parameter[4] = new LbSprocParameter("PhoneNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.PhoneNo);
                parameter[5] = new LbSprocParameter("GSTNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.GSTNo);
                parameter[6] = new LbSprocParameter("MobileNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.MobileNo);
                parameter[7] = new LbSprocParameter("IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.IsActive);
                parameter[8] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.ModifyBy);
                parameter[9] = new LbSprocParameter("StateId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.StateId);
                parameter[10] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Id);
                parameter[11] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Password);
                parameter[12] = new LbSprocParameter("CpHotelId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.CpHotelId);
                parameter[13] = new LbSprocParameter("CpAuthenticationCode", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.CpAuthenticationCode);
                parameter[14] = new LbSprocParameter("PropertyName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.PropertyName);
                parameter[15] = new LbSprocParameter("ReviewLink", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.ReviewLink);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_UpdateHotelDetails", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public DataSet GetUsersByUserId(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetUsers", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int insertUserDetails(UserCls objUserCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                parameter[0] = new LbSprocParameter("Username", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.UserName);
                parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.Password);
                parameter[2] = new LbSprocParameter("IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.IsActive);
                parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.CreatedBy);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_InsertUserDetails", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public int UpdateuserDetails(UserCls objUserCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[5];
                parameter[0] = new LbSprocParameter("UserName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.UserName);
                parameter[1] = new LbSprocParameter("IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.IsActive);
                parameter[2] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.ModifyBy);
                parameter[3] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.Id);
                parameter[4] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objUserCls.Password);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_UpdateUserDetails", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }
        public int InsertUpdateRoomDetails(RoomCls objRoomCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[25];
                parameter[0] = new LbSprocParameter("@Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Id);
                parameter[1] = new LbSprocParameter("@CategoryId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.CategoryId);
                parameter[2] = new LbSprocParameter("@RoomFrom", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.RoomFrom);
                parameter[3] = new LbSprocParameter("@RoomTo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.RoomTo);
                parameter[4] = new LbSprocParameter("@Price", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Price);
                parameter[5] = new LbSprocParameter("@GSTSlabId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.GSTSlab);
                parameter[6] = new LbSprocParameter("@IsUnderHK", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.IsUnderHK);
                parameter[7] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.IsActive);
                parameter[8] = new LbSprocParameter("@GroupName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.GroupName);
                parameter[9] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.CreatedBy);
                parameter[10] = new LbSprocParameter("@ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.ModifyBy);
                parameter[11] = new LbSprocParameter("@Monday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Monday);
                parameter[12] = new LbSprocParameter("@Tuesday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Tuesday);
                parameter[13] = new LbSprocParameter("@Wednesday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Wednesday);
                parameter[14] = new LbSprocParameter("@Thursday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Thursday);
                parameter[15] = new LbSprocParameter("@Friday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Friday);
                parameter[16] = new LbSprocParameter("@Saturday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Saturday);
                parameter[17] = new LbSprocParameter("@Sunday", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Sunday);
                parameter[18] = new LbSprocParameter("@ExBadChargesEP", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.ExBadChargesEP);
                parameter[19] = new LbSprocParameter("@ExBadChargesCP", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.ExBadChargesCP);
                parameter[20] = new LbSprocParameter("@ExBadChargesMAP", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.ExBadChargesMAP);
                parameter[21] = new LbSprocParameter("@Persons", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.Persons);
                parameter[22] = new LbSprocParameter("@EP", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.EP);
                parameter[23] = new LbSprocParameter("@CP", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.CP);
                parameter[24] = new LbSprocParameter("@MAP", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objRoomCls.MAP);

                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_InsertUpdateRoomDetails", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public DataSet GetRoomDetails(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                ds = elhelper.ExecuteDataset("USP_GetRoomDetails", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public int ConfirmationUserForForgotPassword(string email)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("Email", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, email);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_ConfirmationUserForForgotPassword", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }
        public int ForgotPassword(AdminCls objAdmin)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("username", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objAdmin.Username);
                parameter[1] = new LbSprocParameter("Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objAdmin.Password);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_ForgotPassword", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Response;
        }

        public int UpdateHouseKeepingsRoom(RoomCls objRoomsCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[3];
                parameter[0] = new LbSprocParameter("Id", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objRoomsCls.Id);
                parameter[1] = new LbSprocParameter("IsUnderHK", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objRoomsCls.IsUnderHK);
                parameter[2] = new LbSprocParameter("CategoryId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objRoomsCls.CategoryId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_UpdateHouseKeepingsRoom", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }


        public DataSet GetHouseKeepingRooms(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ds = elhelper.ExecuteDataset("USP_GetHouseKeepingRooms", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetRoomNo(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetRoomNo", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetRoomNoNotBookedByCategory(int UserId, int categoryId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                parameter[1] = new LbSprocParameter("categoryId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, categoryId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetRoomNoNotBooked", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetRoomNoForBooking(int userId, int categoryId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("categoryId", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, categoryId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetRoomNoForBooking", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string SetBookingDetail(BookingCls objBooking)
        {
            string Response = "0";
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("@XmlData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objBooking.ToXML());
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_InsertUpdateBookingDetails", parameter);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Response = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public int SetEnquiryDetail(EnquiryCls objEnquiry)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[12];
                parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.Id);
                parameter[1] = new LbSprocParameter("FromDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.FromDate);
                parameter[2] = new LbSprocParameter("ToDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.ToDate);
                parameter[3] = new LbSprocParameter("categoryId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.categoryId);
                parameter[4] = new LbSprocParameter("RoomId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.RoomId);
                parameter[5] = new LbSprocParameter("BookingSourceId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.BookingSourceId);
                parameter[6] = new LbSprocParameter("EnquiryBy", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.EnquiryBy);
                parameter[7] = new LbSprocParameter("ContactNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.ContactNo);
                parameter[8] = new LbSprocParameter("Notes", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.Notes);
                parameter[9] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.IsActive);
                parameter[10] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.CreatedBy);
                parameter[11] = new LbSprocParameter("Modifyby", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objEnquiry.Modifyby);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_SetEnquiryDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }


        public int SetBookingSourceType(BookingSourceTypeCls bookingSourceType)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSourceType.Id);
            parameter[1] = new LbSprocParameter("BookingSourceTypeName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, bookingSourceType.BookingSourceTypeName);
            parameter[2] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, bookingSourceType.IsActive);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSourceType.CreatedBy);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSourceType.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetBookingSourceType", parameter);
            return Response;
        }

        public int SetBookingSource(BookingSourceCls bookingSource)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[8];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.Id);
            parameter[1] = new LbSprocParameter("BookingSourceName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.BookingSourceName);
            parameter[2] = new LbSprocParameter("BookingSourceTypeId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.BookingSourceTypeId);
            parameter[3] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.IsActive);
            parameter[4] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.CreatedBy);
            parameter[5] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.ModifyBy);
            parameter[6] = new LbSprocParameter("OTANameChannel", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.OTANameChannel);
            parameter[7] = new LbSprocParameter("Commision", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, bookingSource.Commision);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetBookingSource", parameter);
            return Response;
        }

        public int SetBookingType(BookingTypeCls bookingType)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingType.Id);
            parameter[1] = new LbSprocParameter("BookingTypeName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, bookingType.BookingTypeName);
            parameter[2] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, bookingType.IsActive);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingType.CreatedBy);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, bookingType.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetBookingType", parameter);
            return Response;
        }

        public int SetBusinessSource(BusinessSourceCls businessSource)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, businessSource.Id);
            parameter[1] = new LbSprocParameter("BusinessSourceName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, businessSource.BusinessSourceName);
            parameter[2] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, businessSource.IsActive);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, businessSource.CreatedBy);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, businessSource.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetBusinessSource", parameter);
            return Response;
        }

        public DataSet GetBookingSourceType(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingSourceType", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookingSource()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingSource", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookingStatus(int BookingId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("BookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingStatus", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetBusinessSource(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBusinessSource", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookingType()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingType", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetDashBoardAgainstId(int Id, int Type)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                parameter[1] = new LbSprocParameter("Type", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Type);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetdashBoard", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetRoomNoByCategory(int userId, int categoryId, string fromDate, string toDate, int bookingId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[5];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("categoryId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, categoryId);
                parameter[2] = new LbSprocParameter("fromDate", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, fromDate);
                parameter[3] = new LbSprocParameter("toDate", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, toDate);
                parameter[4] = new LbSprocParameter("bookingId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, bookingId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetRoomNoByCategory", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetPriceByRoomNo(int userId, int roomId, DateTime dt)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[3];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("roomId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, roomId);
                parameter[2] = new LbSprocParameter("bookDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, dt);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetPriceByRoomNo", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public BookingCls GetBookingDetailById(int BookingId, int userId)
        {
            DataSet ds = new DataSet();
            BookingCls objBooking = new BookingCls();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("bookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                parameter[1] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingDetailById", parameter);
                if (ds != null && ds.Tables[0] != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objBooking = new BookingCls(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objBooking;
        }

        public List<CustomerDetailCls> GetCustomerDetails(int BookingId, int userId)
        {
            DataSet ds = new DataSet();
            List<CustomerDetailCls> lstCustomerDetail = new List<CustomerDetailCls>();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("bookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                parameter[1] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetCustomerDetails", parameter);
                if (ds != null && ds.Tables[0] != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstCustomerDetail.Add(new CustomerDetailCls(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCustomerDetail;
        }
        public BookingCls GetBookingDetailByBookindIdAndId(int BookingId, int userId)
        {
            DataSet ds = new DataSet();
            BookingCls objBooking = new BookingCls();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("bookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                parameter[1] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingDetailByBookingIdandUserId", parameter);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        objBooking = new BookingCls(dr);
                    }
                }
                List<EntityLayer.BookingCls.Contacts> lstContactsDetail = new List<EntityLayer.BookingCls.Contacts>();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[1] != null)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        lstContactsDetail.Add(new EntityLayer.BookingCls.Contacts(dr));
                    }
                    objBooking.lstCustomerContacts = lstContactsDetail;
                }
                List<EntityLayer.BookingCls.Documents> lstDocumentsDetail = new List<EntityLayer.BookingCls.Documents>();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[1] != null)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        lstDocumentsDetail.Add(new EntityLayer.BookingCls.Documents(dr));
                    }
                    objBooking.CustomerDocument = lstDocumentsDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objBooking;
        }
        public DataSet GeBookedRoomNoLastDays()
        {

            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GeBookedRoomNoLastDays", parameter);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookedRoomDetail(int userId)
        {

            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookedRoomDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public List<Events> GetAllEvents(int userId)
        {
            List<Events> lstEvents = new List<Events>();
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetEvents", parameter);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lstEvents.Add(new Events(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstEvents;
        }

        public DataSet GetRoomCategoryWise(int userId, int categoryId, DateTime bookingDate)
        {

            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[3];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("categoryId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, categoryId);
                parameter[2] = new LbSprocParameter("bookingdate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, bookingDate);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetRoomCategoryWise", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookingInformationById(int BookingId, int userId)
        {
            DataSet ds = new DataSet();
            BookingCls objBooking = new BookingCls();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("bookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                parameter[1] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingInformationById", parameter);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetExpressSearch(string SearchName, int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("SearchName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, SearchName);
                parameter[1] = new LbSprocParameter("UserId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ds = elhelper.ExecuteDataset("USP_GetExpressSearch", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public decimal GetGSTByRoomNo(int userId, int roomId)
        {
            decimal GST = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("roomId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, roomId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                GST = (decimal)elhelper.ExecuteScalar("USP_GetGSTByRoomNo", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GST;
        }

        public DataSet GetHotalById(int HotelId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("HotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, HotelId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetHotelById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int UpdateHotalById(hotelCls objhotelCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[3];
                parameter[0] = new LbSprocParameter("HotelId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.Id);
                parameter[1] = new LbSprocParameter("checkOut", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.checkOut);
                parameter[2] = new LbSprocParameter("LocationLink", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objhotelCls.LocationLink);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_UpdateHotalById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public DataSet GetBookingSourceOnMonth(string HotelId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("HotelId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, HotelId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingSourceOnMonth", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllTaxSlab(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllTaxSlab", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public int SetTaxSlab(TaxSlabCls taxSlab)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[8];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.Id);
            parameter[1] = new LbSprocParameter("TaxSlabName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.TaxSlabName);
            parameter[2] = new LbSprocParameter("StartAt", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.StartAt);
            parameter[3] = new LbSprocParameter("EndTo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.EndTo);
            parameter[4] = new LbSprocParameter("Taxpercent", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.Taxpercent);
            parameter[5] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.IsActive);
            parameter[6] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.CreatedBy);
            parameter[7] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, taxSlab.ModifyBy);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetTaxSlab", parameter);
            return Response;
        }

        public int CheckOutBooking(BookingCls objBooking)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("@XmlData", DbType.Xml, LbSprocParameter.LbParameterDirection.INPUT, objBooking.ToXML());
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_CheckOutBooking", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }
        public DataSet GetPreBookingData(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetPreBookingData", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int SetPreBooking(PreBookingCls objPreBookingCls)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[15];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.Id);
            parameter[1] = new LbSprocParameter("FromDate", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.FromDate);
            parameter[2] = new LbSprocParameter("ToDate", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.ToDate);
            parameter[3] = new LbSprocParameter("CategoryId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.CategoryId);
            parameter[4] = new LbSprocParameter("BookingSourceId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.BookingSourceId);
            parameter[5] = new LbSprocParameter("BookingId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.BookingId);
            parameter[6] = new LbSprocParameter("ContactPerson", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.ContactPerson);
            parameter[7] = new LbSprocParameter("ContactNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.ContactNo);
            parameter[8] = new LbSprocParameter("Notes", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.Notes);
            parameter[9] = new LbSprocParameter("Hotelid", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.Hotelid);
            parameter[10] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.IsActive);
            parameter[11] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.CreatedBy);
            parameter[12] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.ModifyBy);
            parameter[13] = new LbSprocParameter("Status", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.Status);
            parameter[14] = new LbSprocParameter("RefNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPreBookingCls.RefNo);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetPreBooking", parameter);
            return Response;
        }


        public DataSet GetPartialPaymentDetails(int BookingId, int userId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("@BookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                parameter[1] = new LbSprocParameter("@UserId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetPartialPaymentDetails", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public int PartialPayment(int BookingId, decimal Amount, string Description, int userId)
        {
            //DataSet ds = new DataSet();
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                parameter[0] = new LbSprocParameter("@BookingId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, BookingId);
                parameter[1] = new LbSprocParameter("@Amount", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, Amount);
                parameter[2] = new LbSprocParameter("@Description", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, Description);
                parameter[3] = new LbSprocParameter("@UserId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_PartialPayment", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public DataSet GetPreBookingStatus(int userId, DateTime bookingDate)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("curdate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, bookingDate);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetPreBookingStatus", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public decimal GetTaxPercentage(int userId, decimal Amount)
        {
            decimal GST = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("amount", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Amount);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                GST = Convert.ToDecimal(elhelper.ExecuteScalar("USP_GetTaxByAmount", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GST;
        }


        public DataSet GetPlan(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                ds = elhelper.ExecuteDataset("USP_GetPlans", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int InsertUpdatePlan(PlanCls objPlanCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[7];
                parameter[0] = new LbSprocParameter("@Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.Id);
                parameter[1] = new LbSprocParameter("@PlanName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.PlanName);
                parameter[2] = new LbSprocParameter("@Duration", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.Duration);
                parameter[3] = new LbSprocParameter("@Price", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.Price);
                parameter[4] = new LbSprocParameter("@IsActive", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.IsActive);
                parameter[5] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.CreatedBy);
                parameter[6] = new LbSprocParameter("@ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objPlanCls.ModifyBy);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_InsertUpdatePlan", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }

        public DataSet GetHotelPlans(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ds = elhelper.ExecuteDataset("USP_GetHotalPlan", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet GetHotals(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetHotelList", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public int InsertUpdatePlan(HotelPlanCls objHotelPlanCls)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[10];
                parameter[0] = new LbSprocParameter("@Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.Id);
                parameter[1] = new LbSprocParameter("@HotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.HotelId);
                parameter[2] = new LbSprocParameter("@PlanId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.PlanId);
                parameter[3] = new LbSprocParameter("@Startdate", DbType.Date, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.Startdate);
                parameter[4] = new LbSprocParameter("@EndDate", DbType.DateTime, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.EndDate);
                parameter[5] = new LbSprocParameter("@Duration", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.Duration);
                parameter[6] = new LbSprocParameter("@Price", DbType.Decimal, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.Price);
                parameter[7] = new LbSprocParameter("@Status", DbType.Int16, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.Status);
                parameter[8] = new LbSprocParameter("@CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.CreatedBy);
                parameter[9] = new LbSprocParameter("@ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objHotelPlanCls.ModifyBy);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_InsertUpdateHotelPlan", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }


        public DataSet GetPlanDetail(int planId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("planId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, planId);

                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetPlanDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookedRoomDetail_Admin(int userId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookedRoomDetail_Admin", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }




        public int AppSetting(int Id, string value)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, Id);
                parameter[1] = new LbSprocParameter("value", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, value);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = elhelper.ExecuteNonQuery("USP_AppSetting", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }



        public DataSet GetAppSetting()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAppSetting", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetAppSettingById(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
                ds = elhelper.ExecuteDataset("USP_GetAppSettingById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetAllRoomPlan(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllRoomPlan", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int SetRoomPlan(RoomPlanCls roomPlan)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, roomPlan.Id);
            parameter[1] = new LbSprocParameter("RoomPlanName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, roomPlan.RoomPlanName);
            parameter[2] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, roomPlan.IsActive);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, roomPlan.CreatedBy);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, roomPlan.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_SetRoomPlan", parameter));
            return Response;
        }

        public DataSet GetPlanAdmin()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetPlanAdmin", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetTranSummary(DateTime currDate, int userId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("currDate", DbType.Date, LbSprocParameter.LbParameterDirection.INPUT, currDate);
                parameter[1] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_TranSummary", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetTranSummaryDetail(DateTime FromDate, DateTime ToDate, int userId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[3];
                parameter[0] = new LbSprocParameter("FromDate", DbType.Date, LbSprocParameter.LbParameterDirection.INPUT, FromDate);
                parameter[1] = new LbSprocParameter("ToDate", DbType.Date, LbSprocParameter.LbParameterDirection.INPUT, ToDate);
                parameter[2] = new LbSprocParameter("userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetTranSummaryDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int SetExpanseHead(ExpanseHeadCls expanseHead)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[5];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, expanseHead.Id);
            parameter[1] = new LbSprocParameter("ExpanseHead", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, expanseHead.ExpanseHead);
            parameter[2] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, expanseHead.IsActive);
            parameter[3] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, expanseHead.CreatedBy);
            parameter[4] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, expanseHead.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();

            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_SetExpanseHead", parameter));
            return Response;
        }

        public DataSet GetAllExpanseHead(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllExpanseHead", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllExpance(int UserId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("userId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, UserId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllExpance", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int SetExpance(ExpanseCls objExpanse)
        {

            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[7];
            parameter[0] = new LbSprocParameter("Id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.Id);
            parameter[1] = new LbSprocParameter("Amount", DbType.Double, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.Amount);
            parameter[2] = new LbSprocParameter("ExpanseDate", DbType.Date, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.ExpanseDate);
            parameter[3] = new LbSprocParameter("ExpanseHeadId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.ExpanseHeadId);
            parameter[4] = new LbSprocParameter("IsActive", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.IsActive);
            parameter[5] = new LbSprocParameter("CreatedBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.CreatedBy);
            parameter[6] = new LbSprocParameter("ModifyBy", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, objExpanse.ModifyBy);

            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = elhelper.ExecuteNonQuery("USP_SetExpance", parameter);
            return Response;
        }

        public DataSet GetHotelPolicy(int hotelId)
        {
            DataSet ds = new DataSet();
            BookingCls objBooking = new BookingCls();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("HotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, hotelId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetHotelPolicy", parameter);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetHotelDetailForCP(int userId,int HotelIdCP)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("hotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                parameter[1] = new LbSprocParameter("hotelIdCP", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, HotelIdCP);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetHotelDetailForCP", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetBookingSourceDetail(int cpHotelId, string BookingSourceId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("cpHotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, cpHotelId);
                parameter[1] = new LbSprocParameter("BookingSourceId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, BookingSourceId);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetBookingSourceDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public void InsertResponse(int HotelId, string BookingLog, string RequestLog, string ResponseLog)
        {
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[4];
                parameter[0] = new LbSprocParameter("HotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, HotelId);
                parameter[1] = new LbSprocParameter("BookingLog", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, BookingLog);
                parameter[2] = new LbSprocParameter("RequestLog", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, RequestLog);
                parameter[3] = new LbSprocParameter("ResponseLog", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, ResponseLog);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                elhelper.ExecuteNonQuery("USP_InsertResponse", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCommision(string source)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("OTANameChannel", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, source);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetCommisionById", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int CancelBooking(int HotelId, string VoucherNo)
        {
            int Response = 0;
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                parameter[0] = new LbSprocParameter("@HotelId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, HotelId);
                parameter[1] = new LbSprocParameter("@VoucherNo", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, VoucherNo);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_CancelBooking", parameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Response;
        }


        public DataSet RptCPDetail(int userId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@userId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, userId);
                ds = elhelper.ExecuteDataset("USP_RptCPDetail", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }




        public DataSet GetBookingDetailByHBookingId(string HBookingId,int HotelId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[2];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("@HBookingId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, HBookingId);
                parameter[1] = new LbSprocParameter("@HotelId", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, HotelId);
                ds = elhelper.ExecuteDataset("UPS_GetBookingDetailByHBookingId", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public void InsertLogs( string ResponseLog)
        {
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("logs", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, ResponseLog);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                elhelper.ExecuteNonQuery("USP_CPLogs", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
