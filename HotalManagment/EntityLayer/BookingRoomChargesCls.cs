using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class BookingRoomChargesCls
    {
        public int Id { get; set; }
        public DateTime Fdate { get; set; }
        public int BookingId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public decimal RoomCharges { get; set; }
        public bool Isonline { get; set; }
        public decimal OTACommision { get; set; }
        public decimal OTAGst { get; set; }
        public decimal Price { get; set; }
        public BookingRoomChargesCls()
        { }

        public BookingRoomChargesCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);
        
            if (dr.Table.Columns.Contains("Fdate") && !Convert.IsDBNull(dr["Fdate"]))
                this.Fdate = Convert.ToDateTime(dr["Fdate"]);
            
            if (dr.Table.Columns.Contains("BookingId") && !Convert.IsDBNull(dr["BookingId"]))
                this.BookingId = Convert.ToInt32(dr["BookingId"]);
            
            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            
            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
            
            if (dr.Table.Columns.Contains("RoomCharges") && !Convert.IsDBNull(dr["RoomCharges"]))
                this.RoomCharges = Convert.ToDecimal(dr["RoomCharges"]);

            if (dr.Table.Columns.Contains("Isonline") && !Convert.IsDBNull(dr["Isonline"]))
                this.Isonline = Convert.ToBoolean(dr["Isonline"]);

            if (dr.Table.Columns.Contains("OTACommision") && !Convert.IsDBNull(dr["OTACommision"]))
                this.OTACommision = Convert.ToDecimal(dr["OTACommision"]);

            if (dr.Table.Columns.Contains("OTAGst") && !Convert.IsDBNull(dr["OTAGst"]))
                this.OTAGst = Convert.ToDecimal(dr["OTAGst"]);


            if (dr.Table.Columns.Contains("Price") && !Convert.IsDBNull(dr["Price"]))
                this.Price = Convert.ToDecimal(dr["Price"]);



        }
    }
}
