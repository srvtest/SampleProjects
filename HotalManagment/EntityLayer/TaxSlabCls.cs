using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class TaxSlabCls
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string TaxSlabName { get; set; }
        public double StartAt { get; set; }
        public double EndTo { get; set; }
        public double Taxpercent { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }

        public TaxSlabCls()
        { }

        public TaxSlabCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("HotelId") && !Convert.IsDBNull(dr["HotelId"]))
                this.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (dr.Table.Columns.Contains("TaxSlabName") && !Convert.IsDBNull(dr["TaxSlabName"]))
                this.TaxSlabName = Convert.ToString(dr["TaxSlabName"]);

            if (dr.Table.Columns.Contains("StartAt") && !Convert.IsDBNull(dr["StartAt"]))
                this.StartAt = Convert.ToDouble(dr["StartAt"]);

            if (dr.Table.Columns.Contains("EndTo") && !Convert.IsDBNull(dr["EndTo"]))
                this.EndTo = Convert.ToDouble(dr["EndTo"]);

            if (dr.Table.Columns.Contains("Taxpercent") && !Convert.IsDBNull(dr["Taxpercent"]))
                this.Taxpercent = Convert.ToDouble(dr["Taxpercent"]);

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
