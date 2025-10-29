using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TableNo
    {
        public int TableNumberID { get; set; }
        [Required(ErrorMessage = "Please enter table number")]
        public string TableNumber { get; set; }
        [Required(ErrorMessage = "Please enter table capacity")]
        public byte? TableCapacity { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public bool IsBusy { get; set; }

       // [Required(ErrorMessage = "Please select Restaurant")]
        public int? RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
