using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class ItemsCls
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public int GSTSlabeId { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }

        public ItemsCls()
        { }

        public ItemsCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("BookingId") && !Convert.IsDBNull(dr["BookingId"]))
                this.BookingId = Convert.ToInt32(dr["BookingId"]);

            if (dr.Table.Columns.Contains("ItemId") && !Convert.IsDBNull(dr["ItemId"]))
                this.ItemId = Convert.ToInt32(dr["ItemId"]);

            if (dr.Table.Columns.Contains("ItemName") && !Convert.IsDBNull(dr["ItemName"]))
                this.ItemName = Convert.ToString(dr["ItemName"]);

            if (dr.Table.Columns.Contains("Price") && !Convert.IsDBNull(dr["Price"]))
                this.Price = Convert.ToDouble(dr["Price"]);

            if (dr.Table.Columns.Contains("Quantity") && !Convert.IsDBNull(dr["Quantity"]))
                this.Quantity = Convert.ToInt32(dr["Quantity"]);

            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
                this.Status = Convert.ToInt32(dr["Status"]);

            if (dr.Table.Columns.Contains("Code") && !Convert.IsDBNull(dr["Code"]))
                this.Code = Convert.ToString(dr["Code"]);

            if (dr.Table.Columns.Contains("GSTSlabeId") && !Convert.IsDBNull(dr["GSTSlabeId"]))
                this.GSTSlabeId = Convert.ToInt32(dr["GSTSlabeId"]);

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
        }
    }
}
