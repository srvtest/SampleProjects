using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserHotelDto
    {
        public int idUserHotel { get; set; }
        public int idUser { get; set; }
        public int idHotel { get; set; }
        public bool bActive { get; set; }
        public bool isDeleted { get; set; }
        public bool Status { get; set; }
        public string HotelName { get; set; }
        public string Username { get; set; }
        public string sName { get; set; }
        public UserHotelDto()
        { }
        public UserHotelDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idUserHotel") && !Convert.IsDBNull(dr["idUserHotel"]))
                this.idUserHotel = Convert.ToInt32(dr["idUserHotel"]);            
            if (dr.Table.Columns.Contains("idUser") && !Convert.IsDBNull(dr["idUser"]))
                this.idUser = Convert.ToInt32(dr["idUser"]);
            if (dr.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(dr["idHotel"]))
                this.idHotel = Convert.ToInt32(dr["idHotel"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.Status = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("HotelName") && !Convert.IsDBNull(dr["HotelName"]))
                this.HotelName = Convert.ToString(dr["HotelName"]);
            if (dr.Table.Columns.Contains("Username") && !Convert.IsDBNull(dr["Username"]))
                this.Username = Convert.ToString(dr["Username"]);
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.sName = Convert.ToString(dr["sName"]);
        }
    }
}
