using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class ProductVideoCls
    {
        public int idProductVideo { get; set; }
        public int idProduct { get; set; }
        public string Videourl { get; set; }
       // public bool bStatus { get; set; }
        public int Createdby { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public string VideoName { get; set; }
        public Int16 bStatus { get; set; }
        public string guid { get; set; }
    }
}
