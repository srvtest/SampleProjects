using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
   public  class hotelCls
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public int StateId { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Logo { get; set; }
        public string GSTNo { get; set; }
        public string Password { get; set; }
        public string checkOut { get; set; }
        public string LocationLink { get; set; }
        public string Hotelpolicy { get; set; }
        public string Cancellation { get; set; }
        public string CpHotelId { get; set; }
        public string CpAuthenticationCode { get; set; }

        public string PropertyName { get; set; }
        public string ReviewLink { get; set; }

        public hotelCls()
        { }

        public hotelCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("HotelName") && !Convert.IsDBNull(dr["HotelName"]))
                this.HotelName = Convert.ToString(dr["HotelName"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToInt16(dr["IsActive"]);

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("Creationdate") && !Convert.IsDBNull(dr["Creationdate"]))
                this.Creationdate = Convert.ToDateTime(dr["Creationdate"]);

            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

            if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

            if (dr.Table.Columns.Contains("Address") && !Convert.IsDBNull(dr["Address"]))
                this.Address = Convert.ToString(dr["Address"]);

            if (dr.Table.Columns.Contains("EmailId") && !Convert.IsDBNull(dr["EmailId"]))
                this.EmailId = Convert.ToString(dr["EmailId"]);

            if (dr.Table.Columns.Contains("PhoneNo") && !Convert.IsDBNull(dr["PhoneNo"]))
                this.PhoneNo = Convert.ToString(dr["PhoneNo"]);

            if (dr.Table.Columns.Contains("MobileNo") && !Convert.IsDBNull(dr["MobileNo"]))
                this.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (dr.Table.Columns.Contains("Logo") && !Convert.IsDBNull(dr["Logo"]))
                this.Logo = Convert.ToString(dr["Logo"]);

            if (dr.Table.Columns.Contains("GSTNo") && !Convert.IsDBNull(dr["GSTNo"]))
                this.GSTNo = Convert.ToString(dr["GSTNo"]);

            if (dr.Table.Columns.Contains("StateId") && !Convert.IsDBNull(dr["StateId"]))
                this.StateId = Convert.ToInt32(dr["StateId"]);

             if (dr.Table.Columns.Contains("LocationLink") && !Convert.IsDBNull(dr["LocationLink"]))
                this.LocationLink = Convert.ToString(dr["LocationLink"]);

             if (dr.Table.Columns.Contains("Hotelpolicy") && !Convert.IsDBNull(dr["Hotelpolicy"]))
                 this.Hotelpolicy = Convert.ToString(dr["Hotelpolicy"]);

             if (dr.Table.Columns.Contains("Cancellation") && !Convert.IsDBNull(dr["Cancellation"]))
                 this.Cancellation = Convert.ToString(dr["Cancellation"]);

             if (dr.Table.Columns.Contains("CpHotelId") && !Convert.IsDBNull(dr["CpHotelId"]))
                 this.CpHotelId = Convert.ToString(dr["CpHotelId"]);

             if (dr.Table.Columns.Contains("CpAuthenticationCode") && !Convert.IsDBNull(dr["CpAuthenticationCode"]))
                 this.CpAuthenticationCode = Convert.ToString(dr["CpAuthenticationCode"]);

             if (dr.Table.Columns.Contains("PropertyName") && !Convert.IsDBNull(dr["PropertyName"]))
                 this.PropertyName = Convert.ToString(dr["PropertyName"]);

             if (dr.Table.Columns.Contains("ReviewLink") && !Convert.IsDBNull(dr["ReviewLink"]))
                 this.ReviewLink = Convert.ToString(dr["ReviewLink"]);
        }


    }
}
