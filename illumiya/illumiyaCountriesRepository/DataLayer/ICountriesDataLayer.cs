using illumiyaCountriesRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaCountriesRepository.DataLayer
{
    public interface ICountriesDataLayer
    {
        Task<IEnumerable<Country>> GetCountriesListAsync();
    }
}
