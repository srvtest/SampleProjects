using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class ProductCls
    {
        public int idProduct { get; set; }
        public string sName { get; set; }
        public string SEOName { get; set; }
        public int idCategory { get; set; }
        public string Features { get; set; }
        public Int16 IsFeatureProduct { get; set; }
        public string ImageURL { get; set; }
        public Int16 bStatus { get; set; }
        public List<ProductImageCls> ProductImageCls { get; set; }
        public List<ProductVideoCls> ProductVideoCls { get; set; }
        public int? Createdby { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int idMasterCategory { get; set; }
        public int idCollection { get; set; }
        public int idMaterial { get; set; }
        public int idGemstone { get; set; }
        public int idGender { get; set; }
        public int idColor { get; set; }
        public int idShape { get; set; }
        public int idSize { get; set; }
        public int sColor { get; set; }
        public int sShape { get; set; }
        public int sSize { get; set; }


    }
}
