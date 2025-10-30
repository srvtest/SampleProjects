using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CheckInReportWithGuestDataRequestModel
    {
        public int HotelId { get; set; }
        public int? BookingId { get; set; }
        public string CheckInDate { get; set; }
    }
}
