//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class NotificationLogsDL
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
        public ResponseDto GetNotificationLogs(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<NotificationLogsDto> lstUserDetails = new List<NotificationLogsDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetNotificationLogs", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new NotificationLogsDto(dr));
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
        //public ResponseDto InsertUpdateDeleteRequestResponseLog(NotificationLogsDto para, string Con = "")
        //{
        //    if (string.IsNullOrEmpty(Con))
        //        Con = CommonDL.conString;
        //    try
        //    {
        //        DLUtility dLUtility = new DLUtility();
        //        DataSet ds = new DataSet();
        //        SqlParameter[] parameter = new SqlParameter[10];
        //        string ResponseMessage = string.Empty;
        //        int ResponseCode = 0;

        //        parameter[0] = new SqlParameter("RequestResponseLogId", para.RequestResponseLogId);
        //        parameter[1] = new SqlParameter("ErrorMessage", para.RequestAPIType);
        //        parameter[2] = new SqlParameter("ErrorType", para.RequestAPIName); 
        //        parameter[3] = new SqlParameter("HotelId", para.HotelId);
        //        parameter[4] = new SqlParameter("PoliceStationId", para.PoliceStationId);
        //        parameter[5] = new SqlParameter("CreatedOn", para.CreatedOn);
        //        parameter[6] = new SqlParameter("RequestBody", para.RequestBody);
        //        parameter[7] = new SqlParameter("ResponseBody", para.ResponseBody);
        //        parameter[8] = new SqlParameter("HttpRequestResponse", para.HttpRequestResponse);
        //        parameter[9] = new SqlParameter("isDeleted", para.isDeleted);
        //        //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
        //        EventLogDto eventLogDto = new EventLogDto()
        //        {
        //            MethodName = "InsertUpdateDeleteRequestResponseLog",
        //            Parameter = parameter.ToXML(),
        //            ProcName = "usp_InsertUpdateDeleteForRequestResponseLog",
        //            idUser = idUsr,
        //            dtCreated = DateTime.Now,
        //        };
        //        CommonDL.InsertEventLog(eventLogDto, Con);
        //        ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateDeleteForRequestResponseLog", parameter);
        //        if (ds != null)
        //        {
        //            ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
        //            ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
        //        }
        //        ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogDto errorLogDto = new ErrorLogDto()
        //        {
        //            ErrorType = "DB Error",
        //            ErrorMessage = ex.Message,
        //            idUser = idUsr,
        //            dtCreated = DateTime.Now
        //        };
        //        CommonDL.InsertErrorLog(errorLogDto, Con);
        //    }
        //    return null;
        //}
        //public ResponseDto GetRequestResponseLogById(int RequestResponseLogId, string Con = "")
        //{
        //    if (string.IsNullOrEmpty(Con))
        //        Con = CommonDL.conString;
        //    try
        //    {
        //        DLUtility dLUtility = new DLUtility();
        //        RequestResponseLogDto userDetails = new RequestResponseLogDto();
        //        DataSet ds = new DataSet();
        //        SqlParameter[] parameter = new SqlParameter[1];
        //        string ResponseMessage = string.Empty;
        //        int ResponseCode = 0;
        //        //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
        //        parameter[0] = new SqlParameter("RequestResponseLogId", RequestResponseLogId);
        //        ds = SqlHelper.ExecuteDataset(Con, "usp_GetRequestResponseLogById", parameter);
        //        if (ds != null)
        //        {
        //            ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
        //            ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
        //            if (ds.Tables.Count > 1)
        //            {
        //                foreach (DataRow dr in ds.Tables[1].Rows)
        //                {
        //                    userDetails = new RequestResponseLogDto(dr);
        //                }
        //            }
        //        }
        //        ResponseDto response = new ResponseDto(ResponseCode, userDetails, ResponseMessage);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogDto errorLogDto = new ErrorLogDto()
        //        {
        //            ErrorType = "DB Error",
        //            ErrorMessage = ex.Message,
        //            idUser = idUsr,
        //            dtCreated = DateTime.Now
        //        };
        //        CommonDL.InsertErrorLog(errorLogDto, Con);
        //    }
        //    return null;
        //}
        
        //public DataSet GetAllRequestResponseLog(string Con = "")
        //{
        //    if (string.IsNullOrEmpty(Con))
        //        Con = CommonDL.conString;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlParameter[] parameter;
        //        parameter = new SqlParameter[0];
        //        //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
        //        ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllRequestResponseLog", parameter);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogDto errorLogDto = new ErrorLogDto()
        //        {
        //            ErrorType = "DB Error",
        //            ErrorMessage = ex.Message,
        //            idUser = idUsr,
        //            dtCreated = DateTime.Now
        //        };
        //        CommonDL.InsertErrorLog(errorLogDto, Con);
        //    }
        //    return ds;
        //}
    }
}
