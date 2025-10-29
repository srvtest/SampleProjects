using System;
using System.Data;

namespace EntityLayer
{
    public class RoomCls
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string RoomFrom { get; set; }
        public string RoomTo { get; set; }
        public decimal Price { get; set; }
        public int GSTSlab { get; set; }
        public Int16 IsUnderHK { get; set; }
        public Int16 IsActive { get; set; }
        public string GroupName { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public decimal Monday { get; set; }
        public decimal Tuesday { get; set; }
        public decimal Wednesday { get; set; }
        public decimal Thursday { get; set; }
        public decimal Friday { get; set; }
        public decimal Saturday { get; set; }
        public decimal Sunday { get; set; }

        public int Persons { get; set; }
        
        public decimal EP { get; set; }
        public decimal CP { get; set; }
        public decimal MAP { get; set; }

        public decimal ExBadChargesEP { get; set; }
        public decimal ExBadChargesCP { get; set; }
        public decimal ExBadChargesMAP { get; set; }

        public RoomCls()
        {
        }
        public RoomCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("CategoryId") && !Convert.IsDBNull(dr["CategoryId"]))
                this.CategoryId = Convert.ToInt32(dr["CategoryId"]);

            if (dr.Table.Columns.Contains("RoomFrom") && !Convert.IsDBNull(dr["RoomFrom"]))
                this.RoomFrom = Convert.ToString(dr["RoomFrom"]);

            if (dr.Table.Columns.Contains("RoomTo") && !Convert.IsDBNull(dr["RoomTo"]))
                this.RoomTo = Convert.ToString(dr["RoomTo"]);

            if (dr.Table.Columns.Contains("Price") && !Convert.IsDBNull(dr["Price"]))
                this.Price = Convert.ToDecimal(dr["Price"]);

            if (dr.Table.Columns.Contains("GSTSlab") && !Convert.IsDBNull(dr["GSTSlab"]))
                this.GSTSlab = Convert.ToInt32(dr["GSTSlab"]);

            if (dr.Table.Columns.Contains("IsUnderHK") && !Convert.IsDBNull(dr["IsUnderHK"]))
                this.IsUnderHK = Convert.ToInt16(dr["IsUnderHK"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToInt16(dr["IsActive"]);

            if (dr.Table.Columns.Contains("GroupName") && !Convert.IsDBNull(dr["GroupName"]))
                this.GroupName = Convert.ToString(dr["GroupName"]);

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

            if (dr.Table.Columns.Contains("Monday") && !Convert.IsDBNull(dr["Monday"]))
                this.Monday = Convert.ToDecimal(dr["Monday"]);

            if (dr.Table.Columns.Contains("Tuesday") && !Convert.IsDBNull(dr["Tuesday"]))
                this.Tuesday = Convert.ToDecimal(dr["Tuesday"]);

            if (dr.Table.Columns.Contains("Wednesday") && !Convert.IsDBNull(dr["Wednesday"]))
                this.Wednesday = Convert.ToDecimal(dr["Wednesday"]);

            if (dr.Table.Columns.Contains("Thursday") && !Convert.IsDBNull(dr["Thursday"]))
                this.Thursday = Convert.ToDecimal(dr["Thursday"]);

            if (dr.Table.Columns.Contains("Friday") && !Convert.IsDBNull(dr["Friday"]))
                this.Friday = Convert.ToDecimal(dr["Friday"]);

            if (dr.Table.Columns.Contains("Saturday") && !Convert.IsDBNull(dr["Saturday"]))
                this.Saturday = Convert.ToDecimal(dr["Saturday"]);

            if (dr.Table.Columns.Contains("Sunday") && !Convert.IsDBNull(dr["Sunday"]))
                this.Sunday = Convert.ToDecimal(dr["Sunday"]);

            if (dr.Table.Columns.Contains("Persons") && !Convert.IsDBNull(dr["Persons"]))
                this.Persons = Convert.ToInt32(dr["Persons"]);

            if (dr.Table.Columns.Contains("ExBadChargeEP") && !Convert.IsDBNull(dr["ExBadChargeEP"]))
                this.ExBadChargesEP = Convert.ToDecimal(dr["ExBadChargeEP"]);

            if (dr.Table.Columns.Contains("ExBadChargeCP") && !Convert.IsDBNull(dr["ExBadChargeCP"]))
                this.ExBadChargesCP = Convert.ToDecimal(dr["ExBadChargeCP"]);

            if (dr.Table.Columns.Contains("ExBadChargeMAP") && !Convert.IsDBNull(dr["ExBadChargeMAP"]))
                this.ExBadChargesMAP = Convert.ToDecimal(dr["ExBadChargeMAP"]);

            if (dr.Table.Columns.Contains("EP") && !Convert.IsDBNull(dr["EP"]))
                this.EP = Convert.ToDecimal(dr["EP"]);

            if (dr.Table.Columns.Contains("CP") && !Convert.IsDBNull(dr["CP"]))
                this.CP = Convert.ToDecimal(dr["CP"]);

            if (dr.Table.Columns.Contains("MAP") && !Convert.IsDBNull(dr["MAP"]))
                this.MAP = Convert.ToDecimal(dr["MAP"]);

        }
    }
}