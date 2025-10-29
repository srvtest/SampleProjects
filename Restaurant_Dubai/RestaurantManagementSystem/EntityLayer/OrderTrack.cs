using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class OrderTrack
    {
        public int DeliveryID { get; set; }
        [Required(ErrorMessage = "Please enter order ID")]
        public int? OrderID { get; set; }

        public bool Packed { get; set; }

        public string DineIn { get; set; }

        public DateTime? DineInDate { get; set; }

        public string DineOut { get; set; }

        public DateTime? DineOutDate { get; set; }

        public string Delivered { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string DeliveryDesc { get; set; }

        public int? StaffID { get; set; }

        public int? CustomerID { get; set; }

        public string CustomerName { get; set; }

        public int? RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        public decimal DeliveryCost { get; set; }

        public byte? PaymentType { get; set; }

        public decimal Amount { get; set; }

        public string Address { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
