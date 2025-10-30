using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HotelMasterDto
    {
        public int idHotelMaster { get; set; }
        public string HotelID { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string RegMobileNumber { get; set; }
        public string HotelOwnerName { get; set; }
        public string HotelOwnerNumber { get; set; }
        public string HotelWebsite { get; set; }
        public string HotelEmail { get; set; }
        public int HotelPoliceStationId { get; set; }
        public bool Status { get; set; }
        public string IsSubscribed { get; set; }
        public bool isDeleted { get; set; }
        public int HotelDistrictId { get; set; }
        public int HotelCityid { get; set; }
        public int HotelStateId { get; set; }
        public DateTime SubscriptionExpireDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int HotelTypeId { get; set; }
        //public string HotelRegistrationDoc { get; set; }
        //public string HotelOwnerAdharFront { get; set; }
        public string filePass { get; set; }
        public string Password { get; set; }
        public string OTPValid { get; set; }
        public string policeContact { get; set; }
        public string Token { get; set; }
        public int HotelRoomCapacity { get; set; }
        public string CityName { get; set; }
        public string Expdate { get; set; }
        public string PoliceStationName { get; set; }
        public string DistrictName { get; set; }
        public string stateName { get; set; }
        public string PropertyTypeName { get; set; }
        //public string HotelOwnerAdharBack { get; set; }
        public string PoliceStationEmailId { get; set; }
        //public int idHotelMaster { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonMobile { get; set; }
        public string Website { get; set; }
        public string EmailAddress { get; set; }
        public int idPoliceStation { get; set; }
        //public bool bActive { get; set; }
         public int idPoliceStationMaster { get; set; }
        public int idDistrict { get; set; }
        public int idCity { get; set; }
        public int idState { get; set; }
        //public DateTime ValidUpto { get; set; }
        public int PropertyType { get; set; }
        public string FileGumasta { get; set; }
        public string FileAdhar { get; set; }

        //public string OTP { get; set; }

        public int NoOfRoom { get; set; }
        public string FileAdharBack { get; set; }
        public string PaymentStatus { get; set; }
        public string HotelRegistrationDocPath { get; set; }
        public string HotelOwnerAdharFrontPath { get; set; }
        public string HotelOwnerAdharBackPath { get; set; }
        public IFormFile HotelRegistrationDoc { get; set; }
        public IFormFile HotelOwnerAdharFront { get; set; }
        public IFormFile HotelOwnerAdharBack { get; set; }
        public HotelMasterDto()
        { }
        public HotelMasterDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idHotelMaster") && !Convert.IsDBNull(dr["idHotelMaster"]))
                this.idHotelMaster = Convert.ToInt32(dr["idHotelMaster"]);

            if (dr.Table.Columns.Contains("HotelID") && !Convert.IsDBNull(dr["HotelID"]))
                this.HotelID = Convert.ToString(dr["HotelID"]);

            if (dr.Table.Columns.Contains("HotelName") && !Convert.IsDBNull(dr["HotelName"]))
                this.HotelName = Convert.ToString(dr["HotelName"]);

            if (dr.Table.Columns.Contains("HotelAddress") && !Convert.IsDBNull(dr["HotelAddress"]))
                this.HotelAddress = Convert.ToString(dr["HotelAddress"]);

            if (dr.Table.Columns.Contains("HotelOwnerName") && !Convert.IsDBNull(dr["HotelOwnerName"]))
                this.HotelOwnerName = Convert.ToString(dr["HotelOwnerName"]);

            if (dr.Table.Columns.Contains("HotelOwnerNumber") && !Convert.IsDBNull(dr["HotelOwnerNumber"]))
                this.HotelOwnerNumber = Convert.ToString(dr["HotelOwnerNumber"]);

            if (dr.Table.Columns.Contains("HotelEmail") && !Convert.IsDBNull(dr["HotelEmail"]))
                this.HotelEmail = Convert.ToString(dr["HotelEmail"]);

            if (dr.Table.Columns.Contains("HotelPoliceStationId") && !Convert.IsDBNull(dr["HotelPoliceStationId"]))
                this.HotelPoliceStationId = Convert.ToInt32(dr["HotelPoliceStationId"]);

            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
                this.Status = Convert.ToBoolean(dr["Status"]);

            if (dr.Table.Columns.Contains("IsSubscribed") && !Convert.IsDBNull(dr["IsSubscribed"]))
                this.IsSubscribed = Convert.ToString(dr["IsSubscribed"]);

            if (dr.Table.Columns.Contains("HotelStateId") && !Convert.IsDBNull(dr["HotelStateId"]))
                this.HotelStateId = Convert.ToInt32(dr["HotelStateId"]);

            if (dr.Table.Columns.Contains("HotelCityid") && !Convert.IsDBNull(dr["HotelCityid"]))
                this.HotelCityid = Convert.ToInt32(dr["HotelCityid"]);

            if (dr.Table.Columns.Contains("HotelDistrictId") && !Convert.IsDBNull(dr["HotelDistrictId"]))
                this.HotelDistrictId = Convert.ToInt32(dr["HotelDistrictId"]);

            if (dr.Table.Columns.Contains("SubscriptionExpireDate") && !Convert.IsDBNull(dr["SubscriptionExpireDate"]))
                this.SubscriptionExpireDate = Convert.ToDateTime(dr["SubscriptionExpireDate"]);

            if (dr.Table.Columns.Contains("CreatedAt") && !Convert.IsDBNull(dr["CreatedAt"]))
                this.CreatedAt = Convert.ToDateTime(dr["CreatedAt"]);

            if (dr.Table.Columns.Contains("PropertyType") && !Convert.IsDBNull(dr["PropertyType"]))
                this.PropertyTypeName = Convert.ToString(dr["PropertyType"]);

            if (dr.Table.Columns.Contains("HotelTypeId") && !Convert.IsDBNull(dr["HotelTypeId"]))
                this.HotelTypeId = Convert.ToInt32(dr["HotelTypeId"]);

            if (dr.Table.Columns.Contains("HotelRegistrationDoc") && !Convert.IsDBNull(dr["HotelRegistrationDoc"]))
                this.HotelRegistrationDocPath = Convert.ToString(dr["HotelRegistrationDoc"]);

            if (dr.Table.Columns.Contains("HotelOwnerAdharFront") && !Convert.IsDBNull(dr["HotelOwnerAdharFront"]))
                this.HotelOwnerAdharFrontPath = Convert.ToString(dr["HotelOwnerAdharFront"]);

            if (dr.Table.Columns.Contains("RegMobileNumber") && !Convert.IsDBNull(dr["RegMobileNumber"]))
                this.RegMobileNumber = Convert.ToString(dr["RegMobileNumber"]);

            if (dr.Table.Columns.Contains("HotelWebsite") && !Convert.IsDBNull(dr["HotelWebsite"]))
                this.HotelWebsite = Convert.ToString(dr["HotelWebsite"]);

            if (dr.Table.Columns.Contains("filePass") && !Convert.IsDBNull(dr["filePass"]))
                this.filePass = Convert.ToString(dr["filePass"]);
            if (dr.Table.Columns.Contains("Password") && !Convert.IsDBNull(dr["Password"]))
                this.Password = Convert.ToString(dr["Password"]);

            //if (dr.Table.Columns.Contains("OTPValid") && !Convert.IsDBNull(dr["OTPValid"]))
            //    this.OTPValid = Convert.ToString(dr["OTPValid"]);

            if (dr.Table.Columns.Contains("policeContact") && !Convert.IsDBNull(dr["policeContact"]))
                this.policeContact = Convert.ToString(dr["policeContact"]);

            if (dr.Table.Columns.Contains("CityName") && !Convert.IsDBNull(dr["CityName"]))
                this.CityName = Convert.ToString(dr["CityName"]);

            if (dr.Table.Columns.Contains("HotelRoomCapacity") && !Convert.IsDBNull(dr["HotelRoomCapacity"]))
                this.HotelRoomCapacity = Convert.ToInt32(dr["HotelRoomCapacity"]);

            //if (dr.Table.Columns.Contains("Expdate") && !Convert.IsDBNull(dr["Expdate"]))
            //    this.Expdate = Convert.ToString(dr["Expdate"]);

            if (dr.Table.Columns.Contains("PoliceStationName") && !Convert.IsDBNull(dr["PoliceStationName"]))
                this.PoliceStationName = Convert.ToString(dr["PoliceStationName"]);

            if (dr.Table.Columns.Contains("DistrictName") && !Convert.IsDBNull(dr["DistrictName"]))
                this.DistrictName = Convert.ToString(dr["DistrictName"]);

            if (dr.Table.Columns.Contains("stateName") && !Convert.IsDBNull(dr["stateName"]))
                this.stateName = Convert.ToString(dr["stateName"]);

            if (dr.Table.Columns.Contains("HotelOwnerAdharBack") && !Convert.IsDBNull(dr["HotelOwnerAdharBack"]))
                this.HotelOwnerAdharBackPath = Convert.ToString(dr["HotelOwnerAdharBack"]);

            if (dr.Table.Columns.Contains("emailid") && !Convert.IsDBNull(dr["emailid"]))
                this.PoliceStationEmailId = Convert.ToString(dr["emailid"]);

            if (dr.Table.Columns.Contains("Address") && !Convert.IsDBNull(dr["Address"]))
                this.Address = Convert.ToString(dr["Address"]);

            if (dr.Table.Columns.Contains("Contact") && !Convert.IsDBNull(dr["Contact"]))
                this.Contact = Convert.ToString(dr["Contact"]);

            if (dr.Table.Columns.Contains("ContactPerson") && !Convert.IsDBNull(dr["ContactPerson"]))
                this.ContactPerson = Convert.ToString(dr["ContactPerson"]);

            if (dr.Table.Columns.Contains("ContactPersonMobile") && !Convert.IsDBNull(dr["ContactPersonMobile"]))
                this.ContactPersonMobile = Convert.ToString(dr["ContactPersonMobile"]);

            if (dr.Table.Columns.Contains("EmailAddress") && !Convert.IsDBNull(dr["EmailAddress"]))
                this.EmailAddress = Convert.ToString(dr["EmailAddress"]);

            if (dr.Table.Columns.Contains("idPoliceStation") && !Convert.IsDBNull(dr["idPoliceStation"]))
                this.idPoliceStation = Convert.ToInt32(dr["idPoliceStation"]);

            if (dr.Table.Columns.Contains("idDistrict") && !Convert.IsDBNull(dr["idDistrict"]))
                this.idDistrict = Convert.ToInt32(dr["idDistrict"]);

            if (dr.Table.Columns.Contains("idCity") && !Convert.IsDBNull(dr["idCity"]))
                this.idCity = Convert.ToInt32(dr["idCity"]);

            if (dr.Table.Columns.Contains("idState") && !Convert.IsDBNull(dr["idState"]))
                this.idState = Convert.ToInt32(dr["idState"]);

            if (dr.Table.Columns.Contains("PropertyType") && !Convert.IsDBNull(dr["PropertyType"]))
                this.PropertyType = Convert.ToInt32(dr["PropertyType"]);

            //if (dr.Table.Columns.Contains("FileGumasta") && !Convert.IsDBNull(dr["FileGumasta"]))
            //    this.FileGumasta = Convert.ToString(dr["FileGumasta"]);

            //if (dr.Table.Columns.Contains("FileAdhar") && !Convert.IsDBNull(dr["FileAdhar"]))
            //    this.FileAdhar = Convert.ToString(dr["FileAdhar"]);

            if (dr.Table.Columns.Contains("NoOfRoom") && !Convert.IsDBNull(dr["NoOfRoom"]))
                this.NoOfRoom = Convert.ToInt32(dr["NoOfRoom"]);

            if (dr.Table.Columns.Contains("PaymentStatus") && !Convert.IsDBNull(dr["PaymentStatus"]))
                this.PaymentStatus = Convert.ToString(dr["PaymentStatus"]);
            
            if (dr.Table.Columns.Contains("Website") && !Convert.IsDBNull(dr["Website"]))
                this.Website = Convert.ToString(dr["Website"]);

            if (dr.Table.Columns.Contains("idPoliceStationMaster") && !Convert.IsDBNull(dr["idPoliceStationMaster"]))
                this.idPoliceStationMaster = Convert.ToInt32(dr["idPoliceStationMaster"]);
        }
    }
}
