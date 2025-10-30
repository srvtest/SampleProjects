using DataLayer;
//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DataLayer
{
    public class HotelMasterDL
    {
        private int idUsr
        {
            get
            {
                int id = 0;
                //try
                //{
                //    id = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0;
                //}
                //catch (Exception)
                //{
                //}

                return id;
            }

        }
        public ResponseDto GetHotelDetail(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<HotelMasterDto> lstHotelDetails = new List<HotelMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetHotelDetail", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstHotelDetails.Add(new HotelMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstHotelDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetHotelById(int idHotelMaster, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                HotelMasterDto hotelMasterDto = new HotelMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idHotelMaster", idHotelMaster);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetHotelById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            hotelMasterDto = new HotelMasterDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, hotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto ValidateMobileNo(string sMobileNo, out int idHotelMaster, out string sPropertyType, string Con = "", string OTP = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            idHotelMaster = 0;
            sPropertyType = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                List<HotelCategoryDto> hotelCategoryDtos = new List<HotelCategoryDto>();
                MobileOtpDto mobileOtpDto = new MobileOtpDto();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("MobileNo", sMobileNo);
                parameter[1] = new SqlParameter("OTP", OTP);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_ValidateMobileNo", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ResponseCode == 1)
                    {
                        idHotelMaster = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        sPropertyType = Convert.ToString(ds.Tables[1].Rows[0][2]);
                    }
                    if (ds.Tables.Count == 2)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            mobileOtpDto = new MobileOtpDto(dr);
                        }
                    }
                    if (ds.Tables.Count > 2)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            hotelCategoryDtos.Add(new HotelCategoryDto(dr));
                        }
                    }
                }
                ResponseDto response;
                if (ds.Tables.Count > 2)
                {
                    response = new ResponseDto(ResponseCode, hotelCategoryDtos, ResponseMessage);
                }
                else
                {
                    response = new ResponseDto(ResponseCode, mobileOtpDto, ResponseMessage);
                }
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public DataSet GetAllCity(string StateId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("IdDistrict", Convert.ToInt32(StateId));
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllCity", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public DataSet GetAllDistrict(string StateId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("StateId", StateId);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllDistrict", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public DataSet GetAllState(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[0];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllState", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public DataSet GetAllZone(string CityId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("CityId", CityId);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllZone", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public DataSet GetAllPoliceStation(string idZone, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idCity", idZone);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllPoliceStation", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public ResponseDto GetHotelByPoliceStationId(int idUser, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<HotelMasterDto> lsthotelMasterDto = new List<HotelMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("iduser", idUser);
                //EventLogDto eventLogDto = new EventLogDto()
                //{
                //    MethodName = "GetHotelByPoliceStationId",
                //    Parameter = parameter.ToXML(),
                //    ProcName = "usp_GetHotelByPoliceStationId",
                //    idUser = idUsr,
                //    dtCreated = DateTime.Now,
                //};
                //CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetHotelByPoliceStationId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelMasterDto.Add(new HotelMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public DataSet GetAllPropertyType(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[0];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllPropertyType", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public ResponseDto InsertUpdateHotelCategory(HotelCategoryDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[5];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("@IdHotel", para.idHotel);
                parameter[1] = new SqlParameter("@idHotelRoomCategory", para.idHotelRoomCategory);
                parameter[2] = new SqlParameter("@CategoryName", para.CategoryName);
                parameter[3] = new SqlParameter("@iPrice", para.iPrice);
                parameter[4] = new SqlParameter("@isDeleted", para.isDeleted);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateHotelCategory",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateHotelCategory",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateHotelCategory", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                }
                ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetHotelCategory(int idHotel, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<HotelCategoryDto> lsthotelCategoryDto = new List<HotelCategoryDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idHotel", idHotel);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetHotelCategory", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelCategoryDto.Add(new HotelCategoryDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelCategoryDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto InsertUpdateDeleteHotel(HotelMasterDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[21];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("HotelID", para.HotelID);
                parameter[1] = new SqlParameter("HotelName", para.HotelName);
                parameter[2] = new SqlParameter("HotelAddress", para.HotelAddress);
                parameter[3] = new SqlParameter("HotelOwnerNumber", para.HotelOwnerNumber);
                parameter[4] = new SqlParameter("HotelOwnerName", para.HotelOwnerName);
                parameter[5] = new SqlParameter("HotelEmail", para.HotelEmail);
                parameter[6] = new SqlParameter("Status", para.Status);
                if (para.HotelPoliceStationId == 0)
                {
                    parameter[7] = new SqlParameter("HotelPoliceStationId", null);
                }
                else
                {
                    parameter[7] = new SqlParameter("HotelPoliceStationId", para.HotelPoliceStationId);
                }
                parameter[8] = new SqlParameter("isDeleted", para.isDeleted);
                if (para.SubscriptionExpireDate == DateTime.MinValue)
                {
                    parameter[9] = new SqlParameter("SubscriptionExpireDate", null);
                }
                else
                {
                    parameter[9] = new SqlParameter("SubscriptionExpireDate", para.SubscriptionExpireDate);
                }
                parameter[10] = new SqlParameter("HotelStateId", para.HotelStateId);
                parameter[11] = new SqlParameter("HotelCityid", para.HotelCityid);
                parameter[12] = new SqlParameter("HotelDistrictId", para.HotelDistrictId);
                parameter[13] = new SqlParameter("HotelTypeId", para.HotelTypeId);
                parameter[14] = new SqlParameter("RegMobileNumber", para.RegMobileNumber);
                parameter[15] = new SqlParameter("HotelWebsite", para.HotelWebsite);
                parameter[16] = new SqlParameter("Password", para.Password);
                parameter[17] = new SqlParameter("idHotelNew", sizeof(int));
                parameter[18] = new SqlParameter("HotelRoomCapacity", para.HotelRoomCapacity);
                parameter[19] = new SqlParameter("CreatedAt", DateTime.Now);
                parameter[20] = new SqlParameter("IsSubscribed", para.IsSubscribed);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteHotel",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForHotelMaster",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateDeleteForHotelMaster", parameter);
                int idHotelNew = 0;
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        idHotelNew = Convert.ToInt32(ds.Tables[1].Rows[0]["idHotelNew"]);
                    }
                }
                //int idHotelNew =Convert.ToInt32( parameter[19].Value);
                //int idHotelNew = Convert.IsDBNull("idHotelNew") ? 0 : Convert.ToInt32("idHotelNew");
                ResponseDto response = new ResponseDto(ResponseCode, idHotelNew, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto InsertHotelCategory(List<HotelCategoryDto> para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("@HotelCategoryData", para.ToXML());
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertHotelCategory", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                }
                ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetAllPropertyTypeApi(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                List<PropertyTypeDto> lsthotelMasterDto = new List<PropertyTypeDto>();
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                SqlParameter[] parameter;
                parameter = new SqlParameter[0];
                ////SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                //ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllPropertyType", parameter);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllPropertyTypeApi", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelMasterDto.Add(new PropertyTypeDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetAllStateApi(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                List<StateDto> lsthotelMasterDto = new List<StateDto>();
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                SqlParameter[] parameter;
                parameter = new SqlParameter[0];
                ////SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                //ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllPropertyType", parameter);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllStateApi", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelMasterDto.Add(new StateDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetAllDistrictApi(int StateId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                List<DistrictDto> lsthotelMasterDto = new List<DistrictDto>();
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("StateId", StateId);
                ////SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                //ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllPropertyType", parameter);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllDistrictApi", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelMasterDto.Add(new DistrictDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetAllCityApi(int IdDistrict, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                List<CityDto> lsthotelMasterDto = new List<CityDto>();
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("IdDistrict", IdDistrict);
                ////SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                //ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllPropertyType", parameter);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllCityApi", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelMasterDto.Add(new CityDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetAllPoliceStationApi(int idCity, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                List<PoliceStationMasterDto> lsthotelMasterDto = new List<PoliceStationMasterDto>();
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("idCity", idCity);
                ////SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                //ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllPropertyType", parameter);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllPoliceStationApi", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lsthotelMasterDto.Add(new PoliceStationMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lsthotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto UpdateHotelValidUptoById(int hotelId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("@idHotelmaster", hotelId);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_UpdateHotelValidUptoById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                }
                ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public ResponseDto GetHotelByMobileNumber(string MobileNumber, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                HotelMasterDto hotelMasterDto = new HotelMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("MobileNumber", MobileNumber);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetHotelByMobileNumber", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            hotelMasterDto = new HotelMasterDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, hotelMasterDto, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }

        public ResponseDto ResetHotelPassword(int HotelID, string encryptedPassword, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                string regMobileNumber = "", UserName = "", Password = "", HotelName = "", HotelEmail = "";
                DLUtility dLUtility = new DLUtility();
                HotelMasterDto userDetails = new HotelMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("HotelID", HotelID);
                parameter[1] = new SqlParameter("Password", encryptedPassword);
                ds = SqlHelper.ExecuteDataset(Con, "usp_ResetHotelPassword", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new HotelMasterDto(dr);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, userDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }
        public DataSet GetAllPoliceStationMaster(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[0];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                //parameter[0] = new SqlParameter("idCity", idZone);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllPoliceStationMaster", parameter);
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return ds;
        }
        public ResponseDto InsertUpdateDeleteHotelImage(HotelMasterDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[4];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("HotelID", para.HotelID);
                parameter[1] = new SqlParameter("HotelRegistrationDoc", para.HotelRegistrationDocPath);
                parameter[2] = new SqlParameter("HotelOwnerAdharFront", para.HotelOwnerAdharFrontPath);
                parameter[3] = new SqlParameter("HotelOwnerAdharBack", para.HotelOwnerAdharBackPath);

                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateForHotelImage",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateForHotelImage",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateForHotelImage", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                }
                ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }

        public async Task<OtpResponseModel> SendSMS(string message, string numbers, string TemplateId, string sendername, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            OtpResponseModel res = new OtpResponseModel();
            try
            {
                string url = "http://sms.bulksmsind.in/v2/sendSMS?username=amanshivhare&message=" + message + "&sendername=" + sendername + "&smstype=TRANS&numbers=" + numbers + "&apikey=ad7c2f00-c152-43d5-8984-e62c353aeba5&peid=1201161743317422401&templateid=" + TemplateId + "";
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                var result = response.Content.ReadAsStringAsync().Result;
                res = JsonConvert.DeserializeObject<List<OtpResponseModel>>(result).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return res;
        }

        public async Task<ResponseDto> InsertNotificationLogsAsync(int Id, string regMobileNumber, string message, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            string res = "";
            try
            {
                SqlParameter[] parameter = new SqlParameter[9];
                parameter[0] = new SqlParameter("@NotificationType", "SMS");
                parameter[1] = new SqlParameter("@MobileNumber", regMobileNumber);
                parameter[2] = new SqlParameter("@Email", "");
                parameter[3] = new SqlParameter("@Message", message);
                parameter[4] = new SqlParameter("@UserType", "Hotel");
                parameter[5] = new SqlParameter("@UserTypeID", Id);
                parameter[6] = new SqlParameter("@isSent", 0);
                parameter[7] = new SqlParameter("@CreatedAt", DateTime.Now);
                parameter[8] = new SqlParameter("@TemplateID", "1707174705171965535");
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertNotificationLogsAsync",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertNotificationLogs",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                object insertedId = SqlHelper.ExecuteScalar(Con, "usp_InsertNotificationLogs", parameter);
                string NotificationID = "";
                if (insertedId != null)
                {
                    NotificationID = (insertedId).ToString();
                }

                try
                {
                    OtpResponseModel msgresponse = await SendSMS(message, regMobileNumber, "1707174705171965535", "GTRPRT",Con);
                    if (msgresponse.status == "success")
                    {
                        SqlParameter[] param= new SqlParameter[5];
                        param[0] = new SqlParameter("@isSent", "1");
                        param[1] = new SqlParameter("@SentID", msgresponse.msgID);
                        param[2] = new SqlParameter("@sentStatus", msgresponse.status);
                        param[3] = new SqlParameter("@NotificationLogsID", NotificationID);
                        param[4] = new SqlParameter("@SentDatetime", DateTime.Now);                      
                        EventLogDto eventLogDto1 = new EventLogDto()
                        {
                            MethodName = "InsertNotificationLogsAsync",
                            Parameter = parameter.ToXML(),
                            ProcName = "usp_UpdateNotificationLogs",
                            idUser = idUsr,
                            dtCreated = DateTime.Now,
                        };
                        CommonDL.InsertEventLog(eventLogDto, Con);
                        SqlHelper.ExecuteNonQuery(Con, "usp_UpdateNotificationLogs", param);
                        res = "success";
                    }
                    else
                    {
                        SqlParameter[] param = new SqlParameter[5];
                        param[0] = new SqlParameter("@isSent", "0");
                        param[1] = new SqlParameter("@SentID", msgresponse.msgID);
                        param[2] = new SqlParameter("@sentStatus", msgresponse.status);
                        param[3] = new SqlParameter("@NotificationLogsID", NotificationID);
                        param[4] = new SqlParameter("@SentDatetime", DateTime.Now);
                        EventLogDto eventLogDto1 = new EventLogDto()
                        {
                            MethodName = "InsertNotificationLogsAsync",
                            Parameter = parameter.ToXML(),
                            ProcName = "usp_UpdateNotificationLogs",
                            idUser = idUsr,
                            dtCreated = DateTime.Now,
                        };
                        CommonDL.InsertEventLog(eventLogDto, Con);
                        SqlHelper.ExecuteNonQuery(Con, "usp_UpdateNotificationLogs", param);
                    }
                }
                catch (Exception ex)
                {
                    //insertError(ex.Message, "NotificationLogs At Hotel Reset Password.");
                    ErrorLogDto errorLogDto = new ErrorLogDto()
                    {
                        ErrorType = "DB Error",
                        ErrorMessage = ex.Message,
                        idUser = idUsr,
                        dtCreated = DateTime.Now,
                        Method = "NotificationLogs At Hotel Reset Password."
                    };
                    CommonDL.InsertErrorLog(errorLogDto, Con);
                }
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = idUsr,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto, Con);
            }
            return null;
        }       
    }
}
