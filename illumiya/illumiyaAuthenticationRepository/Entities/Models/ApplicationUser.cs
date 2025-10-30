using illumiyaFramework.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaAuthenticationRepository.Entities.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public EGlobal.Roles Role { get; set; }
    }
}
