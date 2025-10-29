using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RoleAccess
    {
        public Int32 UserRoleAccessID { get; set; }
        public Int32 AccessID { get; set; }
        public Int32? RolesID { get; set; }
        public Int32? RoleAccessMasterID { get; set; }
    }
}
