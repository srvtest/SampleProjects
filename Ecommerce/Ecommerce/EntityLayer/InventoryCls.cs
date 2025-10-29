using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class InventoryCls
    {
        public int idInventory { get; set; }
        public int idProduct { get; set; }
        public int quantity { get; set; }
        public DateTime createdate { get; set; }
    }
}
