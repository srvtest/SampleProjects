using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Commission
    {
        [Required(ErrorMessage = "Please select Role.")]
        public int? RoleID { get; set; }
        
        public int CommissionID { get; set; }
        [Required(ErrorMessage = "Please select User.")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter Percentage.")]
        public decimal Percentage { get; set; }

        public string Desc { get; set; }
        [Required(ErrorMessage = "Please select Restaurant.")]
        public int? RestaurantID { get; set; }       

        public string RestaurantName { get; set; }
    }
}
