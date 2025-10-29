using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class CustomerLoginResponse
    {
        public string UserAuthToken { get; set; }
        public int UserID { get; set; }
        public int HasConfigurationChanged { get; set; }

    }
}