using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ReportCls
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<CustomerOrderCls> Status { get; set; }
        //public string Status { get; set; }
       // public string Country { get; set; }
        public List<CountryCls> lstCountry { get; set; }
    }
}
