using Dapper;
using illumiyaCountriesRepository.Entities.Models;
using illumiyaFramework.Entities;
using illumiyaFramework.Entities.Configurations;
using illumiyaCountriesRepository.Mappers;
using illumiyaFramework.Log;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaCountriesRepository.DataLayer
{
    public class CountriesDataLayer : BaseRepository, ICountriesDataLayer
    {
        public CountriesDataLayer(IOptions<DBConnectionOptions> setting)
           : base(setting) { }

        public async Task<IEnumerable<Country>> GetCountriesListAsync()
        {
            IEnumerable<Country> response = null;
            try
            {
                var result = await _db.QueryAsync<Entities.DB.Country>($"select * from tblcountries");

                if (result != null)
                    response = result.Map();
                else
                    Logger.Error("GetUserAsync > result is null");
            }
            catch (Exception ex)
            {
                Logger.Error("CountriesDataLayer => Error get countries list", ex);
            }
            return response;
        }
    }
}
