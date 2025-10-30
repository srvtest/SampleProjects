using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RolePoliceStationDto
    {
        public int idRolePoliceStation { get; set; }
        public int idPoliceStation { get; set; }
        public int idRole { get; set; }
        public int idDistrict { get; set; }
        public int idCity { get; set; }
        public int idState { get; set; }
        public string DistrictName { get; set; }
        public string stateName { get; set; }
        public string CityName { get; set; }
        public bool isDeleted { get; set; }
        public string PoliceStationName { get; set; }
        public string sName { get; set; }
        public RolePoliceStationDto()
        { }
        public RolePoliceStationDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idRolePoliceStation") && !Convert.IsDBNull(dr["idRolePoliceStation"]))
                this.idRolePoliceStation = Convert.ToInt32(dr["idRolePoliceStation"]);           
            if (dr.Table.Columns.Contains("idPoliceStation") && !Convert.IsDBNull(dr["idPoliceStation"]))
                this.idPoliceStation = Convert.ToInt32(dr["idPoliceStation"]);
            if (dr.Table.Columns.Contains("idRole") && !Convert.IsDBNull(dr["idRole"]))
                this.idRole = Convert.ToInt32(dr["idRole"]);
            if (dr.Table.Columns.Contains("idDistrict") && !Convert.IsDBNull(dr["idDistrict"]))
                this.idDistrict = Convert.ToInt32(dr["idDistrict"]);
            if (dr.Table.Columns.Contains("idCity") && !Convert.IsDBNull(dr["idCity"]))
                this.idCity = Convert.ToInt32(dr["idCity"]);
            if (dr.Table.Columns.Contains("idState") && !Convert.IsDBNull(dr["idState"]))
                this.idState = Convert.ToInt32(dr["idState"]);
            if (dr.Table.Columns.Contains("DistrictName") && !Convert.IsDBNull(dr["DistrictName"]))
            {
                this.DistrictName = Convert.ToString(dr["DistrictName"]);
            }
            if (dr.Table.Columns.Contains("CityName") && !Convert.IsDBNull(dr["CityName"]))
            {
                this.CityName = Convert.ToString(dr["CityName"]);
            }
            if (dr.Table.Columns.Contains("stateName") && !Convert.IsDBNull(dr["stateName"]))
            {
                this.stateName = Convert.ToString(dr["stateName"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("PoliceStationName") && !Convert.IsDBNull(dr["PoliceStationName"]))
                this.PoliceStationName = Convert.ToString(dr["PoliceStationName"]);
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.sName = Convert.ToString(dr["sName"]);
        }
    }
}
