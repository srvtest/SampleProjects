using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerAddress
    {
        public int idCustomer { get; set; }
        public int idCustomerAddress { get; set; }
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
        public Int16 IsDefaultAddr { get; set; }
        public string CountryName { get; set; }
        public CustomerAddress()
        {

        }
    }
}
