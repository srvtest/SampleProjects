using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class State
    {
        public int? StateID { get; set; }

        [Required(ErrorMessage = "Please enter State Name")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please select Country")]
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public List<Country> lstCountry { get; set; }

        public bool IsActive { get; set; }

    }
}
