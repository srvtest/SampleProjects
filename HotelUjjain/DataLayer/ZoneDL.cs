using ELHelper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class ZoneDL
    {
        public ResponseDto GetZone()
        {
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<ZoneDto> lstUserDetails = new List<ZoneDto>();
                DataSet ds = new DataSet();
                LbSprocParameter[] parameter = new LbSprocParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                ds = elHelper.ExecuteDataset("usp_GetZone", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new ZoneDto(dr));
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

        public ResponseDto InsertUpdateDeleteZone(ZoneDto para)
        {
            try
            {
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                LbSprocParameter[] parameter = new LbSprocParameter[6];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;

                parameter[0] = new LbSprocParameter("idZone", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.idZone);
                parameter[1] = new LbSprocParameter("idState", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.StateID);
                parameter[2] = new LbSprocParameter("ZoneName", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, para.ZoneName);
                parameter[3] = new LbSprocParameter("isDeleted", DbType.Boolean, LbSprocParameter.LbParameterDirection.INPUT, para.isDeleted);
                parameter[4] = new LbSprocParameter("idCity", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.CityId);
                parameter[5] = new LbSprocParameter("bActive", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, para.bActive);

                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteZone",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForZone",
                    idUser = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto);
                ds = elHelper.ExecuteDataset("usp_InsertUpdateDeleteForZone", parameter);
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
                    idUser = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto);
            }
            return null;
        }
        public ResponseDto GetZoneById(int idZone)
        {
            try
            {
                DLUtility dLUtility = new DLUtility();
                ZoneDto userDetails = new ZoneDto();
                DataSet ds = new DataSet();
                LbSprocParameter[] parameter = new LbSprocParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("idZone", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, idZone);
                ds = elHelper.ExecuteDataset("usp_GetZoneById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new ZoneDto(dr);
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
                    idUser = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0,
                    dtCreated = DateTime.Now
                };
                CommonDL.InsertErrorLog(errorLogDto);
            }
            return null;
        }
        public DataSet GetAllCity(string StateId)
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                parameter[0] = new LbSprocParameter("StateId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, StateId);
                ds = elhelper.ExecuteDataset("USP_GetAllCity", parameter);
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
            return ds;
        }
        public DataSet GetAllState()
        {
            DataSet ds = new DataSet();
            try
            {
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[0];
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_GetAllState", parameter);
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
            return ds;
        }
    }
}
