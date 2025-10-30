using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserDto
    {
        public int idUser { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public bool bActive { get; set; }
        public bool isDeleted { get; set; }
        public string Newpassword { get; set; }
        public string Token { get; set; }
        public string MobileNumber { get; set; }
        public string UserType { get; set; }
        public string sType { get; set; }

        public List<UserRightsDto> rights { get; set; }
        public UserDto()
        { }
        public UserDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idUser") && !Convert.IsDBNull(dr["idUser"]))
                this.idUser = Convert.ToInt32(dr["idUser"]);
          
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.Name = Convert.ToString(dr["sName"]);

            if (dr.Table.Columns.Contains("Username") && !Convert.IsDBNull(dr["Username"]))
                this.Username = Convert.ToString(dr["Username"]);
            if (dr.Table.Columns.Contains("password") && !Convert.IsDBNull(dr["password"]))
                this.password = Convert.ToString(dr["password"]);
            if (dr.Table.Columns.Contains("MobileNumber") && !Convert.IsDBNull(dr["MobileNumber"]))
                this.MobileNumber = Convert.ToString(dr["MobileNumber"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);

            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("Newpassword") && !Convert.IsDBNull(dr["Newpassword"]))
                this.Newpassword = Convert.ToString(dr["Newpassword"]);

            if (dr.Table.Columns.Contains("sType") && !Convert.IsDBNull(dr["sType"]))
                this.UserType = Convert.ToString(dr["sType"]);
            if (dr.Table.Columns.Contains("sType") && !Convert.IsDBNull(dr["sType"]))
                this.sType = Convert.ToString(dr["sType"]);
        }
    }
}
