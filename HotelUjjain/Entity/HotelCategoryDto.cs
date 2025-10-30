using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class HotelCategoryDto
    {
        public int idHotelRoomCategory { get; set; }
        public int idHotel { get; set; }
        public string CategoryName { get; set; }
        public int iPrice { get; set; }
        public int NoOfRoom { get; set; }
        public bool bChecked { get; set; }
        public bool isDeleted { get; set; }

        public HotelCategoryDto() { }

        public HotelCategoryDto(DataRow dr)
        {


            if (dr.Table.Columns.Contains("idHotelRoomCategory") && !Convert.IsDBNull(dr["idHotelRoomCategory"]))
            {
                this.idHotelRoomCategory = Convert.ToInt32(dr["idHotelRoomCategory"]);
            }

            if (dr.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(dr["idHotel"]))
            {
                this.idHotel = Convert.ToInt32(dr["idHotel"]);
            }

            if (dr.Table.Columns.Contains("CategoryName") && !Convert.IsDBNull(dr["CategoryName"]))
            {
                this.CategoryName = Convert.ToString(dr["CategoryName"]);
            }

            if (dr.Table.Columns.Contains("iPrice") && !Convert.IsDBNull(dr["iPrice"]))
            {
                this.iPrice = Convert.ToInt32(dr["iPrice"]);
            }
            if (dr.Table.Columns.Contains("NoOfRoom") && !Convert.IsDBNull(dr["NoOfRoom"]))
            {
                this.NoOfRoom = Convert.ToInt32(dr["NoOfRoom"]);
            }


        }
    }
}
