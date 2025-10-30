using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PoliceStationMasterDto
    {
        public int idPoliceStationMaster { get; set; }
        public string PoliceStationName { get; set; }
        public string Password { get; set; }
        public int idCity { get; set; }
        public int idState { get; set; }
        public int idZone { get; set; }
        public string ZoneName { get; set; }
        public string stateName { get; set; }
        public string CityName { get; set; }
        public bool isDeleted { get; set; }
        public int idDistrict { get; set; }
        public string DistrictName { get; set; }
        public string MobileNumber { get; set; }
        public string landLineNumber { get; set; }
        public string EmailId { get; set; }
        public PoliceStationMasterDto()
        { }
        public PoliceStationMasterDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idPoliceStationMaster") && !Convert.IsDBNull(dr["idPoliceStationMaster"]))
                this.idPoliceStationMaster = Convert.ToInt32(dr["idPoliceStationMaster"]);
            if (dr.Table.Columns.Contains("PoliceStationName") && !Convert.IsDBNull(dr["PoliceStationName"]))
                this.PoliceStationName = Convert.ToString(dr["PoliceStationName"]);
            if (dr.Table.Columns.Contains("Password") && !Convert.IsDBNull(dr["Password"]))
                this.Password = Convert.ToString(dr["Password"]);
            if (dr.Table.Columns.Contains("CityId") && !Convert.IsDBNull(dr["CityId"]))
                this.idCity = Convert.ToInt32(dr["CityId"]);
            if (dr.Table.Columns.Contains("StateID") && !Convert.IsDBNull(dr["StateID"]))
                this.idState = Convert.ToInt32(dr["StateID"]);
            if (dr.Table.Columns.Contains("idZone") && !Convert.IsDBNull(dr["idZone"]))
                this.idZone = Convert.ToInt32(dr["idZone"]);
            if (dr.Table.Columns.Contains("ZoneName") && !Convert.IsDBNull(dr["ZoneName"]))
            {
                this.ZoneName = Convert.ToString(dr["ZoneName"]);
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
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.idPoliceStationMaster = Convert.ToInt32(dr["Id"]);
            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.PoliceStationName = Convert.ToString(dr["sName"]);
            if (dr.Table.Columns.Contains("idDistrict") && !Convert.IsDBNull(dr["idDistrict"]))
                this.idDistrict = Convert.ToInt32(dr["idDistrict"]);
            if (dr.Table.Columns.Contains("DistrictName") && !Convert.IsDBNull(dr["DistrictName"]))
            {
                this.DistrictName = Convert.ToString(dr["DistrictName"]);
            }

            if (dr.Table.Columns.Contains("MobileNumber") && !Convert.IsDBNull(dr["MobileNumber"]))
            {
                this.MobileNumber = Convert.ToString(dr["MobileNumber"]);
            }

            if (dr.Table.Columns.Contains("LandlineNumber") && !Convert.IsDBNull(dr["LandlineNumber"]))
            {
                this.landLineNumber = Convert.ToString(dr["LandlineNumber"]);
            }

            if (dr.Table.Columns.Contains("emailid") && !Convert.IsDBNull(dr["emailid"]))
            {
                this.EmailId = Convert.ToString(dr["emailid"]);
            }

        }
    }
}
