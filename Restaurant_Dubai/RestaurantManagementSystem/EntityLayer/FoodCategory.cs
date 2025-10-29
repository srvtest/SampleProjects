using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class FoodCategory
    {
        public int FoodCategoryID { get; set; }
        [Required(ErrorMessage = "Please enter category title")]
        public string CategoryTitle { get; set; }

        public string Description { get; set; }

        public string Images { get; set; }

        public int? RestaurantID { get; set; }

        public string RestaurantName { get; set; }
       // [Required(ErrorMessage = "Please select Cuisine")]
        public int? CuisineID { get; set; }

        public string CuisineType { get; set; }

        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Boolean ApplyToAll { get; set; }

        public int BaseFoodCategoryID { get; set; }

    }
}
