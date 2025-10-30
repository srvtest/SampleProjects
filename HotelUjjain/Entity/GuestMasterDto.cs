using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entity
{
    [Serializable]
    [XmlRoot("GuestMasterDto")]
    public class GuestMasterDto
    {
        public int idGuestMaster { get; set; }
        public int idMain { get; set; }
        public int idHotel { get; set; }
        public string ContactNo { get; set; }
        public string ContactNoTemp { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string EnterDate { get; set; }
        public string Description { get; set; }
        public bool isSubmitted { get; set; }
        public bool bActive { get; set; }
        public string GuestName { get; set; }
        public string IdentificationNo { get; set; }
        public string IdentificationNoTemp { get; set; }
        public string IdentificationType { get; set; }
        public string Address { get; set; }
        public bool isDeleted { get; set; }
        public int AddionalGuest { get; set; }
        public string HotelName { get; set; }
        public string GuestDetailXml { get; set; }
        public string GuestRoomXml { get; set; }
        public string IDProofNumber { get; set; }
        public string GuestMobileNumber { get; set; }

        [XmlElement("GuestDetailDto")]
        public List<GuestDetailDto> Details { get; set; }
        [XmlElement("GuestRoomDto")]
        public List<GuestRoomDto> GuestRoomDetails { get; set; }

        [XmlElement("HotelCategoryDto")]
        public List<HotelCategoryDto> Categories { get; set; }

        public int idHotelGuestDetail { get; set; }
        public string GuestLastName { get; set; }
        public string gender { get; set; }
        public string TravelReson { get; set; }
        public string city { get; set; }
        public string PIncode { get; set; }
        public string filePass { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string SubmitDate { get; set; }
        public string SubmitBy { get; set; }
        public string HotelAddress { get; set; }
        public string HotelContact { get; set; }
        public DateTime CreatedDate { get; set; }
        public string sDocName { get; set; }
        public string PoliceStationEmailId { get; set; }
        public string PoliceStationNo { get; set; }
        public DateTime CreatedAt { get; set; }

        public int HotelID { get; set; }
        public string GuestId { get; set; }
        public string BookingID { get; set; }
        public GuestMasterDto()
        { }
        public GuestMasterDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idGuestMaster") && !Convert.IsDBNull(dr["idGuestMaster"]))
                this.idGuestMaster = Convert.ToInt32(dr["idGuestMaster"]);

            if (dr.Table.Columns.Contains("GuestName") && !Convert.IsDBNull(dr["GuestName"]))
                this.GuestName = Convert.ToString(dr["GuestName"]);

            if (dr.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(dr["idHotel"]))
                this.idHotel = Convert.ToInt32(dr["idHotel"]);

            if (dr.Table.Columns.Contains("sName") && !Convert.IsDBNull(dr["sName"]))
                this.HotelName = Convert.ToString(dr["sName"]);

            if (dr.Table.Columns.Contains("IdentificationNo") && !Convert.IsDBNull(dr["IdentificationNo"]))
                this.IdentificationNo = Convert.ToString(dr["IdentificationNo"]);

            if (dr.Table.Columns.Contains("IdentificationType") && !Convert.IsDBNull(dr["IdentificationType"]))
                this.IdentificationType = Convert.ToString(dr["IdentificationType"]);

            if (dr.Table.Columns.Contains("Address") && !Convert.IsDBNull(dr["Address"]))
                this.Address = Convert.ToString(dr["Address"]);

            if (dr.Table.Columns.Contains("isSubmitted") && !Convert.IsDBNull(dr["isSubmitted"]))
                this.isSubmitted = Convert.ToBoolean(dr["isSubmitted"]);

            if (dr.Table.Columns.Contains("Description") && !Convert.IsDBNull(dr["Description"]))
                this.Description = Convert.ToString(dr["Description"]);

            if (dr.Table.Columns.Contains("EnterDate") && !Convert.IsDBNull(dr["EnterDate"]))
                this.EnterDate = Convert.ToString(dr["EnterDate"]);

            if (dr.Table.Columns.Contains("CheckOutDate") && !Convert.IsDBNull(dr["CheckOutDate"]))
                this.CheckOutDate = Convert.ToString(dr["CheckOutDate"]);

            if (dr.Table.Columns.Contains("CheckInDate") && !Convert.IsDBNull(dr["CheckInDate"]))
                this.CheckInDate = Convert.ToString(dr["CheckInDate"]);

            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);

            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);

            if (dr.Table.Columns.Contains("AddionalGuest") && !Convert.IsDBNull(dr["AddionalGuest"]))
                this.AddionalGuest = Convert.ToInt32(dr["AddionalGuest"]);

            if (dr.Table.Columns.Contains("ContactNo") && !Convert.IsDBNull(dr["ContactNo"]))
                this.ContactNo = Convert.ToString(dr["ContactNo"]);

            if (dr.Table.Columns.Contains("GuestDetailXml") && !Convert.IsDBNull(dr["GuestDetailXml"]))
            {
                this.GuestDetailXml = Convert.ToString(dr["GuestDetailXml"]);
                this.Details = this.GuestDetailXml.FromXML<GuestMasterDto>().Details;
            }
            if (dr.Table.Columns.Contains("GuestRoomXml") && !Convert.IsDBNull(dr["GuestRoomXml"]))
            {
                this.GuestRoomXml = Convert.ToString(dr["GuestRoomXml"]);
                this.GuestRoomDetails = this.GuestRoomXml.FromXML<GuestMasterDto>().GuestRoomDetails;
            }


            if (dr.Table.Columns.Contains("idHotelGuestDetail") && !Convert.IsDBNull(dr["idHotelGuestDetail"]))
                this.idHotelGuestDetail = Convert.ToInt32(dr["idHotelGuestDetail"]);

            if (dr.Table.Columns.Contains("GuestLastName") && !Convert.IsDBNull(dr["GuestLastName"]))
                this.GuestLastName = Convert.ToString(dr["GuestLastName"]);

            if (dr.Table.Columns.Contains("gender") && !Convert.IsDBNull(dr["gender"]))
                this.gender = Convert.ToString(dr["gender"]);

            if (dr.Table.Columns.Contains("TravelReson") && !Convert.IsDBNull(dr["TravelReson"]))
                this.TravelReson = Convert.ToString(dr["TravelReson"]);

            if (dr.Table.Columns.Contains("city") && !Convert.IsDBNull(dr["city"]))
                this.city = Convert.ToString(dr["city"]);

            if (dr.Table.Columns.Contains("PIncode") && !Convert.IsDBNull(dr["PIncode"]))
                this.PIncode = Convert.ToString(dr["PIncode"]);

            if (dr.Table.Columns.Contains("filePass") && !Convert.IsDBNull(dr["filePass"]))
                this.filePass = Convert.ToString(dr["filePass"]);

            if (dr.Table.Columns.Contains("Image1") && !Convert.IsDBNull(dr["Image1"]))
                this.Image1 = Convert.ToString(dr["Image1"]);

            if (dr.Table.Columns.Contains("Image2") && !Convert.IsDBNull(dr["Image2"]))
                this.Image2 = Convert.ToString(dr["Image2"]);

            if (dr.Table.Columns.Contains("SubmitDate") && !Convert.IsDBNull(dr["SubmitDate"]))
                this.SubmitDate = Convert.ToString(dr["SubmitDate"]);
            
            if (dr.Table.Columns.Contains("HotelName") && !Convert.IsDBNull(dr["HotelName"]))
                this.HotelName = Convert.ToString(dr["HotelName"]);
            
            if (dr.Table.Columns.Contains("SubmitBy") && !Convert.IsDBNull(dr["SubmitBy"]))
                this.SubmitBy = Convert.ToString(dr["SubmitBy"]);
            
            if (dr.Table.Columns.Contains("HotelAddress") && !Convert.IsDBNull(dr["HotelAddress"]))
                this.HotelAddress = Convert.ToString(dr["HotelAddress"]);
            
            if (dr.Table.Columns.Contains("Contact") && !Convert.IsDBNull(dr["Contact"]))
                this.HotelContact = Convert.ToString(dr["Contact"]);
            if (dr.Table.Columns.Contains("CreatedDate") && !Convert.IsDBNull(dr["CreatedDate"]))
                this.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            if (dr.Table.Columns.Contains("idMain") && !Convert.IsDBNull(dr["idMain"]))
                this.idMain = Convert.ToInt32(dr["idMain"]);
            if (dr.Table.Columns.Contains("sDocName") && !Convert.IsDBNull(dr["sDocName"]))
                this.sDocName = Convert.ToString(dr["sDocName"]);
            if (dr.Table.Columns.Contains("PoliceStationEmailId") && !Convert.IsDBNull(dr["PoliceStationEmailId"]))
                this.PoliceStationEmailId = Convert.ToString(dr["PoliceStationEmailId"]);
            if (dr.Table.Columns.Contains("PoliceStationNo") && !Convert.IsDBNull(dr["PoliceStationNo"]))
                this.PoliceStationNo = Convert.ToString(dr["PoliceStationNo"]);
            if (dr.Table.Columns.Contains("IDProofNumber") && !Convert.IsDBNull(dr["IDProofNumber"]))
                this.IDProofNumber = Convert.ToString(dr["IDProofNumber"]);
            if (dr.Table.Columns.Contains("GuestMobileNumber") && !Convert.IsDBNull(dr["GuestMobileNumber"]))
                this.GuestMobileNumber = Convert.ToString(dr["GuestMobileNumber"]);
            if (dr.Table.Columns.Contains("CreatedAt") && !Convert.IsDBNull(dr["CreatedAt"]))
                this.CreatedAt = Convert.ToDateTime(dr["CreatedAt"]);
            if (dr.Table.Columns.Contains("HotelID") && !Convert.IsDBNull(dr["HotelID"]))
                this.HotelID = Convert.ToInt32(dr["HotelID"]);

            if (dr.Table.Columns.Contains("GuestId") && !Convert.IsDBNull(dr["GuestId"]))
                this.GuestId = Convert.ToString(dr["GuestId"]);
            if (dr.Table.Columns.Contains("BookingID") && !Convert.IsDBNull(dr["BookingID"]))
                this.BookingID = Convert.ToString(dr["BookingID"]);
            if (dr.Table.Columns.Contains("GuestID") && !Convert.IsDBNull(dr["GuestID"]))
                this.GuestId = Convert.ToString(dr["GuestID"]);

        }
    
    }


}
