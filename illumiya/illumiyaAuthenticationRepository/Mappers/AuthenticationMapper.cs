using illumiyaAuthenticationRepository.Entities.Models;
using illumiyaFramework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace illumiyaAuthenticationRepository.Mappers
{
    public static class AuthenticationMapper
    {
        public static IEnumerable<ApplicationUser> Map(this IEnumerable<Entities.DB.ApplicationUser> list)
        {
            return list.Select(i => i.Map());
        }

        public static ApplicationUser Map(this Entities.DB.ApplicationUser item)
        {
            return new ApplicationUser()
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                Role = (EGlobal.Roles)item.RoleId
            };
        }
    }
}
