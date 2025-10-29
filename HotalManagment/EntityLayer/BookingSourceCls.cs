using System;
using System.Data;

namespace EntityLayer
{
    public class BookingSourceCls
    {
        public int Id { get; set; }
        public string BookingSourceName { get; set; }
        public int BookingSourceTypeId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public string OTANameChannel { get; set; }
        public Decimal Commision { get; set; }

        public BookingSourceCls()
        { }

        public BookingSourceCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("BookingSourceName") && !Convert.IsDBNull(dr["BookingSourceName"]))
                this.BookingSourceName = Convert.ToString(dr["BookingSourceName"]);

            if (dr.Table.Columns.Contains("BookingSourceTypeId") && !Convert.IsDBNull(dr["BookingSourceTypeId"]))
                this.BookingSourceTypeId = Convert.ToInt32(dr["BookingSourceTypeId"]);

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

            if (dr.Table.Columns.Contains("OTANameChannel") && !Convert.IsDBNull(dr["OTANameChannel"]))
                this.OTANameChannel = Convert.ToString(dr["OTANameChannel"]);

            if (dr.Table.Columns.Contains("Commision") && !Convert.IsDBNull(dr["Commision"]))
                this.Commision = Convert.ToDecimal(dr["Commision"]);
        }
    }
}
