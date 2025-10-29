using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AdminCls
    {
        public int idAdmin { get; set; }
        public string sName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool bStatus { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
