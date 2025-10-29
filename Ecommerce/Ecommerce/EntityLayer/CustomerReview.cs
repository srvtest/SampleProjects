using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class CustomerReview
    {
        public int idCustomerReview { get; set; }
        public int idCustomer { get; set; }
        public int idProduct { get; set; }
        public decimal starRating { get; set; }
        public string imageURL { get; set; }
        public string headline { get; set; }
        public string review { get; set; }
        public Int16 bStatus { get; set; }
        public DateTime dtCreated { get; set; }
        public DateTime dtModified { get; set; }
    }
}
