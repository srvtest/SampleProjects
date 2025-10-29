using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class ProductImageCls
    {
        public int idProductImage { get; set; }
        public int idProduct { get; set; }
        public string imageurl { get; set; }
        public int Createdby { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }       
        public string ImageName { get; set; }
        public Int16 bStatus { get; set; }
        public string guid { get; set; }
    }
}
