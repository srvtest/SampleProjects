using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Role
    {
        public int RolesID { get; set; }

        [Required(ErrorMessage = "Please enter Role Name.")]
        public string RoleName { get; set; }

        public string RoleDesc { get; set; }
        [Required(ErrorMessage = "Please select Restaurant")]
        public int? RestaurantID { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
