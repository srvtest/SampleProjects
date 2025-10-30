using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CountryDto
    {
        public int CountryID { get; set; }
        public string countryName { get; set; }

        public CountryDto() { }

        public CountryDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("CountryID") && !Convert.IsDBNull(dr["CountryID"]))
            {
                this.CountryID = Convert.ToInt32(dr["CountryID"]);
            }
            if (dr.Table.Columns.Contains("countryName") && !Convert.IsDBNull(dr["countryName"]))
            {
                this.countryName = Convert.ToString(dr["countryName"]);
            }
        }
    }
}
