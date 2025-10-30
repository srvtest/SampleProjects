//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{

    public class CityDL
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
        public ResponseDto GetCity(string Con="")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<CityDto> lstUserDetails = new List<CityDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;

                ds = SqlHelper.ExecuteDataset(Con,"usp_GetCity", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new CityDto(dr));
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
        public ResponseDto InsertUpdateDeleteCity(CityDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[6];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;

                parameter[0] = new SqlParameter("StateId", para.StateID);
                parameter[1] = new SqlParameter("CityName", para.CityName);   
                parameter[2] = new SqlParameter("CityId", para.CityId);
                parameter[3] = new SqlParameter("bActive", para.bActive);    
                parameter[4] = new SqlParameter("isDeleted", para.isDeleted);
                parameter[5] = new SqlParameter("idDistrict", para.idDistrict);
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteCity",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForCity",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);

                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateDeleteForCity", parameter);
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
        public ResponseDto GetCityById(int idCity, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                CityDto userDetails = new CityDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                parameter[0] = new SqlParameter("CityID", idCity);
                ds = SqlHelper.ExecuteDataset(Con, "usp_GetCityById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new CityDto(dr);
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
        public DataSet GetAllState(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter[] parameter = new SqlParameter[0];
                    ds = SqlHelper.ExecuteDataset(Con, "USP_GetAllState", parameter);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
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
        public DataSet GetDistictByStateId(int StateId, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("StateId", StateId);
                ds = SqlHelper.ExecuteDataset(Con, "USP_GetDistrictByStateId", parameter);
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
    }
}
