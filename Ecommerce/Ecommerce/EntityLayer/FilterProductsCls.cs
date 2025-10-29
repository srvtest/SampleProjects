using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class FilterProductsCls
    {
        public List<MasterCategoryCls> lstMasterCategory;
        public List<CollectionCls> lstCollection;
        public List<CategoryCls> lstCategory;
        public List<MaterialCls> lstMaterial;
        public List<GemstoneCls> lstGemstone;
        public List<GenderCls> lstGender;
        public List<ColorCls> lstColor;
        public List<ShapeCls> lstShape { get; set; }
        public List<SizeCls> lstSize { get; set; }
    }
}
