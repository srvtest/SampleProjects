using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerCls
    {
        public int idCustomer { get; set; }
        public string sName { get; set; }
        public short Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
        public short bStatus { get; set; }
        public int idCountry { get; set; }
        public string VerificationCode { get; set; }
        public string isEmailVerified { get; set; }
    }
}
