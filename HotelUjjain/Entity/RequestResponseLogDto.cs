using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RequestResponseLogDto
    {
        public int RequestResponseLogId { get; set; }
        public int HotelId { get; set; }
        public int PoliceStationId { get; set; }
        public string RequestAPIType { get; set; }
        public string RequestAPIName { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string HttpRequestResponse { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isDeleted { get; set; }
        public RequestResponseLogDto() { }

        public RequestResponseLogDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("RequestResponseLogId") && !Convert.IsDBNull(dr["RequestResponseLogId"]))
            {
                this.RequestResponseLogId = Convert.ToInt32(dr["RequestResponseLogId"]);
            }
            if (dr.Table.Columns.Contains("RequestAPIType") && !Convert.IsDBNull(dr["RequestAPIType"]))
            {
                this.RequestAPIType = Convert.ToString(dr["RequestAPIType"]);
            }
            if (dr.Table.Columns.Contains("RequestAPIName") && !Convert.IsDBNull(dr["RequestAPIName"]))
            {
                this.RequestAPIName = Convert.ToString(dr["RequestAPIName"]);
            }
            if (dr.Table.Columns.Contains("HotelId") && !Convert.IsDBNull(dr["HotelId"]))
            {
                this.HotelId = Convert.ToInt32(dr["HotelId"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("RequestBody") && !Convert.IsDBNull(dr["RequestBody"]))
            {
                this.RequestBody = Convert.ToString(dr["RequestBody"]);
            }
            if (dr.Table.Columns.Contains("ResponseBody") && !Convert.IsDBNull(dr["ResponseBody"]))
            {
                this.ResponseBody = Convert.ToString(dr["ResponseBody"]);
            }
            if (dr.Table.Columns.Contains("HttpRequestResponse") && !Convert.IsDBNull(dr["HttpRequestResponse"]))
            {
                this.HttpRequestResponse = Convert.ToString(dr["HttpRequestResponse"]);
            }
            if (dr.Table.Columns.Contains("PoliceStationId") && !Convert.IsDBNull(dr["PoliceStationId"]))
            {
                this.PoliceStationId = Convert.ToInt32(dr["PoliceStationId"]);
            }
            if (dr.Table.Columns.Contains("CreatedOn") && !Convert.IsDBNull(dr["CreatedOn"]))
            {
                this.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            }
        }
    }
}
