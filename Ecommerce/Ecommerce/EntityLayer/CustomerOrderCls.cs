using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerOrderCls
    {
        public int idCustomerOrder { get; set; }
        public int idCustomer { get; set; }
        public string sOrderNo { get; set; }
        public DateTime dtOrder { get; set; }
        public DateTime dtApproval { get; set; }
        public string sName { get; set; }
        public string Mobile { get; set; }
        public string PinCode { get; set; }
        public string sAddress1 { get; set; }
        public string sAddress2 { get; set; }
        public string sCity { get; set; }
        public string sState { get; set; }
        public string sLandMark { get; set; }
        public string AddressType { get; set; }
        public string AlternateNo { get; set; }
        public string CouponCode { get; set; }
        public int bStatus { get; set; }
        public decimal totalAmount { get; set; }
        public int TotalProduct { get; set; }
        public int TotalQuantity { get; set; }
        public string ApproveReject { get; set; }
        public string Comment { get; set; }
        public string ShippingComment { get; set; }
        public string TrackingNumber { get; set; }
        public List<CustomerOrderProductCls> CustomerOrderProductCls;
    }
}
