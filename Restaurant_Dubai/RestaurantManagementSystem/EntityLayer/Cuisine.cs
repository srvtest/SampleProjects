using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cuisine
    {
        [Key]
        public int CuisineId { get; set; }
        [Required(ErrorMessage ="Please enter cuisine type")]
        public string CuisineType { get; set; }
        [Display(Name ="Status")]
        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
