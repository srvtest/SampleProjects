using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StateDto
    {
        public int StateID { get; set; }
        public string stateName { get; set; }
        public int CountryID { get; set; }
        public string countryName { get; set; }
        public bool isDeleted { get; set; }
        public Int16 bActive { get; set; }
        public StateDto() { }

        public StateDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("StateID") && !Convert.IsDBNull(dr["StateID"]))
            {
                this.StateID = Convert.ToInt32(dr["stateID"]);
            }
            if (dr.Table.Columns.Contains("stateName") && !Convert.IsDBNull(dr["stateName"]))
            {
                this.stateName = Convert.ToString(dr["stateName"]);
            }
            if (dr.Table.Columns.Contains("countryName") && !Convert.IsDBNull(dr["countryName"]))
            {
                this.countryName = Convert.ToString(dr["countryName"]);
            }
            if (dr.Table.Columns.Contains("CountryID") && !Convert.IsDBNull(dr["CountryID"]))
            {
                this.CountryID = Convert.ToInt32(dr["CountryID"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToInt16(dr["bActive"]);
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
            {
                this.StateID = Convert.ToInt32(dr["Id"]);
            }
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
            {
                this.stateName = Convert.ToString(dr["sName"]);
            }
        }
    }
}
