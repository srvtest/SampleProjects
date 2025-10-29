using System;
using System.Data;
using System.Collections.Generic;

namespace EntityLayer
{
    public class BookingCls
    {

        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CheckinDate { get; set; }
        public string CheckinTime { get; set; }
        public string CheckoutTime { get; set; }
        public int categoryId { get; set; }
        public string CategoryName { get; set; }
        public int RoomId { get; set; }
        public int RoomNo { get; set; }
        public int BookingSourceId { get; set; }
        public int BookingTypeId { get; set; }
        public string BookingTypeName { get; set; }
        public int Status { get; set; }
        public double RoomCharges { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Adjustment { get; set; }
        public double TotalPay { get; set; }
        public bool bIsActive { get; set; }
        public Int16 IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int Modifyby { get; set; }
        public DateTime ModificationDate { get; set; }
        public string CustomerPhoto { get; set; }
        public List<Documents> CustomerDocument { get; set; }
        public List<Contacts> lstCustomerContacts { get; set; }
        public List<BookingRoomChargesCls> lstBookingRoomChargesCls { get; set; }
        public double AdvanceAmount { get; set; }
        public string OTATranId { get; set; }
        public string ArrivalFrom { get; set; }
        public string DepartureTo { get; set; }
        public double EarlyCheckin { get; set; }
        public double LateCheckout { get; set; }

        public double BasePrice { get; set; }
        public double ExtrabadCharge { get; set; }
        public int RoomPlanid { get; set; }
        public int ExtraBad { get; set; }
        public int Persons { get; set; }

        public double Commission { get; set; }
        public string HBookingId { get; set; }
        public Int16 IsInclusive { get; set; }

        public string BookingGroupDetail { get; set; }

        public int NoOfPersons { get; set; }

        public string ExCheckout { get; set; }
        public string SpecialRequest { get; set; }

        public Int16 PersonCheckIn { get; set; }
        public double OTARoomCharges { get; set; }

        public string VoucherNo { get; set; }
        public double CalcAmount { get; set; }

        public BookingCls()
        { }

        public BookingCls(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                this.Id = Convert.ToInt32(dr["Id"]);

            if (dr.Table.Columns.Contains("BookingDate") && !Convert.IsDBNull(dr["BookingDate"]))
                this.BookingDate = Convert.ToDateTime(dr["BookingDate"]);

            if (dr.Table.Columns.Contains("FromDate") && !Convert.IsDBNull(dr["FromDate"]))
                this.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (dr.Table.Columns.Contains("ToDate") && !Convert.IsDBNull(dr["ToDate"]))
                this.ToDate = Convert.ToDateTime(dr["ToDate"]);

            if (dr.Table.Columns.Contains("CheckinDate") && !Convert.IsDBNull(dr["CheckinDate"]))
                this.CheckinDate = Convert.ToString(dr["CheckinDate"]);

            if (dr.Table.Columns.Contains("CheckinTime") && !Convert.IsDBNull(dr["CheckinTime"]))
                this.CheckinTime = Convert.ToString(dr["CheckinTime"]);

            if (dr.Table.Columns.Contains("CheckoutTime") && !Convert.IsDBNull(dr["CheckoutTime"]))
                this.CheckoutTime = Convert.ToString(dr["CheckoutTime"]);

            if (dr.Table.Columns.Contains("categoryId") && !Convert.IsDBNull(dr["categoryId"]))
                this.categoryId = Convert.ToInt32(dr["categoryId"]);

            if (dr.Table.Columns.Contains("CategoryName") && !Convert.IsDBNull(dr["CategoryName"]))
                this.CategoryName = Convert.ToString(dr["CategoryName"]);

            if (dr.Table.Columns.Contains("RoomId") && !Convert.IsDBNull(dr["RoomId"]))
                this.RoomId = Convert.ToInt32(dr["RoomId"]);

            if (dr.Table.Columns.Contains("RoomNo") && !Convert.IsDBNull(dr["RoomNo"]))
                this.RoomNo = Convert.ToInt32(dr["RoomNo"]);

            if (dr.Table.Columns.Contains("BookingSourceId") && !Convert.IsDBNull(dr["BookingSourceId"]))
                this.BookingSourceId = Convert.ToInt32(dr["BookingSourceId"]);

            if (dr.Table.Columns.Contains("BookingTypeId") && !Convert.IsDBNull(dr["BookingTypeId"]))
                this.BookingTypeId = Convert.ToInt32(dr["BookingTypeId"]);

            if (dr.Table.Columns.Contains("BookingTypeName") && !Convert.IsDBNull(dr["BookingTypeName"]))
                this.BookingTypeName = Convert.ToString(dr["BookingTypeName"]);

            if (dr.Table.Columns.Contains("Status") && !Convert.IsDBNull(dr["Status"]))
                this.Status = Convert.ToInt32(dr["Status"]);

            if (dr.Table.Columns.Contains("RoomCharges") && !Convert.IsDBNull(dr["RoomCharges"]))
                this.RoomCharges = Convert.ToDouble(dr["RoomCharges"]);

            if (dr.Table.Columns.Contains("Discount") && !Convert.IsDBNull(dr["Discount"]))
                this.Discount = Convert.ToDouble(dr["Discount"]);

            if (dr.Table.Columns.Contains("Tax") && !Convert.IsDBNull(dr["Tax"]))
                this.Tax = Convert.ToDouble(dr["Tax"]);

            if (dr.Table.Columns.Contains("Adjustment") && !Convert.IsDBNull(dr["Adjustment"]))
                this.Adjustment = Convert.ToDouble(dr["Adjustment"]);

            if (dr.Table.Columns.Contains("TotalPay") && !Convert.IsDBNull(dr["TotalPay"]))
                this.TotalPay = Convert.ToDouble(dr["TotalPay"]);

            if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
            {
                this.IsActive = Convert.ToInt16(dr["IsActive"]);
                this.bIsActive = (IsActive == 1) ? true : false;
            }

            if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

            if (dr.Table.Columns.Contains("CreationDate") && !Convert.IsDBNull(dr["CreationDate"]))
                this.CreationDate = Convert.ToDateTime(dr["CreationDate"]);

            if (dr.Table.Columns.Contains("Modifyby") && !Convert.IsDBNull(dr["Modifyby"]))
                this.Modifyby = Convert.ToInt32(dr["Modifyby"]);

            if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);


            if (dr.Table.Columns.Contains("OTATranId") && !Convert.IsDBNull(dr["OTATranId"]))
                this.OTATranId = Convert.ToString(dr["OTATranId"]);

            if (dr.Table.Columns.Contains("AdvanceAmount") && !Convert.IsDBNull(dr["AdvanceAmount"]))
                this.AdvanceAmount = Convert.ToDouble(dr["AdvanceAmount"]);

            if (dr.Table.Columns.Contains("ArrivalFrom") && !Convert.IsDBNull(dr["ArrivalFrom"]))
                this.ArrivalFrom = Convert.ToString(dr["ArrivalFrom"]);

            if (dr.Table.Columns.Contains("DepartureTo") && !Convert.IsDBNull(dr["DepartureTo"]))
                this.DepartureTo = Convert.ToString(dr["DepartureTo"]);

            if (dr.Table.Columns.Contains("LateCheckout") && !Convert.IsDBNull(dr["LateCheckout"]))
                this.LateCheckout = Convert.ToDouble(dr["LateCheckout"]);

            if (dr.Table.Columns.Contains("EarlyCheckin") && !Convert.IsDBNull(dr["EarlyCheckin"]))
                this.EarlyCheckin = Convert.ToDouble(dr["EarlyCheckin"]);

            if (dr.Table.Columns.Contains("BasePrice") && !Convert.IsDBNull(dr["BasePrice"]))
                this.BasePrice = Convert.ToDouble(dr["BasePrice"]);

            if (dr.Table.Columns.Contains("ExtrabadCharge") && !Convert.IsDBNull(dr["ExtrabadCharge"]))
                this.ExtrabadCharge = Convert.ToDouble(dr["ExtrabadCharge"]);

            if (dr.Table.Columns.Contains("RoomPlanid") && !Convert.IsDBNull(dr["RoomPlanid"]))
                this.RoomPlanid = Convert.ToInt32(dr["RoomPlanid"]);

            if (dr.Table.Columns.Contains("ExtraBad") && !Convert.IsDBNull(dr["ExtraBad"]))
                this.ExtraBad = Convert.ToInt32(dr["ExtraBad"]);

            if (dr.Table.Columns.Contains("Persons") && !Convert.IsDBNull(dr["Persons"]))
                this.Persons = Convert.ToInt32(dr["Persons"]);

            if (dr.Table.Columns.Contains("Commission") && !Convert.IsDBNull(dr["Commission"]))
                this.Commission = Convert.ToDouble(dr["Commission"]);

            if (dr.Table.Columns.Contains("HBookingId") && !Convert.IsDBNull(dr["HBookingId"]))
                this.HBookingId = Convert.ToString(dr["HBookingId"]);

            if (dr.Table.Columns.Contains("IsInclusive") && !Convert.IsDBNull(dr["IsInclusive"]))
                this.IsInclusive = Convert.ToInt16(dr["IsInclusive"]);

            if (dr.Table.Columns.Contains("NoOfPerson") && !Convert.IsDBNull(dr["NoOfPerson"]))
                this.NoOfPersons = Convert.ToInt16(dr["NoOfPerson"]);

            if (dr.Table.Columns.Contains("BookingGroupDetail") && !Convert.IsDBNull(dr["BookingGroupDetail"]))
                this.BookingGroupDetail = Convert.ToString(dr["BookingGroupDetail"]);

            if (dr.Table.Columns.Contains("ExCheckout") && !Convert.IsDBNull(dr["ExCheckout"]))
                this.ExCheckout = Convert.ToString(dr["ExCheckout"]);

            if (dr.Table.Columns.Contains("SpecialRequest") && !Convert.IsDBNull(dr["SpecialRequest"]))
                this.SpecialRequest= Convert.ToString(dr["SpecialRequest"]);

            if (dr.Table.Columns.Contains("PersonCheckIn") && !Convert.IsDBNull(dr["PersonCheckIn"]))
                this.PersonCheckIn = Convert.ToInt16(dr["PersonCheckIn"]);

            if (dr.Table.Columns.Contains("OTARoomCharges") && !Convert.IsDBNull(dr["OTARoomCharges"]))
                this.OTARoomCharges = Convert.ToDouble(dr["OTARoomCharges"]);

            if (dr.Table.Columns.Contains("VoucherNo") && !Convert.IsDBNull(dr["VoucherNo"]))
                this.VoucherNo = Convert.ToString(dr["VoucherNo"]);

            if (dr.Table.Columns.Contains("CalcAmount") && !Convert.IsDBNull(dr["CalcAmount"]))
                this.CalcAmount = Convert.ToDouble(dr["CalcAmount"]);
        }

