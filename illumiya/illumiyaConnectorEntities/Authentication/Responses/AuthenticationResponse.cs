using illumiyaFramework.Responses;
using illumiyaModels.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaConnectorEntities.Authentication.Responses
{
    public class AuthenticationResponse : BaseResponse
    {
        public string OwnerToken { get; set; }
        public ApplicationUser User { get; set; }
    }
}
