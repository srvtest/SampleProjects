using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RestaurantLogin
    {
        public int RestaurantID { get; set; }
        [Required]
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }
        public string Password { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
        public int UserID { get; set; }
        public string UserAuthToken { get; set; }
    }
}
