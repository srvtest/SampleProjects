using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RoleAccessMaster
    {
        public Int32 RoleAccessMasterID { get; set; }
        [Required(ErrorMessage = "Please select Role")]
        public Int32? RolesID { get; set; }
        [DisplayName("Restaurant")]
        [Required(ErrorMessage = "Please select Restaurant")]
        public Int32 RestaurentID { get; set; }
        public string Descp { get; set; }
        public Int32? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int32? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string RoleName { get; set; }
        public string MenuAccess { get; set; }
        public string RestaurentName { get; set; }
    }
}
