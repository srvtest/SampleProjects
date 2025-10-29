using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class CustomerLogin
    {
        public int CustomerID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string UserAuthToken { get; set; }
        public bool IsSocialLogin { get; set; }
        public string SocialNetworkToken { get; set; }
        public string ConfigurationTimestamp { get; set; }
        public DeviceDetail deviceDetail { get; set; }
    }
}
