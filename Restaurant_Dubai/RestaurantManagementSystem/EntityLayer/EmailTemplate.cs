using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer
{
    public class EmailTemplate
    {
        public int EmailTemplateID { get; set; }
       
        public int? RestaurantID { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Template Body")]
        //[AllowHtml]
        public string EmailBody { get; set; }
        [Display(Name ="Status")]
        public bool IsActive { get; set; }
    }
}
