using illumiyaFramework.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaConnectorEntities.Authentication.Requests
{
    public class AuthenticationRequest : BaseRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
