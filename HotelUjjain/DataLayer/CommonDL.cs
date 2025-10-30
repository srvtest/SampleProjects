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

namespace DataLayer
{
    public static class CommonDL
    {
        public static string conString
        {
            get
            {
                return Convert.ToString(ConfigurationManager.ConnectionStrings["CnnString_Hotel"]);
                //return Convert.ToString(ConfigurationManager.ConnectionStrings["CnnString_icdLive"]);
            }
        }
        public static void InsertErrorLog(ErrorLogDto para,string Con="")
        {
            //if (string.IsNullOrEmpty(Con))
            //    Con = conString;
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter("ErrorMessage", para.ErrorMessage);
            parameter[1] = new SqlParameter("ErrorType", para.ErrorType);
            parameter[2] = new SqlParameter("idUser", para.idUser);
            parameter[3] = new SqlParameter("idHotel", para.idHotel);
            parameter[4] = new SqlParameter("dtCreated", para.dtCreated);
            //ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
            SqlHelper.ExecuteNonQuery(Con, "usp_InsertErrorLog", parameter);
        }
        public static void InsertEventLog(EventLogDto para,string Con="")
        {
            //if (string.IsNullOrEmpty(Con))
            //    Con = conString;
            SqlParameter[] parameter = new SqlParameter[6];
            parameter[0] = new SqlParameter("MethodName", para.MethodName);
            parameter[1] = new SqlParameter("Parameter", para.Parameter);
            parameter[2] = new SqlParameter("ProcName", para.ProcName);
            parameter[3] = new SqlParameter("idUser", para.idUser);
            parameter[4] = new SqlParameter("idHotel", para.idHotel);
            parameter[5] = new SqlParameter("dtCreated", para.dtCreated);
            //ELHelper.ELHelper elHelper = new ELHelper.ELHelper();
            SqlHelper.ExecuteNonQuery(Con, "usp_InsertEventLog", parameter);
        }
    }
}
