using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class AdminCls
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public AdminCls()
        { }

        public AdminCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("Username") && !Convert.IsDBNull(dr["Username"]))
                this.Username = Convert.ToString(dr["Username"]);

            if (dr.Table.Columns.Contains("Password") && !Convert.IsDBNull(dr["Password"]))
                this.Password = Convert.ToString(dr["Password"]);

            if (dr.Table.Columns.Contains("NewPassword") && !Convert.IsDBNull(dr["NewPassword"]))
                this.NewPassword = Convert.ToString(dr["NewPassword"]);
        }
    }
}
