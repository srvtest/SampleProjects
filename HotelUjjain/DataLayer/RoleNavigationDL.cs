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
    public class RoleNavigationDL
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
        public ResponseDto InsertUpdateDeleteRoleNavigation(RoleNavigationDto para, string Con = "")
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

                parameter[0] = new SqlParameter("idRoleNavigation",  para.idRoleNavigation);
                parameter[1] = new SqlParameter("idRole",  para.idRole);
                parameter[2] = new SqlParameter("idNavigation",  para.idNavigation);
                parameter[3] = new SqlParameter("bActive",  para.bActive);
                parameter[4] = new SqlParameter("isDeleted",  para.isDeleted);

                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteRoleNavigation",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForRoleNavigation",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);
                ds = SqlHelper.ExecuteDataset(Con,"usp_InsertUpdateDeleteForRoleNavigation", parameter);
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

        public ResponseDto GetRoleNavigation(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                List<RoleNavigationDto> lstUserDetails = new List<RoleNavigationDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                ds = SqlHelper.ExecuteDataset(Con,"usp_GetRoleNavigation", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstUserDetails.Add(new RoleNavigationDto(dr));
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

        public ResponseDto GetRoleNavigationById(int idRoleNavigation, string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                DLUtility dLUtility = new DLUtility();
                RoleNavigationDto userDetails = new RoleNavigationDto();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[1];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //SqlHelper.ELHelper elHelper = new SqlHelper.ELHelper();
                parameter[0] = new SqlParameter("idRoleNavigation",  idRoleNavigation);
                ds = SqlHelper.ExecuteDataset(Con,"usp_GetRoleNavigationById", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    if (ds.Tables.Count > 1)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            userDetails = new RoleNavigationDto(dr);
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
    }
}
