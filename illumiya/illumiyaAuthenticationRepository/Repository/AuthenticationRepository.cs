using illumiyaAuthenticationRepository.DataLayer;
using illumiyaConnectorEntities.Authentication.Requests;
using illumiyaConnectorEntities.Authentication.Responses;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using illumiyaModels.Authentication;

namespace illumiyaAuthenticationRepository.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IAuthenticationDataLayer _authenticationDataLayer;

        public AuthenticationRepository(IAuthenticationDataLayer authenticationDataLayer)
        {
            _authenticationDataLayer = authenticationDataLayer;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationResponse response, AuthenticationRequest request) {
            try {
                var user = await _authenticationDataLayer.GetUserAsync(request.Username, request.Password);
                if (user != null)
                {
                    response.User = new ApplicationUser()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Role = user.Role
                    };
                    response.Success("AuthenticateAsync");
                }
                else {
                    response.Failed("Invalid Credentials");
                }
            }
            catch (Exception ex) {
                response.Failed(ex);
            }
            return response;
        }
    }
}
