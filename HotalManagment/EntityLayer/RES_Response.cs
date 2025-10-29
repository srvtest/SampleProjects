using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Data;

namespace EntityLayer
{
    
    [XmlRoot(ElementName = "RoomTypes")]
    public class RoomTypes
    {
        public RoomTypes()
        {
            RoomType = new List<RoomType>();
        }
        [XmlElement(ElementName = "RoomType")]
        public List<RoomType> RoomType { get; set; }

    }

 

    [XmlRoot(ElementName = "RateTypes")]
    public class RateTypes
    {
        public RateTypes()
        {
            RateType = new List<RateType>();
        }
        [XmlElement(ElementName = "RateType")]
        public List<RateType> RateType { get; set; }
    }

    [XmlRoot(ElementName = "RatePlan")]
    public class RatePlan
    {
        public RatePlan()
        { }
        [XmlElement(ElementName = "RatePlanID")]
        public string RatePlanID { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "RoomTypeID")]
        public string RoomTypeID { get; set; }
        [XmlElement(ElementName = "RoomType")]
        public string RoomType { get; set; }
        [XmlElement(ElementName = "RateTypeID")]
        public string RateTypeID { get; set; }
        [XmlElement(ElementName = "RateType")]
        public string RateType { get; set; }

        public RatePlan(DataRow dr)
        {
            if (dr.Table.Columns.Contains("RatePlanID") && !Convert.IsDBNull(dr["RatePlanID"]))
                this.RatePlanID = Convert.ToString(dr["RatePlanID"]);

            if (dr.Table.Columns.Contains("Name") && !Convert.IsDBNull(dr["Name"]))
                this.Name = Convert.ToString(dr["Name"]);

            if (dr.Table.Columns.Contains("RoomTypeID") && !Convert.IsDBNull(dr["RoomTypeID"]))
                this.RoomTypeID = Convert.ToString(dr["RoomTypeID"]);

            if (dr.Table.Columns.Contains("RoomType") && !Convert.IsDBNull(dr["RoomType"]))
                this.RoomType = Convert.ToString(dr["RoomType"]);

            if (dr.Table.Columns.Contains("RateTypeID") && !Convert.IsDBNull(dr["RateTypeID"]))
                this.RateTypeID = Convert.ToString(dr["RateTypeID"]);

            if (dr.Table.Columns.Contains("RateType") && !Convert.IsDBNull(dr["RateType"]))
                this.RateType = Convert.ToString(dr["RateType"]);
        }

    }

    [XmlRoot(ElementName = "RatePlans")]
    public class RatePlans
    {
        public RatePlans()
        {
            RatePlan = new List<RatePlan>();
        }
        [XmlElement(ElementName = "RatePlan")]
        public List<RatePlan> RatePlan { get; set; }
    }

    [XmlRoot(ElementName = "RoomInfo")]
    public class RoomInfo
    {
        public RoomInfo()
        {
            RoomTypes = new RoomTypes();
            RateTypes = new RateTypes();
            RatePlans = new RatePlans();
        }
        [XmlElement(ElementName = "RoomTypes")]
        public RoomTypes RoomTypes { get; set; }
        [XmlElement(ElementName = "RateTypes")]
        public RateTypes RateTypes { get; set; }
        [XmlElement(ElementName = "RatePlans")]
        public RatePlans RatePlans { get; set; }
    }


    [XmlRoot(ElementName = "RentalInfo")]
    public class RentalInfo
    {
         public RentalInfo()
        { }
        [XmlElement(ElementName = "EffectiveDate")]
        public string EffectiveDate { get; set; }
        [XmlElement(ElementName = "PackageCode")]
        public string PackageCode { get; set; }
        [XmlElement(ElementName = "PackageName")]
        public string PackageName { get; set; }
        [XmlElement(ElementName = "RoomTypeCode")]
        public string RoomTypeCode { get; set; }
        [XmlElement(ElementName = "RoomTypeName")]
        public string RoomTypeName { get; set; }
        [XmlElement(ElementName = "Adult")]
        public string Adult { get; set; }
        [XmlElement(ElementName = "Child")]
        public string Child { get; set; }
        [XmlElement(ElementName = "Rent")]
        public string Rent { get; set; }
        [XmlElement(ElementName = "Discount")]
        public string Discount { get; set; }
    }

    [XmlRoot(ElementName = "BookingTran")]
    public class BookingTran
    {
         public BookingTran()
        { }
        [XmlElement(ElementName = "SubBookingId")]
        public string SubBookingId { get; set; }
        [XmlElement(ElementName = "TransactionId")]
        public string TransactionId { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "IsConfirmed")]
        public string IsConfirmed { get; set; }
        [XmlElement(ElementName = "VoucherNo")]
        public string VoucherNo { get; set; }
        [XmlElement(ElementName = "PackageCode")]
        public string PackageCode { get; set; }
        [XmlElement(ElementName = "PackageName")]
        public string PackageName { get; set; }
        [XmlElement(ElementName = "RateplanCode")]
        public string RateplanCode { get; set; }
        [XmlElement(ElementName = "RateplanName")]
        public string RateplanName { get; set; }
        [XmlElement(ElementName = "RoomTypeCode")]
        public string RoomTypeCode { get; set; }
        [XmlElement(ElementName = "RoomTypeName")]
        public string RoomTypeName { get; set; }
        [XmlElement(ElementName = "Start")]
        public string Start { get; set; }
        [XmlElement(ElementName = "End")]
        public string End { get; set; }
        [XmlElement(ElementName = "TotalRate")]
        public string TotalRate { get; set; }
        [XmlElement(ElementName = "TotalDiscount")]
        public string TotalDiscount { get; set; }
        [XmlElement(ElementName = "TotalExtraCharge")]
        public string TotalExtraCharge { get; set; }
        [XmlElement(ElementName = "TotalPayment")]
        public string TotalPayment { get; set; }
        [XmlElement(ElementName = "TACommision")]
        public string TACommision { get; set; }
        [XmlElement(ElementName = "PayAtHotel")]
        public string PayAtHotel { get; set; }
        [XmlElement(ElementName = "Salutation")]
        public string Salutation { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "Gender")]
        public string Gender { get; set; }
        [XmlElement(ElementName = "DateOfBirth")]
        public string DateOfBirth { get; set; }
        [XmlElement(ElementName = "SpouseDateOfBirth")]
        public string SpouseDateOfBirth { get; set; }
        [XmlElement(ElementName = "WeddingAnniversary")]
        public string WeddingAnniversary { get; set; }
        [XmlElement(ElementName = "Nationality")]
        public string Nationality { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "Zipcode")]
        public string Zipcode { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Mobile")]
        public string Mobile { get; set; }
        [XmlElement(ElementName = "Fax")]
        public string Fax { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "IdentiyType")]
        public string IdentiyType { get; set; }
        [XmlElement(ElementName = "IdentityNo")]
        public string IdentityNo { get; set; }
        [XmlElement(ElementName = "ExpiryDate")]
        public string ExpiryDate { get; set; }
        [XmlElement(ElementName = "TransportationMode")]
        public string TransportationMode { get; set; }
        [XmlElement(ElementName = "Vehicle")]
        public string Vehicle { get; set; }
        [XmlElement(ElementName = "PickupDate")]
        public string PickupDate { get; set; }
        [XmlElement(ElementName = "PickupTime")]
        public string PickupTime { get; set; }
        [XmlElement(ElementName = "Source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }
        [XmlElement(ElementName = "AffiliateName")]
        public string AffiliateName { get; set; }
        [XmlElement(ElementName = "AffiliateCode")]
        public string AffiliateCode { get; set; }
        [XmlElement(ElementName = "CCLink")]
        public string CCLink { get; set; }
        [XmlElement(ElementName = "CCNo")]
        public string CCNo { get; set; }
        [XmlElement(ElementName = "CCType")]
        public string CCType { get; set; }
        [XmlElement(ElementName = "CCExpiryDate")]
        public string CCExpiryDate { get; set; }
        [XmlElement(ElementName = "CardHoldersName")]
        public string CardHoldersName { get; set; }
        [XmlElement(ElementName = "RentalInfo")]
        public List<RentalInfo> RentalInfo { get; set; }
    }


    [XmlRoot(ElementName = "BookByInfo")]
    public class BookByInfo
    {
        public BookByInfo()
        { }
        [XmlElement(ElementName = "LocationId")]
        public string LocationId { get; set; }
        [XmlElement(ElementName = "UniqueID")]
        public string UniqueID { get; set; }
        [XmlElement(ElementName = "BookedBy")]
        public string BookedBy { get; set; }
        [XmlElement(ElementName = "Salutation")]
        public string Salutation { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "Gender")]
        public string Gender { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "Zipcode")]
        public string Zipcode { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Mobile")]
        public string Mobile { get; set; }
        [XmlElement(ElementName = "Fax")]
        public string Fax { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "Source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "IsChannelBooking")]
        public string IsChannelBooking { get; set; }
        [XmlElement(ElementName = "BookingTran")]
        public List<BookingTran> lstBookingTran { get; set; }
    }


    [XmlRoot(ElementName = "Reservation")]
    public class Reservation
    {
        public Reservation()
        { }
        [XmlElement(ElementName = "BookByInfo")]
        public BookByInfo BookByInfo { get; set; }
    }

    [XmlRoot(ElementName = "Reservations")]
    public class Reservations
    {
        public Reservations()
        { }
        [XmlElement(ElementName = "Reservation")]
        public List<Reservation> Reservation { get; set; }

        [XmlElement(ElementName = "CancelReservation")]
        public List<CancelReservation> CancelReservation { get; set; }
    }

    [XmlRoot(ElementName = "Errors")]
    public class Errors
    {
        public Errors()
        { }
        [XmlElement(ElementName = "ErrorCode")]
        public string ErrorCode { get; set; }
        [XmlElement(ElementName = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }

    [XmlRoot(ElementName = "RES_Response")]
    public class RES_Response
    {
        public RES_Response()
        {
            Reservations = new Reservations();
            Errors = new Errors();
        }
        [XmlElement(ElementName = "Reservations")]
        public Reservations Reservations { get; set; }

        [XmlElement(ElementName = "RoomInfo")]
        public RoomInfo RoomInfo { get; set; }

        [XmlElement(ElementName = "Errors")]
        public Errors Errors { get; set; }
    }

    [XmlRoot(ElementName = "CancelReservation")]
    public class CancelReservation
    {
        public CancelReservation()
        { }
        [XmlElement(ElementName = "LocationId")]
        public string LocationId { get; set; }
        [XmlElement(ElementName = "UniqueID")]
        public string UniqueID { get; set; }
        [XmlElement(ElementName = "Remark")]
        public string Remark { get; set; }
        [XmlElement(ElementName = "VoucherNo")]
        public string VoucherNo { get; set; }
    }
}
