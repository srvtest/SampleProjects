using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GuestRoomDto
    {
        public int idHotelRoomCategory { get; set; }
        public int idGuestRoom { get; set; }
        public int idGuest { get; set; }
        public int iPrice { get; set; }


        public GuestRoomDto() { }

        public GuestRoomDto(DataRow dr)
        {


            if (dr.Table.Columns.Contains("idHotelRoomCategory") && !Convert.IsDBNull(dr["idHotelRoomCategory"]))
            {
                this.idHotelRoomCategory = Convert.ToInt32(dr["idHotelRoomCategory"]);
            }

            if (dr.Table.Columns.Contains("idGuestRoom") && !Convert.IsDBNull(dr["idGuestRoom"]))
            {
                this.idGuestRoom = Convert.ToInt32(dr["idGuestRoom"]);
            }

            if (dr.Table.Columns.Contains("idGuest") && !Convert.IsDBNull(dr["idGuest"]))
            {
                this.idGuest = Convert.ToInt32(dr["idGuest"]);
            }

            if (dr.Table.Columns.Contains("iPrice") && !Convert.IsDBNull(dr["iPrice"]))
            {
                this.iPrice = Convert.ToInt32(dr["iPrice"]);
            }


        }
    }
}
