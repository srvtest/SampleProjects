using AdminHotel_PoliceApi.Helper;
using DataLayer;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AdminHotel_PoliceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelGuestController : ControllerBase
    {
        #region Variable Declaration
        private int idUsr
        {
            get
            {
                int id = 0;
                //try
                //{
                //    id = HttpContext.Current.ApplicationInstance.Session.Count > 0 ? Convert.ToInt32(HttpContext.Current.ApplicationInstance.Session["UserId"]) : 0;
                //}
                //catch (Exception)
                //{
                //}
                return id;
            }

        }
        private int NoOfRoom
        {
            get
            {

                return NoOfRoom;
            }
            set
            {
                NoOfRoom = value;
            }
        }

        private static string _EncryptionKey;
        public static string EncryptionKey
        {
            get
            {
                if (_EncryptionKey == null || _EncryptionKey == string.Empty)
                {
                    _EncryptionKey = "H0t3l!Gu35t";
                }
                return _EncryptionKey;
            }
        }
        public readonly IConfiguration _Configuration;
        ResponseDto response;
        GuestMasterDL objuserDL = new GuestMasterDL();
        private readonly AppSettings _appSettings;
        List<HotelCategoryDto> hotelCategoryDtos = new List<HotelCategoryDto>();
        List<GuestMasterDto> userDto = new List<GuestMasterDto>();
        private readonly IMemoryCache _memoryCache;
        public bool PassValue;
        public int idHotelMaster
        {
            get
            {
                var authorizationHeader = HttpContext.Request.Headers["Authorization"];
                string accessToken = string.Empty;
                if (authorizationHeader.ToString().StartsWith("Bearer"))
                {
                    accessToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();
                }
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
                string id = jwt.Claims.First(c => c.Type == "idHotelMaster").Value;
                return Convert.ToInt32(id);
            }

        }
        HotelMasterDto userDto1 = new HotelMasterDto();
        #endregion
        #region Constructor Declarations
        public HotelGuestController(IConfiguration Configuration, IOptions<AppSettings> appSettings, IMemoryCache memoryCache)
        {
            _Configuration = Configuration;
            _appSettings = appSettings.Value;
            _memoryCache = memoryCache;
        }
        #endregion
        [AllowAnonymous]
        [HttpPost("SendOTPValidateMobileNo")]
        [SwaggerOperation(Summary = "Send OTP validate mobile number for new hotel registration.")]
        public async Task<string> SendOTPValidateMobileNo(string sMobile)
        {
            if (!string.IsNullOrEmpty(sMobile))
            {
                Random generator = new Random();
                string MobileOTP = Convert.ToString(generator.Next(100000, 1000000));
                var aa = _Configuration["test"];
                if (aa == "1")
                {
                    MobileOTP = "123456";
                }
                int idHotel = 0;
                string sPropertyType = string.Empty;
                hotelCategoryDtos = null;
                HotelMasterDL objLoginDL = new HotelMasterDL();
                response = objLoginDL.ValidateMobileNo(sMobile, out idHotel, out sPropertyType, _Configuration.GetConnectionString("DefaultConnection"), MobileOTP);
                if (response != null)
                {
                    if (response.StatusCode == 0 || response.StatusCode == 1)
                    {
                        if (aa != "1")
                        {
                            string sSms = "Hello, Your OTP to Login is " + MobileOTP + " Thanks Fanatical Technologies";
                            UtilityFunction.SendSMS(sSms, sMobile, _Configuration["TemplateIdOTP"]);
                        }
                        if (response.StatusCode == 1)
                        {
                            hotelCategoryDtos = (List<HotelCategoryDto>)response.Result;
                            // BindCategory();
                        }
                        return JsonConvert.SerializeObject(response);
                    }
                    else
                    {
                        response.Message = "यह मोबाइल नंबर पहले से पंजीकृत है। कृपया पंजीकरण के लिए नया नंबर उपयोग करे , या आप लॉगिन पेज पर जाकर इस नंबर से लॉगिन कर सकते हैं। होटल लॉगिन लिंक - ";
                        return JsonConvert.SerializeObject(response);
                    }
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया मोबाइल नंबर दर्ज करे");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [AllowAnonymous]
        [HttpPost("ValidateSignUpMobileOTP")]
        [SwaggerOperation(Summary = "Validate signUp mobile OTP for new hotel registration.")]
        //[Route("HotelLogin")]
        public string ValidateSignUpMobileOTP(string sMobile, string Otp)
        {
            if (!string.IsNullOrEmpty(sMobile) && !string.IsNullOrEmpty(Otp))
            {
                LoginDL objLoginDL = new LoginDL();
                response = objLoginDL.ValidateSignUpOTP(sMobile, Otp, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    //HotelMasterDto userDto1 = (HotelMasterDto)response.Result;
                    //ResponseDto response1 = objLoginDL.ValidateSubcription(userDto1.idHotelMaster, _Configuration.GetConnectionString("DefaultConnection"));
                    //if (response1 != null)
                    //{
                    //    TokenExpireForSubcriptionDto dto = (TokenExpireForSubcriptionDto)response1.Result;
                    //    var token = generateJwtToken(userDto1, dto.ValidExpire);
                    //    userDto1.Token = token;
                    //}

                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpPost("HotelSignUp")]
        [SwaggerOperation(Summary = "Hotel Registration")]
        public string HotelRegistration(HotelMasterDto hotelDto)
        {
            if (hotelDto != null)
            {
                string sFruntFileName = "";
                string sBackFileName = "";
                string sBackAdharFileName = "";
                string sFPassword = "";

                var validation = Validation.HotelRegistration(hotelDto);
                if (validation != null && validation.StatusCode < 0)
                    return JsonConvert.SerializeObject(validation);

                if (string.IsNullOrEmpty(hotelDto.filePass))
                {
                    sFPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
                }
                if (hotelDto.FileGumasta != "")
                {
                    sFruntFileName = UploadImageToFolder(hotelDto.FileGumasta, sFPassword);
                }
                if (hotelDto.FileAdhar != "")
                {
                    sBackFileName = UploadImageToFolder(hotelDto.FileAdhar, sFPassword);
                }
                if (hotelDto.FileAdharBack != "")
                {
                    sBackAdharFileName = UploadImageToFolder(hotelDto.FileAdharBack, sFPassword);
                }
                hotelDto.FileGumasta = sFruntFileName;
                hotelDto.FileAdhar = sBackFileName;
                hotelDto.FileAdharBack = sBackAdharFileName;
                hotelDto.filePass = sFPassword;
                //hotelDto.ValidUpto = DateTime.Now.AddDays(2);
                //NoOfRoom = hotelDto.NoOfRoom;
                HotelMasterDL objHotelDL = new HotelMasterDL();
                response = objHotelDL.InsertUpdateDeleteHotel(hotelDto, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpPost("InsertCategory")]
        [SwaggerOperation(Summary = "Insert room category for hotel.")]
        public string InsertCategory(HotelCategoryDto hotelDto)
        {
            if (hotelDto != null)
            {
                //hotelDto = new List<HotelCategoryDto>();
                //foreach (var item in hotelDto)
                //{
                //    item.idHotel = idHotelMaster;
                //}
                var validation = Validation.InsertCategory(hotelDto);
                if (validation != null && validation.StatusCode < 0)
                    return JsonConvert.SerializeObject(validation);

                HotelMasterDL objHotelDL = new HotelMasterDL();
                response = objHotelDL.InsertUpdateHotelCategory(hotelDto, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpPost("Free7DaysTrail")]
        [SwaggerOperation(Summary = "Free 7 days trail for hotel.")]
        public string Free7DaysTrail(int HotelId)
        {
            if (HotelId > 0)
            {
                //HotelId = idHotelMaster;
                //hotelDto = new List<HotelCategoryDto>();
                HotelMasterDL objHotelDL = new HotelMasterDL();
                response = objHotelDL.UpdateHotelValidUptoById(HotelId, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया अपनी होटल चुने।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [AllowAnonymous]
        [HttpPost("GetHotelDetails")]
        [SwaggerOperation(Summary = "Get hotel details")]
        public string GetHotelDetails(int HotelId)
        {
            if (HotelId > 0)
            {
                //HotelId = idHotelMaster;
                SubcriptionDetails objSub = new SubcriptionDetails();
                HotelMasterDL objuserDL = new HotelMasterDL();
                ResponseDto response = objuserDL.GetHotelById(HotelId, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया होटल चुने।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [AllowAnonymous]
        [HttpPost("GetSubcriptionDetails")]
        [SwaggerOperation(Summary = "Get subcription details for hotel.")]
        public string GetSubcriptionDetails(int HotelId)
        {
            if (HotelId > 0)
            {
                //HotelId = idHotelMaster;
                SubcriptionDetails objSub = new SubcriptionDetails();
                HotelMasterDL objuserDL = new HotelMasterDL();
                ResponseDto response = objuserDL.GetHotelById(HotelId, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    HotelMasterDto hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                        if (hotelDto.NoOfRoom <= 10)
                        {
                            response.StatusCode = 0;
                            objSub.Price = _Configuration["propertyHotel2500Value"];
                            objSub.Url = _Configuration["propertyHotel2500"];
                            response.Result = objSub;
                        }
                        else if (hotelDto.NoOfRoom <= 35)
                        {
                            response.StatusCode = 1;
                            objSub.Price = _Configuration["propertyHotel3500Value"];
                            objSub.Url = _Configuration["propertyHotel3500"];
                            response.Result = objSub;
                        }
                        else
                        {
                            response.StatusCode = 2;
                            objSub.Price = _Configuration["propertyHotel5500Value"];
                            objSub.Url = _Configuration["propertyHotel5500"];
                            response.Result = objSub;
                        }
                        return JsonConvert.SerializeObject(response);
                    }
                }
                ResponseDto errorResponse = new ResponseDto(1, null, "इस होटल के विरुद्ध कोई रिकॉर्ड नहीं मिला।");
                return JsonConvert.SerializeObject(errorResponse);
            }
            ResponseDto errorResponse1 = new ResponseDto(-1, null, "कृपया होटल चुने।");
            return JsonConvert.SerializeObject(errorResponse1);
        }
        [AllowAnonymous]
        [HttpPost("SendOTPLogin")]
        [SwaggerOperation(Summary = "Send OTP login for registered hotel.")]
        public async Task<string> SendOTP(string sMobile)
        {
            if (!string.IsNullOrEmpty(sMobile))
            {
                Random generator = new Random();
                string MobileOTP = Convert.ToString(generator.Next(100000, 1000000));
                var aa = _Configuration["test"];
                if (aa == "1")
                {
                    MobileOTP = "123456";
                }
                LoginDL objLoginDL = new LoginDL();
                response = objLoginDL.SetOTP(sMobile, MobileOTP, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    if (response.StatusCode == 0)
                    {
                        string sSms = "Hello, Your OTP to Login is " + MobileOTP + " Thanks Fanatical Technologies";
                        UtilityFunction.SendSMS(sSms, sMobile, _Configuration["TemplateIdOTP"]);
                        return JsonConvert.SerializeObject(response);
                    }
                    else
                    {
                        if (response.StatusCode == 1)
                        {
                            response.Message = "आपका सब्सक्रिप्शन प्लान समाप्त हो गया है। कृपया नीचे दिए गए लिंक पर जाकर अपना प्लान सक्रिय करें।";
                        }
                        return JsonConvert.SerializeObject(response);
                    }
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया पंजीकृत मोबाइल नंबर डाले।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [AllowAnonymous]
        [HttpPost("HotelLogin")]
        [SwaggerOperation(Summary = "Hotel login for registered hotel.")]
        public string HotelLogin(string sMobile, string Otp)
        {
            if (!string.IsNullOrEmpty(sMobile) && !string.IsNullOrEmpty(Otp))
            {
                LoginDL objLoginDL = new LoginDL();
                response = objLoginDL.ValidateHotelLogin(sMobile, Otp, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    userDto1 = (HotelMasterDto)response.Result;
                    ResponseDto response1 = objLoginDL.ValidateSubcription(userDto1.idHotelMaster, _Configuration.GetConnectionString("DefaultConnection"));
                    if (response1 != null)
                    {
                        TokenExpireForSubcriptionDto dto = (TokenExpireForSubcriptionDto)response1.Result;
                        var token = generateJwtToken(userDto1, dto.ValidExpire);
                        userDto1.Token = token;
                    }
                    string tmpimagePath = _Configuration["imagePath"];
                    //string strFolderTemp;
                    //strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
                    foreach (var file in Directory.GetFiles(tmpimagePath.ToString()))
                    {
                        System.IO.File.Delete(file);
                    }
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, string.IsNullOrEmpty(sMobile) ? "कृपया पंजीकृत मोबाइल नंबर डाले।" : "कृपया प्रताप ओटीपी संख्या डाले।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [HttpPost("ValidateSubcription")]
        [SwaggerOperation(Summary = "Validate subcription for registered hotel.")]
        public string ValidateSubcription(int HotelId)
        {
            if (HotelId > 0)
            {
                LoginDL objLoginDL = new LoginDL();
                HotelId = idHotelMaster;
                response = objLoginDL.ValidateSubcription(HotelId, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    //HotelMasterDto userDto1 = (HotelMasterDto)response.Result;

                    //var token = generateJwtToken(userDto1);
                    //userDto1.Token = token;
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया होटल चुने।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [HttpPost("InsertUpdateDeleteGuestMaster")]
        [SwaggerOperation(Summary = "Insert update and delete guest for registered hotel.")]
        public string InsertUpdateDeleteGuestMaster(GuestMasterDto guestMasterDto)
        {
            if (guestMasterDto != null)
            {
                guestMasterDto.idHotel = idHotelMaster;
                guestMasterDto.ContactNoTemp = guestMasterDto.ContactNo;
                guestMasterDto.IdentificationNoTemp = guestMasterDto.IdentificationNo;
                string sFruntFileName = "";
                string sBackFileName = "";
                string sFPassword = "";

                var validation = Validation.InsertUpdateDeleteGuestMaster(guestMasterDto);
                if (validation != null && validation.StatusCode < 0)
                    return JsonConvert.SerializeObject(validation);

                if (string.IsNullOrEmpty(guestMasterDto.filePass))
                {
                    sFPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
                }
                else
                {
                    sFPassword = guestMasterDto.filePass;
                }

                if (guestMasterDto.Image1 != "")
                {
                    sFruntFileName = UploadImageToFolder(guestMasterDto.Image1, sFPassword);
                }
                if (guestMasterDto.Image2 != "")
                {
                    sBackFileName = UploadImageToFolder(guestMasterDto.Image2, sFPassword);
                }
                guestMasterDto.Image1 = sFruntFileName;
                guestMasterDto.Image2 = sBackFileName;
                guestMasterDto.filePass = sFPassword;

                foreach (var item in guestMasterDto.Details)
                {
                    //item.sName = "With " + guestMasterDto.GuestName;
                    item.sName = item.sName;
                    item.ContactNo = guestMasterDto.ContactNo;
                    item.ContactNoTemp = item.ContactNo;
                    item.IdentificationNoTemp = item.IdentificationNo;
                    string sFruntFileNameDetail = "";
                    string sBackFileNameDetail = "";
                    string sFPasswordDetail = "";

                    if (string.IsNullOrEmpty(item.filePass))
                    {
                        sFPasswordDetail = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
                    }
                    else
                    {
                        sFPasswordDetail = item.filePass;
                    }

                    if (item.Image != "")
                    {
                        sFruntFileNameDetail = UploadImageToFolder(item.Image, sFPasswordDetail);
                    }
                    if (item.Image2 != "")
                    {
                        sBackFileNameDetail = UploadImageToFolder(item.Image2, sFPasswordDetail);
                    }
                    item.Image = sFruntFileNameDetail;
                    item.Image2 = sBackFileNameDetail;
                    item.filePass = sFPasswordDetail;
                }
                // guestMasterDto.Categories = new List<HotelCategoryDto>();
                string sCategory = "", sPrice = "";
                foreach (HotelCategoryDto item in guestMasterDto.Categories)
                {
                    if (item.bChecked)
                    {
                        sCategory += (string.IsNullOrEmpty(sCategory) ? "" : " And ") + item.CategoryName;
                        sPrice += (string.IsNullOrEmpty(sPrice) ? "" : " And ") + item.iPrice;
                        //guestMasterDto.Categories.Add(new HotelCategoryDto { idHotelRoomCategory = Convert.ToInt32(hdnidHotelRoomCategory.Value), idHotel = snsHotelId, iPrice = Convert.ToInt32(hdniPrice.Value) });
                    }
                }
                response = objuserDL.InsertUpdateDeleteGuestMaster(guestMasterDto, PassValue, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    string sSMS = "Dear Guest, For Your stay in " + userDto1.HotelName + " Room Category: " + (string.IsNullOrEmpty(sCategory) ? "NA" : sCategory) + " Approved Rate is: " + (string.IsNullOrEmpty(sPrice) ? "NA" : sPrice) + " For any issue during your stay Please contact on below number " + userDto1.policeContact + " Thanks, Fanatical Technologies";
                    if (response.StatusCode == 0)
                    {
                        UtilityFunction.SendSMS(sSMS, guestMasterDto.ContactNoTemp, _Configuration["TemplateIdGuestSMS"]);
                    }
                    else if (response.StatusCode == 1)
                    {
                        UtilityFunction.SendSMS(sSMS, guestMasterDto.ContactNoTemp, _Configuration["TemplateIdGuestSMS"]);
                        ResponseDto response1 = objuserDL.GetPoliceStationNoBySurveillanceNo(guestMasterDto.ContactNo);
                        if (response1 != null)
                        {
                            List<GuestMasterDto> userDto2 = (List<GuestMasterDto>)response1.Result;
                            if (userDto != null)
                            {
                                string policeSMS = "Namaskar Aapne Jo detail monitoring ke liye portal pe Dali thi Us ki Entry abhi Hotel me hui hai. Adhik Jankari ke liye aap samprk kare " + userDto1.Contact + " Team Fanatical Technologies";
                                UtilityFunction.SendSMS(policeSMS, userDto2[0].PoliceStationNo, _Configuration["TemplateIdPoliceAlert"]);
                            }
                        }
                    }
                    else if (response.StatusCode == -1 || response.StatusCode == -2 || response.StatusCode == -3)
                    {

                    }
                    response.Message = response.Message.Replace("</br>", "");
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost("ValidateDateForAddGuest")]
        [SwaggerOperation(Summary = "Validate date for add guest for registered hotel.")]
        public string ValidateDateForAddGuest(string HotelId, string SubmitDate)
        {
            if (!string.IsNullOrEmpty(HotelId) && !string.IsNullOrEmpty(SubmitDate))
            {
                if (string.IsNullOrEmpty(HotelId))
                    HotelId = Convert.ToString(idHotelMaster);
                response = objuserDL.ValidateSubmitDate(Convert.ToInt32(HotelId), Convert.ToDateTime(SubmitDate), _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    int count = (int)response.Result;
                    if (count == 0)
                    {
                        response.StatusCode = 0;
                        response.Message = "आपने पहले ही तारीख " + Convert.ToDateTime(SubmitDate).ToString("dd-MMMM-yyyy") + " के लिए गेस्ट  की चेक इन एंट्री कर ली है , इसलिए यह विकल्प आपके लिए निष्क्रिय है। यहां से आप केवल तभी रिपोर्ट सबमिट कर सकते हैं यदि आपके होटल में 0 चेक इन हैं।";
                        //response.Message = "तारीख " + Convert.ToDateTime(SubmitDate).ToString("dd-MMMM-yyyy") + " की रिपोर्ट सबमिट नहीं हुई है।";
                    }
                    else
                    {
                        response.StatusCode = 1;
                        response.Message = "तारीख " + Convert.ToDateTime(SubmitDate).ToString("dd-MMMM-yyyy") + " की रिपोर्ट सबमिट हो चुकी है।";
                    }
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया सबमिट तारीख चुने।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [HttpPost("GuestDetails")]
        [SwaggerOperation(Summary = "Guest details for registered hotel.")]
        public string GuestDetails(string idGuestMaster)
        {
            if (!string.IsNullOrEmpty(idGuestMaster))
            {
                response = objuserDL.GetGuestCompleteDetailByGuestId(idGuestMaster, PassValue, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    userDto = (List<GuestMasterDto>)response.Result;
                    if (userDto != null)
                    {                                             
                        if (userDto[0].Details != null && userDto[0].Details.Count > 0)
                        {
                            foreach (var item in userDto[0].Details)
                            {
                                item.ContactNo = item.ContactNo.Decrypt(EncryptionKey, true);
                                item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);                                
                                string GuestImagePath = _Configuration["GetImagePath"];
                                string tmpimagePath = _Configuration["imagePath"];
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFile(new Uri(GuestImagePath + item.Image), tmpimagePath + item.Image);
                                    client.DownloadFile(new Uri(GuestImagePath + item.Image2), tmpimagePath + item.Image2);
                                }
                                string strFilePath3 = Guid.NewGuid().ToString() + Path.GetExtension(item.Image);
                                UtilityFunction.DecryptFile(tmpimagePath + item.Image, tmpimagePath + strFilePath3, item.filePass);

                                string strFilePath4 = Guid.NewGuid().ToString() + Path.GetExtension(item.Image2);
                                UtilityFunction.DecryptFile(tmpimagePath + item.Image2, tmpimagePath + strFilePath4, item.filePass);

                                item.Image = ConvertImageToBase64(tmpimagePath + strFilePath3);
                                item.Image2 = ConvertImageToBase64(tmpimagePath + strFilePath4);
                            }
                        }
                        string strFolder;                       
                        strFolder = _Configuration["GetImagePath"];
                        string strFolderTemp;
                        strFolderTemp = _Configuration["imagePath"];
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(new Uri(strFolder + userDto[0].Image1), strFolderTemp + userDto[0].Image1);
                            client.DownloadFile(new Uri(strFolder + userDto[0].Image2), strFolderTemp + userDto[0].Image2);
                        }
                        string strFilePath1 = Guid.NewGuid().ToString() + Path.GetExtension(userDto[0].Image1);
                        UtilityFunction.DecryptFile(strFolderTemp + userDto[0].Image1, strFolderTemp + strFilePath1, userDto[0].filePass);

                        string strFilePath2 = Guid.NewGuid().ToString() + Path.GetExtension(userDto[0].Image2);
                        UtilityFunction.DecryptFile(strFolderTemp + userDto[0].Image2, strFolderTemp + strFilePath2, userDto[0].filePass);

                        userDto[0].Image1 = ConvertImageToBase64(strFolderTemp + strFilePath1);
                        userDto[0].Image2 = ConvertImageToBase64(strFolderTemp + strFilePath2);
                       
                        return JsonConvert.SerializeObject(response);
                    }
                    ResponseDto errorResponse = new ResponseDto(-1, null, "अतिथि आईडी मौजूद नहीं है।");
                    return JsonConvert.SerializeObject(errorResponse);
                }
            }
            ResponseDto errorResponse1 = new ResponseDto(-1, null, "कृपया अतिथि की आईडी चुने।");
            return JsonConvert.SerializeObject(errorResponse1);
        }
        [HttpPost("SearchGuest")]
        [SwaggerOperation(Summary = "Search guest for registered hotel.")]
        public string SearchGuest(string HotelId, string? GuestName, string? AadharNo, string? sMobile)
        {
            if (string.IsNullOrEmpty(GuestName) && string.IsNullOrEmpty(AadharNo) && string.IsNullOrEmpty(sMobile))
            {
                ResponseDto response = new ResponseDto(-1, null, "कृपया कम से कम नाम, आधार, मोबाइल इनमें से कोई एक भरें।");
                return JsonConvert.SerializeObject(response);
            }
            if (!string.IsNullOrEmpty(HotelId))
            {
                HotelId = Convert.ToString(idHotelMaster);
                GuestFilterDto guestFilterDto = new GuestFilterDto();
                guestFilterDto.idHotel = Convert.ToInt32(HotelId);
                guestFilterDto.GuestName = string.IsNullOrEmpty(GuestName) ? "" : GuestName.Trim();
                guestFilterDto.IdentificationNo = string.IsNullOrEmpty(AadharNo) ? "" : AadharNo.Trim();
                guestFilterDto.ContactNo = string.IsNullOrEmpty(sMobile) ? "" : sMobile.Trim();

                response = objuserDL.GetGuestMasterFilter(guestFilterDto, PassValue, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost("AllSubmitedGuestByHotelId")]
        [SwaggerOperation(Summary = "All submited guest list by HotelId")]
        public string AllSubmitedGuestByHotelId(string HotelId, string fromDate, string toDate)
        {
            if (!string.IsNullOrEmpty(HotelId) && !string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                HotelId = Convert.ToString(idHotelMaster);
                GuestFilterDto guestFilterDto = new GuestFilterDto();
                guestFilterDto.idHotel = Convert.ToInt32(HotelId);
                guestFilterDto.FilterFromDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
                guestFilterDto.FilterToDate = Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy");

                response = objuserDL.GetSubmitedGuestSummeryByHotelId(guestFilterDto, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse1 = new ResponseDto(-1, null, string.IsNullOrEmpty(fromDate) ? "कृपया तिथि से (from date) चयन करें।" : "कृपया तिथि तक (to date) चयन करें।");
            return JsonConvert.SerializeObject(errorResponse1);
        }
        [HttpPost("SubmitedGuestDetailForReport")]
        [SwaggerOperation(Summary = "Submited guest detail for report")]
        public string SubmitedGuestDetailForReport(string HotelId, string fromDate, string toDate)
        {
            ResponseDto errorResponse1 = new ResponseDto(-1, null, "Failed.");
            if (!string.IsNullOrEmpty(HotelId) && !string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                HotelId = Convert.ToString(idHotelMaster);
                GuestFilterDto guestFilterDto = new GuestFilterDto();
                guestFilterDto.idHotel = Convert.ToInt32(HotelId);
                guestFilterDto.FilterFromDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
                guestFilterDto.FilterToDate = Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy");

                response = objuserDL.GetGuestCompleteDetailForReport(guestFilterDto, PassValue, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    userDto = (List<GuestMasterDto>)response.Result;
                    foreach (var item in userDto)
                    {
                        //item.ContactNo = item.ContactNo.Decrypt(EncryptionKey, true);
                        //item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);
                        item.Image1 = GetBase64FromFile(item.Image1, item.filePass);
                        item.Image2 = GetBase64FromFile(item.Image2, item.filePass);
                    }
                    return JsonConvert.SerializeObject(response);
                }
                else
                {
                    return guestFilterDto.ToXML();
                }
            }
            else
            {
                errorResponse1 = new ResponseDto(-1, null, string.IsNullOrEmpty(fromDate) ? "कृपया तिथि से (from date) चयन करें।" : "कृपया तिथि तक (to date) चयन करें।");

            }
            return JsonConvert.SerializeObject(errorResponse1);
        }
        [HttpPost("AllPendingGuestList")]
        [SwaggerOperation(Summary = "All pending guest list by hotel id")]
        public string AllPendingGuestList(string HotelId)
        {
            if (!string.IsNullOrEmpty(HotelId))
            {
                HotelId = Convert.ToString(idHotelMaster);
                response = objuserDL.GetPandingGuestSummeryByHotelId(Convert.ToInt32(HotelId), _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost("GuestPandingDetailForReport")]
        [SwaggerOperation(Summary = "Guest pending detail for report")]
        public string GuestPandingDetailForReport(string HotelId, string fromDate, string toDate)
        {
            ResponseDto errorResponse1 = new ResponseDto(-1, null, "Failed.");
            if (!string.IsNullOrEmpty(HotelId) && !string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                HotelId = Convert.ToString(idHotelMaster);
                GuestFilterDto guestFilterDto = new GuestFilterDto();
                guestFilterDto.idHotel = Convert.ToInt32(HotelId);
                guestFilterDto.FilterFromDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
                guestFilterDto.FilterToDate = Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy");

                response = objuserDL.GetGuestPandingDetailForReport(guestFilterDto, PassValue, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    userDto = (List<GuestMasterDto>)response.Result;
                    foreach (var item in userDto)
                    {
                        //item.ContactNo = item.ContactNo.Decrypt(EncryptionKey, true);
                        //item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);
                        item.Image1 = GetBase64FromFile(item.Image1, item.filePass);
                        item.Image2 = GetBase64FromFile(item.Image2, item.filePass);
                    }
                    return JsonConvert.SerializeObject(response);
                }
                else
                {
                    return guestFilterDto.ToXML();
                }
            }
            else
            {
                errorResponse1 = new ResponseDto(-1, null, string.IsNullOrEmpty(fromDate) ? "कृपया तिथि से (from date) चयन करें।" : "कृपया तिथि तक (to date) चयन करें।");
            }
            return JsonConvert.SerializeObject(errorResponse1);
        }
        [HttpPost("ValidateSubmitDate")]
        [SwaggerOperation(Summary = "Validate submit date")]
        public string ValidateSubmitDate(string HotelId, string SubmitDate)
        {
            if (!string.IsNullOrEmpty(HotelId) && !string.IsNullOrEmpty(SubmitDate))
            {
                HotelId = Convert.ToString(idHotelMaster);
                response = objuserDL.ValidateSubmitDate(Convert.ToInt32(HotelId), Convert.ToDateTime(SubmitDate), _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    int count = (int)response.Result;
                    if (count == 0)
                    {
                        int totalGuest = 0;
                        ResponseDto obj = objuserDL.GetPandingGuestByHotelId(Convert.ToInt32(HotelId), Convert.ToDateTime(SubmitDate), _Configuration.GetConnectionString("DefaultConnection"));
                        if (obj != null)
                        {
                            if (obj.StatusCode == 0)
                            {
                                List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                                if (userDto != null)
                                {
                                    totalGuest = userDto.Sum(x => x.AddionalGuest);
                                }
                            }
                        }
                        if (totalGuest == 0)
                        {
                            response.Message = "तारीख " + Convert.ToDateTime(SubmitDate).ToString("dd-MMMM-yyyy") + " को मेरी होटल में कोई गेस्ट नहीं रुका था।";
                        }
                        else
                        {
                            response.StatusCode = 1;
                            response.Message = "तारीख " + Convert.ToDateTime(SubmitDate).ToString("dd-MMMM-yyyy") + " को मेरी होटल में टोटल " + totalGuest + " गेस्ट रुके थे।";
                        }
                    }
                    else
                    {
                        response.StatusCode = 2;
                        response.Message = "तारीख " + Convert.ToDateTime(SubmitDate).ToString("dd-MMMM-yyyy") + " की रिपोर्ट सबमिट हो चुकी है।";
                    }
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया सबमिट तारीख चुने।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [HttpPost("SubmitGuestData")]
        [SwaggerOperation(Summary = "Submit guest data by name")]
        public string SubmitGuestData(string HotelId, string SubmitDate, string SubmitBy)
        {
            if (!string.IsNullOrEmpty(HotelId) && !string.IsNullOrEmpty(SubmitDate))
            {
                HotelId = Convert.ToString(idHotelMaster);
                GuestFilterDto guestFilterDto = new GuestFilterDto();
                guestFilterDto.idHotel = Convert.ToInt32(HotelId);
                guestFilterDto.SubmitDate = Convert.ToDateTime(SubmitDate);
                guestFilterDto.SubmitBy = SubmitBy;
                response = objuserDL.SubmitGuestData(guestFilterDto, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            ResponseDto errorResponse = new ResponseDto(-1, null, "कृपया सबमिट तारीख चुने।");
            return JsonConvert.SerializeObject(errorResponse);
        }
        [AllowAnonymous]
        [HttpPost("HotelCategory")]
        [SwaggerOperation(Summary = "Get hotel room category list by hotelId")]
        public string GetHotelCategoryById(string idHotel)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            if (!string.IsNullOrEmpty(idHotel))
            {
                //idHotel = Convert.ToString(idHotelMaster);
                response = objHotelDL.GetHotelCategory(Convert.ToInt32(idHotel), _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpGet("GetAllPropertyType")]
        [SwaggerOperation(Summary = "Get all property type list")]
        public string GetAllPropertyType()
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            response = objHotelDL.GetAllPropertyTypeApi(_Configuration.GetConnectionString("DefaultConnection"));
            if (response != null)
            {
                return JsonConvert.SerializeObject(response);
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpGet("GetAllState")]
        [SwaggerOperation(Summary = "Get all state list")]
        public string GetAllState()
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            response = objHotelDL.GetAllStateApi(_Configuration.GetConnectionString("DefaultConnection"));
            if (response != null)
            {
                return JsonConvert.SerializeObject(response);
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpPost("GetAllDistrict")]
        [SwaggerOperation(Summary = "Get all district list by state id")]
        public string GetAllDistrict(int StateId)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            if (StateId != null)
            {
                response = objHotelDL.GetAllDistrictApi(StateId, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpPost("GetAllCity")]
        [SwaggerOperation(Summary = "Get all city list by district id")]
        public string GetAllCity(int IdDistrict)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            if (IdDistrict != null)
            {
                response = objHotelDL.GetAllCityApi(IdDistrict, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [AllowAnonymous]
        [HttpPost("GetAllPoliceStation")]
        [SwaggerOperation(Summary = "Get all police station list by city id")]
        public string GetAllPoliceStation(int idCity)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            if (idCity != null)
            {
                response = objHotelDL.GetAllPoliceStationApi(idCity, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    return JsonConvert.SerializeObject(response);
                }
            }
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost("HotelLogout")]
        [SwaggerOperation(Summary = "Hotel logout")]
        public string HotelLogout(int HotelId)
        {
            LoginDL objLoginDL = new LoginDL();
            HotelId = idHotelMaster;
            string accessToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();
            if (!string.IsNullOrEmpty(accessToken))
            {
                response = objLoginDL.ValidateSubcription(HotelId, _Configuration.GetConnectionString("DefaultConnection"));
                if (response != null)
                {
                    TokenExpireForSubcriptionDto dto = (TokenExpireForSubcriptionDto)response.Result;
                    DateTimeOffset expirationTime = dto.ValidExpire;
                    _memoryCache.Set(accessToken, true, expirationTime);
                    return JsonConvert.SerializeObject(response);
                }
                return JsonConvert.SerializeObject(response);
            }
            return JsonConvert.SerializeObject(response);
        }

        #region Non action method in API's
        [NonAction]
        public string UploadImageToFolder(string image, string Password)
        {
            string filename = Guid.NewGuid().ToString() + ".jpeg";
            byte[] imageByteArray = Convert.FromBase64String(image);
            //string[] img = image.Split("base64,");
            //string[] imageExtention = img[0].Split("data:image/");
            //string filename = Guid.NewGuid().ToString() + "." + imageExtention[1].Replace(";","");
            //byte[] imageByteArray = Convert.FromBase64String(img[1]);


            string sFileName;
            string pathD = System.IO.Directory.GetCurrentDirectory() + "\\Image\\";
            var aa = pathD + filename;
            string tempLength;
            FileInfo FI = null;
            System.IO.FileStream FS = null;
            FI = new System.IO.FileInfo(aa);
            if (FI.Directory.Exists)
                FI.Directory.Create();
            FS = FI.Exists ? FI.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write) : FI.Create();
            FS.Write(imageByteArray, 0, imageByteArray.Length);
            tempLength = FS.Name;

            //var strFilePath = _Configuration["GetImagePath"] + filename;
            var strFilePath = _Configuration["GetGuestImagePath"];
            //strFilePath = "C:\\inetpub\\wwwroot\\Ritesh_Proj\\HotelGuestSystem\\GuestDetail\\GuestFiles\\";
            //strFilePath = "E:\\srv projects\\Hotel Guest Reorting System\\Guest Reorting System\\GuestFiles\\";
            FS.Close();
            FS.Dispose();
            FS = null;
            FI = null;
            sFileName = tempLength.Replace(pathD, "");
            //UtilityFunction.EncryptFile(tempLength, strFilePath.Replace("Temp_",""), Password);

            //string sFileName1 = Guid.NewGuid().ToString() + ".jpeg";
            UtilityFunction.EncryptFile(tempLength, strFilePath + sFileName, Password);
            
            //sFileName = tempLength.Replace("C:\\inetpub\\wwwroot\\Ritesh_Proj\\HotelGuestSystem\\HotelAPI\\Image\\", "");
            FileInfo Fd = null;
            Fd = new System.IO.FileInfo(aa);
            if (Fd.Directory.Exists)
                Fd.Delete();
            Fd = null;
            //System.IO.File.Delete(aa);
            return sFileName;
        }
        [NonAction]
        public string ConvertImageToBase64(string path)
        {
            //string imagePath = "mountains.jpg";
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
        [NonAction]
        private string GetBase64FromFile(string image1, string filePass)
        {
            string strFolder1;
            strFolder1 = _Configuration["GetImagePath"];
            //strFolder1 = "C:\\inetpub\\wwwroot\\Ritesh_Proj\\HotelGuestSystem\\GuestDetail\\GuestFiles\\";
            //strFolder1 = "E:\\srv projects\\Hotel Guest Reorting System\\Guest Reorting System\\GuestFiles\\";

            //if (!Directory.Exists(strFolder1))
            //{
            //    Directory.CreateDirectory(strFolder1);
            //}
            string strFolderTemp1;
            //strFolderTemp1 = "C:\\inetpub\\wwwroot\\Ritesh_Proj\\HotelGuestSystem\\GuestDetail\\GuestFiles\\Temp\\";
            //strFolderTemp1 = "E:\\srv projects\\Hotel Guest Reorting System\\Guest Reorting System\\GuestFiles\\Temp\\";
            strFolderTemp1 = _Configuration["imagePath"];
            //if (!Directory.Exists(strFolderTemp1))
            //{
            //    Directory.CreateDirectory(strFolderTemp1);
            //}
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(strFolder1 + image1), strFolderTemp1 + image1);
            }
            string strFilePath3 = Guid.NewGuid().ToString() + Path.GetExtension(image1);
            UtilityFunction.DecryptFile(strFolderTemp1 + image1, strFolderTemp1 + strFilePath3, filePass);
            return ConvertImageToBase64(strFolderTemp1 + strFilePath3);


            //string strFolder1;
            //strFolder1 = _Configuration["GetImagePath"];
            ////if (!Directory.Exists(strFolder1))
            ////{
            ////    Directory.CreateDirectory(strFolder1);
            ////}
            //string strFolderTemp1;
            //strFolderTemp1 = _Configuration["imagePath"];
            ////if (!Directory.Exists(strFolderTemp1))
            ////{
            ////    Directory.CreateDirectory(strFolderTemp1);
            ////}

            //string strFilePath3 = Guid.NewGuid().ToString() + Path.GetExtension(image1);
            //UtilityFunction.DecryptFile(strFolder1 + image1, strFolderTemp1 + strFilePath3, filePass);
            //return ConvertImageToBase64(strFolderTemp1 + strFilePath3);
        }
        [NonAction]
        private string generateJwtToken(HotelMasterDto user, DateTime dto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Here you  can fill claim information from database for the usere as well
            var claims = new[] {
                new Claim("idHotelMaster", user.idHotelMaster.ToString()),
                new Claim("HotelName", user.HotelName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            TimeSpan difference = dto - DateTime.Now;
            int days = (int)difference.TotalDays;
            var token = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer,
                claims,
                expires: DateTime.Now.AddDays(days),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
