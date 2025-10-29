using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityLayer
{
    public class Events
    {
        public int BookingId { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }

        public Events()
        {

        }

        public Events(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.BookingId = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("Title") && !Convert.IsDBNull(dr["Title"]))
                this.title = Convert.ToString(dr["Title"]);

            if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                this.start = !string.IsNullOrEmpty(Convert.ToString(dr["FromDate"])) ? Convert.ToDateTime(dr["FromDate"]).ToShortDateString() : "";

            if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                this.end = !string.IsNullOrEmpty(Convert.ToString(dr["ToDate"])) ? Convert.ToDateTime(dr["ToDate"]).ToShortDateString() : "";
            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
            {
                if (Convert.ToInt32(dr["Status"]) == 3)
                {
                    this.backgroundColor = "Red";
                    this.borderColor = "Red";
                }
                //else
                //{
                //    this.backgroundColor = "Green";
                //    this.borderColor = "Green";
                //}
            }
            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
            {

                switch (Convert.ToInt32(dr["Status"]))
                {
                    case 1:
                        this.backgroundColor = "#007bff";
                        this.borderColor = "#007bff";
                        break;
                    case 2:
                        this.backgroundColor = "#28a745";
                        this.borderColor = "#28a745";
                        break;
                    case 3:
                        this.backgroundColor = "#17a2b8";
                        this.borderColor = "#17a2b8";
                        break;
                    case 4:
                        this.backgroundColor = "#E67D21";
                        this.borderColor = "#E67D21";
                        break;
                    default:
                        break;
                }
              
               
            }

        }
    }
}
