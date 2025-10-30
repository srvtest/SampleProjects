using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace illumiyaCountriesRepository.Mappers
{
    public static class CountryMapper
    {
        public static IEnumerable<Entities.Models.Country> Map(this IEnumerable<Entities.DB.Country> list)
        {
            return list.Select(i => i.MapToCountry());
        }

        public static Entities.Models.Country MapToCountry(this Entities.DB.Country item)
        {
            return new Entities.Models.Country()
            {
                Id = item.Id,
                ISO = item.ISO,
                ISO3 = item.ISO3,
                Name = item.Name,
                NiceName = item.NiceName,
                NumCode = item.NumCode,
                PhoneCode = item.PhoneCode
            };
        }

        public static IEnumerable<illumiyaModels.Countries.Country> Map(this IEnumerable<Entities.Models.Country> list)
        {
            return list.Select(i => i.MapToCountry());
        }

        public static illumiyaModels.Countries.Country MapToCountry(this Entities.Models.Country item)
        {
            return new illumiyaModels.Countries.Country()
            {
                Id = item.Id,
                ISO = item.ISO,
                ISO3 = item.ISO3,
                Name = item.Name,
                NiceName = item.NiceName,
                NumCode = item.NumCode,
                PhoneCode = item.PhoneCode
            };
        }
    }
}
