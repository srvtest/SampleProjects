using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class DiscountCouponCls
    {
        public int idCoupon { get; set; }
        public string sName { get; set; }
        public DateTime PeriodFrom { get; set; }
        public decimal CouponValue { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal MinCartValue { get; set; }
        public decimal MaxDisCountValue { get; set; }
        public string Description { get; set; }
        public Int16 bActive { get; set; }
        public int idCountry { get; set; }        
        public string sCountryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public Int16 isDelete { get; set; }
    }
}
