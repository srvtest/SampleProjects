using illumiyaEntities.Authentication.Requests;
using illumiyaEntities.Authentication.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaWorkflows.Authentication
{
    public interface IAuthenticationWorkflow
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, AuthenticationResponse response);
    }
}
