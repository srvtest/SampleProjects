using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Offers
    {
        public int ID { get; set; }
        public string NameofOffer { get; set; }
        public string OfferImage { get; set; }
        public string OfferDetail { get; set; }
        public string Description { get; set; }
        public DateTime Validity { get; set; }
        public int Value { get; set; }
        public string ValueType { get; set; }
        public int RestaurantId { get; set; }
        public int DiscountType { get; set; }
        public double MaxDiscountValue { get; set; }
        public double MinOrderValue { get; set; }
        public int limit { get; set; }

    }
}
