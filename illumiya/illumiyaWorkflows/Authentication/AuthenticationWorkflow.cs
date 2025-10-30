using illumiyaAuthenticationConnector;
using illumiyaEntities.Authentication.Requests;
using illumiyaEntities.Authentication.Responses;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaWorkflows.Authentication
{
    public class AuthenticationWorkflow : IAuthenticationWorkflow
    {
        private readonly IAuthenticationConnector _authenticationConnector;

        public AuthenticationWorkflow(IAuthenticationConnector authenticationConnector)
        {
            _authenticationConnector = authenticationConnector;
        }



        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, AuthenticationResponse response) {
            try {
                response = await _authenticationConnector.AuthenticateAsync(request, response);
                
            }
            catch (Exception ex) {
                response.Failed(ex);
            }
            return response;
        }
    }
}
