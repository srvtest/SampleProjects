using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
  public  class HotelPlanCls
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int PlanId { get; set; }

        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public Int16 Status { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }


        public HotelPlanCls()
        {
        }
        public HotelPlanCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("HotelId") && !Convert.IsDBNull(dr["HotelId"]))
                this.HotelId = Convert.ToInt32(dr["HotelId"]);

            if (dr.Table.Columns.Contains("PlanId") && !Convert.IsDBNull(dr["PlanId"]))
                this.PlanId = Convert.ToInt32(dr["PlanId"]);

            if (dr.Table.Columns.Contains("Startdate") && !Convert.IsDBNull(dr["Startdate"]))
                this.Startdate = Convert.ToDateTime(dr["Startdate"]);

            if (dr.Table.Columns.Contains("EndDate") && !Convert.IsDBNull(dr["EndDate"]))
                this.EndDate = Convert.ToDateTime(dr["EndDate"]);

            if (dr.Table.Columns.Contains("Duration") && !Convert.IsDBNull(dr["Duration"]))
                this.Duration = Convert.ToInt32(dr["Duration"]);

            if (dr.Table.Columns.Contains("Price") && !Convert.IsDBNull(dr["Price"]))
                this.Price = Convert.ToDecimal(dr["Price"]);

            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
                this.Status = Convert.ToInt16(dr["Status"]);

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("ModifyBy") && !Convert.IsDBNull(dr["ModifyBy"]))
                this.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);

        }
    }
}
