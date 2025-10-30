using illumiyaConnectorEntities.Authentication.Requests;
using illumiyaConnectorEntities.Authentication.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaAuthenticationRepository.Repository
{
    public interface IAuthenticationRepository
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationResponse response, AuthenticationRequest request);
    }
}
