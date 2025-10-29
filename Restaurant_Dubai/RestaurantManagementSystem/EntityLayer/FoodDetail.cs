using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EntityLayer
{
    public class FoodDetail
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "Please enter valid price")]
        public decimal Price { get; set; }
        [Range(typeof(Decimal), "0", "9999", ErrorMessage = "Please enter valid discount price")]
        public decimal DiscountPrice { get; set; }
        [Required(ErrorMessage = "Please select food category")]
        public int? FoodCategoryID { get; set; }
        [Required(ErrorMessage = "Please enter quantity")]
        [Range(typeof(int),"1", "99", ErrorMessage = "Please enter valid quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter food type")]
        public string FoodType { get; set; }

       // public string images { get; set; }
        [Display(Name ="Status")]
        public bool IsActive { get; set; }

        public string SearchTag { get; set; }

        public int? SpecialFoodID { get; set; }

        public int RestaurantID { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Boolean ApplyToAll { get; set; }

        public int BaseFoodID { get; set; }

        public HttpPostedFileBase user_image_data { get; set; }
    }
}
