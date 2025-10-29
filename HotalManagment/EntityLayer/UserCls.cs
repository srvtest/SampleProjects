using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
  public  class UserCls
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Creationdate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public UserCls()
        { }
    }
}
