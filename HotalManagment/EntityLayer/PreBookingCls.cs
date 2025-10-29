using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class PreBookingCls
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public int BookingSourceId { get; set; }
        public String BookingSourceName { get; set; }
        public int BookingId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string Notes { get; set; }
        public int Hotelid { get; set; }
        public int Status { get; set; }
        public string RefNo { get; set; }
        
        public PreBookingCls()
        { }

        public PreBookingCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                this.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                this.ToDate = Convert.ToDateTime(dr["ToDate"]);

            if (dr.Table.Columns.Contains("CategoryId") && !Convert.IsDBNull(dr["CategoryId"]))
                this.CategoryId = Convert.ToInt32(dr["CategoryId"]);

            if (dr.Table.Columns.Contains("CategoryName") && !Convert.IsDBNull(dr["CategoryName"]))
                this.CategoryName = Convert.ToString(dr["CategoryName"]);

            if (dr.Table.Columns.Contains("BookingSourceId") && !Convert.IsDBNull(dr["BookingSourceId"]))
                this.BookingSourceId = Convert.ToInt32(dr["BookingSourceId"]);

            if (dr.Table.Columns.Contains("BookingSourceName") && !Convert.IsDBNull(dr["BookingSourceName"]))
                this.BookingSourceName = Convert.ToString(dr["BookingSourceName"]);

            if (dr.Table.Columns.Contains("BookingId") && !Convert.IsDBNull(dr["BookingId"]))
                this.BookingId = Convert.ToInt32(dr["BookingId"]);

            if (dr.Table.Columns.Contains("ContactPerson") && !Convert.IsDBNull(dr["ContactPerson"]))
                this.ContactPerson = Convert.ToString(dr["ContactPerson"]);

            if (dr.Table.Columns.Contains("ContactNo") && !Convert.IsDBNull(dr["ContactNo"]))
                this.ContactNo = Convert.ToString(dr["ContactNo"]);

            if (dr.Table.Columns.Contains("Notes") && !Convert.IsDBNull(dr["Notes"]))
                this.Notes = Convert.ToString(dr["Notes"]);

            if (dr.Table.Columns.Contains("Hotelid") && !Convert.IsDBNull(dr["Hotelid"]))
                this.Hotelid = Convert.ToInt32(dr["Hotelid"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("Creationdate") && !Convert.IsDBNull(dr["Creationdate"]))
                this.Creationdate = Convert.ToDateTime(dr["Creationdate"]);

            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

            if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
                this.Status = Convert.ToInt32(dr["Status"]);

            if (dr.Table.Columns.Contains("RefNo") && !Convert.IsDBNull(dr["RefNo"]))
                this.RefNo = Convert.ToString(dr["RefNo"]);

        }
    }
}
