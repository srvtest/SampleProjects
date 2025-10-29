using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Please enter First Name")]
        public string Firstname { get; set; }

        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please enter Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        public string OfficeAddress { get; set; }

        public int Gender { get; set; } 

        public bool IsActive { get; set; }

        public string IpAddress { get; set; }

        public string CarRegistrationNo { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool IsSocialLogin { get; set; }

        public string SocialNetworkToken { get; set; }

        public long ConfigurationTimestamp { get; set; }

        public string ModelName { get; set; }

        public string OSVersion { get; set; }

        public string PlatformName { get; set; }

        public double AppVersion { get; set; }

        public string UserAuthToken { get; set; }

        public string DeviceToken { get; set; }

        public CustomerLogin CustomerLogin { get; set; }

        public DeviceDetail deviceDetail { get; set; }

        public int RestaurantID { get; set; }

        public int TransID { get; set; }

    }
}
