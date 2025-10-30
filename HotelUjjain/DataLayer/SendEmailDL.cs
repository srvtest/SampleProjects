using Entity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SendEmailDL
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
        public ResponseDto InsertUpdateDeleteSendEmail(SendEmailDto para, string Con = "")
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

                parameter[0] = new SqlParameter("IdSendEmail", para.IdSendEmail);
                parameter[1] = new SqlParameter("Subject", para.Subject);
                parameter[2] = new SqlParameter("Message", para.Message);
                parameter[3] = new SqlParameter("ToEmailId", para.ToEmailId);
                //parameter[3] = new SqlParameter("bActive", para.bActive);
                parameter[4] = new SqlParameter("isDeleted", para.isDeleted);
                //parameter[5] = new SqlParameter("idDistrict", para.idDistrict);
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "InsertUpdateDeleteForSendEmail",
                    Parameter = parameter.ToXML(),
                    ProcName = "usp_InsertUpdateDeleteForSendEmail",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);

                ds = SqlHelper.ExecuteDataset(Con, "usp_InsertUpdateDeleteForSendEmail", parameter);
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
