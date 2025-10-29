using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerOrderProductCls
    {
        public int idCustomerOrderProduct { get; set; }
        public int idCustomerOrder { get; set; }
        public int idProduct { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ShippingCharge { get; set; }
        public int idCountry { get; set; }

        public CustomerOrderProductCls() {
        }
    }
}
