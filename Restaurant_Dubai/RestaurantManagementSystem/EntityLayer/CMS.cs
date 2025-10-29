using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer
{
    public class CMS
    {
        public int CMSID { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; }

       // [AllowHtml]
        public string PageDesc { get; set; }
        [Required]
        [Display(Name = "Restaurant")]
        public int? RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        [Required]
        [Display(Name = "CMSType")]
        public int? CMSTypeID { get; set; }
        public string CMSTypeName { get; set; }
        public bool IsActive { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
