using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class Enum
    {

        enum Response
        {
            Yes = 1,
            No = 2,
            Maybe = 3
        }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public enum OrderStatus
    {
        Pending = 0,
        Approved = 1,
        Reject = 2,
        Shipped = 3,
        Delivered = 4,
        [Description("User Cancel")]
        UserCancel = 5
    }
    public enum MasterStatus
    {
        PrivacyPolicy = 3,
        RefundPolicy = 7,
        BuyBackPolicy = 9,
        CancellationPolicy = 10,
        ExchangePolicy = 6,
        ShippingPolicy = 8

    }
}
