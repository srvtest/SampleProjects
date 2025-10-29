using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ProductPriceCls
    {
        public int idProductPrice { get; set; }
        public int idProduct { get; set; }
        public int idCountry { get; set; }
        public int idCurrency { get; set; }
        public string Currency { get; set; }

        public double B2Bprice { get; set; }
        public double B2Cprice { get; set; }
        public int Discount { get; set; }
        public decimal ShipmentCharges { get; set; }
        //public bool bStatus { get; set; }
        public int Createdby { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public Int16 bStatus { get; set; }
    }
}
