using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ViewRoleAccessModel
    {
        public List<Access> lstAccess { get; set; }

        public List<RoleAccess> lstRoleAccess { get; set; }

        public string Desc { get; set; }

        public Int32? RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        public Int32? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Int32? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
