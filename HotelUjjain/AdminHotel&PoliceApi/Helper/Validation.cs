using Entity;
using Microsoft.AspNetCore.Http;

namespace AdminHotel_PoliceApi.Helper
{
    public static class Validation
    {
        public static ValidateResponseDto HotelRegistration(HotelMasterDto hotelDto)
        {
            string errorMessage = ""; int numb = 1;
            if (hotelDto != null)
            {
                if (string.IsNullOrEmpty(hotelDto.HotelName))
                {
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_HOTELNAME);
                }
                if (string.IsNullOrEmpty(hotelDto.Address))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_ADDRESS);
                if (string.IsNullOrEmpty(hotelDto.Contact))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CONTACT);
                if (string.IsNullOrEmpty(hotelDto.ContactPerson))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CONTACTPERSON);
                if (string.IsNullOrEmpty(hotelDto.EmailAddress))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_EmailAddress);
                if (hotelDto.idState < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_STATE);
                if (hotelDto.idCity < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CITY);
                if (hotelDto.idDistrict < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_DISTRICT);
                if (hotelDto.PropertyType < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_PROPERTYTYPE);
                if (string.IsNullOrEmpty(hotelDto.FileGumasta))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_FILEGUMASTA);
                if (string.IsNullOrEmpty(hotelDto.FileAdhar))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_FILEADHAR);
                if (string.IsNullOrEmpty(hotelDto.FileAdharBack))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_FILEADHARBACK);
                if (string.IsNullOrEmpty(hotelDto.ContactPersonMobile))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CONTACTPERSONMOBILE);
                if (hotelDto.idPoliceStation < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_POLICESTATION);
                if (hotelDto.NoOfRoom <= 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_NOOFROOM);


                if (!string.IsNullOrEmpty(errorMessage))
                    return new ValidateResponseDto { StatusCode = -1, Message = errorMessage };
                else
                    return new ValidateResponseDto { StatusCode = 1, Message = "" };
            }
            return default;
        }

        public static ValidateResponseDto InsertCategory(HotelCategoryDto hotelDto)
        {
            string errorMessage = ""; int numb = 1;
            if (hotelDto != null)
            {
                if (hotelDto.idHotel < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IDHOTEL );
                if (string.IsNullOrEmpty(hotelDto.CategoryName))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CATEGORYNAME );
                if (hotelDto.iPrice < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IPRICE );

                if (!string.IsNullOrEmpty(errorMessage))
                    return new ValidateResponseDto { StatusCode = -1, Message = errorMessage };
                else
                    return new ValidateResponseDto { StatusCode = 1, Message = "" };
            }
            return default;
        }
        public static ValidateResponseDto InsertUpdateDeleteGuestMaster(GuestMasterDto guestMasterDto)
        {
            string errorMessage = ""; int numb = 1;
            if (guestMasterDto != null)
            {
                if (guestMasterDto.idHotel < 0)
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IDHOTEL );
                if (string.IsNullOrEmpty(guestMasterDto.GuestName))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_GUESTNAME );
                //if (string.IsNullOrEmpty(guestMasterDto.Address))
                //    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_GUESTADDRESS );
                if (string.IsNullOrEmpty(guestMasterDto.ContactNo))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_GUESTCONTACTNUMBER );
                if (string.IsNullOrEmpty(guestMasterDto.IdentificationNo))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IDENTIFICATIONNO );
                if (string.IsNullOrEmpty(guestMasterDto.IdentificationType))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IDENTIFICATIONTYPE );
                if (string.IsNullOrEmpty(guestMasterDto.CheckInDate))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CHECKINDATE );
                if (string.IsNullOrEmpty(guestMasterDto.CheckOutDate))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CHECKOUTDATE );
                //if (string.IsNullOrEmpty(guestMasterDto.Description))
                //    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_DESCRIPTION };
                // GuestXml //
                //if (string.IsNullOrEmpty(guestMasterDto.GuestLastName))
                //    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_GUESTLASTNAME );
                if (string.IsNullOrEmpty(guestMasterDto.gender))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_GENDER );
                if (string.IsNullOrEmpty(guestMasterDto.TravelReson))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_TRAVELRESON );
                if (string.IsNullOrEmpty(guestMasterDto.city))
                    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_CITY );
                //if (string.IsNullOrEmpty(guestMasterDto.PIncode))
                //    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_PINCODE );
                //if (string.IsNullOrEmpty(guestMasterDto.Image1))
                //    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IMAGE1 };
                //if (string.IsNullOrEmpty(guestMasterDto.Image2))
                //    errorMessage = string.Concat(errorMessage, errorMessage == "" ? "" : Environment.NewLine, (numb++ + ". "), StringMessage.VALID_IMAGE2 };
                // CategoriesXml //
                if (!string.IsNullOrEmpty(errorMessage))
                    return new ValidateResponseDto { StatusCode = -1, Message = errorMessage };
                else
                    return new ValidateResponseDto { StatusCode = 1, Message = "" };
            }
            return default;
        }
    }
}
