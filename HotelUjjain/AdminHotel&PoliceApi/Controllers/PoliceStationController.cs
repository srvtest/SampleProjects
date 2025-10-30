using DataLayer;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminHotel_PoliceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceStationController : ControllerBase
    {
        #region Variable Declaration
        public readonly IConfiguration _Configuration;
        ResponseDto response;
        //GuestMasterApiDL objuserDL = new GuestMasterApiDL();
        //HotelMasterApiDL objHotelDL = new HotelMasterApiDL();
        //SurveillanceApiDL surveillanceDL = new SurveillanceApiDL();
        #endregion
        #region Constructor Declarations
        public PoliceStationController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
        #endregion
        //[HttpGet("PoliceLogin")]
        //public string PoliceLogin(string Username, string password)
        //{
        //    if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(password))
        //    {
        //        LoginApiDL objLoginDL = new LoginApiDL();
        //        UserDto userDto = new UserDto();
        //        userDto.Username = Username;
        //        userDto.password = password;
        //        response = objLoginDL.ValidateUserLogin("", userDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetHotelByPoliceStationId")]
        //public string GetHotelByPoliceStationId(string UserId)
        //{
        //    if (!string.IsNullOrEmpty(UserId))
        //    {
        //        response = objHotelDL.GetHotelByPoliceStationId("", Convert.ToInt32(UserId));
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpPost("GetNotSubmitGuestDetailByPoliceStationId")]
        //public string GetNotSubmitGuestDetailByPoliceStationId(GuestFilterDto guestFilterDto)
        //{
        //    if (guestFilterDto != null)
        //    {
        //        response = objuserDL.GetNotSubmitGuestDetailByPoliceStationId("", guestFilterDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetHotelGuestDetailByPoliceStationId")]
        //public string GetHotelGuestDetailByPoliceStationId(string UserId, string sMonth, string sYear, string idHotel)
        //{
        //    if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(sMonth) && !string.IsNullOrEmpty(sYear) && !string.IsNullOrEmpty(idHotel))
        //    {
        //        GuestFilterDto guestFilterDto = new GuestFilterDto();
        //        guestFilterDto.idUser = Convert.ToInt32(UserId);
        //        guestFilterDto.sMonth = Convert.ToInt32(sMonth);
        //        guestFilterDto.sYear = Convert.ToInt32(sYear);
        //        guestFilterDto.idHotel = Convert.ToInt32(idHotel);
        //        response = objuserDL.GetHotelGuestDetailByPoliceStationId("", guestFilterDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetGuestMasterById")]
        //public string GetGuestMasterById(string idGuestMaster)
        //{
        //    if (!string.IsNullOrEmpty(idGuestMaster))
        //    {
        //        response = objuserDL.GetGuestMasterById("", Convert.ToInt32(idGuestMaster));
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetGuestDetailByPoliceStationId")]
        //public string GetGuestDetailByPoliceStationId(string UserId, string FilterFromDate, string FilterToDate, string idHotel)
        //{
        //    if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(FilterFromDate) && !string.IsNullOrEmpty(FilterToDate) && !string.IsNullOrEmpty(idHotel))
        //    {
        //        GuestFilterDto guestFilterDto = new GuestFilterDto();
        //        guestFilterDto.idUser = Convert.ToInt32(UserId);
        //        guestFilterDto.FilterFromDate = FilterFromDate;
        //        guestFilterDto.FilterToDate = FilterToDate;
        //        guestFilterDto.idHotel = Convert.ToInt32(idHotel);
        //        response = objuserDL.GetGuestDetailByPoliceStationId("", guestFilterDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetSubmitedGuestByHotelId")]
        //public string GetSubmitedGuestByHotelId(string UserId, string submitDate)
        //{
        //    if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(submitDate))
        //    {
        //        GuestFilterDto guestFilterDto = new GuestFilterDto();
        //        guestFilterDto.idUser = Convert.ToInt32(UserId);
        //        guestFilterDto.FilterFromDate = submitDate;
        //        guestFilterDto.FilterToDate = submitDate;
        //        response = objuserDL.GetSubmitedGuestByHotelId("", guestFilterDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetGuestDetailSearchByPoliceStationId")]
        //public string GetGuestDetailSearchByPoliceStationId(string UserId, string FilterName, string FilterAdhar, string FilterContact)
        //{
        //    if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(FilterName) && !string.IsNullOrEmpty(FilterAdhar) && !string.IsNullOrEmpty(FilterContact))
        //    {
        //        GuestFilterDto guestFilterDto = new GuestFilterDto();
        //        guestFilterDto.idUser = Convert.ToInt32(UserId);
        //        guestFilterDto.FilterName = FilterName;
        //        guestFilterDto.FilterAdhar = FilterAdhar;
        //        guestFilterDto.FilterContact = FilterContact;
        //        response = objuserDL.GetGuestDetailSearchByPoliceStationId("", guestFilterDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetSurveillance")]
        //public string GetSurveillance(string UserId)
        //{
        //    if (!string.IsNullOrEmpty(UserId))
        //    {
        //        response = surveillanceDL.GetSurveillance("", Convert.ToInt32(UserId));
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("InsertUpdateForSurveillance")]
        //public string InsertUpdateForSurveillance(string UserId,string SurveillanceNo)
        //{
        //    if (!string.IsNullOrEmpty(UserId)&& !string.IsNullOrEmpty(SurveillanceNo))
        //    {
        //        SurveillanceDto surveillanceDto = new SurveillanceDto();
        //        surveillanceDto.surveillanceDetail = SurveillanceNo;
        //        surveillanceDto.idUser = Convert.ToInt32(UserId);
        //        response = surveillanceDL.InsertUpdateForSurveillance("", surveillanceDto);
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}

        //[HttpGet("GetsurveillanceById")]
        //public string GetsurveillanceById(string idsurveillance)
        //{
        //    if (!string.IsNullOrEmpty(idsurveillance))
        //    {
        //        response = objuserDL.GetGuestMasterById("", Convert.ToInt32(idsurveillance));
        //        if (response != null)
        //        {
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}
    }
}
