using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ReviewRating
    {
        public int ReviewRatingID { get; set; }

        [Required(ErrorMessage = "Please Provide Rating")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 to 10")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Please enter valid rating.")]
        public int? Rating { get; set; } = 5;

        //[DataType(DataType.Text)]
        //[RegularExpression(@"[a-zA]*$", ErrorMessage = "Please enter text only")]
        [Required(ErrorMessage = "Please enter review")]
        public string Review { get; set; }

        
        public int? RestaurantID { get; set; }

        [Required(ErrorMessage = "Please select Customer")]
        public int? CustomerID { get; set; }
        public string CustomerName { get; set; }
        [Display(Name ="Status")]
        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
