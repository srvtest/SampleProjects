using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RestaurantUser
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter First Name.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LastName { get; set; }

        public int Gender { get; set; }

        //public string Gendern { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter mobile number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        public string OfficeAddress { get; set; }

        public bool IsActive { get; set; }

        public string IpAddress { get; set; }
        [Required(ErrorMessage = "Please select Role")]
        public int? RolesID { get; set; }
        [Required(ErrorMessage = "Please select Restaurant")]
        public int? RestaurantID { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

       

        

    }
}
