using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class BookingDetailsCls
    {
        public int Id { get; set; }
        public string categoryName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public BookingDetailsCls()
        {

        }
        public BookingDetailsCls(DataRow dr)
        {
           
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("categoryName") && !Convert.IsDBNull(dr["categoryName"]))
                this.categoryName = Convert.ToString(dr["categoryName"]);
        
             if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                 this.FromDate = Convert.ToDateTime(dr["FromDate"]);
        
             if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                 this.ToDate = Convert.ToDateTime(dr["ToDate"]);
        }
    }
}
