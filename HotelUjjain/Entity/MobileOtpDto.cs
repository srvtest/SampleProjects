using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Entity
{
    public class MobileOtpDto
    {
        public int MobileOtpid { get; set; }
        public string sMobileNo { get; set; }
        public string OTP { get; set; }
        public string OTPValid { get; set; }
        public MobileOtpDto() { }

        public MobileOtpDto(DataRow dr)
        {
            //if (dr.Table.Columns.Contains("id") && !Convert.IsDBNull(dr["id"]))
            //{
            //    this.MobileOtpid = Convert.ToInt32(dr["id"]);
            //}
            if (dr.Table.Columns.Contains("sMobileNo") && !Convert.IsDBNull(dr["sMobileNo"]))
            {
                this.sMobileNo = Convert.ToString(dr["sMobileNo"]);
            }
            if (dr.Table.Columns.Contains("OTP") && !Convert.IsDBNull(dr["OTP"]))
            {
                this.OTP = Convert.ToString(dr["OTP"]);
            }
            //if (dr.Table.Columns.Contains("OTPValid") && !Convert.IsDBNull(dr["OTPValid"]))
            //{
            //    this.OTPValid = Convert.ToString(dr["OTPValid"]);
            //}
        }
    }
}
