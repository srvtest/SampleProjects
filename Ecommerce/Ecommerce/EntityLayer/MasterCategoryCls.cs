using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class MasterCategoryCls
    {
        public int idMasterCategory { get; set; }
        public string sName { get; set; }
        public bool bStatus { get; set; }
    }

   public class CollectionCls
    {
        public int idCollection { get; set; }
        public string sName { get; set; }
        public bool bStatus { get; set; }
    }

    public class MaterialCls
    {
        public int idMaterial { get; set; }
        public string sName { get; set; }
        public bool bStatus { get; set; }
    }
    public class GemstoneCls
    {
        public int idGemstone { get; set; }
        public string sName { get; set; }
        public bool bStatus { get; set; }
    }
    public class GenderCls
    {
        public int idGender { get; set; }
        public string sName { get; set; }
        public bool bStatus { get; set; }
    }
}
