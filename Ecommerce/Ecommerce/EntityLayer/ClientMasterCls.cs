using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ClientMasterCls
    {
        public int idClientMaster { get; set; }
        public string sName { get; set; }
        public string slogo { get; set; }
        public string sAddress { get; set; }
        public string sCity { get; set; }
        public string sState { get; set; }
        public string sZip { get; set; }
        public string sPhoneNumber { get; set; }
        public string sMobilenumber { get; set; }
        public string sEmail { get; set; }
        public string sFBURL { get; set; }
        public string sGURL { get; set; }
        public string sLinkdinURL { get; set; }
        public string sTwitterURL { get; set; }
        public Int16 bActive { get; set; }
        public int idCountry { get; set; }
        public string sCountryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public Int16 isDelete { get; set; }
        public string host { get; set; }
        public string fromEmail { get; set; }
        public string password { get; set; }

    }
}
