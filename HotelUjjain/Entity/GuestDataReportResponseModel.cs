using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GuestDataReportResponseModel
    {
        public HotelDetailResponseModel hotelDetails { get; set; }
        public string Totalguest { get; set; }
        public string CheckInDate { get; set; }
        public string MaleCount { get; set; }
        public string FemaleCount { get; set; }
        public List<guestdetailsResponseModel> guestdetails { get; set; }
        public List<guestImagedetailsResponseModel> guestimagedetails { get; set; }
    }
}
