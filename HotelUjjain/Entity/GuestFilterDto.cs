using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GuestFilterDto
    {
        public int idHotel { get; set; }

        public string GuestName { get; set; }

        public string ContactNo { get; set; }
        public string IdentificationNo { get; set; }
        public DateTime SubmitDate { get; set; }
        public int idUser { get; set; }
        public int sMonth { get; set; }
        public int sYear { get; set; }

        public string FilterName { get; set; }
        public string FilterAdhar { get; set; }
        public string FilterContact { get; set; }

        public string FilterFromDate { get; set; }
        public string FilterToDate { get; set; }
        public string SubmitBy { get; set; }
        //public int HotelID { get; set; }

        public GuestFilterDto()
        { }
        public GuestFilterDto(DataRow dr)
        {
            //if (dr.Table.Columns.Contains("HotelID") && !Convert.IsDBNull(dr["HotelID"]))
            //    this.HotelID = Convert.ToInt32(dr["HotelID"]);          

        }
    }
}
