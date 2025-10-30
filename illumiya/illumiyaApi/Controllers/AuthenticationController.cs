using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using illumiyaEntities.Authentication.Requests;
using illumiyaEntities.Authentication.Responses;
using illumiyaFramework.Helpers;
using illumiyaFramework.Responses;
using illumiyaWorkflows.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace illumiyaApi.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationWorkflow _authenticationWorkflow;
        private readonly JWTHelper _jwtHelper;

        public AuthenticationController(IAuthenticationWorkflow authenticationWorkflow, JWTHelper jwtHelper)
        {
            _authenticationWorkflow = authenticationWorkflow;
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<AuthenticationResponse> AuthenticateAsync([FromBody] AuthenticationRequest request)
        {
            var response = ResponseHelper.GetResponse<AuthenticationResponse>();
            try
            {
                if (ModelState.IsValid)
                {
                    response = await _authenticationWorkflow.AuthenticateAsync(request, response);
                    if (response.IsSuccess)
                    {
                        if (response.User != null)
                        {
                            var jwtToken = _jwtHelper.SignInJWT(response.User.Id, response.User.Name, response.User.Email, response.User.Role.ToString(), response.OwnerToken);
                            if (jwtToken != null)
                            {
                                response.Header.AuthToken = jwtToken;
                            }
                            else { response.Failed("jwtToken failed"); }
                        }
                        else { response.Failed("Invalid Credentials"); }
                    }
                    else { response.Failed("Invalid Credentials"); }
                }
                else
                {
                    var errors = ModelState.Values.Select(x => x.Errors.Select(y => y.ErrorMessage));
                    response.Failed("");
                }

            }
            catch (Exception ex)
            {
                response.Failed(ex);
            }
            return response;
        }

        
    }
}
