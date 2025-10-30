using illumiyaAuthenticationRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaAuthenticationRepository.DataLayer
{
    public interface IAuthenticationDataLayer
    {
        Task<ApplicationUser> GetUserAsync(string username, string password);
    }
}
