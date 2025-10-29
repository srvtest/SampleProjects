using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Access
    {

        public int AccessID { get; set; }

        [Required(ErrorMessage = "Please enter Access Name.")]
        public string AccessName { get; set; }
        public string AccessDesc { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool isChecked { get; set; }
        [Required(ErrorMessage = "Please select Base Access.")]
        public int BaseAccessID { get; set; }
        //[Required(ErrorMessage = "Please enter Page URL.")]
        public string PageURL { get; set; }


    }
}
