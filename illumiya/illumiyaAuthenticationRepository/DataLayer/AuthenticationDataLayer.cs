using Dapper;
using illumiyaAuthenticationRepository.Entities.Models;
using illumiyaAuthenticationRepository.Mappers;
using illumiyaFramework.Crypto;
using illumiyaFramework.Entities;
using illumiyaFramework.Entities.Configurations;
using illumiyaFramework.Log;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaAuthenticationRepository.DataLayer
{
    public class AuthenticationDataLayer : BaseRepository, IAuthenticationDataLayer
    {
        public AuthenticationDataLayer(IOptions<DBConnectionOptions> setting)
            : base(setting) { }

        public async Task<ApplicationUser> GetUserAsync(string username, string password)
        {
            ApplicationUser response = null;
            try {
                password = MD5Generator.GenerateHash(password);
                var result = await _db.QueryFirstOrDefaultAsync<Entities.DB.ApplicationUser>($"select * from tblUsers where Username = '{username}' and Password = '{password}' and IsActive = true");

                if (result != null)
                {
                    response = result.Map();
                }
                else {
                    Logger.Error("GetUserAsync > result is null");
                }
            }
            catch (Exception ex) {
                Logger.Error("AuthenticationDataLayer => Error get user by username and password", ex);
            }
            return response;
        }
    }
}
