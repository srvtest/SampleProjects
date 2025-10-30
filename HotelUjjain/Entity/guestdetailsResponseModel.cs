using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class guestdetailsResponseModel
    {
        public string BookingID { get; set; }
        public int guestID { get; set; }
        public string guestName { get; set; }
        public string gender { get; set; }
        public string guestMobileNumber { get; set; }
        public string guestCity { get; set; }
        public string guestVisitPurpose { get; set; }
        public string guestIDType { get; set; }
        public string guestIDNumber { get; set; }
        public string guestFrontSideDocs { get; set; }
        public string guestBackSideDocs { get; set; }
        public int guestAge { get; set; }
        public string BookingComment { get; set; }
        public guestdetailsResponseModel()
        { }
        public guestdetailsResponseModel(DataRow dr)
        {
            if (dr.Table.Columns.Contains("BookingID") && !Convert.IsDBNull(dr["BookingID"]))
                this.BookingID = Convert.ToString(dr["BookingID"]);
            if (dr.Table.Columns.Contains("guestID") && !Convert.IsDBNull(dr["guestID"]))
                this.guestID = Convert.ToInt32(dr["guestID"]);
            if (dr.Table.Columns.Contains("guestName") && !Convert.IsDBNull(dr["guestName"]))
                this.guestName = Convert.ToString(dr["guestName"]);
            if (dr.Table.Columns.Contains("gender") && !Convert.IsDBNull(dr["gender"]))
                this.gender = Convert.ToString(dr["gender"]);
            if (dr.Table.Columns.Contains("guestMobileNumber") && !Convert.IsDBNull(dr["guestMobileNumber"]))
                this.guestMobileNumber = Convert.ToString(dr["guestMobileNumber"]);
            if (dr.Table.Columns.Contains("guestCity") && !Convert.IsDBNull(dr["guestCity"]))
                this.guestCity = Convert.ToString(dr["guestCity"]);
            if (dr.Table.Columns.Contains("guestVisitPurpose") && !Convert.IsDBNull(dr["guestVisitPurpose"]))
                this.guestVisitPurpose = Convert.ToString(dr["guestVisitPurpose"]);
            if (dr.Table.Columns.Contains("guestIDType") && !Convert.IsDBNull(dr["guestIDType"]))
                this.guestIDType = Convert.ToString(dr["guestIDType"]);
            if (dr.Table.Columns.Contains("guestIDNumber") && !Convert.IsDBNull(dr["guestIDNumber"]))
                this.guestIDNumber = Convert.ToString(dr["guestIDNumber"]);
            if (dr.Table.Columns.Contains("guestFrontSideDocs") && !Convert.IsDBNull(dr["guestFrontSideDocs"]))
                this.guestFrontSideDocs = Convert.ToString(dr["guestFrontSideDocs"]);
            if (dr.Table.Columns.Contains("guestBackSideDocs") && !Convert.IsDBNull(dr["guestBackSideDocs"]))
                this.guestBackSideDocs = Convert.ToString(dr["guestBackSideDocs"]);
            if (dr.Table.Columns.Contains("guestAge") && !Convert.IsDBNull(dr["guestAge"]))
                this.guestAge = Convert.ToInt32(dr["guestAge"]);
            if (dr.Table.Columns.Contains("BookingComment") && !Convert.IsDBNull(dr["BookingComment"]))
                this.BookingComment = Convert.ToString(dr["BookingComment"]);
        }
    }
}
