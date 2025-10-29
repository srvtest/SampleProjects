using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserCouponRedemptionCls
    {
        public int idUserCouponRedemptionCls { get; set; }                
        public int idCountry { get; set; }        
        public int idCoupon { get; set; }
        public int idCustomer { get; set; }
        public int idCustomerOrder { get; set; }
    }
}
