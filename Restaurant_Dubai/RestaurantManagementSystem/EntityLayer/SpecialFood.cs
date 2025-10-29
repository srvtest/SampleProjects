using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SpecialFood
    {
        
        public int SpecialFoodID { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        public string Desc { get; set; }
        [Required(ErrorMessage = "Please select Restaurant")]
        public int RestaurantID { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
