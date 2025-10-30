using illumiyaFramework.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace illumiyaEntities.Authentication.Requests
{
    public class AuthenticationRequest : BaseRequest
    {
        [Required(ErrorMessage = "Username cannot be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }
    }
}