        [Serializable]
        public class Documents
        {
            public string Id { get; set; }
            public string DocumentName { get; set; }
            public string DocumentUID { get; set; }
            public string ContactsId { get; set; }
            public string Notes { get; set; }
            public bool bIsActive { get; set; }
            public Int16 IsActive { get; set; }
            public int CreatedBy { get; set; }
            public int Modifyby { get; set; }
            public DateTime ModificationDate { get; set; }
            public Documents()
            {

            }

            public Documents(DataRow dr)
            {
                if (dr.Table.Columns.Contains("id") && !Convert.IsDBNull(dr["id"]))
                    this.Id = Convert.ToString(dr["id"]);

                if (dr.Table.Columns.Contains("CustomerId") && !Convert.IsDBNull(dr["CustomerId"]))
                    this.ContactsId = Convert.ToString(dr["CustomerId"]);

                if (dr.Table.Columns.Contains("documentName") && !Convert.IsDBNull(dr["documentName"]))
                {
                    string[] document = Convert.ToString(dr["documentName"]).Split(new char[] { '_' }, 2);
                    this.DocumentName = document[1];
                    this.DocumentUID = document[0];
                }
                if (dr.Table.Columns.Contains("DocumentFile") && !Convert.IsDBNull(dr["DocumentFile"]))
                {
                    string[] document = Convert.ToString(dr["DocumentFile"]).Split(new char[] { '_' }, 2);
                    this.DocumentName = document[1];
                    this.DocumentUID = document[0];
                }
                if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                {
                    this.IsActive = Convert.ToInt16(dr["IsActive"]);
                    this.bIsActive = (IsActive == 1) ? true : false;
                }
                if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                    this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                if (dr.Table.Columns.Contains("Modifyby") && !Convert.IsDBNull(dr["Modifyby"]))
                    this.Modifyby = Convert.ToInt32(dr["Modifyby"]);

                if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                    this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                if (dr.Table.Columns.Contains("Notes") && !Convert.IsDBNull(dr["Notes"]))
                    this.ContactsId = Convert.ToString(dr["Notes"]);
            }
        }
        [Serializable]
        public class Contacts
        {
            public string ContactId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string EmailId { get; set; }
            public string MobileNo { get; set; }
            public string CustomerPhoto { get; set; }
            public bool bIsActive { get; set; }
            public Int16 IsActive { get; set; }
            public int CreatedBy { get; set; }
            public int Modifyby { get; set; }
            public DateTime ModificationDate { get; set; }
            public string GSTno { get; set; }
            public Contacts()
            {

            }

