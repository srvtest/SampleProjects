using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HotelGuestDetailDto
    {
        public int idHotelGuestDetail { get; set; }
        public DateTime SubmitDate { get; set; }
        public int idHotel { get; set; }
        public HotelGuestDetailDto()
        { }
        public HotelGuestDetailDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idHotelGuestDetail") && !Convert.IsDBNull(dr["idHotelGuestDetail"]))
                this.idHotelGuestDetail = Convert.ToInt32(dr["idHotelGuestDetail"]);
            if (dr.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(dr["idHotel"]))
                this.idHotel = Convert.ToInt32(dr["idHotel"]);
            if (dr.Table.Columns.Contains("SubmitDate") && !Convert.IsDBNull(dr["SubmitDate"]))
                this.SubmitDate = Convert.ToDateTime(dr["SubmitDate"]);
        }
    }
}
