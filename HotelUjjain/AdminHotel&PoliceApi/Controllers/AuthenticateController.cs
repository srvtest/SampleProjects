using AdminHotel_PoliceApi.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminHotel_PoliceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticationService _authService;
        public AuthenticateController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        //[HttpPost("authenticate")]
        //public IActionResult AuthenticateUser(AuthenticateRequest model)
        //{
        //    var response = _authService.Authenticate(model);

        //    if (response == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(response);
        //}

    }
}
