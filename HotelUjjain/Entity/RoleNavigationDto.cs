using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RoleNavigationDto
    {
        public int idRoleNavigation { get; set; }
        public int idNavigation { get; set; }
        public int idRole { get; set; }
        public bool bActive { get; set; }
        public bool isDeleted { get; set; } 
        public string sRoleName { get; set; }
        public RoleNavigationDto()
        { }
        public RoleNavigationDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idRoleNavigation") && !Convert.IsDBNull(dr["idRoleNavigation"]))
                this.idRoleNavigation = Convert.ToInt32(dr["idRoleNavigation"]);
            if (dr.Table.Columns.Contains("idRole") && !Convert.IsDBNull(dr["idRole"]))
                this.idRole = Convert.ToInt32(dr["idRole"]);
            if (dr.Table.Columns.Contains("idNavigation") && !Convert.IsDBNull(dr["idNavigation"]))
                this.idNavigation = Convert.ToInt32(dr["idNavigation"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]); 
            if (dr.Table.Columns.Contains("sRoleName") && !Convert.IsDBNull(dr["sRoleName"]))
                this.sRoleName = Convert.ToString(dr["sRoleName"]);
        }
    }
}
