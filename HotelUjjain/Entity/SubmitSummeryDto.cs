
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SubmitSummeryDto
    {
        public string HotelName { get; set; }
        public string SubmitDate { get; set; }
        public string TotalGuest { get; set; }
        public int idHotelMaster { get; set; }
        public string SubmitType { get; set; }

        public SubmitSummeryDto() {
        
        }

        public SubmitSummeryDto(DataRow dr)
        {
                 
        if (dr.Table.Columns.Contains("HotelName") && !Convert.IsDBNull(dr["HotelName"]))
                this.HotelName = Convert.ToString(dr["HotelName"]);

        if (dr.Table.Columns.Contains("SubmitDate") && !Convert.IsDBNull(dr["SubmitDate"]))
                this.SubmitDate = Convert.ToString(dr["SubmitDate"]);

        if (dr.Table.Columns.Contains("TotalGuest") && !Convert.IsDBNull(dr["TotalGuest"]))
                this.TotalGuest = Convert.ToString(dr["TotalGuest"]);

        if (dr.Table.Columns.Contains("idHotelMaster") && !Convert.IsDBNull(dr["idHotelMaster"]))
                this.idHotelMaster = Convert.ToInt32(dr["idHotelMaster"]);

        if (dr.Table.Columns.Contains("SubmitType") && !Convert.IsDBNull(dr["SubmitType"]))
                this.SubmitType = Convert.ToString(dr["SubmitType"]);




    }

}
}
