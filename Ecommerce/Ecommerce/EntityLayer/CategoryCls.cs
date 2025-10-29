using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class CategoryCls
    {
       public int idCategory { get; set; }
       public string sName { get; set; }
       public bool bStatus { get; set; }
       public int Createdby { get; set; }
       public DateTime CreationDate { get; set; }
       public int ModifyBy { get; set; }
       public DateTime ModificationDate { get; set; }
    }
}
