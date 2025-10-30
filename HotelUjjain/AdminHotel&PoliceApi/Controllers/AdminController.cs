using AdminHotel_PoliceApi.Helper;
using DataLayer;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdminHotel_PoliceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region Variable Declaration
        public readonly IConfiguration _Configuration;
        ResponseDto response;
        private readonly AppSettings _appSettings;
        //private IAuthenticationService _authService;
        #endregion
        #region Constructor Declarations
        public AdminController(IConfiguration Configuration, IOptions<AppSettings> appSettings)
        {
            _Configuration = Configuration;
            _appSettings = appSettings.Value;
            // _authService = authService;
        }
        #endregion
        //[AllowAnonymous]
        //[HttpGet("Login")]
        //public string Login(string Username, string Password)
        //{
        //    if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
        //    {
        //        LoginApiDL objLoginDL = new LoginApiDL();
        //        UserDto userDto = new UserDto();
        //        userDto.Username = Username;
        //        userDto.password = Password;
        //        response = objLoginDL.ValidateUserLogin("", userDto);
        //        if (response != null)
        //        {
        //            UserDto userDto1 = (UserDto)response.Result;
        //            var token = generateJwtToken(userDto1);
        //            userDto1.Token=token;
        //            return JsonConvert.SerializeObject(response);
        //        }
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}
        //[NonAction]
        //private string generateJwtToken(UserDto user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    // Here you  can fill claim information from database for the usere as well
        //    var claims = new[] {
        //        new Claim("idUser", user.idUser.ToString()),
        //        new Claim("Name", user.Name.ToString()),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };

        //    var token = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer,
        //        claims,
        //        expires: DateTime.Now.AddHours(24),
        //        signingCredentials: credentials
        //        );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}



        //[HttpGet("GetAllState")]
        //public string GetAllState()
        //{
        //    StateApiDL objStateDl = new StateApiDL();
        //    DataSet ds = new DataSet();
        //    response = objStateDl.GetState("");
        //    //getExecuteDataset("", "usp_GetState", null); 
        //    // ResponseDto obj = new ResponseDto(0,ds,"");
        //    if (response != null)
        //    {
        //        return JsonConvert.SerializeObject(response);
        //    }
        //    return JsonConvert.SerializeObject(response);
        //}


    }
}
