using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class CategoryCls
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public string CpCategoryId { get; set; }
        public string CpAuthentication { get; set; }

        public CategoryCls()
        { }

        public CategoryCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("CategoryName") && !Convert.IsDBNull(dr["CategoryName"]))
                this.CategoryName = Convert.ToString(dr["CategoryName"]);

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

            if (dr.Table.Columns.Contains("CpCategoryId") && !Convert.IsDBNull(dr["CpCategoryId"]))
                this.CpCategoryId = Convert.ToString(dr[" CpCategoryId"]);

            if (dr.Table.Columns.Contains("CpAuthentication") && !Convert.IsDBNull(dr["CpAuthentication"]))
                this.CpAuthentication = Convert.ToString(dr["CpAuthentication"]);
        
        }

    }
}
