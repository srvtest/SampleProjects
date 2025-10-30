using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PropertyTypeDto
    {
        public int idProperty { get; set; }
        public string PropertyType { get; set; }
        public bool isDeleted { get; set; }
        public Int16 bActive { get; set; }

        public PropertyTypeDto() { }

        public PropertyTypeDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idProperty") && !Convert.IsDBNull(dr["idProperty"]))
            {
                this.idProperty = Convert.ToInt32(dr["idProperty"]);
            }
            if (dr.Table.Columns.Contains("PropertyType") && !Convert.IsDBNull(dr["PropertyType"]))
            {
                this.PropertyType = Convert.ToString(dr["PropertyType"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToInt16(dr["bActive"]);
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
            {
                this.idProperty = Convert.ToInt32(dr["Id"]);
            }
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
            {
                this.PropertyType = Convert.ToString(dr["sName"]);
            }
        }
    }
}
