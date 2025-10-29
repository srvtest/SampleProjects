using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TableReservation
    {
        public int TableReservationID { get; set; }
        [Required(ErrorMessage = "Please select Table")]
        public int TableNumberID { get; set; }
        [Required(ErrorMessage = "Please enter book start time")]
        [Display(Name = "The Display Name")DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}"), DataType(DataType.DateTime)]
        public DateTime BookStartTime { get; set; }

        //[Required(ErrorMessage = "Time Should be in '0:HH:mm.'")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        //[DataType(DataType.Time)]
        //public DateTime BookEndTime { get; set; }

        //[Required(ErrorMessage = "Please select Restaurant")]
        public int RestaurantID { get; set; }

        public string RestaurantName { get; set; }

       // [Required(ErrorMessage = "Please select Customer")]
        public int CustomerID { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public string CustomerName { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
