using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ViewModelRestaurantSearch
    {
        public string Lat { get; set; }
        public string Long { get; set; }
        public double Radius { get; set; }
        public int CategoryType { get; set; }
    }
}
