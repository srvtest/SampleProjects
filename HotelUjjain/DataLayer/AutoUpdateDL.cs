using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataLayer
{
    public class AutoUpdateDL
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
        public void UpdateData(string Con = "")
        {
            if (string.IsNullOrEmpty(Con))
                Con = CommonDL.conString;
            try
            {
                //string Con = Convert.ToString(ConfigurationManager.ConnectionStrings["CnnString_Hotel"]);
                //List<GuestMasterDto> lstUserDetails = new List<GuestMasterDto>();
                DataSet ds = new DataSet();
                SqlParameter[] parameter = new SqlParameter[0];
                string ResponseMessage = string.Empty;
                int ResponseCode = 0;
                //parameter[0] = new SqlParameter("idHotel", idHotel);
                //parameter[1] = new SqlParameter("CheckInDate", CheckInDate);
                EventLogDto eventLogDto = new EventLogDto()
                {
                    MethodName = "AutoSubmitbySystemHotelReport",
                    Parameter = parameter.ToXML(),
                    ProcName = "USP_AutoSubmitbySystemHotelReport",
                    idUser = idUsr,
                    dtCreated = DateTime.Now,
                };
                CommonDL.InsertEventLog(eventLogDto, Con);

                ds = SqlHelper.ExecuteDataset(Con, "USP_AutoSubmitbySystemHotelReport", parameter);
                if (ds != null)
                {
                    ResponseMessage = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                    ResponseCode = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseCode"]);
                    //if (ds.Tables.Count > 1)
                    //{
                    //    foreach (DataRow dr in ds.Tables[1].Rows)
                    //    {
                    //        lstUserDetails.Add(new GuestMasterDto(dr));
                    //    }
                    //}
                }
                ResponseDto response = new ResponseDto(ResponseCode, null, ResponseMessage);
               // return response;
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
        }
    }
}
