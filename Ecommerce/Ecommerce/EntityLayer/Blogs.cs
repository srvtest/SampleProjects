using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class BlogsCls
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public DateTime Datetime { get; set; }
        public string URL { get; set; }
        public string MetaTags { get; set; }

    }
}
