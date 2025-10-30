using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaAuthenticationRepository.Entities.DB
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
