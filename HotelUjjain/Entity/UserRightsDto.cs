using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserRightsDto
    {
        public int idUserRights { get; set; }
        public int idUser { get; set; }
        public int idRole { get; set; }
        public bool bActive { get; set; }
        public bool bDeleted { get; set; }
        public string sRoleName { get; set; }
        public UserRightsDto()
        { }
        public UserRightsDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idUserRights") && !Convert.IsDBNull(dr["idUserRights"]))
                this.idUserRights = Convert.ToInt32(dr["idUserRights"]);
            if (dr.Table.Columns.Contains("idUser") && !Convert.IsDBNull(dr["idUser"]))
                this.idUser = Convert.ToInt32(dr["idUser"]);
            if (dr.Table.Columns.Contains("idRole") && !Convert.IsDBNull(dr["idRole"]))
                this.idRole = Convert.ToInt32(dr["idRole"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("bDeleted") && !Convert.IsDBNull(dr["bDeleted"]))
                this.bDeleted = Convert.ToBoolean(dr["bDeleted"]);
            if (dr.Table.Columns.Contains("sRoleName") && !Convert.IsDBNull(dr["sRoleName"]))
                this.sRoleName = Convert.ToString(dr["sRoleName"]);
        }
    }
}
