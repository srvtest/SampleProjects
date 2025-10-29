using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using System.Data;
using ELHelper;

namespace DataLayer
{
    public class DL_WSHotalManagment
    {
        public RES_Response RoomInfo(string HotelCode)
        {

            RES_Response objRES_Response = new RES_Response();
            try
            {
                DataSet ds = new DataSet();
                LbSprocParameter[] parameter;
                parameter = new LbSprocParameter[1];
                parameter[0] = new LbSprocParameter("HotelCode", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, HotelCode);
                ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
                ds = elhelper.ExecuteDataset("USP_WSRoomInfo", parameter);
                RoomInfo objRoomInfo = new RoomInfo();
                //if (ds.Tables.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        RoomType objRoomType = new RoomType(dr);
                //        objRES_Response.RoomInfo.RoomTypes.RoomType.Add(objRoomType);
                //    }
                //}

                //if (ds.Tables.Count > 1)
                //{
                //    foreach (DataRow dr in ds.Tables[1].Rows)
                //    {
                //        RateType objRateType = new RateType(dr);
                //        objRES_Response.RoomInfo.RateTypes.RateType.Add(objRateType);
                //    }
                //}

                //if (ds.Tables.Count > 2)
                //{
                //    foreach (DataRow dr in ds.Tables[2].Rows)
                //    {
                //        RatePlan objRatePlan = new RatePlan(dr);
                //        objRES_Response.RoomInfo.RatePlans.RatePlan.Add(objRatePlan);
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRES_Response;
        }

    }
}
