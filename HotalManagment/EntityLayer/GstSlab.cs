using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
   public class GstSlab
    {
        public int Id { get; set; }
        public string GSTSlab { get; set; }
        public Int32  Percentage { get; set; }
        public bool IsActive { get; set; }

         public GstSlab()
        { }

         public GstSlab(DataRow dr)
         {

             if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                 this.Id = Convert.ToInt32(dr["Id"]);


             if (dr.Table.Columns.Contains("GSTSlab") && !Convert.IsDBNull(dr["GSTSlab"]))
                 this.GSTSlab = Convert.ToString(dr["GSTSlab"]);

             if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                 this.IsActive = Convert.ToBoolean(dr["IsActive"]);

             if (dr.Table.Columns.Contains("Percentage") && !Convert.IsDBNull(dr["Percentage"]))
                 this.Percentage = Convert.ToInt32(dr["Percentage"]);
         }
    }
}
