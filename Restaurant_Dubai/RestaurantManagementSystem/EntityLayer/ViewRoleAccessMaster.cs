using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ViewRoleAccessMaster
    {
        public RoleAccessMaster objRoleAccessMaster { get; set; }

        public List<Role> lstRole { get; set; }

        public List<RoleAccess> lstRoleAccess { get; set; }

        public List<Access> lstAccess { get; set; }

        public List<Restaurant> lstRestaurant { get; set; }
    }
}
