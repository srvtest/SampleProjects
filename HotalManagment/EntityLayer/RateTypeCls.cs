using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace EntityLayer
{
   public class RateTypeCls
    {
          public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string RateTypeId { get; set; }
        public bool IsActive { get; set; }
        public string PlanId { get; set; }

        public RateTypeCls()
        { }

        public RateTypeCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("Name") && !Convert.IsDBNull(dr["Name"]))
               this.Name = Convert.ToString(dr["Name"]);

           if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
              this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

          if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
               this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

            if (dr.Table.Columns.Contains("RateTypeId") && !Convert.IsDBNull(dr["RateTypeId"]))
               this.RateTypeId = Convert.ToString(dr["RateTypeId"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                this.IsActive = Convert.ToBoolean(dr["IsActive"]);

            if (dr.Table.Columns.Contains("PlanId") && !Convert.IsDBNull(dr["PlanId"]))
                this.PlanId = Convert.ToString(dr["PlanId"]);
          
        }

    
    }
}
