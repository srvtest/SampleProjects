using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class City
    {
        public int? CityID { get; set; }

        [Required(ErrorMessage = "Please enter City name.")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please select Country.")]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public List<Country> lstCountry { get; set; }
        [Required(ErrorMessage = "Please select State.")]
        public int StateID { get; set; }
        public string StateName { get; set; }
        public List<State> lstState { get; set; }

        public bool IsActive { get; set; }

    }
}
