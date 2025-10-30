using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ZoneDto
    {
        public int idZone { get; set; }
        public int CityId { get; set; }
        public string ZoneName { get; set; }
        public int StateID { get; set; }
        public string stateName { get; set; }
        public string CityName { get; set; }
        public bool isDeleted { get; set; }
        public Int16 bActive { get; set; }

        public ZoneDto() { }

        public ZoneDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idZone") && !Convert.IsDBNull(dr["idZone"]))
            {
                this.idZone = Convert.ToInt32(dr["idZone"]);
            }
            if (dr.Table.Columns.Contains("CityId") && !Convert.IsDBNull(dr["CityId"]))
            {
                this.CityId = Convert.ToInt32(dr["CityId"]);
            }
            if (dr.Table.Columns.Contains("ZoneName") && !Convert.IsDBNull(dr["ZoneName"]))
            {
                this.ZoneName = Convert.ToString(dr["ZoneName"]);
            }
            if (dr.Table.Columns.Contains("StateID") && !Convert.IsDBNull(dr["StateID"]))
            {
                this.StateID = Convert.ToInt32(dr["StateID"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("CityName") && !Convert.IsDBNull(dr["CityName"]))
            {
                this.CityName = Convert.ToString(dr["CityName"]);
            }
            if (dr.Table.Columns.Contains("stateName") && !Convert.IsDBNull(dr["stateName"]))
            {
                this.stateName = Convert.ToString(dr["stateName"]);
            }
            if (dr.Table.Columns.Contains("idCity") && !Convert.IsDBNull(dr["idCity"]))
            {
                this.CityId = Convert.ToInt32(dr["idCity"]);
            }
            if (dr.Table.Columns.Contains("idState") && !Convert.IsDBNull(dr["idState"]))
            {
                this.StateID = Convert.ToInt32(dr["idState"]);
            }
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToInt16(dr["bActive"]);
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
            {
                this.idZone = Convert.ToInt32(dr["Id"]);
            }
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
            {
                this.ZoneName = Convert.ToString(dr["sName"]);
            }
        }
    }
}
