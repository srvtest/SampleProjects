using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RoleDto
    {
        public string sName { get; set; }
        public int nDisplaySeq { get; set; }
        public int idRole { get; set; }
        public bool bActive { get; set; }
        public bool isDeleted { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public RoleDto()
        { }
        public RoleDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idRole") && !Convert.IsDBNull(dr["idRole"]))
                this.idRole = Convert.ToInt32(dr["idRole"]);
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.sName = Convert.ToString(dr["sName"]);
            if (dr.Table.Columns.Contains("nDisplaySeq") && !Convert.IsDBNull(dr["nDisplaySeq"]))
                this.nDisplaySeq = Convert.ToInt32(dr["nDisplaySeq"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
        }
    }
}
