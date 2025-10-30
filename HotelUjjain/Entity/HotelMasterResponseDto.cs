using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HotelMasterResponseDto
    {
        public string OTP { get; set; }
        public string OTPValid { get; set; }
        public HotelMasterResponseDto()
        { }
        public HotelMasterResponseDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("OTP") && !Convert.IsDBNull(dr["OTP"]))
                this.OTP = Convert.ToString(dr["OTP"]);
            if (dr.Table.Columns.Contains("OTPValid") && !Convert.IsDBNull(dr["OTPValid"]))
                this.OTPValid = Convert.ToString(dr["OTPValid"]);
        }
    }
}
