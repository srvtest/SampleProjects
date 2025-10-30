//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class GuestMasterDL
    {
        private static string _EncryptionKey;
        public static string EncryptionKey
        {
            get
            {
                if (_EncryptionKey == null || _EncryptionKey == string.Empty)
                {
                    _EncryptionKey = "H0t3l!Gu35t";
                }
                return _EncryptionKey;
            }
        }
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
        public ResponseDto InsertUpdateDeleteGuestMaster(GuestMasterDto para, bool PassAPI, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                //if (PassAPI)
                //{
                //    para.ContactNo = para.ContactNo;
                //    para.IdentificationNo = para.IdentificationNo;
                //    if (para.Details != null && para.Details.Count > 0)
                //    {
                //        foreach (GuestDetailDto item in para.Details)
                //        {
                //            item.ContactNo = item.ContactNo;
                //            item.IdentificationNo = item.IdentificationNo;
                //        }
                //    }
                //}
                //else
                //{
                para.ContactNo = para.ContactNo.Encrypt(EncryptionKey, true);
                para.IdentificationNo = para.IdentificationNo.Encrypt(EncryptionKey, true);
                if (para.Details != null && para.Details.Count > 0)
                {
                    foreach (GuestDetailDto item in para.Details)
                    {
                        item.ContactNo = item.ContactNo.Encrypt(EncryptionKey, true);
                        item.IdentificationNo = item.IdentificationNo.Encrypt(EncryptionKey, true);
                    }
                }
                //  }
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[25];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;

                parameter[0] = new SqlParameter("idGuestMaster", para.idGuestMaster);
                parameter[1] = new SqlParameter("idHotel", para.idHotel);
                parameter[2] = new SqlParameter("bActive", para.bActive);
                parameter[3] = new SqlParameter("isDeleted", para.isDeleted);
                parameter[4] = new SqlParameter("GuestName", para.GuestName);
                parameter[5] = new SqlParameter("Address", para.Address);
                parameter[6] = new SqlParameter("ContactNo", para.ContactNo);
                parameter[7] = new SqlParameter("IdentificationNo", para.IdentificationNo);
                parameter[8] = new SqlParameter("IdentificationType", para.IdentificationType);
                parameter[9] = new SqlParameter("CheckInDate", para.CheckInDate);
                parameter[10] = new SqlParameter("CheckOutDate", para.CheckOutDate);
                parameter[11] = new SqlParameter("Description", para.Description);
                parameter[12] = new SqlParameter("AddionalGuest", para.AddionalGuest);
                parameter[13] = new SqlParameter("GuestXml", para.Details.ToXML());

                parameter[14] = new SqlParameter("GuestLastName", para.GuestLastName);
                parameter[15] = new SqlParameter("gender", para.gender);
                parameter[16] = new SqlParameter("TravelReson", para.TravelReson);
                parameter[17] = new SqlParameter("city", para.city);
                parameter[18] = new SqlParameter("PIncode", para.PIncode);
                parameter[19] = new SqlParameter("filePass", para.filePass);
                parameter[20] = new SqlParameter("Image1", para.Image1);
                parameter[21] = new SqlParameter("Image2", para.Image2);
                parameter[22] = new SqlParameter("CategoriesXml", para.Categories.ToXML());
                parameter[23] = new SqlParameter("IdentificationNoTemp", para.IdentificationNoTemp);
                parameter[24] = new SqlParameter("ContactNoTemp", para.ContactNoTemp);
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteGuestMaster",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForGuestMaster",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateDeleteForGuestMaster", parameter);
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
        public ResponseDto InsertUpdateDeleteGuestMasterXML(GuestMasterDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;

                parameter[0] = new SqlParameter("GuestMasterXml", para.ToXML());
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateDeleteForGuestMaster", parameter);
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
        public ResponseDto GetGuestMaster(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestMaster", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestMasterById(int idGuestMaster, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<GuestMasterDto> userDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idGuestMaster", idGuestMaster);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestMasterById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                            string identificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            guestMasterDto.IdentificationNo = identificationNo;
                            userDetails.Add(guestMasterDto);
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
        public ResponseDto GetGuestMasterFilter(GuestFilterDto guestFilterDto, bool PassAPI, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                //if (PassAPI)
                //{
                //    guestFilterDto.ContactNo = !string.IsNullOrEmpty(guestFilterDto.ContactNo) ? guestFilterDto.ContactNo : guestFilterDto.ContactNo;
                //    guestFilterDto.IdentificationNo = !string.IsNullOrEmpty(guestFilterDto.IdentificationNo) ? guestFilterDto.IdentificationNo : guestFilterDto.IdentificationNo;
                //}
                //else
                //{
                guestFilterDto.ContactNo = !string.IsNullOrEmpty(guestFilterDto.ContactNo) ? guestFilterDto.ContactNo.Encrypt(EncryptionKey, true) : guestFilterDto.ContactNo;
                guestFilterDto.IdentificationNo = !string.IsNullOrEmpty(guestFilterDto.IdentificationNo) ? guestFilterDto.IdentificationNo.Encrypt(EncryptionKey, true) : guestFilterDto.IdentificationNo;
                //}                
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestMasterData", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestDetailDto = new GuestMasterDto(dr);
                            //if (PassAPI)
                            //{
                            //    guestDetailDto.IdentificationNo = guestDetailDto.IdentificationNo;
                            //    guestDetailDto.ContactNo = guestDetailDto.ContactNo;
                            //}
                            //else
                            //{
                            guestDetailDto.IdentificationNo = guestDetailDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            guestDetailDto.ContactNo = guestDetailDto.ContactNo.Decrypt(EncryptionKey, true);
                            //}                            
                            lstUserDetails.Add(guestDetailDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto SubmitGuestData(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "SubmitGuestData",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_SubmitGuestData",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "usp_SubmitGuestData", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestDetailByPoliceStationId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<SubmitSummeryDto> lstUserDetails = new List<SubmitSummeryDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestDetailByPoliceStationId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new SubmitSummeryDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetHotelGuestDetailByPoliceStationId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetHotelGuestDetailByPoliceStationId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestDetailSearchByPoliceStationId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                guestFilterDto.ContactNo = !string.IsNullOrEmpty(guestFilterDto.ContactNo) ? guestFilterDto.ContactNo.Encrypt(EncryptionKey, true) : guestFilterDto.ContactNo;
                guestFilterDto.IdentificationNo = !string.IsNullOrEmpty(guestFilterDto.IdentificationNo) ? guestFilterDto.IdentificationNo.Encrypt(EncryptionKey, true) : guestFilterDto.IdentificationNo;
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestDetailSearchByPoliceStationId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                            guestMasterDto.IdentificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            lstUserDetails.Add(guestMasterDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetPandingGuestByHotelId(int idHotel, DateTime CheckInDate, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idHotel", idHotel);
                parameter[1] = new SqlParameter("CheckInDate", CheckInDate);

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetPandingGuestByHotelId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetSubmitedGuestByHotelId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[3];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idHotel", guestFilterDto.idHotel);
                parameter[1] = new SqlParameter("fDate", guestFilterDto.FilterFromDate);
                parameter[2] = new SqlParameter("ldate", guestFilterDto.FilterToDate);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetSubmitedGuestByHotelId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                            string identificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            guestMasterDto.IdentificationNo = identificationNo;
                            lstUserDetails.Add(guestMasterDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetNotSubmitGuestDetailByPoliceStationId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetNotSubmitGuestDetailByPoliceStationId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetPandingGuestSummeryByHotelId(int idHotel, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idHotel", idHotel);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetPandingGuestSummeryByHotelId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto ValidateSubmitDate(int idHotel, DateTime submitDate, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                int count = 0;
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idHotel", idHotel);
                parameter[1] = new SqlParameter("submitDate", submitDate);
                ds = SqlHelper.ExecuteDataset(Con, "usp_ValidateSubmitDate", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, count, ResponseMessage);
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
        public ResponseDto GetSubmitedGuestSummeryByHotelId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetSubmitedGuestSummeryByHotelId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestCompleteDetail(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestCompleteDetail", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestCompleteDetailForReport(GuestFilterDto guestFilterDto, bool PassValue, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestCompleteDetailForReport", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            if (PassValue)
                            {
                                guestMasterDto.ContactNo = guestMasterDto.ContactNo;
                                string identificationNo = guestMasterDto.IdentificationNo;
                                guestMasterDto.IdentificationNo = identificationNo;
                            }
                            else
                            {
                                guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                                string identificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                                guestMasterDto.IdentificationNo = identificationNo;
                            }

                            lstUserDetails.Add(guestMasterDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestPandingDetailForReport(GuestFilterDto guestFilterDto, bool PassApi, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestPandingDetailForReport", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            //if (PassApi)
                            //{
                            //    guestMasterDto.ContactNo = guestMasterDto.ContactNo;
                            //    string identificationNo = guestMasterDto.IdentificationNo;
                            //    guestMasterDto.IdentificationNo = identificationNo;
                            //}
                            //else
                            //{
                            guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                            string identificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            guestMasterDto.IdentificationNo = identificationNo;
                            //}                           
                            //foreach (var item in guestMasterDto.Details)
                            //{
                            //    item.ContactNo= item.ContactNo.Decrypt(EncryptionKey, true);
                            //    item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);
                            //}
                            lstUserDetails.Add(guestMasterDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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
        public ResponseDto GetGuestCompleteDetailByGuestId(string idGuestMaster, bool PassApi, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<GuestMasterDto> userDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idGuestMaster", Convert.ToInt32(idGuestMaster));
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestCompleteDetailByGuestId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            //if (PassApi)
                            //{
                            //    guestMasterDto.ContactNo = guestMasterDto.ContactNo;
                            //    string identificationNo = guestMasterDto.IdentificationNo;
                            //    guestMasterDto.IdentificationNo = identificationNo;
                            //}
                            //else
                            //{
                            guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                            string identificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            guestMasterDto.IdentificationNo = identificationNo;
                            //}
                            userDetails.Add(guestMasterDto);
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
        public ResponseDto GetGuestMasterAdmin(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                guestFilterDto.FilterContact = !string.IsNullOrEmpty(guestFilterDto.FilterContact) ? guestFilterDto.FilterContact.Encrypt(EncryptionKey, true) : guestFilterDto.FilterContact;
                guestFilterDto.FilterAdhar = !string.IsNullOrEmpty(guestFilterDto.FilterAdhar) ? guestFilterDto.FilterAdhar.Encrypt(EncryptionKey, true) : guestFilterDto.FilterAdhar;
                //guestFilterDto.FilterContact = !string.IsNullOrEmpty(guestFilterDto.FilterContact) ? guestFilterDto.FilterContact.Encrypt(EncryptionKey, true) : guestFilterDto.FilterContact;
                //guestFilterDto.FilterAdhar = !string.IsNullOrEmpty(guestFilterDto.FilterAdhar) ? guestFilterDto.FilterAdhar.Encrypt(EncryptionKey, true) : guestFilterDto.FilterAdhar;
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestMasterAdmin", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            guestMasterDto.GuestMobileNumber = guestMasterDto.GuestMobileNumber;
                            guestMasterDto.IDProofNumber = guestMasterDto.IDProofNumber;
                            lstUserDetails.Add(guestMasterDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
                return response;
            }
            catch (Exception ex)
            {
                ErrorLogDto errorLogDto = new ErrorLogDto()
                {
                    ErrorType = "DB Error",
                    ErrorMessage = ex.Message,
                    idUser = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto);
            }
            return null;
        }
        public ResponseDto GetPendingGuestDetailByPoliceStationId(GuestFilterDto guestFilterDto, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<SubmitSummeryDto> lstUserDetails = new List<SubmitSummeryDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());

                ds = SqlHelper.ExecuteDataset(Con, "usp_GetPendingGuestDetailByPoliceStationId", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new SubmitSummeryDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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

        public ResponseDto GetGuestPendingDetailForPoliceReport(GuestFilterDto guestFilterDto, bool PassApi, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("GuestFilterXml", guestFilterDto.ToXML());
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetGuestPendingDetailForPoliceReport", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            GuestMasterDto guestMasterDto = new GuestMasterDto(dr);
                            //if (PassApi)
                            //{
                            //    guestMasterDto.ContactNo = guestMasterDto.ContactNo;
                            //    string identificationNo = guestMasterDto.IdentificationNo;
                            //    guestMasterDto.IdentificationNo = identificationNo;
                            //}
                            //else
                            //{
                            guestMasterDto.ContactNo = guestMasterDto.ContactNo.Decrypt(EncryptionKey, true);
                            string identificationNo = guestMasterDto.IdentificationNo.Decrypt(EncryptionKey, true);
                            guestMasterDto.IdentificationNo = identificationNo;
                            //}                           
                            //foreach (var item in guestMasterDto.Details)
                            //{
                            //    item.ContactNo= item.ContactNo.Decrypt(EncryptionKey, true);
                            //    item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);
                            //}
                            lstUserDetails.Add(guestMasterDto);
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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

        public ResponseDto GetPoliceStationNoBySurveillanceNo(string SurveillanceNo, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("SurveillanceNo", SurveillanceNo);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetPoliceStationNoBySurveillanceNo", parameter);
                if (ds != null)
                {
                    //ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    //ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            lstUserDetails.Add(new GuestMasterDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstUserDetails, ResponseMessage);
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

        public ResponseDto GetGuestMasterByHotelID(CheckInReportWithGuestDataRequestModel requestModel, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<GuestDataReportResponseModel> userDetails = new List<GuestDataReportResponseModel>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[3];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("@HotelID", requestModel.HotelId);
                parameter[1] = new SqlParameter("@CheckInDate", requestModel.CheckInDate);
                if (requestModel.BookingId != null)
                {
                    parameter[2] = new SqlParameter("@BookingID", requestModel.BookingId);
                }
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "GetGuestDataReport",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_GetGuestDataReport",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con, "GetGuestDataReport", parameter);
                if (ds != null)
                {                   
                    var responseModel = new GuestDataReportResponseModel();
                    responseModel.hotelDetails = new HotelDetailResponseModel
                    {
                        HotelName = ds.Tables[0].Rows[0]["HotelName"].ToString(),
                        HotelAddress = ds.Tables[0].Rows[0]["HotelAddress"].ToString(),
                        HotelMobileNumber = ds.Tables[0].Rows[0]["HotelMobileNumber"].ToString()
                    };

                    responseModel.Totalguest = ds.Tables[0].Rows[0]["Totalguest"].ToString();
                    responseModel.CheckInDate = ds.Tables[0].Rows[0]["CheckInDate"].ToString();
                    responseModel.MaleCount = ds.Tables[0].Rows[0]["MaleCount"].ToString();
                    responseModel.FemaleCount = ds.Tables[0].Rows[0]["FemaleCount"].ToString();
                    var guestDetailsJson = ds.Tables[0].Rows[0]["guestdetails"].ToString();
                    if (!string.IsNullOrEmpty(guestDetailsJson))
                    {
                        responseModel.guestdetails = JsonSerializer.Deserialize<List<guestdetailsResponseModel>>(guestDetailsJson);
                        foreach (var guest in responseModel.guestdetails)
                        {
                            guest.guestMobileNumber = (guest.guestMobileNumber);
                            guest.guestIDNumber = MaskIDProofNumber((guest.guestIDNumber));
                            //guest.guestMobileNumber = EncryptionHelper.Decrypt(guest.guestMobileNumber);
                            //guest.guestIDNumber = MaskIDProofNumber(EncryptionHelper.Decrypt(guest.guestIDNumber));
                            guest.guestFrontSideDocs = guest.guestFrontSideDocs;
                            guest.guestBackSideDocs = guest.guestBackSideDocs;
                        }
                    }
                    var guestImageDetailsJson = ds.Tables[0].Rows[0]["guestImagedetails"].ToString();
                    if (!string.IsNullOrEmpty(guestImageDetailsJson))
                    {
                        responseModel.guestimagedetails = JsonSerializer.Deserialize<List<guestImagedetailsResponseModel>>(guestImageDetailsJson);
                        foreach (var guest in responseModel.guestimagedetails)
                        {
                            guest.guestFrontSideDocs = guest.guestFrontSideDocs;
                            guest.guestBackSideDocs = guest.guestBackSideDocs;
                        }
                    }
                    userDetails.Add(responseModel);
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
        public string MaskIDProofNumber(string idProofNumber)
        {
            if (string.IsNullOrEmpty(idProofNumber))
            {
                return string.Empty; // Return empty if input is null or empty
            }
            // Assuming you want to mask all but the last 4 digits (you can adjust this if needed)
            int visibleLength = 4;
            int maskLength = idProofNumber.Length - visibleLength;

            if (maskLength <= 0)
            {
                // If the length of the IDProofNumber is less than or equal to the visible length, return it as is
                return idProofNumber;
            }

            // Mask all characters except for the last 4
            string maskedID = new string('*', maskLength) + idProofNumber.Substring(maskLength);

            return maskedID;
        }
        public ResponseDto UpdateGuestMaster(List<GuestMasterDto> para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("UpdateGuestMasterXml", para.ToXML());
                
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "UpdateGuestMaster",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_UpdateForGuestMaster",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_UpdateForGuestMaster", parameter);
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
    }
}
