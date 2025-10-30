using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NavigationDto
    {
        public int idNavigation { get; set; }
        public string Label { get; set; }
        public string Route { get; set; }
        public string Icon { get; set; }
        public bool bActive { get; set; }
        public int parentId { get; set; }
        public string SortOrder { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public List<RoleNavigationDto> roles { get; set; }
        public NavigationDto()
        { }
        public NavigationDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idNavigation") && !Convert.IsDBNull(dr["idNavigation"]))
                this.idNavigation = Convert.ToInt32(dr["idNavigation"]);
            if (dr.Table.Columns.Contains("Label") && !Convert.IsDBNull(dr["Label"]))
                this.Label = Convert.ToString(dr["Label"]);
            if (dr.Table.Columns.Contains("Route") && !Convert.IsDBNull(dr["Route"]))
                this.Route = Convert.ToString(dr["Route"]);
            if (dr.Table.Columns.Contains("Icon") && !Convert.IsDBNull(dr["Icon"]))
                this.Icon = Convert.ToString(dr["Icon"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("parentId") && !Convert.IsDBNull(dr["parentId"]))
                this.parentId = Convert.ToInt32(dr["parentId"]);
            if (dr.Table.Columns.Contains("SortOrder") && !Convert.IsDBNull(dr["SortOrder"]))
                this.SortOrder = Convert.ToString(dr["SortOrder"]);
            if (dr.Table.Columns.Contains("Description") && !Convert.IsDBNull(dr["Description"]))
                this.Description = Convert.ToString(dr["Description"]);
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
        }
    }
}
