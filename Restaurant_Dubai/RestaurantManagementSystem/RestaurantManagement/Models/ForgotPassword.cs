using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class ForgotPassword
    {
        [Required]
        [Display(Name = "Username")]
        public string Email { get; set; }
    }
}