using System;
using System.Data;

namespace EntityLayer
{
    public class PlanCls
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public Int16 IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
       
        public PlanCls()
        {
        }
        public PlanCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("PlanName") && !Convert.IsDBNull(dr["PlanName"]))
                this.PlanName = Convert.ToString(dr["PlanName"]);

            if (dr.Table.Columns.Contains("Duration") && !Convert.IsDBNull(dr["Duration"]))
                this.Duration = Convert.ToInt32(dr["Duration"]);

            if (dr.Table.Columns.Contains("Price") && !Convert.IsDBNull(dr["Price"]))
                this.Price = Convert.ToDecimal(dr["Price"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToInt16(dr["IsActive"]);
         
            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

        }
    }
}