            public Contacts(DataRow dr)
            {
                if (dr.Table.Columns.Contains("id") && !Convert.IsDBNull(dr["id"]))
                    this.ContactId = Convert.ToString(dr["id"]);

                if (dr.Table.Columns.Contains("FirstName") && !Convert.IsDBNull(dr["FirstName"]))
                    this.FirstName = Convert.ToString(dr["FirstName"]);

                if (dr.Table.Columns.Contains("LastName") && !Convert.IsDBNull(dr["LastName"]))
                    this.LastName = Convert.ToString(dr["LastName"]);

                if (dr.Table.Columns.Contains("Age") && !Convert.IsDBNull(dr["Age"]))
                    this.Age = Convert.ToInt16(dr["Age"]);

                if (dr.Table.Columns.Contains("Gender") && !Convert.IsDBNull(dr["Gender"]))
                    this.Gender = Convert.ToString(dr["Gender"]);

                if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
                    this.EmailId = Convert.ToString(dr["Email"]);

                if (dr.Table.Columns.Contains("Mobile") && !Convert.IsDBNull(dr["Mobile"]))
                    this.MobileNo = Convert.ToString(dr["Mobile"]);

                if (dr.Table.Columns.Contains("Photo") && !Convert.IsDBNull(dr["Photo"]))
                    this.CustomerPhoto = Convert.ToString(dr["Photo"]);

                if (dr.Table.Columns.Contains("IsActive") && !Convert.IsDBNull(dr["IsActive"]))
                {
                    this.IsActive = Convert.ToInt16(dr["IsActive"]);
                    this.bIsActive = (IsActive == 1) ? true : false;
                }
                if (dr.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(dr["CreatedBy"]))
                    this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                if (dr.Table.Columns.Contains("Modifyby") && !Convert.IsDBNull(dr["Modifyby"]))
                    this.Modifyby = Convert.ToInt32(dr["Modifyby"]);

                if (dr.Table.Columns.Contains("ModificationDate") && !Convert.IsDBNull(dr["ModificationDate"]))
                    this.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                if (dr.Table.Columns.Contains("GSTno") && !Convert.IsDBNull(dr["GSTno"]))
                    this.GSTno = Convert.ToString(dr["GSTno"]);
            }
        }
    }
}
