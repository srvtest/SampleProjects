using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Tax
    {
        public int TaxID { get; set; }

        [Required(ErrorMessage = "Please enter Tax Percentage.")]
        [Range(0, 100, ErrorMessage = "Please enter valid percentage")]
        public decimal TaxInPercentage { get; set; }

        public decimal Amount { get; set; }
        //[Required(ErrorMessage = "Please select Restaurant")]
        public int? RestaurantID { get; set; }

        public string  RestaurantName { get; set; }
        [Required(ErrorMessage = "Please enter Tax Name.")]
        public string TaxName { get; set; }
      
        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
