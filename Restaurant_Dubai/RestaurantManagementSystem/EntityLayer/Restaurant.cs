using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }

        public string Logo { get; set; }
        [Required(ErrorMessage = "Please enter Country Name.")]
        public int? CountryID { get; set; }
        [Required(ErrorMessage = "Please enter State Name.")]
        public int? StateID { get; set; }
        [Required(ErrorMessage = "Please enter City Name.")]
        public int? CityID { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        [Required(ErrorMessage = "Please select Parent Branch.")]
        public int ParentBranchID { get; set; }
        public bool IsBranch { get; set; }
        public string MAP { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        [Required(ErrorMessage = "Please enter Address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Contact.")]
        public string Contact { get; set; }

        public string Policy { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        public bool Status { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
