//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class PoliceStationMasterDL
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
        public ResponseDto GetPoliceStationMaster(string Con="")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<PoliceStationMasterDto> lstUserDetails = new List<PoliceStationMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con,"usp_GetPoliceStationMaster", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new PoliceStationMasterDto(dr));
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
        public ResponseDto InsertUpdateDeletePoliceStationMaster(PoliceStationMasterDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[10];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;

                parameter[0] = new SqlParameter("idPoliceStationMaster", para.idPoliceStationMaster);
                parameter[1] = new SqlParameter("PoliceStationName", para.PoliceStationName);
                parameter[2] = new SqlParameter("idCity", para.idCity);
                parameter[3] = new SqlParameter("idState", para.idState);
                parameter[4] = new SqlParameter("idDistrict",  para.idDistrict);   
                parameter[5] = new SqlParameter("isDeleted", para.isDeleted);
                parameter[6] = new SqlParameter("MobileNumber", para.MobileNumber);
                parameter[7] = new SqlParameter("LandlineNumber", para.landLineNumber);
                parameter[8] = new SqlParameter("emailid", para.EmailId);
                parameter[9] = new SqlParameter("Password", para.Password);


                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeletePoliceStationMaster",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForPoliceStationMaster",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con,"usp_InsertUpdateDeleteForPoliceStationMaster", parameter);
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
        public ResponseDto GetPoliceStationMasterById(int idPoliceStationMaster, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                PoliceStationMasterDto userDetails = new PoliceStationMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idPoliceStationMaster",  idPoliceStationMaster);
                ds = SqlHelper.ExecuteDataset(Con,"usp_GetPoliceStationMasterById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new PoliceStationMasterDto(dr);
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
                parameter[0] = new SqlParameter("IdDistrict",  StateId);
                ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllCity", parameter);
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
                ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllState", parameter);
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
                parameter[0] = new SqlParameter("CityId",  CityId);
                ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllZone", parameter);
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
                parameter[0] = new SqlParameter("StateId",  StateId);
                ds = SqlHelper.ExecuteDataset(Con,"USP_GetAllDistrict", parameter);
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

        public ResponseDto GetPoliceStationMasterByName(int idPoliceStationMaster, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                PoliceStationMasterDto userDetails = new PoliceStationMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idPoliceStationMaster", idPoliceStationMaster);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetPoliceStationMasterByName", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new PoliceStationMasterDto(dr);
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
        public DataSet GetAllPoliceStation(string idUser, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idUser", idUser);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetPoliceStationByUserId", parameter);
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

        public ResponseDto GetPoliceStationProfileById(int idPoliceStationMaster, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                PoliceStationMasterDto userDetails = new PoliceStationMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idPoliceStationMaster", idPoliceStationMaster);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetPoliceStationProfileById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new PoliceStationMasterDto(dr);
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

        public ResponseDto ResetPoliceStationPassword(int idPoliceStationMaster,string encryptedPassword, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                PoliceStationMasterDto userDetails = new PoliceStationMasterDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[2];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idPoliceStationMaster", idPoliceStationMaster);
                parameter[1] = new SqlParameter("Password", encryptedPassword);
                ds = SqlHelper.ExecuteDataset(Con, "usp_ResetPoliceStationPassword", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new PoliceStationMasterDto(dr);
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
                    OtpResponseModel msgresponse = await SendSMS(message, regMobileNumber, "1707174705171965535", "GTRPRT", Con);
                    if (msgresponse.status == "success")
                    {
                        SqlParameter[] param = new SqlParameter[5];
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
