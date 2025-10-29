using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Data;

namespace EntityLayer
{
    [XmlRoot(ElementName = "Authentication")]
    public class Authentication
    {
        [XmlElement(ElementName = "HotelCode")]
        public string HotelCode { get; set; }
        [XmlElement(ElementName = "AuthCode")]
        public string AuthCode { get; set; }
        public Authentication()
        { }
        public Authentication(DataRow dr)
        {
            if (dr.Table.Columns.Contains("HotelCode") && !Convert.IsDBNull(dr["HotelCode"]))
                this.HotelCode = Convert.ToString(dr["HotelCode"]);

            if (dr.Table.Columns.Contains("AuthCode") && !Convert.IsDBNull(dr["AuthCode"]))
                this.AuthCode = Convert.ToString(dr["AuthCode"]);
        }
    }

    [XmlRoot(ElementName = "Bookings")]
    public class Bookings
    {
        [XmlElement(ElementName = "Booking")]
        public List<Booking> Booking { get; set; }
        public Bookings(){}
    }

    [XmlRoot(ElementName = "Booking")]
    public class Booking
    {
        [XmlElement(ElementName = "BookingId")]
        public string BookingId { get; set; }
        [XmlElement(ElementName = "PMS_BookingId")]
        public string PMS_BookingId { get; set; }
        [XmlElement(ElementName = "SubBookingId")]
        public string SubBookingId { get; set; }

        public Booking()
        { }
        public Booking(DataRow dr)
        {
            if (dr.Table.Columns.Contains("BookingId") && !Convert.IsDBNull(dr["BookingId"]))
                this.BookingId = Convert.ToString(dr["BookingId"]);

            if (dr.Table.Columns.Contains("PMS_BookingId") && !Convert.IsDBNull(dr["PMS_BookingId"]))
                this.PMS_BookingId = Convert.ToString(dr["PMS_BookingId"]);

            if (dr.Table.Columns.Contains("SubBookingId") && !Convert.IsDBNull(dr["SubBookingId"]))
                this.PMS_BookingId = Convert.ToString(dr["SubBookingId"]);
        }
    }

    [XmlRoot(ElementName = "RES_Request")]
    public class RES_Request
    {
        [XmlElement(ElementName = "Request_Type")]
        public string Request_Type { get; set; }
        [XmlElement(ElementName = "Authentication")]
        public Authentication Authentication { get; set; }
        [XmlElement(ElementName = "RoomType")]
        public List<RoomType> RoomType { get; set; }
        [XmlElement(ElementName = "RateType")]
        public RateType RateType { get; set; }

        public Bookings Bookings { get; set; }

        public RES_Request()
        {
            Authentication = new EntityLayer.Authentication();
            RoomType = new List<EntityLayer.RoomType>();
            RateType = new RateType();
            Bookings = new Bookings();
        }
        public RES_Request(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Request_Type") && !Convert.IsDBNull(dr["Request_Type"]))
                this.Request_Type = Convert.ToString(dr["Request_Type"]);
        }
    }

    [XmlRoot(ElementName = "RoomType")]
    public class RoomType
    {
        [XmlElement(ElementName = "RoomTypeID")]
        public string RoomTypeID { get; set; }
        [XmlElement(ElementName = "FromDate")]
        public string FromDate { get; set; }
        [XmlElement(ElementName = "ToDate")]
        public string ToDate { get; set; }
        [XmlElement(ElementName = "Availability")]
        public string Availability { get; set; }
        public RoomType()
        { }
        public RoomType(DataRow dr)
        {
            if (dr.Table.Columns.Contains("RoomTypeID") && !Convert.IsDBNull(dr["RoomTypeID"]))
                this.RoomTypeID = Convert.ToString(dr["RoomTypeID"]);
            if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                this.FromDate = Convert.ToString(dr["FromDate"]);
            if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                this.ToDate = Convert.ToString(dr["ToDate"]);
            if (dr.Table.Columns.Contains("Availability") && !Convert.IsDBNull(dr["Availability"]))
                this.Availability = Convert.ToString(dr["Availability"]);

        }
    }

    [XmlRoot(ElementName = "RoomRate")]
    public class RoomRate
    {
        [XmlElement(ElementName = "Base")]
        public string Base { get; set; }
        [XmlElement(ElementName = "ExtraAdult")]
        public string ExtraAdult { get; set; }
        [XmlElement(ElementName = "ExtraChild")]
        public string ExtraChild { get; set; }
        public RoomRate()
        { }
        public RoomRate(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Base") && !Convert.IsDBNull(dr["Base"]))
                this.Base = Convert.ToString(dr["Base"]);
            if (dr.Table.Columns.Contains("ExtraAdult") && !Convert.IsDBNull(dr["ExtraAdult"]))
                this.ExtraAdult = Convert.ToString(dr["ExtraAdult"]);
            if (dr.Table.Columns.Contains("ExtraChild") && !Convert.IsDBNull(dr["ExtraChild"]))
                this.ExtraChild = Convert.ToString(dr["ExtraChild"]);
        }
    }

    [XmlRoot(ElementName = "RateType")]
    public class RateType
    {
        [XmlElement(ElementName = "RoomTypeID")]
        public string RoomTypeID { get; set; }
        [XmlElement(ElementName = "RateTypeID")]
        public string RateTypeID { get; set; }
        [XmlElement(ElementName = "FromDate")]
        public string FromDate { get; set; }
        [XmlElement(ElementName = "ToDate")]
        public string ToDate { get; set; }
        [XmlElement(ElementName = "RoomRate")]
        public RoomRate RoomRate { get; set; }
        public RateType()
        { }
        public RateType(DataRow dr)
        {
            if (dr.Table.Columns.Contains("RoomTypeID") && !Convert.IsDBNull(dr["RoomTypeID"]))
                this.RoomTypeID = Convert.ToString(dr["RoomTypeID"]);

            if (dr.Table.Columns.Contains("RateTypeID") && !Convert.IsDBNull(dr["RateTypeID"]))
                this.RateTypeID = Convert.ToString(dr["RateTypeID"]);

            if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                this.FromDate = Convert.ToString(dr["FromDate"]);

            if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                this.ToDate = Convert.ToString(dr["ToDate"]);


        }
    }

}

