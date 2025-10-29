using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Country
    {
        public int? CountryID { get; set; }

        [Required(ErrorMessage = "Please enter Country Name.")]
        public string CountryName { get; set; }

        public bool IsActive { get; set; }

    }
}
