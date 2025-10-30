using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ImageInformation
    {
        public string ImageName { get; set; }
        public string ImageData { get; set; }
        public ImageInformation() { }

        public ImageInformation(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ImageName") && !Convert.IsDBNull(dr["ImageName"]))
            {
                this.ImageName = Convert.ToString(dr["ImageName"]);
            }
            if (dr.Table.Columns.Contains("ImageData") && !Convert.IsDBNull(dr["ImageData"]))
            {
                this.ImageData = Convert.ToString(dr["ImageData"]);
            }
        }
        }
}
