using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RestaurantSearch
    {
        public string DeviceLocation { get; set; }
        public string CuisineType { get; set; }
        public int CuisineID { get; set; }
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string MAP { get; set; }
        public double Dist { get; set; }



        public DeviceDetail deviceDetail { get; set; }

    }
}
