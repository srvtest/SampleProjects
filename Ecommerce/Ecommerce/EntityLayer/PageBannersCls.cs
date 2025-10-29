using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PageBannersCls
    {
        public int idPageBanners { get; set; }
        public string sName { get; set; }
        public string ImageURL { get; set; }
        public Int16 bActive { get; set; }
        public int idCountry { get; set; }
        public string sDimension { get; set; }
        public string sCountryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public Int16 isDelete { get; set; }
    }
}
