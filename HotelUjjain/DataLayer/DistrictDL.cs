//using ELHelper;
using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class DistrictDL
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
        public ResponseDto GetDistrict(string Con="")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<DistrictDto> lstDistrictDto = new List<DistrictDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con,"usp_GetDistrict", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstDistrictDto.Add(new DistrictDto(dr));
                        }
                    }
                }
                ResponseDto response = new ResponseDto(ResponseCode, lstDistrictDto, ResponseMessage);
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
        public ResponseDto InsertUpdateDeleteDistrict(DistrictDto para, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[5];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                
                parameter[0] = new SqlParameter("idState",  para.StateID);
                parameter[1] = new SqlParameter("DistrictName",  para.DistrictName);
                parameter[2] = new SqlParameter("bActive", para.bActive);
                parameter[3] = new SqlParameter("isDeleted",  para.isDeleted);
                parameter[4] = new SqlParameter("idDistrict", para.idDistrict);
                //parameter[4] = new SqlParameter("idCity",  para.CityId);


                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteDistrict",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForDistrict",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con,"usp_InsertUpdateDeleteForDistrict", parameter);
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
        public ResponseDto GetDistrictById(int idDistrict, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                DistrictDto userDetails = new DistrictDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idDistrict",  idDistrict);
                ds = SqlHelper.ExecuteDataset(Con,"usp_GetDistrictById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new DistrictDto(dr);
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
        public DataSet GetAllCity(string idDistrict, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameter;
                parameter = new SqlParameter[1];
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idDistrict",  idDistrict);
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
    }
}
