using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class ImageCls
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Int16 bStatus { get; set; }
        public string guid { get; set; }
    }
}
