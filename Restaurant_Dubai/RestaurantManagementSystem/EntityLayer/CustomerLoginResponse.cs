using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerLoginResponse
    {
        public string UserAuthToken { get; set; }
        public int CustomerID { get; set; }
        public int HasConfigurationChanged { get; set; }
        public CustomerLoginResponse(DataRow dr)
        {
            if (dr.Table.Columns.Contains("UserAuthToken") && !Convert.IsDBNull(dr["UserAuthToken"]))
                this.UserAuthToken = Convert.ToString(dr["UserAuthToken"]);

            if (dr.Table.Columns.Contains("CustomerID") && !Convert.IsDBNull(dr["CustomerID"]))
                this.CustomerID = Convert.ToInt32(dr["CustomerID"]);

            if (dr.Table.Columns.Contains("HasConfigurationChanged") && !Convert.IsDBNull(dr["HasConfigurationChanged"]))
                this.HasConfigurationChanged = Convert.ToInt32(dr["HasConfigurationChanged"]);
        }
    }
}
