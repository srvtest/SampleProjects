using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Order
    {
        public int TransID { get; set; }
        [Required(ErrorMessage = "Please enter order number")]
        public Int64 OrderNumber { get; set; }
        [Required(ErrorMessage = "Please select customer")]
        public int? CustomerID { get; set; }

        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Please select table")]
        public int TableID { get; set; }
        [Required(ErrorMessage = "Please enter no. of person")]
        public int NumOfPerson { get; set; }

        [Required(ErrorMessage = "Please enter time of arrival")]
        public string TimeOfArrival { get; set; }
        [Required(ErrorMessage = "Please enter order serve time")]
        public string OrderServeTime { get; set; }

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please select restaurant")]
        public int? RestaurantID { get; set; }

        public string RestaurantName { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public List<OrderDetails> lstOrderDetails { get; set; }
    }

    public class OrderDetails
    {
        public int? FoodID { get; set; }

        public string FoodName { get; set; }

        public int? Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
