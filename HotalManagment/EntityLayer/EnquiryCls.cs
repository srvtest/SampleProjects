using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class EnquiryCls
    {

        public int Id { get; set; }
        public DateTime EnquiryDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int categoryId { get; set; }
        public int RoomId { get; set; }
        public int RoomNo { get; set; }
        public int BookingSourceId { get; set; }
        public string EnquiryBy { get; set; }
        public string ContactNo { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int Modifyby { get; set; }
        public DateTime ModificationDate { get; set; }

        public EnquiryCls()
        { }

        public EnquiryCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);


            if (dr.Table.Columns.Contains("EnquiryDate") && !Convert.IsDBNull(dr["EnquiryDate"]))
                this.EnquiryDate = Convert.ToDateTime(dr["EnquiryDate"]);

            if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                this.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                this.ToDate = Convert.ToDateTime(dr["ToDate"]);

            if (dr.Table.Columns.Contains("categoryId") && !Convert.IsDBNull(dr["categoryId"]))
                this.categoryId = Convert.ToInt32(dr["categoryId"]);

            if (dr.Table.Columns.Contains("RoomId") && !Convert.IsDBNull(dr["RoomId"]))
                this.RoomId = Convert.ToInt32(dr["RoomId"]);

            if (dr.Table.Columns.Contains("RoomNo") && !Convert.IsDBNull(dr["RoomNo"]))
                this.RoomNo = Convert.ToInt32(dr["RoomNo"]);

            if (dr.Table.Columns.Contains("BookingSourceId") && !Convert.IsDBNull(dr["BookingSourceId"]))
                this.BookingSourceId = Convert.ToInt32(dr["BookingSourceId"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("CreationDate") && !Convert.IsDBNull(dr["CreationDate"]))
                this.CreationDate = Convert.ToDateTime(dr["CreationDate"]);

            if (dr.Table.Columns.Contains("Modifyby") && !Convert.IsDBNull(dr["Modifyby"]))
                this.Modifyby = Convert.ToInt32(dr["Modifyby"]);

            if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

            if (dr.Table.Columns.Contains("EnquiryBy") && !Convert.IsDBNull(dr["EnquiryBy"]))
                this.EnquiryBy = Convert.ToString(dr["EnquiryBy"]);

            if (dr.Table.Columns.Contains("ContactNo") && !Convert.IsDBNull(dr["ContactNo"]))
                this.ContactNo = Convert.ToString(dr["ContactNo"]);

            if (dr.Table.Columns.Contains("Notes") && !Convert.IsDBNull(dr["Notes"]))
                this.Notes = Convert.ToString(dr["Notes"]);




        }
    }
}
