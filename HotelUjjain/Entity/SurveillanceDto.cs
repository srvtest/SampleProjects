using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class SurveillanceDto
    {
        public int idsurveillance { get; set; }
        public int idUser { get; set; }
        public string surveillanceDetail { get; set; }
        public string sType { get; set; }
        public bool active { get; set; }
        public bool isTrace { get; set; }
        public string createdDate { get; set; }
        public string PoliceStationName { get; set; }
        public string sName { get; set; }
        public SurveillanceDto() { }

        public SurveillanceDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idsurveillance") && !Convert.IsDBNull(dr["idsurveillance"]))
                this.idsurveillance = Convert.ToInt32(dr["idsurveillance"]);

            if (dr.Table.Columns.Contains("idUser") && !Convert.IsDBNull(dr["idUser"]))
                this.idUser = Convert.ToInt32(dr["idUser"]);

            if (dr.Table.Columns.Contains("surveillanceDetail") && !Convert.IsDBNull(dr["surveillanceDetail"]))
                this.surveillanceDetail = Convert.ToString(dr["surveillanceDetail"]);

            if (dr.Table.Columns.Contains("sType") && !Convert.IsDBNull(dr["sType"]))
                this.sType = Convert.ToString(dr["sType"]);

            if (dr.Table.Columns.Contains("active") && !Convert.IsDBNull(dr["active"]))
                this.active = Convert.ToBoolean(dr["active"]);
            
            if (dr.Table.Columns.Contains("isTrace") && !Convert.IsDBNull(dr["isTrace"]))
                this.isTrace = Convert.ToBoolean(dr["isTrace"]);

            if (dr.Table.Columns.Contains("createdDate") && !Convert.IsDBNull(dr["createdDate"]))
                this.createdDate = Convert.ToString(dr["createdDate"]);

            if (dr.Table.Columns.Contains("PoliceStationName") && !Convert.IsDBNull(dr["PoliceStationName"]))
                this.PoliceStationName = Convert.ToString(dr["PoliceStationName"]);
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.sName = Convert.ToString(dr["sName"]);
        }
    }
}
